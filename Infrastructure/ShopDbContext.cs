using System;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
public class ShopDbContext(DbContextOptions options) : DbContext(options)
{
 
    public DbSet<Products> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
    }
}
