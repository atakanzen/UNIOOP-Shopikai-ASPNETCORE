
using Microsoft.EntityFrameworkCore;
using Shopikai.Data;

namespace ShopApp.Models;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new ShopikaiContext(serviceProvider.GetRequiredService<DbContextOptions<ShopikaiContext>>()))
    {
      if (context == null || context.Products == null)
      {
        throw new ArgumentNullException("Null RazorPagesProductContext");
      }

      if (context.Products.Any())
      {
        return;
      }


    }
  }
}