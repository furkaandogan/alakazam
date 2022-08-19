using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alakazam.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Alakazam.Basket.Application;
using Microsoft.OpenApi.Models;
using Alakazam.Basket.Infrastructure;

namespace Alakazam.Basket.Web.Api
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
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSingleton<IdentityContext,IdentityContext>();
            services
                .SetupApp()
                .SetupInfra()
                .AddSwaggerGen(c =>
                {
                    c.OperationFilter<AuthHeaderParameterOperationFilter>();
                    // c.AddSecurityDefinition("user-id", new OpenApiSecurityScheme
                    // {
                    //     Description = "user id bilgisi",
                    //     Name = "user-id",
                    //     In = ParameterLocation.Header,
                    //     Scheme = "bearer",
                    //     Type = SecuritySchemeType.Http,
                    //     BearerFormat = "JWT"
                    // });
                    // c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    //     {
                    //         {
                    //         new OpenApiSecurityScheme
                    //         {
                    //             Reference = new OpenApiReference
                    //             {
                    //                 Type = ReferenceType.SecurityScheme,
                    //                 Id = "user-id"
                    //             },
                    //             Scheme = "bearer",
                    //             Name = "user-id",
                    //             In = ParameterLocation.Header,
                    //             },
                    //             new List<string>()
                    //         }
                    //     });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alakazam Basket API V1.0.0");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
