using corenorthwindapi.Services;
using corenorthwindapi.Data;
using Microsoft.EntityFrameworkCore;

namespace corenorthwindapi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            //add this, if this is a WebAPI Application
            services.AddControllers();

            //add this, if this is a MVC application
            //services.AddMvc();

            //add this, if this is a Razor application
            //services.AddRazorPages();

            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer("Server=devopsmasterlinuxvm.centralus.cloudapp.azure.com,9005;Database=Northwind;User=sa;Password=passw0rd!;"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
