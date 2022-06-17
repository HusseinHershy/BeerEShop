using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Beers.Queries.GetBeersList
{
   public class GetBeersQuery : IRequest<List<BeerVM>>
    {
        public long BreweryId { get; set; }


        public GetBeersQuery(long breweryId)
        {
            BreweryId = breweryId;
        }
    }
}
