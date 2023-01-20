
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Products
{
  public class ProductPageModel : PageModel
  {
    public SelectList CategoryTitleSL { get; set; }

    public void PopulateCategoryTitleSL(ShopikaiContext _context, object selectedCategory = null)
    {
      var categoriesQuery = from c in _context.Categories
                            orderby c.Title
                            select c;

      CategoryTitleSL = new SelectList(categoriesQuery.AsNoTracking(), nameof(Category.Id), nameof(Category.Title), selectedCategory);
    }
  }
}
