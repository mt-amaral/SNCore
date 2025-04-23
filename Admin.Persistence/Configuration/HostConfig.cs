using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class HostConfig : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);

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

        builder.HasOne(x => x.HostGroup)
           .WithMany(x => x.Hosts)
           .HasForeignKey(x => x.GroupId)
           .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.HostModel)
           .WithMany(x => x.Hosts)
           .HasForeignKey(x => x.ModelId);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Host)
            .HasForeignKey(x => x.HostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.RunTimes)
            .WithOne(x => x.Host)
            .HasForeignKey(x => x.HostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
