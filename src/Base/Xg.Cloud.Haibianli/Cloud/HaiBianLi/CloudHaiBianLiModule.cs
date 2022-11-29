using Cloud.Core.Module;
using Cloud.HttpClient;
using System;

namespace Cloud.HaiBianLi
{
    public class CloudHaiBianLiModule : AppModule
    {
        public static readonly string RemoteServiceName = "CloudHaiBianLi";

        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                var configuration = context.Configuration;
                context.Services.AddHttpClientProxies(configuration, this.GetType().Assembly, RemoteServiceName, typeof(IApiService));
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
    }
}
