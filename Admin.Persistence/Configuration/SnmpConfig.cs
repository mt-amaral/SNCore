using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class SnmpConfig : BaseEntityConfig<Snmp>
{
    public override void Configure(EntityTypeBuilder<Snmp> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.SnmpVersion).HasConversion<short>().IsRequired();
        builder.Property(x => x.Community).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Port).IsRequired();

        builder.HasOne(x => x.Hardware)
            .WithOne(x => x.Snmp)
            .HasForeignKey<Snmp>(x => x.HardwareId);
    }
}
