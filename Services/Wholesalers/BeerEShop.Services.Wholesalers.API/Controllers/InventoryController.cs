using BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.UpdateInventory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPut(Name = "UpdateStock")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStock([FromBody] UpdateInventoryCommand command)
        {
            var Brewery = await _mediator.Send(command);
            return Ok(Brewery);
        }
    }
}
