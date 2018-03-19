using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Data.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetSingleAsync(long key);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> GetPagedListAsync(int skip, int pageSize, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> AddAsync(TEntity t);
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> tList);

        Task<TEntity> UpdateAsync(TEntity t);
        Task<TEntity> UpdateAsync(TEntity t, long key);

        Task<int> DeleteAsync(TEntity t);
        Task<int> DeleteAsync(object key);

        Task<int> CountAsync();
    }
}
