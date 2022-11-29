using Cloud.Caching;
using Cloud.Domain.Entities;
using Cloud.EntityFrameworkCore;
using Cloud.Models;
using Cloud.Snowflake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Cloud.Repositories.EntityFrameworkCore
{
    public class EfCoreUnitWork : IEfCoreUnitWork, IUnitWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ICache _cacheService;
        private readonly ISnowflakeIdWorker _SnowflakeIdWorker;
        public EfCoreUnitWork(ApplicationDbContext applicationDbContext, ICache cacheService, ISnowflakeIdWorker SnowflakeIdWorker)
        {
            _context = applicationDbContext;
            _cacheService = cacheService;
            _SnowflakeIdWorker = SnowflakeIdWorker;
        }

        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return Filter(predicate, includeProperties);
        }

        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        public async Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return await Task.Run(()=>Filter(predicate, includeProperties));
        }

        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        public IQueryable<T> FindWithNoTrack<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return FilterWithNoTrack(predicate, includeProperties);
        }

        public async Task<IQueryable<T>> FindWithNoTrackAsync<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return await Task.Run(() => FilterWithNoTrack(predicate, includeProperties));
        }


        public bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Any(predicate);
        }

        public T FindSingle<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return Filter(predicate, includeProperties).FirstOrDefault(predicate);
        }

        public async Task<T> FindSingleAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return await Filter(predicate, includeProperties).FirstOrDefaultAsync(predicate);
        }

        public T FindSingleWithNoTrack<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return FilterWithNoTrack(predicate, includeProperties).FirstOrDefault(predicate);
        }

        public async Task<T> FindSingleWithNoTrackAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return await FilterWithNoTrack(predicate, includeProperties).FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageIndex">The pageIndex.</param>
        /// <param name="pageSize">The pageSize.</param>
        /// <param name="orderBy">排序，格式如："Id"/"Id desc"</param>
        public IQueryable<T> FindByPage<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            if (pageIndex < 1) pageIndex = 1;
            if (string.IsNullOrEmpty(orderBy))
                orderBy = "Id desc";

            return FilterWithNoTrack(predicate, includeProperties).OrderBy(orderBy).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }


        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public int GetCount<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return FilterWithNoTrack(predicate, includeProperties).Count();
        }


        public T Add<T>(T entity) where T : BaseEntity<long>
        {
            entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            return _context.Set<T>().Add(entity).Entity;
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity<long>
        {
            entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            return (await _context.Set<T>().AddAsync(entity)).Entity;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BatchAdd<T>(T[] entities) where T : BaseEntity<long>
        {
            foreach (var entity in entities)
                entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            _context.Set<T>().AddRange(entities);
        }

        public async Task BatchAddAsync<T>(T[] entities) where T : BaseEntity<long>
        {
            foreach (var entity in entities)
                entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void BatchAdd<T>(List<T> entities) where T : BaseEntity<long>
        {
            foreach (var entity in entities)
                entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            _context.Set<T>().AddRange(entities);
        }

        public async Task BatchAddAsync<T>(List<T> entities) where T : BaseEntity<long>
        {
            foreach (var entity in entities)
                entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Update<T>(T entity, IList<string> excludeColumnNames = null) where T : class
        {
            _context.Set<T>().Attach(entity);
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            excludeColumnNames ??= new List<string>();
            excludeColumnNames.Add("createdate");
            excludeColumnNames.Add("createid");
            excludeColumnNames.Add("thirdpartid");
            dbEntityEntry.OriginalValues.Properties.Where(x => excludeColumnNames.Contains(x.Name.ToLower())).ToList().ForEach(x => dbEntityEntry.Property(x.Name).IsModified = false);
        }

        public async Task UpdateAsync<T>(T entity, IList<string> excludeColumnNames = null) where T : class
        {
            await Task.Run(() =>
           {
               _context.Set<T>().Attach(entity);
               EntityEntry dbEntityEntry = _context.Entry(entity);
               dbEntityEntry.State = EntityState.Modified;
               excludeColumnNames ??= new List<string>();
               excludeColumnNames.Add("createdate");
               excludeColumnNames.Add("createid");
               excludeColumnNames.Add("thirdpartid");
               dbEntityEntry.OriginalValues.Properties.Where(x => excludeColumnNames.Contains(x.Name.ToLower())).ToList().ForEach(x => dbEntityEntry.Property(x.Name).IsModified = false);
               return entity;
           });
        }

        public void UpdateByCol<T>(T entity, IList<string> includeColumnNames = null) where T : class
        {
            _context.Set<T>().Attach(entity);
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            var excludeColumnNames = new List<string>
            {
                "createdate",
                "createid",
                "thirdpartid"
            };
            dbEntityEntry.OriginalValues.Properties.Where(x => excludeColumnNames.Contains(x.Name.ToLower())).ToList().ForEach(x => dbEntityEntry.Property(x.Name).IsModified = false);
        }

        public void BatchUpdate<T>(List<T> entities, IList<string> excludeColumnNames = null) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                entities.ForEach(entity =>
                {
                    Update(entity, excludeColumnNames);
                });
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            _context.Set<T>().Where(predicate).ToList().ForEach(e => _context.Entry<T>(e).State = EntityState.Deleted);
        }

        public void Commit() => _context.SaveChanges();

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        private IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var dbSet = query;
            if (predicate != null)
            {
                dbSet = dbSet.Where(predicate);
            }
            return dbSet;
        }

        private IQueryable<T> FilterWithNoTrack<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var dbSet = query.AsNoTracking();
            if (predicate != null)
            {
                dbSet = dbSet.Where(predicate);
            }
            return dbSet;
        }

        public virtual Task<IList<T>> SqlQueryAsync<T>(StringBuilder sql, Pagination pagination = null, params object[] parameters) where T : new() => null;


        public virtual void OnSetted<T>(T entity) where T : BaseEntity<long>
        {
            var cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            _cacheService.Set(cacheConfig.GetCacheKeyOfEntity(entity.Id), entity, cacheConfig.CachingExpirationType);
        }

        public async Task OnSettedAsync<T>(T entity) where T : BaseEntity<long>
        {
            var cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            await _cacheService.SetAsync(cacheConfig.GetCacheKeyOfEntity(entity.Id), entity, cacheConfig.CachingExpirationType);
        }


        public virtual void OnDeleted<T>(T entity) where T : BaseEntity<long>
        {
            var cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            _cacheService.Remove(cacheConfig.GetCacheKeyOfEntity(entity.Id));
        }

        public async Task OnDeletedAsync<T>(T entity) where T : BaseEntity<long>
        {
            var cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            await _cacheService.RemoveAsync(cacheConfig.GetCacheKeyOfEntity(entity.Id));
        }

        public virtual void UpdateCache<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<long>
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var listQuery = query.ToList();
            var cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            var dicQuery = listQuery.ToDictionary(x => cacheConfig.GetCacheKeyOfEntity(x.Id), x => x as object);
            _cacheService.SetAll(dicQuery, cacheConfig.CachingExpirationType);

        }

        public async Task UpdateCacheAsync<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<long>
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var listQuery = query.ToList();
            var cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            var dicQuery = listQuery.ToDictionary(x => cacheConfig.GetCacheKeyOfEntity(x.Id), x => x as object);
            await _cacheService.SetAllAsync(dicQuery, cacheConfig.CachingExpirationType);
        }
        public void RemoveListCache<T>() where T : BaseEntity<long>
        {
            var cacheHelper = new CacheConfig<T>(CachingExpireType.Invariable);
            _cacheService.Remove(cacheHelper.GetListCacheKey());
        }

        public async Task RemoveListCacheAsync<T>() where T : BaseEntity<long>
        {
            var cacheHelper = new CacheConfig<T>(CachingExpireType.Invariable);
            await Task.Run(() => _cacheService.Remove(cacheHelper.GetListCacheKey()));
        }

        /// <summary>
        /// 自定义清除缓存实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void RemoveCache<TOther>(object key) where TOther : class, new()
        {
            var cacheConfig = new CacheConfig<TOther>(CachingExpireType.Invariable);
            _cacheService.Remove(cacheConfig.GetCacheKeyOfEntity(key));
        }

        /// <summary>
        /// 自定义清除缓存实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task RemoveCacheAsync<TOther>(object key) where TOther : class, new()
        {
            var cacheConfig = new CacheConfig<TOther>(CachingExpireType.Invariable);
            await Task.Run(() => _cacheService.Remove(cacheConfig.GetCacheKeyOfEntity(key)));
        }

        public async Task AutoStartListCacheAsync<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity<long>
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var listT = query.ToList();
            var _cacheConfig = new CacheConfig<T>(CachingExpireType.Invariable);
            await _cacheService.SetAsync(_cacheConfig.GetListCacheKey(), listT, _cacheConfig.CachingExpirationType);
        }

        public IDbContextTransaction GetTran() => _context.Database.BeginTransaction();

        public long GetNextId() => _SnowflakeIdWorker.NextId();

        public async Task ExecuteSqlRawAsync(StringBuilder sql) => await _context.ExecuteSqlRawAsync(sql);
    }
}
