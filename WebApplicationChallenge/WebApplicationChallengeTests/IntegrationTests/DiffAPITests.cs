using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Models;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.Domain.Services.Communication;
using VincitWebApplicationTests.Helpers;
using Xunit;

namespace VincitWebAppTests.IntegrationTests
{
    public class DiffAPITests : IClassFixture<IntegrationTestFixture>
    {
        private readonly TestWebApplicationFactory<VincitWebApplication.Startup> _webApplicationFactory;
        private readonly ISensorService _sensorService;

        public DiffAPITests(IntegrationTestFixture integrationTestFixture)
        {
            _sensorService = integrationTestFixture.SensorService;
            _webApplicationFactory = integrationTestFixture.WebApplicationFactory;
        }

        [Fact(DisplayName = "It should return sensor by specified ID")]
        public async Task Get_Valid_Diff()
        {
            double difference = await _sensorService.GetDifferenceAsync("000D6F0003141E14");
            var expectedResult = new DiffResponse("Success", difference);

            var client = _webApplicationFactory.CreateClient();

            var response = await client.GetAsync(@"https://localhost:44338/api/diff/000D6F0003141E14");

            response.EnsureSuccessStatusCode();
            Expect.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var responseString = await response.Content.ReadAsStringAsync();

            Expect.DeepEqualLowerCaseFields(expectedResult, responseString);
        }

        [Fact(DisplayName = "It should return status code 404")]
        public async Task Get_Invalid_Diff()
        {
            string id = "THIS_IS_NOT_A_VALID_ID_FOR_SURE";

            var expectedResult = new NotFoundObjectResult(new DiffResponse(id)).Value;

            var client = _webApplicationFactory.CreateClient();

            var response = await client.GetAsync($"https://localhost:44338/api/diff/{id}");

            Expect.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
            Expect.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var responseString = await response.Content.ReadAsStringAsync();

            // TODO someone is formatting my decimals
            Expect.DeepEqualLowerCaseFields(expectedResult, responseString);
        }
    }
}
