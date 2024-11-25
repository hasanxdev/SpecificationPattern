using System.Linq.Expressions;

namespace WebApplication1.Patterns;

public class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; private set; }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public ISpecification<T> And(ISpecification<T> other)
    {
        return new BaseSpecification<T>(
            Criteria.AndAlso(other.Criteria)
        );
    }

    public ISpecification<T> Or(ISpecification<T> other)
    {
        return new BaseSpecification<T>(
            Criteria.OrElse(other.Criteria)
        );
    }

    public ISpecification<T> Not()
    {
        return new BaseSpecification<T>(
            Criteria.Not()
        );
    }
}

public static class SpecificationExtensions
{
    public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var combined = Expression.AndAlso(
            Expression.Invoke(left, parameter),
            Expression.Invoke(right, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }

    public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var combined = Expression.OrElse(
            Expression.Invoke(left, parameter),
            Expression.Invoke(right, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }

    public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
    {
        var parameter = Expression.Parameter(typeof(T));
        var combined = Expression.Not(Expression.Invoke(expression, parameter));

        return Expression.Lambda<Func<T, bool>>(combined, parameter);
    }
}