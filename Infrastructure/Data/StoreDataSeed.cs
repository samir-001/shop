using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreDataSeed
{
   
    public static async Task seedProducts( ShopDbContext context)
    {
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Products>>(productsData);

            if (products == null) { return; }

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            await context.SaveChangesAsync();
        }
    }
}
