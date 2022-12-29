using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;
using ShopApp.Models;

namespace ShopApp.Pages.Receipts
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesReceiptContext _context;

        public DeleteModel(RazorPagesProduct.Data.RazorPagesReceiptContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Receipt Receipt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Receipt == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt.FirstOrDefaultAsync(m => m.Id == id);

            if (receipt == null)
            {
                return NotFound();
            }
            else 
            {
                Receipt = receipt;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Receipt == null)
            {
                return NotFound();
            }
            var receipt = await _context.Receipt.FindAsync(id);

            if (receipt != null)
            {
                Receipt = receipt;
                _context.Receipt.Remove(Receipt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
