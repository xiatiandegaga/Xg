using Cloud.Core.Module;
using Cloud.HttpClient;
using Microsoft.Extensions.DependencyInjection;
namespace Cloud.HuiYiJie
{
    public class CloudHuiYiJieModule : AppModule
    {
        public static readonly string RemoteServiceName = "CloudHuiYiJie";

        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Configuration;
            context.Services.AddSingleton(typeof(GetHuiYiJieToken));
            context.Services.AddHttpClientProxies(configuration, this.GetType().Assembly, RemoteServiceName,typeof(IApiService));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
    }
}
