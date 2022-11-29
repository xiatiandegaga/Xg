using Microsoft.Extensions.DependencyInjection;
using Cloud.Core.Module;

namespace Cloud.Repositories.EntityFrameworkCore.PostgreSQL
{
    [DependsOn(typeof(CloudEntityFrameworkCoreModule))]
    public class CloudEntityFrameworkCorePostgreSQLModule : AppModule
    {
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Configuration;
            //工作单元
            context.Services.AddScoped(typeof(IUnitWork), typeof(UnitWork));
            //工作单元
            context.Services.AddScoped(typeof(IEfCoreUnitWork), typeof(UnitWork));
            //ef.pgsql初始化配置
            context.Services.AddEntityFrameworkCore(configuration);

            //修改pgsql默认时间映射，改成默认不带时区
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
    }
}
