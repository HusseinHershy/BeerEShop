using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Beers.Queries.GetBeer
{
   public class GetBeerQuery : IRequest<BeerVM>
    {
        public long BeerId { get; set; }


        public GetBeerQuery(long beerId)
        {
            BeerId = beerId;
        }
    }
}
