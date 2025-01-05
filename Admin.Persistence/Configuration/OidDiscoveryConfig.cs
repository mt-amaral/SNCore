using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class OidDicoveryConfig : IEntityTypeConfiguration<OidDiscovery>
{
    public void Configure(EntityTypeBuilder<OidDiscovery> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);

        builder.Property(x => x.OidDiscoveryIndex).HasMaxLength(500).IsRequired();

        builder.HasOne(x => x.DiscoveryOrigin)
            .WithOne(x => x.OidDiscovery)
            .HasForeignKey<OidDiscovery>(x => x.DiscoveryOriginId);
    }
}