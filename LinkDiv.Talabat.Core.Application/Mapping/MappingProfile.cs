using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Core.Domain.Entites.Products;

namespace LinkDev.Talabat.Core.Application.Mapping
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(src => src.Brand!.Name));
            CreateMap<Product, ProductDto>()
            .ForMember(d => d.Category, O => O.MapFrom(src => src.Category!.Name));

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();
        }
    }
}
