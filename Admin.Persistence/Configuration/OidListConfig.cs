using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class OidListConfig : BaseLongEntityConfig<OidList>
{
    public override void Configure(EntityTypeBuilder<OidList> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Oid).HasMaxLength(250).IsRequired();

        builder.HasOne(x => x.Item)
               .WithOne(x => x.OidList)
               .HasForeignKey<Item>(x => x.OidId);
    }
}