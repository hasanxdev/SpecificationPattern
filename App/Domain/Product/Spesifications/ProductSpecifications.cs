using WebApplication1.Patterns;

namespace WebApplication1.Domain.Product.Spesifications;

public class ProductSpecifications
{
    public static ISpecification<Product> IsAvailable()
    {
        return new IsAvailableSpecification();
    }

    public static ISpecification<Product> PriceGreaterThan(decimal price)
    {
        return new PriceGreaterThanSpecification(price);
    }

    public static ISpecification<Product> PriceLessThan(decimal price)
    {
        return new PriceLessThanSpecification(price);
    }
}