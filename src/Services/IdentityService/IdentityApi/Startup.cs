using Cloud.Core.Module;
using Cloud.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCloudModule<CloudBackendModule>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DIUtility.DIApp = app;
            app.ApplicationServices.UseCloudModule();

            //app.UseExceptionless();
            //AutoMapperHelper.serviceProvider = app.ApplicationServices;
            //if (env.IsDevelopment())
            //{
            //    app.UseSwagger(c =>
            //    {
            //        c.PreSerializeFilters.Add((swagger, httpReq) =>
            //        {
            //            swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/{httpReq.Headers["X-Forwarded-Prefix"]}" } };
            //        });
            //    });
            //}
            //else
            //{
            //    app.UseSwagger(c =>
            //    {
            //        c.PreSerializeFilters.Add((swagger, httpReq) =>
            //        {
            //            swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}/{httpReq.Headers["X-Forwarded-Prefix"]}" } };
            //        });
            //    });
            //}

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            //});

            //app.UseRouting();

            //app.UseCors("Cors");

            //app.UseAuthentication();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
