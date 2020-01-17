namespace Thinning.Web
{
    using Autofac;
    using FluentValidation.AspNetCore;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Thinning.Application.Test.Command.AddTest;
    using Thinning.Persistence;
    using Thinning.Persistence.Interfaces;
    using Thinning.Persistence.Interfaces.Repository;
    using Thinning.Persistence.Repository;
    using Thinning.Web.Filters;
    using Thinning.Web.Filters.Validator.Test;

    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json");

            _configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
                options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddTestValidator>());

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IThinningDbContext, ThinningDbContext>();
            services.AddDbContext<ThinningDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("ThinningDatabase")));

            services.AddMediatR(typeof(AddTestCommandHandler).Assembly);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DatabaseAutofacModule(_configuration.GetConnectionString("ThinningDatabase")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
