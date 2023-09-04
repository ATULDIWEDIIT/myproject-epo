using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Service
{
    public interface IProductService : IDisposable
    {
        Products GetById(int id);
        Products Save(Products p);

        Products Update(Products p);
        bool Delete(int id);
        bool Exists(int id, string name);

        List<Subcategories> GetSubCategoryList();
        List<Products> GetAllProduct();
    }
}
