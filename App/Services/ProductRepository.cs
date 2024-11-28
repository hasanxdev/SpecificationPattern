using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Product;
using WebApplication1.Infrastructure;
using WebApplication1.Patterns;

namespace WebApplication1.Services;

public class ProductRepository(ApplicationDbContext context)
{
    public async Task<List<Product>> GetAvailableProductInRangeAsync(decimal startPrice, decimal endPrice)
    {
        return await context.Products.Where(product =>
                product.IsAvailable &&
                product.Price > startPrice &&
                product.Price < endPrice)
            .ToListAsync();
    }
    
    public async Task<List<Product>> GetProductInRangeAsync(decimal startPrice, decimal endPrice)
    {
        return await context.Products.Where(product =>
                product.Price > startPrice &&
                product.Price < endPrice)
            .ToListAsync();
    }
}