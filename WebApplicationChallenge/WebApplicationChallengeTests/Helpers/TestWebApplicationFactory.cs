using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using VincitWebApplication.Persistence.Contexts;

namespace VincitWebApplicationTests.Helpers
{
    // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2#customize-webapplicationfactory
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlite().BuildServiceProvider();

                // Setup copy of original Sqlite database for testing
                var connectionString = Environment.GetEnvironmentVariable("SqliteConnection");
                services.AddEntityFrameworkSqlite().AddDbContext<iot_dbContext>(options =>
                {
                    options.UseSqlite(connectionString);
                });

                // Build the service provider
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<iot_dbContext>();

                    // Ensure the database is created
                    db.Database.Migrate();
                }
            });
        }
    }
}
