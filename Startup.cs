using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MovieApi
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
            services.AddSingleton<Data.IMetadataReader>(new Data.MetadataCsvReader("metadata.csv"));
            services.AddSingleton<Data.IStatReader>(new Data.StatCsvReader("stats.csv"));
            services.AddScoped(typeof(Repositories.IMetadataRepository), typeof(Repositories.MetaDataRepository));
            services.AddScoped(typeof(Services.IMetadataService), typeof(Services.MetadataService));
            services.AddScoped(typeof(Repositories.IStatRepository), typeof(Repositories.StatRepository));
            services.AddScoped(typeof(Services.IMovieService), typeof(Services.MovieService));
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
