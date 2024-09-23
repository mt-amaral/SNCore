using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class ItemConfig : BaseEntityConfig<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ItemName).HasMaxLength(150).IsRequired();

        builder.HasOne(x => x.HostModel)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.ModelId);

        builder.HasOne(x => x.OidList)
            .WithOne(x => x.Item)
            .HasForeignKey<Item>(x => x.OidId);
    }
}