using Digital.Core;
using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Repo
{
    public  interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FinadAll();
        TEntity FindById(object id);

        IQueryable<TEntity> FinadByCondition(Expression<Func<TEntity, bool>> condition);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Update(TEntity dbEntity, TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);

        PagedListResult<TEntity> Search(SearchQuery<TEntity> searchQuery, out int totalCount);
        RepositoryQuery<TEntity> Query();
        void SaveChanges();
        void UpdateCollection(List<TEntity> entityCollection);
        void InsertCollection(List<TEntity> entityCollection);
        void DeleteCollection(List<TEntity> entityCollection);
       
        void Dispose();
        
    }
}
