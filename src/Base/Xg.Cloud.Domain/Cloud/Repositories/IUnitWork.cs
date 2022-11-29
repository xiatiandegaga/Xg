using Cloud.Domain.Entities;
using Cloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Repositories
{
    public interface IUnitWork
    {
        T FindSingle<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<T> FindSingleAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        T FindSingleWithNoTrack<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<T> FindSingleWithNoTrackAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class;
        IQueryable<T> FindWithNoTrack<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class;
        Task<IQueryable<T>> FindWithNoTrackAsync<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class;
        IQueryable<T> FindByPage<T>(int pageIndex = 1, int pageSize = 10, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties) where T : class;

        int GetCount<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class;

        T Add<T>(T entity) where T : BaseEntity<long>;

        Task<T> AddAsync<T>(T entity) where T : BaseEntity<long>;

        void BatchAdd<T>(T[] entities) where T : BaseEntity<long>;

        void BatchAdd<T>(List<T> entities) where T : BaseEntity<long>;

        Task BatchAddAsync<T>(T[] entities) where T : BaseEntity<long>;

        Task BatchAddAsync<T>(List<T> entities) where T : BaseEntity<long>;

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        void Update<T>(T entity, IList<string> excludeColumnNames = null) where T : class;

        Task UpdateAsync<T>(T entity, IList<string> excludeColumnNames = null) where T : class;

        void UpdateByCol<T>(T entity, IList<string> includeColumnNames = null) where T : class;

        void BatchUpdate<T>(List<T> entities, IList<string> excludeColumnNames = null) where T : class;

        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;

        void Commit();

        Task CommitAsync();

        Task<IList<T>> SqlQueryAsync<T>(StringBuilder sql, Pagination pagination = null, params object[] parameters) where T : new();

        void OnSetted<T>(T entity) where T : BaseEntity<long>;

        void OnDeleted<T>(T entity) where T : BaseEntity<long>;

        void UpdateCache<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<long>;

        Task OnSettedAsync<T>(T entity) where T : BaseEntity<long>;

        Task OnDeletedAsync<T>(T entity) where T : BaseEntity<long>;

        Task UpdateCacheAsync<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<long>;

        void RemoveListCache<T>() where T : BaseEntity<long>;

        Task RemoveListCacheAsync<T>() where T : BaseEntity<long>;

        void RemoveCache<TOther>(object key) where TOther : class, new();

        Task RemoveCacheAsync<TOther>(object key) where TOther : class, new();

        Task AutoStartListCacheAsync<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<long>;

        //IDbContextTransaction GetTran();

        long GetNextId();

        /// <summary>
        /// 执行非select的sql语句(快速)
        /// </summary>
        /// <param name="sql">执行非select的sql语句</param>
        /// <returns></returns>
        Task ExecuteSqlRawAsync(StringBuilder sql);

    }
}
