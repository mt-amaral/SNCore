using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HardwareConfig : BaseEntityConfig<Hardware>
{
    public override void Configure(EntityTypeBuilder<Hardware> builder)
    {
        base.Configure(builder); // Chama a configuração base

        builder.Property(x => x.Description).HasMaxLength(50).IsRequired().HasColumnOrder(4);
        builder.Property(x => x.Model).HasMaxLength(50).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Ipv4).HasMaxLength(15).IsRequired().HasColumnOrder(6);

        builder.HasOne(x => x.Snmp)
            .WithOne(x => x.Hardware)
            .HasForeignKey<Snmp>(x => x.HardwareId);

        builder.HasOne(x => x.Telnet)
            .WithOne(x => x.Hardware)
            .HasForeignKey<Telnet>(x => x.HardwareId);
    }
}
