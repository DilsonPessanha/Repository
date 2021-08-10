using Microsoft.EntityFrameworkCore;
using Products.Infrastructure.Model;

namespace Products.Infrastructure.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductObject> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductCrud;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
        }
    }
}
