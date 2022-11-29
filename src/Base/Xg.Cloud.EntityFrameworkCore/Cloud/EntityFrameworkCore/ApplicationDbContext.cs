using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Cloud.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region 自动匹配modelMap
            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            //获取web引用的所有的程序集
            var assemblyDomain = Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(n => n.Name.StartsWith("Domain")).ToList();
            assemblyDomain.Add(Assembly.GetEntryAssembly().GetName());
            assemblyDomain.ForEach(x =>
            {
                var assembly = Assembly.Load(x);
                var mappingTypes = assembly.GetTypes()
                    .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
                var entityMethod = typeof(ModelBuilder).GetMethods()
                    .Single(x => x.Name == "Entity" &&
                            x.IsGenericMethod &&
                            x.ReturnType.Name == "EntityTypeBuilder`1");

                foreach (var mappingType in mappingTypes)
                {
                    var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                    var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                    var entityBuilder = genericEntityMethod.Invoke(builder, null);
                    var mapper = Activator.CreateInstance(mappingType);
                    mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
                }
            });     
        }
        #endregion
    }
}
