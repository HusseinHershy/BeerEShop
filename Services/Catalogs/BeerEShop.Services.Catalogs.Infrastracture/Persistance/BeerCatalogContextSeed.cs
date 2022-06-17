using BeerEShop.Services.Catalogs.Domain.Entities;
using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture.Persistance
{
    public static class BeerCatalogContextSeed
    {
        public static async Task InitializeAsync(BeerCatalogContext beerCatalogContext)
        {
           
                if (!beerCatalogContext.Breweries.Any())
                {
                    beerCatalogContext.Breweries.AddRange(GetPreconfiguredBreweries());
                    await beerCatalogContext.SaveChangesAsync();
                }

                if (!beerCatalogContext.Beers.Any())
                {
                    beerCatalogContext.Beers.AddRange(GetPreconfiguredBeers());
                    await beerCatalogContext.SaveChangesAsync();
                }

            
        }
        private static IEnumerable<Brewery> GetPreconfiguredBreweries()
        {
            return new List<Brewery>
                {
                    new Brewery("Abbaye de Leffe"),
                    new Brewery("Lynlake Brewery"),
                    new Brewery("Granite City Food & Brewery")
                };
        }
        private static IEnumerable<Beer> GetPreconfiguredBeers()
        {
            return new List<Beer>
                {
                    Beer.Create("Leffe Blonde",BeerStatus.Available,5.2m,100,115,130,1),
                     Beer.Create("Imperial Enchanted Rain Rocket",BeerStatus.Available,6.6m,70,80,130,1),
             Beer.Create("Double Enchanted Nugget Trip", BeerStatus.Available, 3.2m, 100, 30, 45, 2),
             Beer.Create("Mosaic Dry Hopped Galactic Juice Daze", BeerStatus.Available, 7.2m, 50, 3, 7, 3)
            };
        }
        


    }
}
