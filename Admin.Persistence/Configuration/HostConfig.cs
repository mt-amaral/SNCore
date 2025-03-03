using Admin.Domain.Entities;
using Admin.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HostConfig : BaseEntityConfig<Host>
{
    public override void Configure(EntityTypeBuilder<Host> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(50);
        builder.Property(x => x.Ipv4).HasMaxLength(15).IsRequired();

        builder.HasOne(x => x.Snmp)
            .WithOne(x => x.Host)
            .HasForeignKey<Snmp>(x => x.HostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Telnet)
            .WithOne(x => x.Host)
            .HasForeignKey<Telnet>(x => x.HostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.CronExpression)
            .WithOne(x => x.Host)
            .HasForeignKey(x => x.HostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.HostGroup)
               .WithMany(x => x.Hosts)
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.HostModel)
               .WithMany(x => x.Hosts)
               .HasForeignKey(x => x.ModelId);
    }
}
