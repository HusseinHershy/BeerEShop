using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Queries.GetBrewery
{
   public class GetBreweryQuery : IRequest<BreweryVM>
    {
        public long BreweryId { get; set; }


        public GetBreweryQuery(long breweryId)
        {
            BreweryId = breweryId;
        }
    }
}
