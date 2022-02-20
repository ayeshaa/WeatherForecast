using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using WeatherForecast.API.WeatherforecastRequest.V1.Repositories.CityData;
using WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecast;
using WeatherForecast.API.WeatherforecastRequest.V1.Services.WeatherForecastAPI;
using WeatherForecast.API.WeatherForecastRequest.V1.Repositories.WeatherForecast;
using WeatherForecast.Service.Services;

namespace WeatherForecast.Service
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
            services.AddRazorPages();

            // connecting hangfire with mongo Db
            services.AddControllers();

            var connectionString = this.Configuration.GetConnectionString("Mongo");
            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    },
                    Prefix = "hangfire.mongo",
                    CheckConnection = true
                })
            );
            services.AddHangfireServer(serverOptions =>
            {
                serverOptions.ServerName = "WeatherForecast.Hangfire";
            });
            services.AddHangfireServer();

            // Resolving Dependency Injection
            services.AddScoped<IWeatherForecastRequestRepository, WeatherForecastRequestRepository>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IWeatherForecastApiService, WeatherForecastApiService>();
            services.AddScoped<ICityRepository, CityRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //// Starting job every hour
            RecurringJob.AddOrUpdate<WeatherForecastSchedularService>(service => service.ExecuteService(), Cron.Hourly);

            //// Starting job daily
            RecurringJob.AddOrUpdate<WeatherForecastSchedularService>(service => service.ExecuteService(), Cron.Daily);

            //// Starting job every 10 minutes
            ////RecurringJob.AddOrUpdate<WebTrackingRequestService>(service => service.ExecuteService(), string.Format("*/{0} * * * *", 10));

            BackgroundJob.Enqueue<WeatherForecastSchedularService>(service => service.ExecuteService());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard();
        }
    }
}
