using System;
using System.Collections.Generic;

#nullable disable

namespace VincitWebApplication.Domain.Models
{
    /// <summary>
    /// Database model for OutsideTemperature
    /// </summary>
    public partial class OutsideTemperature
    {
        public byte[] MeasurementTime { get; set; }
        public byte[] Temperature { get; set; }
    }
}
