using AutoMapper;
using BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder;
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
    public class SaleOrderController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SaleOrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSaleOrder([FromBody] CreateSaleOrderCommand SaleOrderCommand)
        {
            var result = await _mediator.Send(SaleOrderCommand);
            return Ok(result);
        }
    }
}
