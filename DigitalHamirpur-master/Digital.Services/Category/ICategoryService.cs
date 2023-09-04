using Digital.Core;
using Digital.Data.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Digital.Service
{
	public interface ICategoryService : IDisposable
	{


        Categories GetById(int id);
        List<Categories> GetCategoryList();
        void Save(Categories category);
        void Update(Categories category);
        void Delete(int id);
        bool Exists(int id, string name);
        List<Categories> Get(DataTables dataTablesRequest, bool? status, int sortIndex, string sortDirection, out int totalItems);

    }
}
