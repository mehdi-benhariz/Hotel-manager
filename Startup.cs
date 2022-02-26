using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyAPIProject.config;
using MyAPIProject.data;
using MyAPIProject.Repository;
using Serilog;

namespace MyAPIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                    {
                        options.AddPolicy("CorsPolicy", builder =>
                                      {
                                          builder.AllowAnyOrigin()
                                          //    .WithOrigins("http://example.com")
                                          .AllowAnyMethod()
                                          .AllowAnyHeader();
                                      });
                    });
            services.AddDbContext<DataBaseContext>(
                (options =>
                  options.UseSqlite(Configuration.GetConnectionString("sqlConnection")))
                );
            services.AddAutoMapper(typeof(MapperInitializer));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPIProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPIProject v1"));
            }
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt")
            .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                     .MinimumLevel.Error()
                     .WriteTo.File("logs/error-.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                     .CreateLogger();

            // Log.CloseAndFlush();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.File("logs/warning-.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Log.CloseAndFlush();


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
