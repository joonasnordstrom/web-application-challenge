using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.Domain.Services.Communication;
using VincitWebApplicationTests.Helpers;
using Xunit;

namespace VincitWebAppTests.IntegrationTests
{
    public class SummaryAPITests : IClassFixture<IntegrationTestFixture>
    {
        private readonly TestWebApplicationFactory<VincitWebApplication.Startup> _webApplicationFactory;
        private readonly ISensorService _sensorService;

        public SummaryAPITests(IntegrationTestFixture integrationTestFixture)
        {
            _sensorService = integrationTestFixture.SensorService;
            _webApplicationFactory = integrationTestFixture.WebApplicationFactory;
        }

        [Fact(DisplayName = "It should return list of sensors as a SummaryDTO")]
        public async Task Get_Sensors()
        {
            var client = _webApplicationFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:44338/api/summary");

            var expectedResult = new SummaryResponse("Success", await _sensorService.GetSummaryAsync());

            response.EnsureSuccessStatusCode();
            Expect.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var responseString = await response.Content.ReadAsStringAsync();
            Expect.DeepEqualLowerCaseFields(expectedResult, responseString);
        }
    }
}
