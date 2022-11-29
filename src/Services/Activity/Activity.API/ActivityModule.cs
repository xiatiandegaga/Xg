using Cloud.AutoMapper;
using Cloud.Caching;
using Cloud.Core.Module;
using Cloud.Cors;
using Cloud.Domain;
using Cloud.Extensions;
using Cloud.Http.Client;
using Cloud.HttpClient;
using Cloud.Jwt;
using Cloud.Mvc;
using Cloud.Repositories.EntityFrameworkCore;
using Cloud.Repositories.EntityFrameworkCore.PostgreSQL;
using Cloud.Swagger;
using Identity.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CloudHall.EstateMarket.Services.Activity.API
{
    [DependsOn(
     typeof(CloudAutoMapperModule),
     typeof(CloudCachingModule),
     typeof(CloudDomainModule),
     typeof(CloudCorsModule),
     typeof(CloudJwtModule),
     typeof(CloudMvcModule),
     typeof(CloudSwaggerModule),
     typeof(CloudHttpClientModule),
     typeof(CloudEntityFrameworkCoreModule),
     typeof(CloudEntityFrameworkCorePostgreSQLModule)

     )]
    public class ActivityModule : AppModule
    {

        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Configuration;
            context.Services.AddDddBasicService(configuration);

            context.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            context.Services.AddHttpClient();

            context.Services.AddHttpClientProxies(configuration,typeof(IdentitySharedModule).Assembly, IdentitySharedModule.RemoteServiceName);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }

    }
}
