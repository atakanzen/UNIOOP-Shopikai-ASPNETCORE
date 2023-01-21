using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models;
using System.ComponentModel.DataAnnotations;
using Shopikai.Data;

namespace ShopApp.Pages.Orders
{
  public class CreateModel : OrderPageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public CreateModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      PopulateProductsSL(_context);
      return Page();
    }

    [BindProperty]
    public Order Order { get; set; } = default!;

    [BindProperty]
    public int[] SelectedProductIds { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (SelectedProductIds.Length == 0)
      {
        PopulateProductsSL(_context);
        return Page();
      }

      var emptyOrder = new Order();

      if (await TryUpdateModelAsync<Order>(emptyOrder, "order", o => o.ShipmentPostalCode, o => o.ShipmentAddressLabel, o => o.ShipmentAddress))
      {
        _context.Orders.Add(Order);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
      }

      PopulateProductsSL(_context);
      return Page();
    }
  }
}
