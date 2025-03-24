using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class RunTimeConfig : IEntityTypeConfiguration<RunTime>
{
    public void Configure(EntityTypeBuilder<RunTime> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(x => x.Type).HasConversion<byte>().IsRequired().HasColumnOrder(1);
        builder.Property(x => x.Active).HasColumnOrder(2);
        
        builder.HasOne(x => x.CronExpression)
            .WithMany(x => x.RunTime)
            .HasForeignKey(x => x.CronExpressionId);
        
        builder.HasOne(x => x.Item)
            .WithMany(x => x.RunTimes)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.NoAction);
        
        
        builder.HasOne(x => x.Host)
            .WithMany(x => x.RunTimes)
            .HasForeignKey(x => x.HostId);
        
        builder.HasOne(x => x.HostModel)
            .WithMany(x => x.RunTimes)
            .HasForeignKey(x => x.ModelId);
    }
}