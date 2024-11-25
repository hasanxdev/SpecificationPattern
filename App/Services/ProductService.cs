using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Product;
using WebApplication1.Infrastructure;
using WebApplication1.Patterns;

namespace WebApplication1.Services;

public class ProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync(ISpecification<Product> specification)
    {
        return await _context.Set<Product>()
            .Where(specification.Criteria)
            .ToListAsync();
    }
}