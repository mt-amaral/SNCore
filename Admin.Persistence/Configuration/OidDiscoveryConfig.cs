using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class OidDicoveryConfig : BaseLongEntityConfig<OidDiscovery>
{
    public override void Configure(EntityTypeBuilder<OidDiscovery> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.OidDiscoveryIndex).HasMaxLength(500).IsRequired();
        
        builder.HasOne(x => x.DiscoveryOrigin)
            .WithOne(x => x.OidDiscovery)
            .HasForeignKey<OidDiscovery>(x => x.DiscoveryOriginId);
    }
}