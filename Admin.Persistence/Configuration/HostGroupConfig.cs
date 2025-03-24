using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HostGroupConfig : IEntityTypeConfiguration<HostGroup>
{
    
    public void Configure(EntityTypeBuilder<HostGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.GroupName).HasMaxLength(50).IsRequired();

        builder.HasMany(x => x.Hosts)
               .WithOne(x => x.HostGroup)
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}