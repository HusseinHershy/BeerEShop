using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.DeleteBeer
{
    public class DeleteBeerCommand : IRequest<BeerVM>
    {
        public long BearId { get; set; }
        public DeleteBeerCommand(long bearId)
        {
            this.BearId = bearId;
        }
    }
}
