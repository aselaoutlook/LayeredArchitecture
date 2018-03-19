using Jkcs.Contacts.Common;
using Jkcs.Contacts.Data.BaseRepo;
using Jkcs.Contacts.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Data.Uow
{
    [Injectable]
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ContactDBContext context = new ContactDBContext();
        private Dictionary<string, object> _repositories;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        IBaseRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(BaseRepository<>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
