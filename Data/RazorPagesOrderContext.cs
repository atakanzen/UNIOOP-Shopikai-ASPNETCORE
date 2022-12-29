using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace RazorPagesProduct.Data
{
    public class RazorPagesOrderContext : DbContext
    {
        public RazorPagesOrderContext (DbContextOptions<RazorPagesOrderContext> options)
            : base(options)
        {
        }

        public DbSet<ShopApp.Models.Order> Order { get; set; } = default!;
    }
}
