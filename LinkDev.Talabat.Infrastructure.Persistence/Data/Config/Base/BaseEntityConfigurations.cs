using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Domain.Comman;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base
{
    public class BaseEntityConfigurations<TEntity, Tkey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<Tkey> where Tkey : IEquatable<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id)
                        .ValueGeneratedOnAdd();
            builder.Property(E => E.CreatedBy)
                .IsRequired();

            builder.Property(E => E.LastModifiedBy)
                .IsRequired();

            builder.Property(E => E.CreatedOn)
                .IsRequired()
                /*.HasDefaultValueSql("GETUTCDATE()")*/;

            builder.Property(E => E.LastModifiedOn)
                .IsRequired();
        }
    }
}
