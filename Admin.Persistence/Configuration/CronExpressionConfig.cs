using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class CronExpressionConfig : IEntityTypeConfiguration<CronExpression>
{
    public void Configure(EntityTypeBuilder<CronExpression> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.Second).HasMaxLength(50).IsRequired().HasColumnOrder(1);
        builder.Property(x => x.Minute).HasMaxLength(50).IsRequired().HasColumnOrder(2);
        builder.Property(x => x.Hour).HasMaxLength(50).IsRequired().HasColumnOrder(3);
        builder.Property(x => x.Day).HasMaxLength(50).IsRequired().HasColumnOrder(4);
        builder.Property(x => x.Month).HasMaxLength(50).IsRequired().HasColumnOrder(5);
        builder.Property(x => x.Weesday).HasMaxLength(50).IsRequired().HasColumnOrder(6);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired().HasColumnOrder(7);

        builder.HasOne(x => x.Item)
               .WithMany(x => x.CronExpression)
               .HasForeignKey(x => x.ItemId);

        builder.HasOne(x => x.Host)
            .WithMany(x => x.CronExpression)
            .HasForeignKey(x => x.HostId);

    }
}