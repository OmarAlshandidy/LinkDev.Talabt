using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.APIs.Controllers.Base;
using LinkDev.Talabat.Core.Application.Abstraction.Common;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs.Controller.Controllers.Products
{
    public class ProductsController(IServiceManager serviceManager):BaseApiController
    {
        [HttpGet] // Get /api/products
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecParams specParams)
         {
            var products = await serviceManager.ProductService.GetAllProductsAsync(specParams);

            return Ok(products);
        }

        [HttpGet("{id:int}")] // Get /api/products/{id}

        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);
            if (product is null)
             return NotFound();
                
            return Ok(product);

            }

        [HttpGet("brands")] // Get /api/products/brands
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetBrandAsync();
            return Ok(brands);
        }
        [HttpGet("categories")] // Get /api/products/categories
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await serviceManager.ProductService.GetCategoryAsync();
            return Ok(categories);
        }

    }
}
