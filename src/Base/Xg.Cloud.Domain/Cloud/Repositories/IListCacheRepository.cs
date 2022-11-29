using Cloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cloud.Repositories
{
    public interface IListCacheRepository<T> : IRepository<T> where T : BaseEntity<long>
    {
        List<T> GetList(params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> GetListAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<IQueryable<T>> FindByPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties);

        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);

        Task BatchAddAsync(T[] entities);

        Task UpdateAsync(T entity, IList<string> excludeColumnNames = null);

        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        void UpdateCache(params Expression<Func<T, object>>[] includeProperties);

        Task UpdateCacheAsync(params Expression<Func<T, object>>[] includeProperties);

    }
}
