using Digital.Data.Models;
using Digital.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Products> repoProduct;
        private readonly IRepository<Subcategories> repoSubCategory;

        public ProductService(IRepository<Products> _repoProduct, IRepository<Subcategories> _repoSubCategory)
        {
            repoSubCategory = _repoSubCategory;
            repoProduct = _repoProduct;
        }

        public Products GetById(int id)
        {

            return repoProduct.FindById(id);
        }


        public Products Save(Products product)
        {
            return repoProduct.Insert(product);
        }

        public Products Update(Products product)
        {
            return repoProduct.Update(product);
        }

        public bool Delete(int Id)
        {
            repoSubCategory.Delete(Id);
            return true;

        }


        public bool Exists(int id, string name)
        {
            return repoProduct.Query().Filter(e => e.ProductId == id && e.Title == name).Get().Count() > 0 ? true : false;


        }

        public List<Products> GetCategoryList()
        {
            return repoProduct.Query().Filter(x => x.IsActive == true).Get().ToList();
        }

        public void Dispose()
        {
            if (repoProduct != null)
            {
                repoProduct.Dispose();

            }
        }

        public List<Subcategories> GetSubCategoryList()
        {
            return repoSubCategory.Query().Filter(x => x.IsActive == true).Get().ToList();
        }

        public List<Products> GetAllProduct()
        {
            return repoProduct.Query().Filter(x => x.IsActive == true).Get().ToList();
        }
    }
}
