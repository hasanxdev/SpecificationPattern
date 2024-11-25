using WebApplication1.Patterns;

namespace WebApplication1.Domain.Product.Spesifications;

public class ProductSpecifications
{
    public static ISpecification<Product> IsAvailable()
    {
        return new BaseSpecification<Product>(p => p.IsAvailable);
    }

    public static ISpecification<Product> PriceGreaterThan(decimal price)
    {
        return new BaseSpecification<Product>(p => p.Price > price);
    }

    public static ISpecification<Product> PriceLessThan(decimal price)
    {
        return new BaseSpecification<Product>(p => p.Price < price);
    }
}