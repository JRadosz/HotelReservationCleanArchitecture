using Cortex.Mediator.DependencyInjection;
using HotelReservation.Application.Common.Mapping;
using HotelReservation.Application.HotelRooms.Queries.GetHotelRoom;
using HotelReservation.Domain.Repositories;
using HotelReservation.Infrastructure;
using HotelReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            Configuration = InitConfiguration(env);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = Configuration
                    .GetSection("ConnectionStrings")
                    .GetValue<string>("DefaultConnection");
                var versionMySql = new MySqlServerVersion(new Version(8, 0, 34));

                options.UseMySql(connectionString, versionMySql);
            });

            services.AddCortexMediator(
                Configuration,
                new[] { typeof(Program), typeof(GetHotelRoomQueryHandler)}, // Assemblies to scan for handlers
                options => options.AddDefaultBehaviors() // Logging, Validation, Transaction
            );

            services.AddControllers();
            services.AddEndpointsApiExplorer(); // Required for minimal API support
            services.AddSwaggerGen(); // Add Swagger generator

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole()
                       .SetMinimumLevel(LogLevel.Debug);
            });

            services.AddAutoMapper(cfg => { }, typeof(Startup), typeof(HotelRoomProfile));
            services.AddScoped(typeof(ISimpleRepository<>), typeof(SimpleRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); // JSON endpoint
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var dupa = dbContext.Database.GetConnectionString();
                dbContext.Database.Migrate();
            }

        }

        private IConfiguration InitConfiguration(IWebHostEnvironment env)
        {
            // Config the app to read values from appsettings base on current environment value.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
            //
            // Map AppSettings section in appsettings.json file value to AppSetting model
            var dupa = configuration
                .GetSection("ConnectionString")
                .Get<string>(options => options.BindNonPublicProperties = true);
            return configuration;
        }
    }
}
