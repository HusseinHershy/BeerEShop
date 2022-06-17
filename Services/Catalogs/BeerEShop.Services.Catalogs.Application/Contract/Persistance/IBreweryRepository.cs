using BeerEShop.Services.Catalogs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Contract.Persistance
{
    public interface IBreweryRepository : IAsyncRepository<Brewery>
    {
        /// <summary>
        /// Get List Of Breweries
        /// </summary>
        /// <returns>List of Breweries</returns>
        Task<IEnumerable<Brewery>> GetBreweries();

        /// <summary>
        /// Get Brewery By Id
        /// </summary>
        /// <param name="breweryId"> BreweryId</param>
        /// <returns>brewery</returns>
        Task<Brewery> GetBreweryById(long breweryId);

        /// <summary>
        /// Create Brewery
        /// </summary>
        /// <param name="brewery">Brewery Object</param>
        /// <returns>brewery</returns>
        Task<Brewery> CreateBrewery(Brewery brewery);
    }
}
