using System.Text.Json;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Entites.Products;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
    internal class StoreContextInitializer(StoreContext dbContext) : IStoreContextInitializer
    {
       
        public async Task InitializeAsync()
        {
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                // Apply any pending migrations to the database
                await dbContext.Database.MigrateAsync();
            }
        }

        public async Task SeedAsync()
        {
            if (!dbContext.Brands.Any())
            {
                var brandsData = await File.ReadAllTextAsync($"../LinkDev.Talabat.Infrastructure.Persistence/Data/Seeds/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands?.Count > 0)
                {
                    await dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                }
                await dbContext.SaveChangesAsync();

            }

            if (!dbContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync($"../LinkDev.Talabat.Infrastructure.Persistence/Data/Seeds/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (categories?.Count > 0)
                {
                    await dbContext.Set<ProductCategory>().AddRangeAsync(categories);
                }
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync($"../LinkDev.Talabat.Infrastructure.Persistence/Data/Seeds/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products?.Count > 0)
                {
                    await dbContext.Set<Product>().AddRangeAsync(products);
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
