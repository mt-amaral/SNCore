using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HostModelConfig : IEntityTypeConfiguration<HostModel>
{
    public void Configure(EntityTypeBuilder<HostModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.ModelName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.SrcIcon).HasMaxLength(500);

        builder.HasMany(x => x.Hosts)
               .WithOne(x => x.HostModel)
               .HasForeignKey(x => x.ModelId);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.HostModel)
               .HasForeignKey(x => x.ModelId);

        builder.HasMany(x => x.RunTimes)
            .WithOne(x => x.HostModel)
            .HasForeignKey(x => x.ModelId);

    }
}