using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HostGroupConfig : BaseEntityConfig<HostGroup>
{
    public override void Configure(EntityTypeBuilder<HostGroup> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.GroupName).HasMaxLength(50).IsRequired();

        builder.HasMany(x => x.Hosts)
               .WithOne(x => x.HostGroup)
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}