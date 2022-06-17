using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBrewery
{
    public class CreateBreweryCommand : IRequest<BreweryVM>
    {
        /// <summary>
        /// Brewery Name
        /// </summary>
        public string Name { get; set; }
    }
}
