using System.Linq.Expressions;

namespace WebApplication1.Patterns;

public abstract class CompositeSpecification<T> : ISpecification<T>
{
    public abstract bool IsSatisfiedBy(T entity);

    public abstract Expression<Func<T, bool>> ToExpression();

    public ISpecification<T> And(ISpecification<T> other)
    {
        return new AndSpecification<T>(this, other);
    }

    public ISpecification<T> Or(ISpecification<T> other)
    {
        return new OrSpecification<T>(this, other);
    }

    public ISpecification<T> Not()
    {
        return new NotSpecification<T>(this);
    }
}

public class AndSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> _one;
    private readonly ISpecification<T> _other;

    public AndSpecification(ISpecification<T> one, ISpecification<T> other)
    {
        _one = one;
        _other = other;
    }

    public override bool IsSatisfiedBy(T entity)
    {
        return _one.IsSatisfiedBy(entity) && _other.IsSatisfiedBy(entity);
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var oneExpr = _one.ToExpression();
        var otherExpr = _other.ToExpression();

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(
            Expression.Invoke(oneExpr, parameter),
            Expression.Invoke(otherExpr, parameter));

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}

public class OrSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> _one;
    private readonly ISpecification<T> _other;

    public OrSpecification(ISpecification<T> one, ISpecification<T> other)
    {
        _one = one;
        _other = other;
    }

    public override bool IsSatisfiedBy(T entity)
    {
        return _one.IsSatisfiedBy(entity) || _other.IsSatisfiedBy(entity);
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var oneExpr = _one.ToExpression();
        var otherExpr = _other.ToExpression();

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.OrElse(
            Expression.Invoke(oneExpr, parameter),
            Expression.Invoke(otherExpr, parameter));

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}

public class NotSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> _wrapped;

    public NotSpecification(ISpecification<T> wrapped)
    {
        _wrapped = wrapped;
    }

    public override bool IsSatisfiedBy(T entity)
    {
        return !_wrapped.IsSatisfiedBy(entity);
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var wrappedExpr = _wrapped.ToExpression();

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.Not(
            Expression.Invoke(wrappedExpr, parameter));

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}