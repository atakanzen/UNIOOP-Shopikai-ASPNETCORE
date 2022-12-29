using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace RazorPagesProduct.Data
{
    public class RazorPagesCategoryContext : DbContext
    {
        public RazorPagesCategoryContext (DbContextOptions<RazorPagesCategoryContext> options)
            : base(options)
        {
        }

        public DbSet<ShopApp.Models.Category> Category { get; set; } = default!;
    }
}
