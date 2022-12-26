
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;

namespace ShopApp.Models;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new RazorPagesProductContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesProductContext>>()))
    {
      if (context == null || context.Product == null)
      {
        throw new ArgumentNullException("Null RazorPagesProductContext");
      }

      if (context.Product.Any())
      {
        return;
      }

      context.Product.AddRange(
        new Product
        {
          Title = "Basic Shirt",
          Category = "Tops",
          Price = 24.99M,
          Stock = 5000,
          ReleasedDate = DateTime.Parse("2022-1-15")
        },
        new Product
        {
          Title = "Striped Shirt",
          Category = "Tops",
          Price = 27.99M,
          Stock = 3500,
          ReleasedDate = DateTime.Parse("2022-1-15")
        },
        new Product
        {
          Title = "Premium Overcoat",
          Category = "Jackets & Coats",
          Price = 159.99M,
          Stock = 1500,
          ReleasedDate = DateTime.Parse("2022-12-26")
        },
        new Product
        {
          Title = "Slate Shoes",
          Category = "Shoes",
          Price = 2950M,
          Stock = 25,
          ReleasedDate = DateTime.Parse("2022-3-3")
        },
        new Product
        {
          Title = "Elite Sneakers",
          Category = "Shoes",
          Price = 5950M,
          Stock = 5,
          ReleasedDate = DateTime.Parse("2022-3-3")
        }
      );

      context.SaveChanges();
    }
  }
}