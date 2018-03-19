using Jkcs.Contacts.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jkcs.Contacts.Data.BaseRepo
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected internal ContactDBContext context;

        protected DbSet<TEntity> dbset;

        public BaseRepository(ContactDBContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetSingleAsync(long key)
        {
            return await dbset.FindAsync(key);
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dbset.SingleOrDefaultAsync(filter);
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dbset.Where(filter).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPagedListAsync(int skip, int pageSize, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty).AsNoTracking();
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).Skip(skip).Take(pageSize).ToListAsync();
            }
            else
            {
                return await query.Skip(skip).Take(pageSize).ToListAsync();
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            dbset.Add(t);
            await context.SaveChangesAsync();
            return t;
        }

        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> tList)
        {
            dbset.AddRange(tList);
            await context.SaveChangesAsync();
            return tList;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity t)
        {
            dbset.Attach(t);
            await context.SaveChangesAsync();
            return t;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity t, long key)
        {
            if (t == null)
                return null;

            TEntity existing = await dbset.FindAsync(key);

            if(existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(t);
                await context.SaveChangesAsync();
            }

            return existing;
        }

        public virtual async Task<int> DeleteAsync(TEntity t)
        {
            dbset.Remove(t);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(object key)
        {
            TEntity t = await dbset.FindAsync(key);
            dbset.Remove(t);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<int> CountAsync()
        {
            return await dbset.CountAsync();
        }
    }
}
