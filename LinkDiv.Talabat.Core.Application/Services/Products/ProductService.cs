using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Entites.Products;

namespace LinkDev.Talabat.Core.Application.Services.Products
{
    internal class ProductService(IUnitOfWork unitOfWork , IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);
            return productDtos;

        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
        public async Task<IEnumerable<BrandDto>> GetBrandAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandDtos = mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandDtos;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();
            var categoryDtos = mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryDtos;
        }

    }
}
