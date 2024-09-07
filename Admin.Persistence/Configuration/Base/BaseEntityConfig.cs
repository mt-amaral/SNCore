using Admin.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Persistence.Configuration.Base
{
    public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(0);
            builder.Property(x => x.CreationDate).HasColumnOrder(1);
            builder.Property(x => x.UpdateDate).HasColumnOrder(2);
            builder.Property(x => x.Active).HasColumnOrder(3);
        }
    }
}
