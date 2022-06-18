using BeerEShop.Services.Wholesalers.API.Data.Entities.Mapping;
using BeerEShop.Services.Wholesalers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Data
{
    public class WholesalerDbContext : DbContext
    {
        public WholesalerDbContext(DbContextOptions<WholesalerDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Wholesaler> wholesalers { get; set; }
        public DbSet<Inventory> inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WholesalerEntityConfiguration());
        }
    }
}
