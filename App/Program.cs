using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Product.Spesifications;
using WebApplication1.Infrastructure;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await using var scope = app.Services.CreateAsyncScope();
var productService = scope.ServiceProvider.GetRequiredService<ProductRepository>();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

var availableProductInRange = await productService.GetAvailableProductInRangeAsync(40, 100);
var productInRange = await productService.GetProductInRangeAsync(40, 100);

var availableProductInRangeSpec = ProductSpecifications.IsAvailable()
    .And(ProductSpecifications.PriceGreaterThan(40))
    .And(ProductSpecifications.PriceLessThan(100));

var newAvailableProductInRange = await dbContext.Products
    .Where(availableProductInRangeSpec.ToExpression())
    .ToListAsync();

var productInRangeSpec = ProductSpecifications.PriceGreaterThan(40)
    .And(ProductSpecifications.PriceLessThan(100));

var newProductInRange = await dbContext.Products
    .Where(productInRangeSpec.ToExpression())
    .ToListAsync();

app.Run();