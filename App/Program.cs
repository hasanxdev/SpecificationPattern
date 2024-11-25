using WebApplication1.Domain.Product.Spesifications;
using WebApplication1.Infrastructure;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await using var scope = app.Services.CreateAsyncScope();
var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

var products = dbContext.Products.Where(product =>
        product.IsAvailable &&
        product.Price > 50 &&
        product.Price < 100)
    .ToList();

foreach (var product in products)
{
    Console.WriteLine($"Product : {product.Name}, Price: {product.Price}");
}

var specification = ProductSpecifications.IsAvailable()
    .And(ProductSpecifications.PriceGreaterThan(50))
    .And(ProductSpecifications.PriceLessThan(100));

var productsWithSpecification = await productService.GetProductsAsync(specification);

foreach (var product in productsWithSpecification)
{
    Console.WriteLine($"Product with specification : {product.Name}, Price: {product.Price}");
}

app.Run();