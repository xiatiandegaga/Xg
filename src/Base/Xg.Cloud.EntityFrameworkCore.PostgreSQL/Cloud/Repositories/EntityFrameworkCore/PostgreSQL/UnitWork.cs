using Cloud.Caching;
using Cloud.EntityFrameworkCore;
using Cloud.Models;
using Cloud.Snowflake;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Repositories.EntityFrameworkCore.PostgreSQL
{
    public class UnitWork : EfCoreUnitWork, IUnitWork
    {
        private readonly ApplicationDbContext _context;
        public UnitWork(ApplicationDbContext applicationDbContext, ICache cacheService, ISnowflakeIdWorker snowflakeIdWorker) : base(applicationDbContext, cacheService, snowflakeIdWorker)
        {
            _context = applicationDbContext;
        }
        public new async Task<IList<T>> SqlQueryAsync<T>(StringBuilder sql, Pagination pagination = null, params object[] parameters) where T : new() => await _context.SqlQueryAsync<T>(sql, pagination, parameters);
    }
}
