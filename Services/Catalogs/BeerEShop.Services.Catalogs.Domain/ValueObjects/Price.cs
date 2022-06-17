using Ardalis.GuardClauses;
using BeerEShop.Services.Catalogs.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.ValueObjects
{

    public record Price
    {
        public decimal Value { get; private set; }

        public Price? Null => null;

        public static Price Create(decimal value)
        {
            return new Price
            {
                Value = Guard.Against.NegativeOrZero(
                    value,
                    new BeerCatalogDomainException("The Beer item price cannot have negative or zero value.").Message)
            };
        }

        public static implicit operator Price(decimal value) => Create(value);

        public static implicit operator decimal(Price value) =>
            Guard.Against.Null(value.Value, new BeerCatalogDomainException("Price can't be null.").Message);
    }
}
