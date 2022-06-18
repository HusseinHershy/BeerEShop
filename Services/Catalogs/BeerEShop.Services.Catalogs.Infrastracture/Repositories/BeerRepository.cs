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
    public class BeerRepository : RepositoryBase<Beer> , IBeerRepository
    {
        public BeerRepository(BeerCatalogContext dbContext) : base(dbContext)
        {

        }

        public async Task<Beer> CreateBeer(Beer beer)
        {
            return await AddAsync(beer);

        }

        public async Task<bool> DeleteBeerById(long beerId)
        {
            var Beer = await GetBeerById(beerId);
            Beer.ChangeStatus(BeerStatus.Unavailable);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<Beer> GetBeerById(long beerId)
        {
            var Beer = await _dbContext.Beers.Where(p => p.BeerId == beerId)
                              .Include("Brewery")
                               .SingleOrDefaultAsync();
            return Beer;

        }

        public async Task<IEnumerable<Beer>> GetBeers(long BreweryId)
        {
            var Beers = await _dbContext.Beers.Where(p => p.BreweryId == BreweryId && p.BeerStatus == BeerStatus.Available)
                              .Include("Brewery")
                               .ToListAsync();
            return Beers;
        }
    }
}
