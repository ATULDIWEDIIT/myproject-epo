using Digital.Data;
using Digital.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Repo
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {



        private readonly ElectronicDbContext _context;

        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(ElectronicDbContext context, Hashtable repositories)
        {
            _context = context;
            _repositories = repositories;
        }

        public UnitOfWork()
        {
            _context = new ElectronicDbContext();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _context.Dispose();
                }

            _disposed = true;
        }



        public IRepository<T> RepositoryBase<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
