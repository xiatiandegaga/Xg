using Cloud.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cloud.Repositories.EntityFrameworkCore.MySQL
{
    public static class CloudDbContextConfigurationContextMySQLExtensions
    {
        public static void AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0)));
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
