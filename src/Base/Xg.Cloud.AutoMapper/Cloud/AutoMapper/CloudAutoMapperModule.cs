using AutoMapper;
using Cloud.Models.HttpClientUtility;
using Cloud.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Cloud.Core.Module;
using System.Linq;
using System.Reflection;

namespace Cloud.AutoMapper
{
    public class CloudAutoMapperModule : AppModule
    {
        public override void OnConfigureServices(ServiceConfigurationContext context)
        {
            var assemblies = AssemblyUtility.GetEntryAssembly(n => n.Name.EndsWith("Application")).ToList();
            assemblies.Add(Assembly.GetEntryAssembly());
            var arrProfile = assemblies.Select(t => t.DefinedTypes).First().Where(t => t.IsSubclassOf(typeof(Profile)) && !t.IsInterface && !t.IsAbstract).ToArray();
            context.Services.AddAutoMapper(arrProfile);
        }

        public override void OnApplicationInitialization(
          ApplicationInitializationContext context)
        {
            var app = DIUtility.DIApp;
            AutoMapperHelper.serviceProvider = app.ApplicationServices;
        }
    }
}
