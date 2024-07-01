﻿using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class TelnetConfig : IEntityTypeConfiguration<Telnet>
{
    public void Configure(EntityTypeBuilder<Telnet> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.User).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Port).IsRequired();

    }
}
