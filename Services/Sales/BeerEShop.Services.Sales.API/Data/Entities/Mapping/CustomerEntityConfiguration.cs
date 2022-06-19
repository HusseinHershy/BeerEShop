using BeerEShop.Services.Sales.API.Data.Entities;
using EShop.Shared.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Data.Entities.Mapping
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(e => e.CutomerId);

            builder.Property(e => e.CutomerId)
               .HasColumnType(EfConstants.ColumnTypes.BigInteger)
               .HasColumnName("WholesalerId");

            builder.HasIndex(x => x.CutomerId).IsUnique();

            builder.Property(e => e.PhoneNumber)
              .HasColumnType(EfConstants.ColumnTypes.NormalText);

            builder.Property(e => e.EmailAddress)
                  .HasColumnType(EfConstants.ColumnTypes.NormalText);

            builder.Property(e => e.Name)
              .HasColumnType(EfConstants.ColumnTypes.NormalText);

          
        }
    }
}