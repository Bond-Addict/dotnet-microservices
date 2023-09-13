using Microsoft.EntityFrameworkCore;

namespace MyMicroservice.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(
                new Product{Id = 1, Name = "Laptop", Price = 999.99M, Description = "High-end gaming laptop"},
                new Product{Id = 2, Name = "Mouse", Price = 49.99M, Description = "Wireless mouse"},
                new Product{Id = 3, Name = "Keyboard", Price = 79.99M, Description = "Mechanical keyboard"}
            );
        }
    }
}