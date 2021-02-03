using BusinessAccessLayer.Repository;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_Abhi.Filters;
using POC_Abhi.Middlewares;

namespace POC_Abhi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
                options.Filters.Add(typeof(CustomExceptionHandler));
            });
            services.AddScoped<IAppSettings,AppSettings>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            //Custom Middleware
            //app.UseMiddleware<MyMiddleware>();
            app.Map("/", endpoints =>
             {
                 endpoints.UseMiddleware<MyMiddleware>();
                 endpoints.UseMiddleware<MyCustomMiddleware>();
             });
            app.UseMvc();            
        }
    }
}
