using BeerEShop.Services.Catalogs.Application.Features.Breweries;
using BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBrewery;
using BeerEShop.Services.Catalogs.Application.Features.Breweries.Queries.GetBrewery;
using BeerEShop.Services.Catalogs.Application.Features.Breweries.Queries.GetBreweryList;
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
    public class BreweriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BreweriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{BreweryId}", Name = "GetBrewery")]
        [ProducesResponseType(typeof(BreweryVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BreweryVM>> GetBreweryById(long BreweryId)
        {
            var query = new GetBreweryQuery(BreweryId);
            var Brewery = await _mediator.Send(query);
            return Ok(Brewery);
        }

        [HttpGet(Name = "GetBreweries")]
        [ProducesResponseType(typeof(List<BreweryVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<BreweryVM>>> GetBreweries()
        {
            var query = new GetBreweriesQuery();
            var Breweries = await _mediator.Send(query);
            return Ok(Breweries);
        }


        [HttpPost(Name = "CreateBrewery")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateBrewery([FromBody] CreateBreweryCommand command)
        {
            var Brewery = await _mediator.Send(command);
            return Ok(Brewery);
        }

    }
}
