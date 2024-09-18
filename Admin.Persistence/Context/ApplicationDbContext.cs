using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Host> Host { get; set; }
    public DbSet<Snmp> Snmp { get; set; }
    public DbSet<Telnet> Telnet { get; set; }
    public DbSet<HostGroup> HostGroup { get; set; }
    public DbSet<HostModel> HostModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
