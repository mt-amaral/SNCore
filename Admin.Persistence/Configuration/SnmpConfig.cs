using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class SnmpConfig : IEntityTypeConfiguration<Snmp>
{
    public void Configure(EntityTypeBuilder<Snmp> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Version);
        builder.Property(x => x.Community).IsRequired();
        builder.Property(x => x.Port).IsRequired();


    }
}
