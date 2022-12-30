using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Catalogues
{
  public class DeleteModel : PageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public DeleteModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Catalogue Catalogue { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.Catalogues == null)
      {
        return NotFound();
      }

      var catalogue = await _context.Catalogues.FirstOrDefaultAsync(m => m.Id == id);

      if (catalogue == null)
      {
        return NotFound();
      }
      else
      {
        Catalogue = catalogue;
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null || _context.Catalogues == null)
      {
        return NotFound();
      }
      var catalogue = await _context.Catalogues.FindAsync(id);

      if (catalogue != null)
      {
        Catalogue = catalogue;
        _context.Catalogues.Remove(Catalogue);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
