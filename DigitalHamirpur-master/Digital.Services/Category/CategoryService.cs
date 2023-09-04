using Digital.Core;
using Digital.Data.Models;
using Digital.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Digital.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Categories> repoCategory;

        public CategoryService(IRepository<Categories> _repoCategory)
        {
            repoCategory = _repoCategory;
        }

        public Categories GetById(int id)
        {
            //return repoCategory.Query()
            //   .Filter(e => e.CategoryId == id)
            //   .Get()
            //   .FirstOrDefault();
            return repoCategory.FindById(id);
        }

        
        public List<Categories> GetCategoryList()
        {
            return repoCategory.Query().Filter(category => category.IsActive==true).Get().ToList();
        }
        public void Save(Categories category)
        {
            repoCategory.Insert(category);
        }

        public void Update(Categories category)
        {
            repoCategory.Update(category);
        }

        public void Delete(int categoryId)
        {
            repoCategory.Delete(categoryId);

        }


        public bool Exists(int id, string name)
        {
            return repoCategory.Query().Filter(e => e.CategoryId != id && e.CategoryTitle == name).Get().Count()>0?true:false;
        }

        public List<Categories> Get(DataTables dataTablesRequest, bool? status, int sortIndex, string sortDirection, out int totalItems)
        {
            var query = FilterGrid(dataTablesRequest, status, sortIndex, sortDirection);

            var data = repoCategory.Search(query, out totalItems);

            return data.Entities.ToList();
        }

       



        public SearchQuery<Categories> FilterGrid(DataTables dataTablesRequest, bool? status, int sortIndex, string sortDirection)
        {
            var query = new SearchQuery<Categories>();

            if (!string.IsNullOrEmpty(dataTablesRequest.sSearch))
            {
                string sSearch = dataTablesRequest.sSearch.ToLower();
                query.AddFilter(ad => ad.CategoryTitle.Contains(sSearch));
                if (status != null)
                {
                    query.AddFilter(ad => ad.IsActive == status);
                }
            }

            query.Take = dataTablesRequest.iDisplayLength;
            query.Skip = dataTablesRequest.iDisplayStart;

            return ShortGrid(query, sortIndex, sortDirection);
        }

        private SearchQuery<Categories> ShortGrid(SearchQuery<Categories> query, int sortIndex, string sortDirection)
        {
            switch (sortIndex)
            {
                case 2:
                    query.AddSortCriteria(new ExpressionSortCriteria<Categories, string>(q => q.CategoryTitle, sortDirection == "asc" ? SortDirection.Ascending : SortDirection.Descending));
                    break;
                //case 3:
                //    query.AddSortCriteria(new ExpressionSortCriteria<ProjectInfo, DateTime>(q => q.AgeGroup.CreatedDate, sortDirection == "asc" ? SortDirection.Ascending : SortDirection.Descending));
                //    break;
                default:
                    query.AddSortCriteria(new ExpressionSortCriteria<Categories, DateTime>(q => q.UpdatedOn.Value, SortDirection.Descending));
                    break;
            }
            return query;
        }


        public void Dispose()
        {
            if (repoCategory != null)
            {
                repoCategory.Dispose();

            }
        }

       
    }
}
