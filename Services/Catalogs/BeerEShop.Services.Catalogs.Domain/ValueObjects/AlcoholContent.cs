using Ardalis.GuardClauses;
using BeerEShop.Services.Catalogs.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.ValueObjects
{

    public record AlcoholContent
    {
        public decimal Value { get; private set; }

        public AlcoholContent? Null => null;

        public static AlcoholContent Create(decimal value)
        {
            return new AlcoholContent
            {
                Value = Guard.Against.NegativeOrZero(
                    value,
                    new BeerCatalogDomainException("The Beer item AlcoholContent cannot have negative or zero value.").Message)
            };
        }

        public static implicit operator AlcoholContent(decimal value) => Create(value);

        public static implicit operator decimal(AlcoholContent value) =>
            Guard.Against.Null(value.Value, new BeerCatalogDomainException("AlcoholContent can't be null.").Message);
    }
}
