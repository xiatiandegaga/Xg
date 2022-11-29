using Cloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cloud.Repositories
{
    public interface ICacheRepository<T> : IRepository<T> where T : BaseEntity<long>
    {
        T FindSingleById(long entityId, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindSingleByIdAsync(long entityId, params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> FindByPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties);

        Task<T> AddAsync(T entity);

        Task BatchAddAsync(T[] entities);

        Task UpdateAsync(T entity, IList<string> excludeColumnNames = null);

        Task DeleteAsync(T entity);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
