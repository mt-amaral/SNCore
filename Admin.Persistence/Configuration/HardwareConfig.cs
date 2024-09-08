using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HardwareConfig : BaseEntityConfig<Hardware>
{
    public override void Configure(EntityTypeBuilder<Hardware> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Model).HasConversion<short>().IsRequired();
        builder.Property(x => x.Ipv4).HasMaxLength(15).IsRequired();

        builder.HasOne(x => x.Snmp)
            .WithOne(x => x.Hardware)
            .HasForeignKey<Snmp>(x => x.HardwareId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Telnet)
            .WithOne(x => x.Hardware)
            .HasForeignKey<Telnet>(x => x.HardwareId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
