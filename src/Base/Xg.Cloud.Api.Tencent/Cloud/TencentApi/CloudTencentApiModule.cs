using Cloud.Core.Module;
using Cloud.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Ocr.V20181119;

namespace Cloud.TencentApi
{
    public class CloudTencentApiModule : AppModule
    {
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Configuration;
            //腾讯云api
            try
            {
                Credential cred = new()
                {
                    SecretId = configuration["CosConfigOptions:SecretId"],
                    SecretKey = configuration["CosConfigOptions:SecretKey"]
                };
                context.Services.AddSingleton(typeof(OcrClient), new OcrClient(cred, "ap-shanghai", new ClientProfile { HttpProfile = new HttpProfile { Endpoint = ("ocr.tencentcloudapi.com") } }));
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message);
            }
        }
    }
}
