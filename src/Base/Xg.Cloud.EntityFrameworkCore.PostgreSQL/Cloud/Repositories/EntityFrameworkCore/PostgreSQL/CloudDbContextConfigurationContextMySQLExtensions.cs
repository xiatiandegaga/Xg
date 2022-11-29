using Cloud.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cloud.Repositories.EntityFrameworkCore.PostgreSQL
{
    public static class CloudDbContextConfigurationContextMySQLExtensions
    {
        public static void AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
