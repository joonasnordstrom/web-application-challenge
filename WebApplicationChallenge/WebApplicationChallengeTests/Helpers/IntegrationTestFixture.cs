using Microsoft.EntityFrameworkCore;
using System;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.Persistence.Contexts;
using VincitWebApplication.Persistence.Repositories;
using VincitWebApplication.Services;

namespace VincitWebApplicationTests.Helpers
{
    public class IntegrationTestFixture : IDisposable
    {
        public readonly TestWebApplicationFactory<VincitWebApplication.Startup> WebApplicationFactory;
        private readonly iot_dbContext _context;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public readonly ISensorService SensorService;
        const string PATH_TO_TEST_DB = "..\\..\\..\\iot_dbTest.sqlite";
        public string CONNECTION_STRING => $"Data Source={PATH_TO_TEST_DB};";

        public IntegrationTestFixture()
        {
            WebApplicationFactory = new TestWebApplicationFactory<VincitWebApplication.Startup>();
            Environment.SetEnvironmentVariable("SqliteConnection", CONNECTION_STRING);
            var contextOptions = new DbContextOptionsBuilder<iot_dbContext>()
                .UseSqlite(CONNECTION_STRING)
                .Options;

            _context = new iot_dbContext(contextOptions);
            _repositoryWrapper = new RepositoryWrapper(_context);
            SensorService = new SensorService(_repositoryWrapper);
        }

        public void Dispose()
        {
        }
    }
}
