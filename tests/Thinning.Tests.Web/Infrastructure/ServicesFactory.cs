namespace Thinning.Tests.Web.Infrastructure
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Thinning.Persistence;
    using Thinning.Persistence.Interfaces;

    public class ServicesFactory
    {
        public static ServicesModel CreateProperServices()
        {
            var services = CreateServiceCollection().BuildServiceProvider().CreateScope();
            var context = services.ServiceProvider.GetRequiredService<IThinningDbContext>();
            var connection = new DatabaseConnection("FAKE");

            ContextDataSeeding.Run(ref context);

            return new ServicesModel
            {
                Context = context,
                Connection = connection
            };
        }

        private static ServiceCollection CreateServiceCollection()
        {
            var services = new ServiceCollection();

            string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

            var basePath
                = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("tests")) + "src\\Thinning.Web";

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{AspNetCoreEnvironment}.json", optional: true)
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            services.AddDbContext<IThinningDbContext, ThinningDbContext>(c => c.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            return services;
        }
    }
}
