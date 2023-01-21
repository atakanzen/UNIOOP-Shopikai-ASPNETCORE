using Shopikai.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShopApp.Pages.Orders
{
  public class OrderPageModel : PageModel
  {
    [Required]
    public MultiSelectList ProductsSL { get; set; }

    public void PopulateProductsSL(ShopikaiContext _context, IEnumerable<Product> selectedProducts = null)
    {
      var productsQuery = from p in _context.Products
                          select p;

      ProductsSL = new MultiSelectList(productsQuery.AsNoTracking(), nameof(Product.Id), nameof(Product.Title), selectedProducts);
    }
  }
}