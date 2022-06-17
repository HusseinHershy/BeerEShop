using Ardalis.GuardClauses;
using BeerEShop.Services.Catalogs.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.ValueObjects
{

    public record Volume
    {
        public decimal Value { get; private set; }

        public Volume? Null => null;

        public static Volume Create(decimal value)
        {
            return new Volume
            {
                Value = Guard.Against.NegativeOrZero(
                    value,
                    new BeerCatalogDomainException("The Beer item Volume cannot have negative or zero value.").Message)
            };
        }

        public static implicit operator Volume(decimal value) => Create(value);

        public static implicit operator decimal(Volume value) =>
            Guard.Against.Null(value.Value, new BeerCatalogDomainException("Volume can't be null.").Message);
    }
}
