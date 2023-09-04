using Digital.Core;
using Digital.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ElectronicDbContext _DigitalDbContext;
        private DbSet<T> DbSet;

        public Repository(ElectronicDbContext DigitalDbContext)
        {
            _DigitalDbContext = DigitalDbContext;
            DbSet = _DigitalDbContext.Set<T>();
        }



        public IQueryable<T> FinadAll()
        {
            return DbSet.AsNoTracking();
        }

        public IQueryable<T> FinadByCondition(Expression<Func<T, bool>> condition)
        {
            return DbSet.Where(condition).AsNoTracking();
        }


        public T FindById(object id)
        {
            return DbSet.Find(id);
        }

        public T Insert(T entity)
        {
            var res =DbSet.Add(entity);
            _DigitalDbContext.Entry(entity).State = EntityState.Added;
            _DigitalDbContext.SaveChanges();
            return res.Entity;
        }

        public virtual void InsertCollection(List<T> entityCollection)
        {
            entityCollection.ForEach(e =>
            {
                DbSet.Add(e);
            });
        }

        public T Update(T entity)
        {
            var res= DbSet.Update(entity);
            return res.Entity;
        }

        public T Update(T dbEntity, T entity)
        {
            _DigitalDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            _DigitalDbContext.Entry(dbEntity).State = EntityState.Modified;
            return dbEntity;
        }

        public virtual void UpdateCollection(List<T> entityCollection)
        {
            entityCollection.ForEach(e =>
            {
                _DigitalDbContext.Entry(e).State = EntityState.Modified;
            });
            _DigitalDbContext.SaveChanges();
        }
        public void Delete(object id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                _DigitalDbContext.Entry(entity).State = EntityState.Deleted;
                Delete(entity);
            }
            _DigitalDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void DeleteCollection(List<T> entityCollection)
        {
            entityCollection.ForEach(e =>
            {
                _DigitalDbContext.Entry(e).State = EntityState.Deleted;
            });
            _DigitalDbContext.SaveChanges();
        }


        public virtual RepositoryQuery<T> Query()
        {
            var repositoryGetFluentHelper =
                new RepositoryQuery<T>(this);

            return repositoryGetFluentHelper;
        }

        internal IQueryable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>,
               IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IQueryable<T>> customOrderBy = null,
           List<Expression<Func<T, object>>>
               includeProperties = null,
           List<string>
               includeStringProperties = null,
           int? page = null,
           int? pageSize = null)
        {
            IQueryable<T> query = DbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });


            if (includeStringProperties.IsNotNullAndNotEmpty())
                includeStringProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (customOrderBy != null)
                query = customOrderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }
        public void SaveChanges()
        {
            _DigitalDbContext.SaveChanges();
        }



        public virtual PagedListResult<T> Search(SearchQuery<T> searchQuery, out int totalCount)
        {
            IQueryable<T> sequence = DbSet;

            //Applying filters
            sequence = ManageFilters(searchQuery, sequence);

            //Include Properties
            sequence = ManageIncludeProperties(searchQuery, sequence);

            //Resolving Sort Criteria
            //This code applies the sorting criterias sent as the parameter
            sequence = ManageSortCriterias(searchQuery, sequence);

            return GetTheResult(searchQuery, sequence, out totalCount);
        }

        protected virtual PagedListResult<T> GetTheResult(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            //Counting the total number of object.
            var resultCount = sequence.Count();

            var result = (searchQuery.Take > 0)
                                ? (sequence.Skip(searchQuery.Skip).Take(searchQuery.Take).ToList())
                                : (sequence.ToList());

            //Debug info of what the query looks like
            //Console.WriteLine(sequence.ToString());

            // Setting up the return object.
            bool hasNext = (searchQuery.Skip <= 0 && searchQuery.Take <= 0) ? false : (searchQuery.Skip + searchQuery.Take < resultCount);
            return new PagedListResult<T>()
            {
                Entities = result,
                HasNext = hasNext,
                HasPrevious = (searchQuery.Skip > 0),
                Count = resultCount
            };
        }



        protected virtual PagedListResult<T> GetTheResult(SearchQuery<T> searchQuery, IQueryable<T> sequence, out int totalCount)
        {
            //Counting the total number of object.
            totalCount = sequence.Count();

            var result = (searchQuery.Take > 0)
                                ? (sequence.Skip(searchQuery.Skip).Take(searchQuery.Take).ToList())
                                : (sequence.ToList());

            //Debug info of what the query looks like
            //Console.WriteLine(sequence.ToString());

            // Setting up the return object.
            bool hasNext = (searchQuery.Skip <= 0 && searchQuery.Take <= 0) ? false : (searchQuery.Skip + searchQuery.Take < totalCount);
            return new PagedListResult<T>()
            {
                Entities = result,
                HasNext = hasNext,
                HasPrevious = (searchQuery.Skip > 0),
                Count = totalCount
            };
        }

        protected virtual IQueryable<T> ManageFilters(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            if (searchQuery.Filters != null && searchQuery.Filters.Count > 0)
            {
                foreach (var filterClause in searchQuery.Filters)
                {
                    sequence = sequence.Where(filterClause);
                }
            }
            return sequence;
        }
        protected virtual IQueryable<T> ManageIncludeProperties(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            if (!string.IsNullOrWhiteSpace(searchQuery.IncludeProperties))
            {
                var properties = searchQuery.IncludeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var includeProperty in properties)
                {
                    sequence = sequence.Include(includeProperty);
                }
            }
            return sequence;
        }

        protected virtual IQueryable<T> ManageSortCriterias(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            if (searchQuery.SortCriterias != null && searchQuery.SortCriterias.Count > 0)
            {
                var sortCriteria = searchQuery.SortCriterias[0];
                var orderedSequence = sortCriteria.ApplyOrdering(sequence, false);

                if (searchQuery.SortCriterias.Count > 1)
                {
                    for (var i = 1; i < searchQuery.SortCriterias.Count; i++)
                    {
                        var sc = searchQuery.SortCriterias[i];
                        orderedSequence = sc.ApplyOrdering(orderedSequence, true);
                    }
                }
                sequence = orderedSequence;
            }
            else
            {
                try
                {
                    sequence = sequence.OrderBy(x => (true));// as IOrderedQueryable<TEntity>;
                    //sequence = ((IOrderedQueryable<TEntity>)sequence).OrderBy(x => (true));
                }
                catch (Exception ex)
                {

                }
            }
            return sequence;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
