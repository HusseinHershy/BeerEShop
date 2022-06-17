using BeerEShop.Services.Catalogs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Contract.Persistance
{
    public interface IBeerRepository : IAsyncRepository<Beer>
    {
        /// <summary>
        /// Get List Of Beers By Brewery
        /// </summary>
        /// <returns>List of Beers</returns>
        Task<IEnumerable<Beer>> GetBeers(long BreweryId);

        /// <summary>
        /// Get Beer By Id
        /// </summary>
        /// <param name="beerId"> Beer Id</param>
        /// <returns>Product</returns>
        Task<Beer> GetBeerById(long beerId);

        /// <summary>
        /// Delete Beer By Id
        /// </summary>
        /// <param name="beerId"> Beer Id</param>
        /// <returns>Product</returns>
         Task<bool> DeleteBeerById(long beerId);
    }
}
