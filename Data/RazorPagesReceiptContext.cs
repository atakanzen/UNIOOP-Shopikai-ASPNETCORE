using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace RazorPagesProduct.Data
{
    public class RazorPagesReceiptContext : DbContext
    {
        public RazorPagesReceiptContext (DbContextOptions<RazorPagesReceiptContext> options)
            : base(options)
        {
        }

        public DbSet<ShopApp.Models.Receipt> Receipt { get; set; } = default!;
    }
}
