using Microsoft.EntityFrameworkCore;
using VincitWebApplication.Domain.Models;

#nullable disable

namespace VincitWebApplication.Persistence.Contexts
{
    /// <summary>
    /// Database context (ORM) for handling database queries
    /// </summary>
    public class iot_dbContext : DbContext
    {
        public DbSet<CubesensorsDatum> CubesensorsData { get; set; }
        public DbSet<OutsideTemperature> OutsideTemperatures { get; set; }

        public iot_dbContext()
        { }

        public iot_dbContext(DbContextOptions<iot_dbContext> options)
            : base(options)
        { }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CubesensorsDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cubesensors_data");

                entity.Property(e => e.Battery).HasColumnType("INT(10,0)");

                entity.Property(e => e.Cable).HasColumnType("INT(10,0)");

                entity.Property(e => e.Humidity).HasColumnType("INT(10,0)");

                entity.Property(e => e.Light).HasColumnType("INT(10,0)");

                entity.Property(e => e.MeasurementTime)
                    .IsRequired()
                    .HasColumnType("DATETIME2(7)");

                entity.Property(e => e.Noise).HasColumnType("INT(10,0)");

                entity.Property(e => e.Pressure).HasColumnType("INT(10,0)");

                entity.Property(e => e.Rssi).HasColumnType("INT(10,0)");

                entity.Property(e => e.SensorId)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(20)");

                entity.Property(e => e.Temperature).HasColumnType("INT(10,0)");

                entity.Property(e => e.Voc).HasColumnType("INT(10,0)");

                entity.Property(e => e.VocResistance).HasColumnType("INT(10,0)");
            });

            modelBuilder.Entity<OutsideTemperature>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("outside_temperature");

                entity.Property(e => e.MeasurementTime).HasColumnType("DATETIME2");

                entity.Property(e => e.Temperature).HasColumnType("NUMERIC");
            });
        }
    }
}
