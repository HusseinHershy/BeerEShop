using BeerEShop.Services.Wholesalers.API.Data.Entities.Mapping;
using BeerEShop.Services.Wholesalers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Data
{
    public static class WholesalerDbContextSeed
    {
        public static async Task InitializeAsync(WholesalerDbContext wholesalerDbContext)
        {

            if (!wholesalerDbContext.wholesalers.Any())
            {
                wholesalerDbContext.wholesalers.AddRange(GetPreconfiguredWholesalers());
                await wholesalerDbContext.SaveChangesAsync();
            }

        }
        private static IEnumerable<Wholesaler> GetPreconfiguredWholesalers()
        {
            return new List<Wholesaler>
                {
                    new Wholesaler("Olla","03752638","www.Olla.com","HOlla@gmail.com","Beirut"),
                    new Wholesaler("GeneDrinks","03752638","www.Olla.com","HOlla@gmail.com","Leb")
                   
                };
        }
   



    }
}
