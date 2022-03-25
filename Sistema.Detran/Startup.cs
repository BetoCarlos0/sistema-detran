using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sistema.Detran.Domain;
using Sistema.Detran.Infra.Facade;
using Sistema.Detran.Infra.Repositories;
using Sistema.Detran.Infra.Repositories.EF;
using Sistema.Detran.Infra.Singleton;
using System;
using System.IO;

namespace Sistema.Detran
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema.Detran", Version = "v1"
                
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "Sistema.Detran.xml");
                c.IncludeXmlComments(apiPath);
            });
            services.AddSingleton<SingletonContainer>();
            services.AddTransient<IVeiculoRepository, SistemaDetranRepository>();
            services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

            services.AddDbContext<SistemaDetranContext>(opt =>
                opt.UseInMemoryDatabase("Sistema"));

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema.Detran v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
