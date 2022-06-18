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
    public class InventoryEntityConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(e => e.InventoryId);
          
            builder.Property(e => e.InventoryId)
              .HasColumnType(EfConstants.ColumnTypes.BigInteger)
              .HasColumnName("InventoryId");


            builder.Property(e => e.BeerId)
             .HasColumnType(EfConstants.ColumnTypes.BigInteger)
             .HasColumnName("BeerId");

            builder.Property(e => e.WholesalerId)
              .HasColumnType(EfConstants.ColumnTypes.BigInteger)
              .HasColumnName("WholesalerId");

            builder.HasIndex(x => x.InventoryId).IsUnique();
            builder.HasIndex(e => new { e.BeerId, e.WholesalerId }, "Beer_Wholesaler_ibfk").IsUnique();

            builder.Property(e => e.Quantity)
             .HasColumnType(EfConstants.ColumnTypes.RegularDecimal)
             .HasColumnName("Quantity");

          //  builder.HasOne<Wholesaler>(x => x.Wholesaler)
          //.WithMany(x=>x.Inventories)
          //.HasForeignKey(x => x.WholesalerId);

         
        }

    }
}
