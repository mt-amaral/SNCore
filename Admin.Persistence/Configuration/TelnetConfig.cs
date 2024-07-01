﻿using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class TelnetConfig : BaseEntityConfig<Telnet>
{
    public override void Configure(EntityTypeBuilder<Telnet> builder)
    {
        builder.Property(x => x.User).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Port).IsRequired();

        builder.HasOne(x => x.Hardware)
            .WithOne(x => x.Telnet)
            .HasForeignKey<Telnet>(x => x.HardwareId);
    }
}
