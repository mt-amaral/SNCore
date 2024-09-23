using Admin.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration.Base;

public abstract class BaseLongEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseLongEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(0);

    }
}
