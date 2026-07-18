using Microsoft.EntityFrameworkCore;
using RetailStoreQuery;

using var context = new AppDbContext();

// 1. Retrieve all products
var products = await context.Products.ToListAsync();

Console.WriteLine("All Products:");
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - ₹{p.Price}");
}

// 2. Find product by ID
var product = await context.Products.FindAsync(1);

Console.WriteLine($"\nFound: {product?.Name}");

// 3. Find first product with Price > 5000
var expensive = await context.Products
    .FirstOrDefaultAsync(p => p.Price > 5000);

Console.WriteLine($"Expensive: {expensive?.Name}");