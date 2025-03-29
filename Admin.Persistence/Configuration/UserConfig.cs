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
        builder.Property(x => x.Iterations).IsRequired().HasDefaultValue(210_000).HasColumnOrder(3);
        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnType("varbinary(64)").HasColumnOrder(4);; // SHA-512 = 64 bytes
              
        builder.Property(x => x.PasswordSalt)
            .IsRequired()
            .HasColumnType("varbinary(32)").HasColumnOrder(5); // Salt de 256 bits
        
    }
}