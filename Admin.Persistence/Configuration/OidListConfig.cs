using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class OidListConfig : IEntityTypeConfiguration<OidList>
{
    public void Configure(EntityTypeBuilder<OidList> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.Oid).HasMaxLength(250).IsRequired();

        builder.HasOne(x => x.Item)
               .WithOne(x => x.OidList)
               .HasForeignKey<Item>(x => x.OidId);
    }
}