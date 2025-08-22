

namespace LinkDev.Talabat.Core.Domain.Entites.Products
{
    public class Product : BaseAuditableEntity<int>
    {
        public required  string Name { get; set; }
        public required  string Description { get; set; }
        public  string? PictureUrl { get; set; }
        public  decimal Price { get; set; }
        public int? BrandId { get; set; }  //Foreign key for ProductBrand 
        public virtual ProductBrand? Brand { get; set; }
        public int? CategoryId { get; set; } // Foreign key for ProductCategory
        public virtual ProductCategory? Category { get; set; }
    }
}
