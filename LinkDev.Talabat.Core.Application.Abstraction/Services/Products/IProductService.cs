using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductAsync(int id);

        Task<IEnumerable<BrandDto>> GetBrandAsync();

        Task<IEnumerable<CategoryDto>> GetCategoryAsync();
    }
}
