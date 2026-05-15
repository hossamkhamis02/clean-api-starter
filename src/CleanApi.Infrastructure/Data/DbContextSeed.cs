using CleanApi.Domain.Entities;
using CleanApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanApi.Infrastructure.Data;

public static class DbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Categories.AnyAsync())
            return;

        var electronics = new Category { Id = Guid.NewGuid(), Name = "Electronics", Description = "Electronic devices and accessories" };
        var clothing = new Category { Id = Guid.NewGuid(), Name = "Clothing", Description = "Apparel and fashion items" };
        var homeGarden = new Category { Id = Guid.NewGuid(), Name = "Home & Garden", Description = "Home improvement and garden supplies" };

        await context.Categories.AddRangeAsync(electronics, clothing, homeGarden);
        await context.SaveChangesAsync();

        var products = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Name = "Wireless Headphones", SKU = "ELEC-001", Price = 79.99m, CategoryId = electronics.Id },
            new() { Id = Guid.NewGuid(), Name = "USB-C Hub", SKU = "ELEC-002", Price = 34.99m, CategoryId = electronics.Id },
            new() { Id = Guid.NewGuid(), Name = "Bluetooth Speaker", SKU = "ELEC-003", Price = 49.99m, CategoryId = electronics.Id },
            new() { Id = Guid.NewGuid(), Name = "Wireless Charger", SKU = "ELEC-004", Price = 24.99m, CategoryId = electronics.Id },
            new() { Id = Guid.NewGuid(), Name = "Cotton T-Shirt", SKU = "CLTH-001", Price = 19.99m, CategoryId = clothing.Id },
            new() { Id = Guid.NewGuid(), Name = "Denim Jeans", SKU = "CLTH-002", Price = 59.99m, CategoryId = clothing.Id },
            new() { Id = Guid.NewGuid(), Name = "Running Shoes", SKU = "CLTH-003", Price = 89.99m, CategoryId = clothing.Id },
            new() { Id = Guid.NewGuid(), Name = "Garden Hose 50ft", SKU = "HOME-001", Price = 29.99m, CategoryId = homeGarden.Id },
            new() { Id = Guid.NewGuid(), Name = "LED Desk Lamp", SKU = "HOME-002", Price = 39.99m, CategoryId = homeGarden.Id },
            new() { Id = Guid.NewGuid(), Name = "Plant Pot Set", SKU = "HOME-003", Price = 15.99m, CategoryId = homeGarden.Id },
        };

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();
    }
}
