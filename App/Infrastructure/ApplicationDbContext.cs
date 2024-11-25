using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Product;

namespace WebApplication1.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 1500.00m, IsAvailable = true },
            new Product { Id = 2, Name = "Phone", Price = 900.00m, IsAvailable = true },
            new Product { Id = 3, Name = "Headphones", Price = 45.00m, IsAvailable = false },
            new Product { Id = 4, Name = "Mouse", Price = 25.00m, IsAvailable = true },
            new Product { Id = 5, Name = "Monitor", Price = 200.00m, IsAvailable = true },
            new Product { Id = 6, Name = "Keyboard", Price = 80.00m, IsAvailable = true }
        );
    }
}