using Ardalis.GuardClauses;
using BeerEShop.Services.Catalogs.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.ValueObjects
{

    public record SellingPrice
    {
        public decimal Value { get; private set; }

        public SellingPrice? Null => null;

        public static SellingPrice Create(decimal value)
        {
            return new SellingPrice
            {
                Value = Guard.Against.NegativeOrZero(
                    value,
                    new BeerCatalogDomainException("The Beer item SellingPrice cannot have negative or zero value.").Message)
            };
        }

        public static implicit operator SellingPrice(decimal value) => Create(value);

        public static implicit operator decimal(SellingPrice value) =>
         Guard.Against.Null(value.Value, new BeerCatalogDomainException("Price can't be null.").Message);
    }
}
