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
        builder.Property(x => x.Minute).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Hour).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Day).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Month).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Weesday).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Expression).HasMaxLength(500).IsRequired();

        builder.HasOne(x => x.Item)
               .WithOne(x => x.CronExpression)
               .HasForeignKey<CronExpression>(x => x.ItemId);

        builder.HasOne(x => x.Host)
            .WithMany(x => x.CronExpression)
            .HasForeignKey(x => x.HostId);
        
    }
}