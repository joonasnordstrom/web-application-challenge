using System.ComponentModel.DataAnnotations;


namespace VincitWebApplication.Domain.Models
{
    /// <summary>
    /// Database model for CubesensorsDatum
    /// </summary>
    public partial class CubesensorsDatum
    {
        public string SensorId { get; set; }
        public byte[] MeasurementTime { get; set; }
        public long? Temperature { get; set; }
        public long? Pressure { get; set; }
        public long? Humidity { get; set; }
        public long? Voc { get; set; }
        public long? Light { get; set; }
        public long? Noise { get; set; }
        public long? Battery { get; set; }
        public long? Cable { get; set; }
        public long? VocResistance { get; set; }
        public long? Rssi { get; set; }
    }
}
