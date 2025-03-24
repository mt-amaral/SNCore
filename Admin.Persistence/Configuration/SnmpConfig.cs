using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class SnmpConfig : IEntityTypeConfiguration<Snmp>
{
    public  void Configure(EntityTypeBuilder<Snmp> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.SnmpVersion).HasConversion<byte>().IsRequired();
        builder.Property(x => x.Community).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Port).IsRequired();

        builder.HasOne(x => x.Host)
            .WithOne(x => x.Snmp)
            .HasForeignKey<Snmp>(x => x.HostId);
    }
}
