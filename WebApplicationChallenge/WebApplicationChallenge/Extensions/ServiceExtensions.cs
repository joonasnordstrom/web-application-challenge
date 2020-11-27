using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.Persistence.Contexts;
using VincitWebApplication.Persistence.Repositories;

namespace VincitWebApplication.Extensions
{
    /// <summary>
    /// Extension methods for IServiceCollection
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICubesensorsDatumRepository, CubesensorsDatumRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnection");
            services.AddDbContext<iot_dbContext>(options => options.UseSqlite(connectionString));
        }

        // Just in case for possible future front-end framework related CORS issues
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
