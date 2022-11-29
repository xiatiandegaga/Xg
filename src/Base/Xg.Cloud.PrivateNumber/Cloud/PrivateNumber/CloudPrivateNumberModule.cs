using Cloud.Core.Module;
using Cloud.HttpClient;
using Cloud.PrivateNumber.YunCheng;
using System;

namespace Cloud.PrivateNumber
{
    public class CloudPrivateNumberModule : AppModule
    {
        public static readonly string RemoteServiceName = "PrivateNumberYunCheng";

        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                var configuration = context.Configuration;
                context.Services.AddHttpClientProxies(configuration, this.GetType().Assembly, RemoteServiceName, typeof(IApiService));
            }
            catch(Exception ex)
            {

            }
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
    }
}
