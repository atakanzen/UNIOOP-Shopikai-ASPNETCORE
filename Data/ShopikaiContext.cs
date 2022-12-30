using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace Shopikai.Data
{
  public class ShopikaiContext : DbContext
  {
    public ShopikaiContext(DbContextOptions<ShopikaiContext> options)
        : base(options)
    {
    }

    public DbSet<Catalogue> Catalogues { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<Receipt> Receipts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Catalogue>().ToTable("Catalogue");
      modelBuilder.Entity<Category>().ToTable("Category");
      modelBuilder.Entity<Product>().ToTable("Product");
      modelBuilder.Entity<Order>().ToTable("Order");
      modelBuilder.Entity<Receipt>().ToTable("Receipt");
    }

  }
}
