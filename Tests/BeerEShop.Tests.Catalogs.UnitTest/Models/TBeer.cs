using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Tests.Catalogs.UnitTest.Models
{
    public class TBeer
    {
        public string Name { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Volume { get; set; }
        public BeerStatus BeerStatus { get; set; }
        public long? BreweryId { get; set; }
    }
}
