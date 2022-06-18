using AutoMapper;
using EShop.Shared.EventBus.Messages.Events;
using MassTransit;
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
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public OrderController(IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] OrderCheckout basketCheckout)
        {
            
            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<CreateOrderEvent>(basketCheckout);
            await _publishEndpoint.Publish<CreateOrderEvent>(eventMessage);

           

            return Accepted();
        }
    }
}
