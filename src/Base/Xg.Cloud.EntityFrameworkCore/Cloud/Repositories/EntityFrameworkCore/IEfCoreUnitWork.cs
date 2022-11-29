using Microsoft.EntityFrameworkCore.Storage;

namespace Cloud.Repositories.EntityFrameworkCore
{
    public interface IEfCoreUnitWork : IUnitWork
    {
        /// <summary>
        /// 获取事务，用来执行多个表的连续的操作
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetTran();
    }
}
