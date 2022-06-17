using BeerEShop.Services.Catalogs.Application.Features;
using BeerEShop.Services.Catalogs.Application.Features.Beers;
using BeerEShop.Services.Catalogs.Application.Features.Beers.Queries.GetBeer;
using BeerEShop.Services.Catalogs.Application.Features.Beers.Queries.GetBeersList;
using BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBeer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.API.Controllers
{
    [Route("api/V1/[controller]/[action]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{BeerId}", Name = "GetBeer")]
        [ProducesResponseType(typeof(BeerVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BeerVM>> GetBeerById(long BeerId)
        {
            var query = new GetBeerQuery(BeerId);
            var Beer = await _mediator.Send(query);
            return Ok(Beer);
        }

        [HttpGet(Name = "GetBeers")]
        [ProducesResponseType(typeof(List<BeerVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<BeerVM>>> GetBeers(long BreweryId)
        {
            GetBeersQuery query = new GetBeersQuery(BreweryId);
            var Beers = await _mediator.Send(query);
            return Ok(Beers);
        }


        [HttpPost(Name = "CreateBeer")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateBeer([FromBody] CreateBeerCommand command)
        {
            var Beer = await _mediator.Send(command);
            return Ok(Beer);
        }

    }
}
