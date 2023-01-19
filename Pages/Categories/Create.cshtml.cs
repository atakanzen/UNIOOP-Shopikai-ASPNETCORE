using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Categories
{
  public class CreateModel : CatalogueTitlePageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public CreateModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      PopulateCatalogueDropdownList(_context);
      return Page();
    }

    [BindProperty]
    public Category Category { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {

      var emptyCategory = new Category();

      if (await TryUpdateModelAsync<Category>(
        emptyCategory,
        "Category",
        v => v.Id,
        v => v.CatalogueId,
        v => v.Title))
      {
        _context.Categories.Add(emptyCategory);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
      }

      // Select CatalogueId if TryUpdateModelAsync fails.
      PopulateCatalogueDropdownList(_context, emptyCategory.CatalogueId);
      return Page();
    }
  }
}
