using LinkDev.Talabat.Core.Domain.Entites.Products;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
            // Apply all configurations from the current assembly
            // This will automatically apply all IEntityTypeConfiguration implementations in the assembly
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach( var entry in this.ChangeTracker.Entries<BaseAuditableEntity<int>>().Where(entity=>entity.State is EntityState.Added or EntityState.Modified))
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedBy = ""; // Set the created by user
                    entry.Entity.CreatedOn = DateTime.UtcNow; // Set the created on date
                }
                entry.Entity.LastModifiedBy = ""; // Set the last modified by user
                entry.Entity.LastModifiedOn = DateTime.UtcNow; // Set the last modified on date
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
