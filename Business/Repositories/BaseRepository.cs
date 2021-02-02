using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories
{

    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        IEnumerable<T> Filter(Func<T, bool> predicate);

        Task<T> GetById(int id);

        T FirstOrDefault(Expression<Func<T, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DatabaseContext Context;

        public BaseRepository(DatabaseContext context)
        {
            Context = context;
        }
        public async Task AddAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is null)
                return Context.Set<T>().FirstOrDefault();
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is null)
                return await Context.Set<T>().CountAsync();
            else
                return await Context.Set<T>().CountAsync(predicate);
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

    }
}