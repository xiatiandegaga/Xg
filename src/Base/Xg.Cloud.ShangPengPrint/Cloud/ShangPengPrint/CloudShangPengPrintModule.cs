using Microsoft.Extensions.DependencyInjection;
using Cloud.Core.Module;
using System;

namespace Cloud.ShangPengPrint
{
    public class CloudShangPengPrintModule : AppModule
    {
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            try
            {
                context.Services.AddSingleton<IPrint, ShangPengPrint>();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
