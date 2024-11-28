﻿using System.Linq.Expressions;
using WebApplication1.Patterns;

namespace WebApplication1.Domain.Product.Spesifications;

public class PriceLessThanSpecification : CompositeSpecification<Product>
{
    private readonly decimal _price;

    public PriceLessThanSpecification(decimal price)
    {
        _price = price;
    }

    public override bool IsSatisfiedBy(Product entity)
    {
        return entity.Price < _price;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return product => product.Price < _price;
    }
}