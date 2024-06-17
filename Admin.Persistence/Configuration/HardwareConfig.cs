using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HardwareConfig : IEntityTypeConfiguration<Hardware>
{
    public void Configure(EntityTypeBuilder<Hardware> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Model).HasMaxLength(300);
        builder.Property(x => x.Ipv4).HasMaxLength(15).IsRequired();

        builder.HasOne(x => x.Snmp)
       .WithOne(x => x.Hardware)
       .HasForeignKey<Snmp>(x => x.HardwareId);

        builder.HasOne(x => x.Telnet)
               .WithOne(x => x.Hardware)
               .HasForeignKey<Telnet>(x => x.HardwareId);
    }

}
