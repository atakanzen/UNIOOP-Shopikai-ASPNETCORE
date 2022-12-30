using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Catalogues
{
  public class CreateModel : PageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public CreateModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public Catalogue Catalogue { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.Catalogues == null || Catalogue == null)
      {
        return Page();
      }

      _context.Catalogues.Add(Catalogue);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
