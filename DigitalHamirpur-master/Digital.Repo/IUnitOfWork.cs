using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Repo
{
    public interface IUnitOfWork
    {

        void Dispose();
        void Save();
        void Dispose(bool disposing);
        IRepository<T> RepositoryBase<T>() where T : class;
    }
}
