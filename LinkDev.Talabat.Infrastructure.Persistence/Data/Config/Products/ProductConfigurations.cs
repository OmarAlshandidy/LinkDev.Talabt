using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Domain.Entites.Products;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Products
{
    internal class ProductConfigurations : BaseEntityConfigurations<Product,int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
             
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(9,2)");

            builder.HasOne(P => P.Brand)
                .WithMany()
                .HasForeignKey(P => P.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(P => P.Category)
              .WithMany()
              .HasForeignKey(P => P.CategoryId)
              .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
