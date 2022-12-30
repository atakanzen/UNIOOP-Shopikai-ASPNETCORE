using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Receipts
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
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Receipt Receipt { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Receipts == null || Receipt == null)
            {
                return Page();
            }

            _context.Receipts.Add(Receipt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
