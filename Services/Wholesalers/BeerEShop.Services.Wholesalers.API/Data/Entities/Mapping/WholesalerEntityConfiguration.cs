using BeerEShop.Services.Wholesalers.Domain.Entities;
using EShop.Shared.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Data.Entities.Mapping
{
    public class WholesalerEntityConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.ToTable("Wholesaler");
            builder.HasKey(e => e.WholesalerId);

            builder.Property(e => e.WholesalerId)
               .HasColumnType(EfConstants.ColumnTypes.BigInteger)
               .HasColumnName("WholesalerId");

            builder.HasIndex(x => x.WholesalerId).IsUnique();

            builder.Property(e => e.PhoneNbr)
              .HasColumnType(EfConstants.ColumnTypes.NormalText);

            builder.Property(e => e.StoreLocation)
                  .HasColumnType(EfConstants.ColumnTypes.NormalText);

            builder.Property(e => e.Website)
              .HasColumnType(EfConstants.ColumnTypes.NormalText);

            builder.Property(e => e.EmailAddress)
           .HasColumnType(EfConstants.ColumnTypes.NormalText);


            builder.Property(e => e.Name)
          .HasColumnType(EfConstants.ColumnTypes.NormalText);

          
        }
    }
}