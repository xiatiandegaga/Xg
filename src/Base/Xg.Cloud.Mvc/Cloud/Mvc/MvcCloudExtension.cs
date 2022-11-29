using Cloud.Mvc.Filters;
using Cloud.MvcBuilder.Filters;
using Cloud.Utilities.Json;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Cloud.Mvc
{
    public class GroupNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace;
            var groupName = controllerNamespace!.Split('.').LastOrDefault();
            controller.ApiExplorer.GroupName = groupName;
        }
    }

    public static class MvcCloudExtension
    {
        public static void AddCloudMvc(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddControllers(options =>
            {
                options.Filters.Clear();
                options.Filters.Add<AsyncExceptionFilter>();
                options.Filters.Add<AsyncAuthorizationFilter>();
                options.Conventions.Add(new GroupNameConvention());

            }).AddJsonOptions(options =>
            {
                JsonUtility.InitJsonOptions(options.JsonSerializerOptions);
            });

        }
    }
}
