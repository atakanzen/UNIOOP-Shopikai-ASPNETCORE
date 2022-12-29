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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesReceiptContext _context;

        public IndexModel(RazorPagesProduct.Data.RazorPagesReceiptContext context)
        {
            _context = context;
        }

        public IList<Receipt> Receipt { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Receipt != null)
            {
                Receipt = await _context.Receipt.ToListAsync();
            }
        }
    }
}
