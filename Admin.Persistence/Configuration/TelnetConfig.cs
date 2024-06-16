using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration;

internal class TelnetConfig : IEntityTypeConfiguration<Telnet>
{
    public void Configure(EntityTypeBuilder<Telnet> builder)
    {
        builder.HasKey(x => x.Id);

    }
}
