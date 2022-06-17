using BeerEShop.Services.Catalogs.Domain.Common;
using BeerEShop.Services.Catalogs.Domain.Entities;
using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture.Persistance.EntityConfiguration
{
   public class BeerEntityConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        { 
            builder.ToTable("Beer");
            builder.HasKey(e => e.BeerId);
                   
            builder.HasIndex(x => x.BeerId).IsUnique();

            builder.Property(e => e.BeerId)
               .HasColumnType(EfConstants.ColumnTypes.BigInteger)
               .HasColumnName("BeerId");

            builder.Property(x => x.Name)
           .HasColumnType(EfConstants.ColumnTypes.NormalText)
           .HasConversion(name => name.Value, name => Name.Create(name))
           .IsRequired();

            builder.Property(x => x.Volume)
            .HasColumnType(EfConstants.ColumnTypes.RegularDecimal)
            .HasConversion(volume => volume.Value, volume => Volume.Create(volume))
            .IsRequired();

            builder.Property(x => x.Price)
            .HasColumnType(EfConstants.ColumnTypes.PriceDecimal)
            .HasConversion(price => price.Value, price => Price.Create(price))
            .IsRequired();

            builder.Property(x => x.SellingPrice)
           .HasColumnType(EfConstants.ColumnTypes.PriceDecimal)
           .HasConversion(sellingPrice => sellingPrice.Value, sellingPrice => SellingPrice.Create(sellingPrice))
           .IsRequired();

            builder.Property(x => x.AlcoholContent)
        .HasColumnType(EfConstants.ColumnTypes.RegularDecimal)
        .HasConversion(alcoholContent => alcoholContent.Value, alcoholContent => AlcoholContent.Create(alcoholContent))
        .IsRequired();


            builder.Property(x => x.BeerStatus)
            .HasDefaultValue(BeerStatus.Available)
            .HasMaxLength(EfConstants.Lenght.Short)
            .HasConversion(
                x => x.ToString(),
                x => (BeerStatus)Enum.Parse(typeof(BeerStatus), x));

            builder.Property(x => x.BreweryId)
            .HasColumnType(EfConstants.ColumnTypes.BigInteger);

            builder.HasOne<Brewery>(x => x.Brewery)
          .WithMany()
          .HasForeignKey(x => x.BreweryId);


         
        }
    }
}
