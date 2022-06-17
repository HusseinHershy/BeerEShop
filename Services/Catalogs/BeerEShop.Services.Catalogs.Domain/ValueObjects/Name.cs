using Ardalis.GuardClauses;
using BeerEShop.Services.Catalogs.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; private set; }

        public Name? Null => null;

        public static Name Create(string value)
        {
            return new Name
            {
                Value = Guard.Against.NullOrEmpty(value, new BeerCatalogDomainException("Name can't be null mor empty.").Message)
            };
        }

        public static implicit operator Name(string value) => Create(value);

        public static implicit operator string(Name value) =>
            Guard.Against.Null(value.Value, new BeerCatalogDomainException("Name can't be null.").Message);
    }
}
