using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Queries.GetBreweryList
{
   public class GetBreweriesQuery : IRequest<List<BreweryVM>>
    {
    }
}
