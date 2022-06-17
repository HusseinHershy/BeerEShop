using BeerEShop.Services.Catalogs.Domain.Common;
using BeerEShop.Services.Catalogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture.Persistance.EntityConfiguration
{
    class BreweryEntityConfiguration : IEntityTypeConfiguration<Brewery>
    {
    
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.ToTable("breweries");
            builder.HasKey(x => x.BreweryId);
            builder.HasIndex(x => x.BreweryId).IsUnique();
            builder.Property(e => e.BreweryId)
               .HasColumnType(EfConstants.ColumnTypes.BigInteger);
            builder.Property(x => x.Name).HasColumnType(EfConstants.ColumnTypes.NormalText).IsRequired();
        }
}
}