using Admin.Domain.Monitoring;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Context;

public class MonitoringDbContext : DbContext
{
    public DbSet<SensorData> SensorData { get; set; }

    public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SensorData>().ToTable("SensorData").HasNoKey();
        modelBuilder.Entity<SensorData>().Property(x => x.Time).IsRequired();
        modelBuilder.Entity<SensorData>().Property(x => x.TrackingKey).IsRequired();
        modelBuilder.Entity<SensorData>().Property(s => s.Value).HasColumnType("jsonb");

    }
}