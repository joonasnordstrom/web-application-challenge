using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Models;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.DTOs;
using VincitWebApplication.Persistence.Contexts;

namespace VincitWebApplication.Persistence.Repositories
{
    /// <summary>
    /// This repository handles all database queries for datatable cubesensors_data
    /// </summary>
    public class CubesensorsDatumRepository : BaseRepository<CubesensorsDatum>, ICubesensorsDatumRepository
    {
        public CubesensorsDatumRepository(iot_dbContext context) : base(context) { }

        /// <summary>
        /// Get all sensors from database
        /// </summary>
        public async Task<List<CubesensorsDatum>> ListAsync()
        {
            return await base.FindAll()
                .ToListAsync();
        }

        /// <summary>
        /// Get summary of sensors from database
        /// </summary>
        public async Task<List<SummaryDTO>> SummaryAsync()
        {
            var sensorSummary = await Context.CubesensorsData
                .GroupBy(sensor => sensor.SensorId)
                .Select(group => new SummaryDTO
                {
                    SensorId = group.Key,
                    Count = group.Count(),
                    AvgTemp = (double)(group.Sum(i => i.Temperature) / group.Count()) / 100,
                })
                .ToListAsync();

            return sensorSummary;
        }

        /// <summary>
        /// Get latest measurement by SensorId 
        /// </summary>
        public async Task<CubesensorsDatum> FindLatestByIdAsync(string id)
        {
           return await base.FindByCondition(sensor => sensor.SensorId == id)
                .OrderBy(sensor => sensor.MeasurementTime)
                .LastAsync();
        }
    }
}
