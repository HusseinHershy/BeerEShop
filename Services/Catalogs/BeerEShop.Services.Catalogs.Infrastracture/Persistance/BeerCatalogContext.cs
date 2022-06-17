using BeerEShop.Services.Catalogs.Domain.Common;
using BeerEShop.Services.Catalogs.Domain.Entities;
using BeerEShop.Services.Catalogs.Infrastracture.Persistance.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture.Persistance
{
    public class BeerCatalogContext : DbContext
    {
        public BeerCatalogContext(DbContextOptions<BeerCatalogContext> options) : base(options)
        {
        }

        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BeerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BreweryEntityConfiguration());

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "HHershy";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "HHershy";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
    

