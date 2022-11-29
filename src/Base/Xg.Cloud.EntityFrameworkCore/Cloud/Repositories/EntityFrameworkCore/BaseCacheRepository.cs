using Cloud.Caching;
using Cloud.Domain.Entities;
using Cloud.EntityFrameworkCore;
using Cloud.Snowflake;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cloud.Repositories.EntityFrameworkCore
{
    public class BaseCacheRepository<T> : BaseRepository<T>, ICacheRepository<T> where T : BaseEntity<long>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICache _cache;
        private readonly ICacheConfig<T> _cacheConfig;

        public BaseCacheRepository(ApplicationDbContext applicationDbContext, ICache cacheService, ICacheConfig<T> cacheConfig, ISnowflakeIdWorker SnowflakeIdWorker)
            : base(applicationDbContext, SnowflakeIdWorker)
        {
            _context = applicationDbContext;
            _cache = cacheService;
            _cacheConfig = cacheConfig;
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        public override T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            T entity = base.FindSingle(predicate, includeProperties);
            if (null != entity)
            {
                OnSetted(entity);
            }
            return entity;
        }

        /// <summary>
        /// 查找单个（异步方法）
        /// </summary>
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            T entity = base.FindSingle(predicate, includeProperties);
            if (null != entity)
            {
                await OnSettedAsync(entity);
            }
            return entity;
        }


        /// <summary>
        /// 根据过滤条件，获取记录（谨慎使用）
        /// </summary>
        public new virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            long[] entityIds = base.Find(predicate, orderBy, includeProperties).Select(e => e.Id).ToArray();
            return PopulateEntitiesByEntityIds(entityIds, includeProperties);
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        public virtual T FindSingleById(long entityId, params Expression<Func<T, object>>[] includeProperties)
        {
            T entity = _cache.Get<T>(_cacheConfig.GetCacheKeyOfEntity(entityId));
            if (null == entity)
            {
                entity = Filter(e => e.Id == entityId, includeProperties).FirstOrDefault();
                if (entity == null) return null;
                OnSetted(entity);
            }
            return entity;
        }

        /// <summary>
        /// 查找单个（异步方法）
        /// </summary>
        public virtual async Task<T> FindSingleByIdAsync(long entityId, params Expression<Func<T, object>>[] includeProperties)
        {
            T entity = await _cache.GetAsync<T>(_cacheConfig.GetCacheKeyOfEntity(entityId));
            if (null == entity)
            {
                entity = Filter(e => e.Id == entityId, includeProperties).FirstOrDefault();
                if (entity == null) return null;
                await OnSettedAsync(entity);
            }
            return entity;
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageIndex">The pageIndex.</param>
        /// <param name="pageSize">The pageSize.</param>
        /// <param name="orderBy">排序，格式如："Id"/"Id desc"</param>
        /// <param name="includeProperties">一对多的实体.</param>
        public new virtual IEnumerable<T> FindByPage(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            long[] entityIds = base.FindByPage(pageIndex, pageSize, predicate, orderBy, includeProperties).Select(e => e.Id).ToArray();
            return PopulateEntitiesByEntityIds(entityIds, includeProperties);
        }

        /// <summary>
        /// 得到分页记录（异步方法）
        /// </summary>
        /// <param name="pageIndex">The pageIndex.</param>
        /// <param name="pageSize">The pageSize.</param>
        /// <param name="orderBy">排序，格式如："Id"/"Id desc"</param>
        /// <param name="includeProperties">一对多的实体.</param>
        public virtual async Task<IEnumerable<T>> FindByPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            long[] entityIds = base.FindByPage(pageIndex, pageSize, predicate, orderBy, includeProperties).Select(e => e.Id).ToArray();
            return await PopulateEntitiesByEntityIdsAsync(entityIds, includeProperties);
        }


        public override T Add(T entity)
        {
            entity = base.Add(entity);
            OnSetted(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity = base.Add(entity);
            await OnSettedAsync(entity);
            return entity;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public override void BatchAdd(T[] entities)
        {
            base.BatchAdd(entities);
            Parallel.ForEach(entities, t =>
            {
                OnSetted(t);
            });
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public async Task BatchAddAsync(T[] entities)
        {
            base.BatchAdd(entities);
            await Task.Run(() =>
            {
                Parallel.ForEach(entities, t =>
                {
                    OnSetted(t);
                });
            });
        }

        public override T Update(T entity, IList<string> excludeColumnNames = null)
        {
            base.Update(entity, excludeColumnNames);
            OnSetted(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity, IList<string> excludeColumnNames = null)
        {
            base.Update(entity, excludeColumnNames);
            await OnSettedAsync(entity);
        }

        public override void Delete(T entity)
        {
            base.Delete(entity);
            OnDeleted(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            base.Delete(entity);
            await OnDeletedAsync(entity);
        }

        public override void Delete(Expression<Func<T, bool>> predicate)
        {
            base.Delete(predicate);
            var entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                OnDeleted(entity);
            }

        }
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            base.Delete(predicate);
            var entities = _context.Set<T>().Where(predicate);
            await entities.ForEachAsync(e => OnDeleted(e));

        }
        protected virtual IEnumerable<T> PopulateEntitiesByEntityIds(long[] entityIds, params Expression<Func<T, object>>[] includeProperties)
        {
            var entityArr = new T[entityIds.Count()];
            Dictionary<long, int> entityIdsNoCache = new Dictionary<long, int>();
            //先从缓存里取，没有的再去数据库取
            for (int i = 0; i < entityIds.Count(); i++)
            {
                T entity = _cache.Get<T>(_cacheConfig.GetCacheKeyOfEntity(entityIds[i]));
                if (entity != null)
                {
                    entityArr[i] = entity;
                }
                else
                {
                    entityArr[i] = null;
                    entityIdsNoCache[entityIds[i]] = i;
                }
            }
            if (entityIdsNoCache.Count() > 0)
            {
                IEnumerable<T> entitiesFromDb = Filter(e => entityIdsNoCache.Keys.Contains(e.Id), includeProperties);
                foreach (var entityFromDb in entitiesFromDb)
                {
                    entityArr[entityIdsNoCache[entityFromDb.Id]] = entityFromDb;
                    _cache.SetAsync(_cacheConfig.GetCacheKeyOfEntity(entityFromDb.Id), entityFromDb, _cacheConfig.CachingExpirationType);
                }
            }
            return entityArr.AsEnumerable();
        }

        protected virtual async Task<IEnumerable<T>> PopulateEntitiesByEntityIdsAsync(long[] entityIds, params Expression<Func<T, object>>[] includeProperties)
        {
            var entityArr = new T[entityIds.Count()];
            Dictionary<long, int> entityIdsNoCache = new Dictionary<long, int>();
            //先从缓存里取，没有的再去数据库取
            for (int i = 0; i < entityIds.Count(); i++)
            {
                T entity = await _cache.GetAsync<T>(_cacheConfig.GetCacheKeyOfEntity(entityIds[i]));
                if (entity != null)
                {
                    entityArr[i] = entity;
                }
                else
                {
                    entityArr[i] = null;
                    entityIdsNoCache[entityIds[i]] = i;
                }
            }
            if (entityIdsNoCache.Count() > 0)
            {
                IEnumerable<T> entitiesFromDb = Filter(e => entityIdsNoCache.Keys.Contains(e.Id), includeProperties);
                foreach (var entityFromDb in entitiesFromDb)
                {
                    entityArr[entityIdsNoCache[entityFromDb.Id]] = entityFromDb;
                    await _cache.SetAsync(_cacheConfig.GetCacheKeyOfEntity(entityFromDb.Id), entityFromDb, _cacheConfig.CachingExpirationType);
                }
            }
            return entityArr.AsEnumerable();
        }

        protected virtual void OnSetted(T entity)
        {
            _cache.Set(_cacheConfig.GetCacheKeyOfEntity(entity.Id), entity, _cacheConfig.CachingExpirationType);
        }

        protected virtual async Task OnSettedAsync(T entity)
        {
            await _cache.SetAsync(_cacheConfig.GetCacheKeyOfEntity(entity.Id), entity, _cacheConfig.CachingExpirationType);
        }

        protected virtual void OnDeleted(T entity)
        {
            _cache.Remove(_cacheConfig.GetCacheKeyOfEntity(entity.Id));
        }
        protected virtual async Task OnDeletedAsync(T entity)
        {
            await _cache.RemoveAsync(_cacheConfig.GetCacheKeyOfEntity(entity.Id));
        }


    }
}
