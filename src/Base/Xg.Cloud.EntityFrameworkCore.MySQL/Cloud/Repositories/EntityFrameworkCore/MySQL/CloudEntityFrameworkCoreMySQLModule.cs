using Microsoft.Extensions.DependencyInjection;
using Cloud.Core.Module;

namespace Cloud.Repositories.EntityFrameworkCore.MySQL
{
    [DependsOn(typeof(CloudEntityFrameworkCoreModule))]
    public class CloudEntityFrameworkCoreMySQLModule : AppModule
    {
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Configuration;
            //工作单元
            context.Services.AddScoped(typeof(IUnitWork), typeof(UnitWork));
            //工作单元
            context.Services.AddScoped(typeof(IEfCoreUnitWork), typeof(UnitWork));
            //ef.mysql初始化配置
            context.Services.AddEntityFrameworkCore(configuration);
        }
    }
}
