﻿using corenorthwindapi.Services;
using corenorthwindapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace corenorthwindapi
{
    public class Startup
    {

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        private IConfiguration _config { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //add this, if this is a WebAPI Application
            services.AddControllers();

            //add this, if this is a MVC application
            //services.AddMvc();

            //add this, if this is a Razor application
            //services.AddRazorPages();

            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer(_config.GetConnectionString("NorthwindDB")));

            //services.AddSwaggerGen();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebAPI: core.northwind.api",
                    Description = "A simple example for swagger api information",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name XYZ",
                        Email = "xyz@gmail.com",
                        Url = new Uri("https://example.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under OpenApiLicense",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
            services.AddApplicationInsightsTelemetry();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Setting the Default Files
            app.UseDefaultFiles();
            //Adding Static Files Middleware to serve the static files
            app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            ///    await context.Response.WriteAsync("Request handled by the terminating middleware");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "corenorthwindapi v1");
            });
        }
    }
}
