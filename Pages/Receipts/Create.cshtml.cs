using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesProduct.Data;
using ShopApp.Models;

namespace ShopApp.Pages.Receipts
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesReceiptContext _context;

        public CreateModel(RazorPagesProduct.Data.RazorPagesReceiptContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Receipt Receipt { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Receipt == null || Receipt == null)
            {
                return Page();
            }

            _context.Receipt.Add(Receipt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
