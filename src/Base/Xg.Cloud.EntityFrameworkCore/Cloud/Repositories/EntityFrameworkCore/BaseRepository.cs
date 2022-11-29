using Cloud.Domain.Entities;
using Cloud.EntityFrameworkCore;
using Cloud.Snowflake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Cloud.Repositories.EntityFrameworkCore
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity<long>
    {
        private readonly ApplicationDbContext _context;
        private readonly ISnowflakeIdWorker _SnowflakeIdWorker;
        public BaseRepository(ApplicationDbContext applicationDbContext, ISnowflakeIdWorker SnowflakeIdWorker = null)
        {
            _context = applicationDbContext;
            _SnowflakeIdWorker = SnowflakeIdWorker;
        }
        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                return Filter(predicate, includeProperties).OrderByDescending(x => x.Id).AsNoTracking();
            }
            else
            {
                return Filter(predicate, includeProperties).OrderBy(orderBy).AsNoTracking();
            }
        }

        public virtual bool IsExist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public virtual T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return Filter(predicate, includeProperties).AsNoTracking().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageIndex">The pageIndex.</param>
        /// <param name="pageSize">The pageSize. limit max 100</param>
        /// <param name="orderBy">排序，格式如："Id"/"Id desc"</param>
        public virtual IQueryable<T> FindByPage(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize > 1000) pageSize = 1000;
            if (string.IsNullOrEmpty(orderBy))
            {
                return Filter(predicate, includeProperties).OrderByDescending(x => x.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsNoTracking();
            }
            return Filter(predicate, includeProperties).OrderBy(orderBy).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsNoTracking();
        }


        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public virtual int GetCount(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            return Filter(predicate, includeProperties).AsNoTracking().Count();
        }


        public virtual T Add(T entity)
        {
            entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            entity = _context.Set<T>().Add(entity).Entity;
            Commit();
            //LogUtility.Info($"用户ID：{_httpContextAccessor.HttpContext.User.Identity.Name} 对表{typeof(T).Name}执行了插入操作，插入的ID为{entity.Id}。");
            return entity;
        }



        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void BatchAdd(T[] entities)
        {
            foreach (var entity in entities)
                entity.Id = entity.Id == default ? _SnowflakeIdWorker.NextId() : entity.Id;
            _context.Set<T>().AddRange(entities);
            Commit();
            //LogUtility.Info($" 用户ID：{_httpContextAccessor.HttpContext.User.Identity.Name} 对表{typeof(T).Name}执行了批量插入操作，插入的ID为{string.Join(",", entities.Select(e => e.Id))}。");
        }

        public virtual T Update(T entity, IList<string> excludeColumnNames = null)
        {
            _context.Set<T>().Attach(entity);
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            excludeColumnNames ??= new List<string>();
            excludeColumnNames.Add("createdate");
            excludeColumnNames.Add("createid");
            excludeColumnNames.Add("thirdpartid");
            dbEntityEntry.OriginalValues.Properties.Where(x => excludeColumnNames.Contains(x.Name.ToLower())).ToList().ForEach(x => dbEntityEntry.Property(x.Name).IsModified = false);
            //LogUtility.Info($"用户ID： {_httpContextAccessor.HttpContext.User.Identity.Name}对表{typeof(T).Name}执行了更新操作，更新的数据为{JsonUtility.Serialize(entity)}。");
            Commit();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
            Commit();
            //LogUtility.Info($" 用户ID：{_httpContextAccessor.HttpContext.User.Identity.Name} 对表{typeof(T).Name}执行了删除操作，删除的ID为{entity.Id}。");
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            //LogUtility.Info($" 用户ID：{_httpContextAccessor.HttpContext.User.Identity.Name} 对表{typeof(T).Name}执行了批量删除操作，删除的ID为{string.Join(",", entities.Select(e => e.Id))}。");
            Commit();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            if (predicate != null)
            {
                query = query.Where(predicate).AsNoTracking();
            }
            return query;
        }
    }
}
