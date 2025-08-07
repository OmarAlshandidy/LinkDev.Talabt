using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Domain.Entites.Products;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Products
{
    internal class CategoryConfigurations :BaseEntityConfigurations<ProductCategory, int>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .IsRequired();

        }
    }
}
