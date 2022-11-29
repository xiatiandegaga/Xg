using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cloud.Repositories
{
    public interface IRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        bool IsExist(Expression<Func<T, bool>> predicate);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindByPage(int pageIndex = 1, int pageSize = 10, Expression<Func<T, bool>> predicate = null, string orderBy = "Id desc", params Expression<Func<T, object>>[] includeProperties);
        int GetCount(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T Add(T entity);
        void BatchAdd(T[] entities);

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        T Update(T entity, IList<string> excludeColumnNames = null);
        void Delete(T entity);
        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
