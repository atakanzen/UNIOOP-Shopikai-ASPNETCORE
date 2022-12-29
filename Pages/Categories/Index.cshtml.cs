using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;
using ShopApp.Models;

namespace ShopApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesCategoryContext _context;

        public IndexModel(RazorPagesProduct.Data.RazorPagesCategoryContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
