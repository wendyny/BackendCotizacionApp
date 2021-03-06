using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCotizacionApp.AppServices;
using BackendCotizacionApp.DataContext;
using BackendCotizacionApp.DomainServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackendCotizacionApp
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
            services.AddDbContext<CotizacionAppDbContext>();
            services.AddScoped<UsuarioAppService>();
            services.AddScoped<ClienteAppService>();
            services.AddScoped<CategoriaAppService>();
            services.AddScoped<CotizacionAppService>();
            services.AddScoped<ProductoAppService>();
            services.AddScoped<DetalleCotizacionAppService>();
            services.AddScoped<DetalleCotizacionDomainService>();
            services.AddScoped<ClienteDomainService>();
            services.AddScoped<CotizacionDomainService>();
            services.AddScoped<UsuarioDomainService>();
            services.AddScoped<CategoriaDomainService>();
            services.AddScoped<ProductoDomainService>();
            services.AddMvc().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
