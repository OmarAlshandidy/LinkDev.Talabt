using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Common;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entites.Products;
using LinkDev.Talabat.Core.Domain.Specifications.Products;
namespace LinkDev.Talabat.Core.Application.Services.Products
{
    internal class ProductService(IUnitOfWork unitOfWork , IMapper mapper) : IProductService
    {
        public async Task<Pagination<ProductDto>> GetAllProductsAsync(ProductSpecParams specParams)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(specParams); 
            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(spec);
            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);
            var countSpec = new ProductWithFilterationForCount(specParams);
            var Count = await unitOfWork.GetRepository<Product,int>().GetCountAsync(countSpec);
            return  new Pagination<ProductDto>(specParams.PageIndex, specParams.PageSize , Count) {Data= productDtos };

        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
              var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetWithSpecAsync(spec);
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
