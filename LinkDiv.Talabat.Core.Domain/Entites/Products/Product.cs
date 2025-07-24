using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Domain.Comman;

namespace LinkDev.Talabat.Core.Domain.Entites.Products
{
    public class Product : BaseEntity<int>
    {
        public required  string Name { get; set; }
        public required  string Description { get; set; }
        public  string? PictureUrl { get; set; }
        public  decimal Price { get; set; }
        public int? BrandId { get; set; }  //Foreign key for ProductBrand 
        public ProductBrand? Brand { get; set; }
        public int? CategoryId { get; set; } // Foreign key for ProductCategory

        public ProductCategory? Category { get; set; }
    }
}
