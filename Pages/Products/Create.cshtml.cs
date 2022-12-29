using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;
using ShopApp.Models;

namespace ShopApp.Pages.Products
{
  public class CreateModel : PageModel
  {
    private readonly RazorPagesProduct.Data.RazorPagesProductContext _context;

    public CreateModel(RazorPagesProduct.Data.RazorPagesProductContext context)
    {
      _context = context;
    }

    public SelectList? Categories { get; set; }

    public IActionResult OnGet()
    {
      IQueryable<string> categoryQuery = from p in _context.Product
                                         orderby p.Category
                                         select p.Category;

      Categories = new SelectList(categoryQuery.Distinct().ToList());

      return Page();
    }

    [BindProperty]
    public Product Product { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.Product == null || Product == null)
      {
        return Page();
      }

      _context.Product.Add(Product);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
