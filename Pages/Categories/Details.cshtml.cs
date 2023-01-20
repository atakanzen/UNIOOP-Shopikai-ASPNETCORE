using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Categories
{
  public class DetailsModel : PageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public DetailsModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public Category Category { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Categories == null)
      {
        return NotFound();
      }

      var category = await _context.Categories.Include(c => c.Catalogue).FirstOrDefaultAsync(m => m.Id == id);
      if (category == null)
      {
        return NotFound();
      }
      else
      {
        Category = category;
      }
      return Page();
    }
  }
}
