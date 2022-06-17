using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBeer
{
    public class CreateBeerCommand : IRequest<BeerVM>
    {
        /// <summary>
        /// Beer Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Alcohol Content
        /// </summary>
        public decimal AlcoholContent { get; set; }
        /// <summary>
        /// price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Selling Price
        /// </summary>
        public decimal SellingPrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        public decimal Volume { get; set; }
        
        /// <summary>
        /// Brewery Id
        /// </summary>
        public long BreweryId { get; set; }
    }
}
