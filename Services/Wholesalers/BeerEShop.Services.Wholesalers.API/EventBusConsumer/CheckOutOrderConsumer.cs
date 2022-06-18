using AutoMapper;
using BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder;
using EShop.Shared.EventBus.Messages.Events;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.EventBusConsumer
{

        public class CheckOutOrderConsumer : IConsumer<CreateOrderEvent>
        {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public CheckOutOrderConsumer(IMediator mediator, IMapper mapper)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task Consume(ConsumeContext<CreateOrderEvent> context)
            {
            try
            {
                var command = _mapper.Map<CreateOrderCommand>(context.Message);
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {

            }
                

            }
        }
}
