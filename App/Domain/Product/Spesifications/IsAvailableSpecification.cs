using System.Linq.Expressions;
using WebApplication1.Patterns;

namespace WebApplication1.Domain.Product.Spesifications;

public class IsAvailableSpecification : CompositeSpecification<Product>
{
    public override bool IsSatisfiedBy(Product entity)
    {
        return entity.IsAvailable;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return product => product.IsAvailable;
    }
}