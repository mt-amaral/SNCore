using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class SnmpConfig : IEntityTypeConfiguration<Snmp>
{
    public void Configure(EntityTypeBuilder<Snmp> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Version).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Community).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Port).IsRequired();


    }
}
