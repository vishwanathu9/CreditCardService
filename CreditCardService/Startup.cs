using CreditCardService.DbModels;
using CreditCardService.IRepository;
using CreditCardService.Models;
using CreditCardService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CreditCardService
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
            services.AddMvc();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.Configure<Settings>(o => { o.iConfigurationRoot = (IConfigurationRoot)Configuration; });
            services.AddTransient<ICreditCardRepository, CreditCardRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("MyExposeResponseHeadersPolicy",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                      .WithExposedHeaders("x-custom-header"); ;
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCorsMiddleware();
            app.UseCors();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }

    }
}
