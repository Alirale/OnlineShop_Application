using Application.Services;
using Entities.RepositoryInterfaces;
using Infrastructure.Database;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Endpoint
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

            string conection = Configuration["conection"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DatabaseContext>(
                o => o.UseSqlServer(conection));


            services.AddTransient<IPicsRepository, PicsRepository>();
            services.AddTransient<IPossibleExtrasRepository, PossibleExtrasRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<ISpecialRepository, SpecialRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();

            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IExtraFeaturesService, ExtraFeaturesService>();
            services.AddTransient<IProductsCrudService, ProductsCrudService>();
            services.AddTransient<ISpecialsService, SpecialsService>();
            services.AddTransient<IUploaderCrudService, UploaderCrudService>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Endpoint.xml"), true);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Endpoint v1"));
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
