using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VincitWebApplication.DTOs;

namespace VincitWebApplication.Domain.Services
{
    /// <summary>
    /// Interface for Business Logic layer of Sensor 
    /// </summary>
    public interface ISensorService
    {
        Task<List<SummaryDTO>> GetSummaryAsync();
        Task<double> GetDifferenceAsync(string sensorId);
    }
}
