using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace RazorPagesProduct.Data
{
    public class RazorPagesProductContext : DbContext
    {
        public RazorPagesProductContext (DbContextOptions<RazorPagesProductContext> options)
            : base(options)
        {
        }

        public DbSet<ShopApp.Models.Product> Product { get; set; } = default!;
    }
}
