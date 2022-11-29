using Cloud.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Shared
{
    public class ActivitySharedModule : AppModule
    {
        public static readonly string RemoteServiceName = "Activity";
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
    }
}
