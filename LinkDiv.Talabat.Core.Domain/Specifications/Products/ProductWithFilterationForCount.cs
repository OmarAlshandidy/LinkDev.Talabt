using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Domain.Entites.Products;

namespace LinkDev.Talabat.Core.Domain.Specifications.Products
{
    public class ProductWithFilterationForCount : BaseSpecifications<Product, int>
    {
        public ProductWithFilterationForCount(ProductSpecParams specParams) :
            base(
                P => (!specParams.BrandId.HasValue || P.BrandId == specParams.BrandId)
                && (!specParams.CategoryId.HasValue || P.CategoryId == specParams.CategoryId)
                && (string.IsNullOrWhiteSpace(specParams.Search) || P.Name.ToLower().Contains(specParams.Search.ToLower()))
                )
        {
        }
    }
}
