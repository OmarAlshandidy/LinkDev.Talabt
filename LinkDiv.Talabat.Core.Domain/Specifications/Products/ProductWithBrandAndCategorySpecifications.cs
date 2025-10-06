using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Domain.Entites.Products;

namespace LinkDev.Talabat.Core.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications:BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams specParams) :
            base(
                P=>(!specParams.BrandId.HasValue||P.BrandId == specParams.BrandId)
                && (!specParams.CategoryId.HasValue || P.CategoryId == specParams.CategoryId)
                && (string.IsNullOrWhiteSpace(specParams.Search) || P.Name.ToLower().Contains(specParams.Search.ToLower()))
                )
        {
            AddInclude();
             switch (specParams.Sort)
                {
                    case "nameDesc":
                        AddOrderByDesc(p => p.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);


        } 
        public ProductWithBrandAndCategorySpecifications(int id) : base(id)
        {
            AddInclude();
        }

        private void AddInclude()
        {
            Includes.Add(P => P.Brand!);
            Includes.Add(P => P.Category!);
        }
    }
}
