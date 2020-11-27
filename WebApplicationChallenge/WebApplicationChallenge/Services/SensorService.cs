using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Models;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.DTOs;
using VincitWebApplication.Helpers;

namespace VincitWebApplication.Services
{
    /// <summary>
    /// Implementations for Business Logic layer of Sensor 
    /// </summary>
    public class SensorService : ISensorService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public SensorService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<List<SummaryDTO>> GetSummaryAsync()
        {
            return await _repoWrapper.Sensor.SummaryAsync();
        }

        public async Task<double> GetDifferenceAsync(string sensorId)
        {
            CurrentTempHTMLParser html = new CurrentTempHTMLParser();

            double currentTempInHelsinki = await html.GetCurrentTempAsync();
            CubesensorsDatum sensorById = await _repoWrapper.Sensor.FindLatestByIdAsync(sensorId);

            double latestSensorTemp = ((double)sensorById.Temperature) / 100;

            return Math.Abs(currentTempInHelsinki - latestSensorTemp);
        }
    }
}
