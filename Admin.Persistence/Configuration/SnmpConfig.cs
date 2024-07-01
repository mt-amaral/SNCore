using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class SnmpConfig : BaseEntityConfig<Snmp>
{
    public override void Configure(EntityTypeBuilder<Snmp> builder)
    {
        base.Configure(builder); // Chama a configuração base

        builder.Property(x => x.Version).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Community).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Port).IsRequired();

        builder.HasOne(x => x.Hardware)
            .WithOne(x => x.Snmp)
            .HasForeignKey<Snmp>(x => x.HardwareId);
    }
}
