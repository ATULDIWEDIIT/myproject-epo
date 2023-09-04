using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital.Data.Models;
using Digital.Repo;
using Digital.Service;

namespace Digital.Service
{
	public class SubcategoryService: ISubcategoryService
	{
		private readonly IRepository<Subcategories> repoSubCategory;
		private readonly IRepository<Categories> repoCategory;

		public SubcategoryService(IRepository<Subcategories> _repoSubCategory, IRepository<Categories> _repoCategory)
		{
			repoSubCategory = _repoSubCategory;
            repoCategory = _repoCategory;
		}

        public Subcategories GetById(int id)
        {
            
            return repoSubCategory.FindById(id);
        }


        public void Save(Subcategories subcategory)
        {
            repoSubCategory.Insert(subcategory);
        }

        public void Update(Subcategories subcategory)
        {
            repoSubCategory.Update(subcategory);
        }

        public void Delete(int Id)
        {
            repoSubCategory.Delete(Id);

        }


        public bool Exists(int id, string name)
        {
            return repoSubCategory.Query().Filter(e => e.CategoryId == id && e.Title == name).Get().Count() > 0 ? true : false;


        }

        public List<Categories> GetCategoryList()
        {
            return repoCategory.Query().Filter(x =>x.IsActive==true).Get().ToList();
        }

        public void Dispose()
        {
            if (repoSubCategory != null)
            {
                repoSubCategory.Dispose();

            }
        }

       
    }
}
