using BeerEShop.Services.Catalogs.Application.Features.Breweries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features
{
    public class BeerVM
    {
        public string Name { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Volume { get; set; }
        public BeerStatusVM BeerStatus { get; set; }
        public long? BreweryId { get; set; }
        public BreweryVM Brewery { get; set; }
    }
}
