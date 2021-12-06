using GameSecurityLayer;
using GameSecurityLayer.Contexts;
using GameSecurityLayer.Models.Items;
using GameSecurityLayer.Models.Player;
using GameSecurityLayer.Repositories;
using GameSecurityLayer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace GameApi
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

            services.AddDbContext<GameContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Game"), b => b.MigrationsAssembly("GameApi"));
                
            });
                
            services.AddTransient<IPlayerRepository<PlayerModel>, PlayerRepository<PlayerModel>>();
            services.AddTransient<IItemRepository<ItemModel>, ItemRepository<ItemModel>>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IPlayerService<PlayerModel>, PlayerService<PlayerModel>>();
            services.AddTransient<IItemService<ItemModel>, ItemService<ItemModel>>();
            services.AddTransient<IInventoryService, InventoryService>();

            services.AddAuthorization();
            services.AddControllers();
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameApi", Version = "v1" });
                  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameApi v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");
        }
    }
}
