using Cloud.Caching;
using Cloud.Domain.Entities;
using Cloud.EntityFrameworkCore;
using Cloud.Snowflake;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Cloud.Repositories.EntityFrameworkCore
{
    public class BaseListCacheRepository<T> : BaseRepository<T>, IListCacheRepository<T> where T : BaseEntity<long>
    {
        private readonly ICache _cache;
        private List<T> _listT;
        private readonly ICacheConfig<T> _cacheConfig;
        private readonly ILogger<BaseListCacheRepository<T>> _logger;

        public BaseListCacheRepository(ApplicationDbContext applicationDbContext, ICache cacheService, ICacheConfig<T> cacheConfig, ISnowflakeIdWorker SnowflakeIdWorker, ILogger<BaseListCacheRepository<T>> logger) : base(applicationDbContext, SnowflakeIdWorker)
        {
            _cache = cacheService;
            _cacheConfig = cacheConfig;
            _listT = _cache.Get<List<T>>(_cacheConfig.GetListCacheKey());
            _logger = logger;
        }
        public List<T> GetList(params Expression<Func<T, object>>[] includeProperties)
        {
            CheckCache(includeProperties);
            return _listT;
        }

        public async Task<List<T>> GetListAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            await CheckCacheAsync(includeProperties);
            return _listT;
        }

        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public override IQueryable<T> Find(Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            CheckCache(includeProperties);
            var query = _listT.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (string.IsNullOrEmpty(orderBy))
                query = query.OrderByDescending(x => x.Id);
            else
                query = query.OrderBy(orderBy);
            return query;
        }

        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            await CheckCacheAsync(includeProperties);
            var query = _listT.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (string.IsNullOrEmpty(orderBy))
                query = query.OrderByDescending(x => x.Id);
            else
                query = query.OrderBy(orderBy);
            return query;
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        public override T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            CheckCache(includeProperties);
            return _listT.AsQueryable().Where(predicate).FirstOrDefault(predicate);
        }


        /// <summary>
        /// 查找单个
        /// </summary>
        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            await CheckCacheAsync(includeProperties);
            return _listT.AsQueryable().Where(predicate).FirstOrDefault(predicate);
        }


        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageIndex">The pageIndex.</param>
        /// <param name="pageSize">The pageSize. limit max 100</param>
        /// <param name="orderBy">排序，格式如："Id"/"Id desc"</param>
        public override IQueryable<T> FindByPage(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            CheckCache(includeProperties);
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize > 1000) pageSize = 1000;
            var query = _listT.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (string.IsNullOrEmpty(orderBy))
                query = query.OrderByDescending(x => x.Id);
            else
                query = query.OrderBy(orderBy);
            return query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageIndex">The pageIndex.</param>
        /// <param name="pageSize">The pageSize.</param>
        /// <param name="orderBy">排序，格式如："Id"/"Id desc"</param>
        public async Task<IQueryable<T>> FindByPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            await CheckCacheAsync(includeProperties);
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize > 1000) pageSize = 1000;
            var query = _listT.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (string.IsNullOrEmpty(orderBy))
                query = query.OrderByDescending(x => x.Id);
            else
                query = query.OrderBy(orderBy);
            return query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public override int GetCount(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            CheckCache(includeProperties);
            if (predicate != null)
            {
                return _listT.AsQueryable().Where(predicate).Count();

            }
            return _listT.Count();
        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            await CheckCacheAsync(includeProperties);
            if (predicate != null)
            {
                return _listT.AsQueryable().Where(predicate).Count();

            }
            return _listT.Count();
        }

        public override T Add(T entity)
        {
            var t = base.Add(entity);
            RemoveCache();
            return t;
        }

        public async Task AddAsync(T entity)
        {
            base.Add(entity);
            await RemoveCacheAsync();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public override void BatchAdd(T[] entities)
        {
            base.BatchAdd(entities);
            RemoveCache();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public async Task BatchAddAsync(T[] entities)
        {
            base.BatchAdd(entities);
            await RemoveCacheAsync();
        }

        public override T Update(T entity, IList<string> excludeColumnNames = null)
        {
            base.Update(entity, excludeColumnNames);
            RemoveCache();
            return entity;
        }

        public async Task UpdateAsync(T entity, IList<string> excludeColumnNames = null)
        {
            base.Update(entity, excludeColumnNames);
            await RemoveCacheAsync();
        }

        public override void Delete(T entity)
        {
            base.Delete(entity);
            RemoveCache();
        }


        public async Task DeleteAsync(T entity)
        {
            base.Delete(entity);
            await RemoveCacheAsync();
        }


        public override void Delete(Expression<Func<T, bool>> predicate)
        {
            base.Delete(predicate);
            RemoveCache();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            base.Delete(predicate);
            await RemoveCacheAsync();
        }

        private void CheckCache(params Expression<Func<T, object>>[] includeProperties)
        {
            if (_listT == null)
                UpdateCache(includeProperties);
        }

        private async Task CheckCacheAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            if (_listT == null)
                await UpdateCacheAsync(includeProperties);
        }

        public void UpdateCache(params Expression<Func<T, object>>[] includeProperties)
        {
            var listT = base.Filter(null, includeProperties).ToList();
            //if (typeof(T).Name == "Goods")
            //{
            //    var GoodsList = JsonUtility.Deserialize<List<Goods>>(JsonUtility.Serialize(listT));
            //    if (GoodsList.Any(x => x.GoodsImages == null || x.GoodsImages.Count==0))
            //    {
            //        throw new MyException("goodsImages null");
            //    }
            //}
            _cache.Set(_cacheConfig.GetListCacheKey(), listT, _cacheConfig.CachingExpirationType);
            _listT = listT;
        }

        public async Task UpdateCacheAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            var listT = base.Filter(null, includeProperties).ToList();
            //if (typeof(T).Name == "Goods")
            //{
            //    var GoodsList= JsonUtility.Deserialize<List<Goods>>(JsonUtility.Serialize(listT));
            //    if (GoodsList.Any(x => x.GoodsImages == null || x.GoodsImages.Count == 0))
            //    {
            //        throw new MyException("goodsImages null");
            //    }
            //}
            await _cache.SetAsync(_cacheConfig.GetListCacheKey(), listT, _cacheConfig.CachingExpirationType);
            _listT = listT;
        }

        public void RemoveCache()
        {
            var cacheHelper = new CacheConfig<T>(CachingExpireType.Invariable);
            _cache.Remove(cacheHelper.GetListCacheKey());
        }

        public async Task RemoveCacheAsync()
        {
            var cacheHelper = new CacheConfig<T>(CachingExpireType.Invariable);
            await _cache.RemoveAsync(cacheHelper.GetListCacheKey());
        }

    }
}
