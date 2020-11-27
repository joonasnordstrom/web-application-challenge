using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VincitWebApplication.DTOs
{
    /// <summary>
    /// Client-side data transfer object (DTO) for database model CubesensorsDatum api/summary responses
    /// </summary>
    public class SummaryDTO
    {
        public string SensorId { get; set; }
        public int Count { get; set; }
        public double AvgTemp { get; set; }
    }
}
