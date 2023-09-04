using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital.Data.Models;

namespace Digital.Service
{
	public interface ISubcategoryService : IDisposable
	{


        Subcategories GetById(int id);
        void Save(Subcategories subcategory);
      
        void Update(Subcategories subcategory);
        void Delete(int id);
        bool Exists(int id, string name);

        List<Categories> GetCategoryList();
        
    }
}
