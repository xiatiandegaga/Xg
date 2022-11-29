using Cloud.AutoMapper;
using Cloud.Caching;
using Cloud.CloudQRCode;
using Cloud.Core.Module;
using Cloud.Cors;
using Cloud.Domain;
using Cloud.Emailing.MailKit;
using Cloud.EventBus.RabbitMQ;
using Cloud.Extensions;
using Cloud.HaiBianLi;
using Cloud.HuiYiJie;
using Cloud.Jwt;
using Cloud.Models;
using Cloud.Models.HttpClientUtility;
using Cloud.Mvc;
using Cloud.Parking;
using Cloud.PrivateNumber;
using Cloud.Repositories.EntityFrameworkCore;
using Cloud.Repositories.EntityFrameworkCore.PostgreSQL;
using Cloud.ShangPengPrint;
using Cloud.SMS.Tencent;
using Cloud.Swagger;
using Cloud.TencentApi;
using Cloud.TencentCos;
using Essensoft.AspNetCore.Payment.WeChatPay;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi
{
    [DependsOn(
     typeof(CloudAutoMapperModule),
     typeof(CloudCachingModule),
     typeof(CloudDomainModule),
     typeof(CloudCorsModule),
     typeof(CloudJwtModule),
     typeof(CloudMvcModule),
     typeof(CloudSwaggerModule),
     typeof(CloudEntityFrameworkCoreModule),
    //typeof(CloudEntityFrameworkCoreMySQLModule),
     typeof(CloudEntityFrameworkCorePostgreSQLModule),
     typeof(CloudEmailingMailkitModule),
     typeof(CloudEventBusRabbitMQModule),
     typeof(CloudQRCodeModule),
     typeof(CloudSMSTencentModule),
     typeof(CloudShangPengPrintModule),
     typeof(CloudTencentCosModule),
     typeof(CloudPrivateNumberModule),
     typeof(CloudTencentApiModule),
     typeof(CloudParkingModule),
     typeof(CloudHuiYiJieModule),
     typeof(CloudHaiBianLiModule)
     )]
    public class CloudBackendModule : AppModule
    {

        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Configuration;
            context.Services.AddDddBasicService(configuration);
            context.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }

    }
}
