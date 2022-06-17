using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using BeerEShop.Services.Catalogs.Domain.Entities;
using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using BeerEShop.Services.Catalogs.Infrastracture.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture.Repositories
{
    public class BreweryRepository : RepositoryBase<Brewery> , IBreweryRepository
    {
        public BreweryRepository(BeerCatalogContext dbContext) : base(dbContext)
        {

        }

        public async Task<Brewery> CreateBrewery(Brewery brewery)
        {
            return await AddAsync(brewery);
             
        }


        public async Task<IEnumerable<Brewery>> GetBreweries()
        {
            var breweries = await _dbContext.Breweries
                                .ToListAsync();
            return breweries;
        }

        public async Task<Brewery> GetBreweryById(long breweryId)
        {
            var brewery = await _dbContext.Breweries.Where(p => p.BreweryId == breweryId)
                             .SingleOrDefaultAsync();
            return brewery;
        }
    }
}
