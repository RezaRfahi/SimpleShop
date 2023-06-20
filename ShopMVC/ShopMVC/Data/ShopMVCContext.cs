using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Models;

namespace ShopMVC.Data
{
    public class ShopMVCContext : DbContext
    {
        public ShopMVCContext (DbContextOptions<ShopMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ShopMVC.Models.SliderImage> SliderImage { get; set; } = default!;
        public object SliderImages { get; internal set; }
        public DbSet<ShopMVC.Models.Category> Category { get; set; } = default!;
        public DbSet<ShopMVC.Models.Product> Product { get; set; } = default!;
    }
}
