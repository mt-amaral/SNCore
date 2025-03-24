using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.UniqueId).IsRequired().HasColumnType("uniqueidentifier").HasColumnOrder(1);
        builder.Property(x => x.Name).IsUnicode().IsRequired().HasMaxLength(255).HasColumnOrder(2);
        
    }
}