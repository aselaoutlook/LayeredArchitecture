using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Data.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void Save();
        void Dispose();
    }
}
