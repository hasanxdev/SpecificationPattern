using System.Linq.Expressions;

namespace WebApplication1.Patterns;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }

    ISpecification<T> And(ISpecification<T> other);
    ISpecification<T> Or(ISpecification<T> other);
    ISpecification<T> Not();
}