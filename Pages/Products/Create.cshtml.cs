using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Products
{
  public class CreateModel : ProductPageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public CreateModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      PopulateCategoryTitleSL(_context);
      return Page();
    }

    [BindProperty]
    public Product Product { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      var emptyProduct = new Product();

      if (await TryUpdateModelAsync<Product>(emptyProduct, "product", p => p.Title, p => p.CategoryId, p => p.ReleaseDate, p => p.Price, p => p.Stock, p => p.HasDiscount))
      {
        _context.Products.Add(Product);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
      }

      PopulateCategoryTitleSL(_context, emptyProduct.CategoryId);
      return Page();
    }
  }
}
