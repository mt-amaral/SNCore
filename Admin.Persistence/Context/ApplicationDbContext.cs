using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Snmp> Snmp { get; set; }
        public DbSet<Telnet> Telnet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
