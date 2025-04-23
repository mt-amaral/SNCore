using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class ItemConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.ItemName).HasMaxLength(150).IsRequired();

        builder.HasOne(x => x.HostModel)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.ModelId);

        builder.HasOne(x => x.OidList)
            .WithOne(x => x.Item)
            .HasForeignKey<Item>(x => x.OidId);

        builder.HasMany(x => x.RunTimes)
            .WithOne(x => x.Item)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}