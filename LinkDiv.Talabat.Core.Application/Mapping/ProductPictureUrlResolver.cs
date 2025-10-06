using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Domain.Entites.Products;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Core.Application.Mapping
{
    internal class ProductPictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string?>
    {
        public string? Resolve(Product source, ProductDto destination, string? destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["Urls:ApiBaseUrl"]}/{source.PictureUrl}";

            return string.Empty;
        }
    }
}
