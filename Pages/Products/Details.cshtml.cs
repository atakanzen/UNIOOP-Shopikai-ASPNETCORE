using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Products
{
  public class DetailsModel : PageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public DetailsModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Products == null)
      {
        return NotFound();
      }

      var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);
      if (product == null)
      {
        return NotFound();
      }
      else
      {
        Product = product;
      }
      return Page();
    }
  }
}
