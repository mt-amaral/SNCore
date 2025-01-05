using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HostModelConfig : BaseEntityConfig<HostModel>
{
    public override void Configure(EntityTypeBuilder<HostModel> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.ModelName).HasMaxLength(50).IsRequired();

        builder.HasMany(x => x.Hosts)
               .WithOne(x => x.HostModel)
               .HasForeignKey(x => x.ModelId);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.HostModel)
               .HasForeignKey(x => x.ModelId);
    }
}