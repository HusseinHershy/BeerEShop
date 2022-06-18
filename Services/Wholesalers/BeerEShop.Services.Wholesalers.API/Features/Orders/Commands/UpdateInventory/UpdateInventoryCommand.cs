using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest<long>
    {
        public long BeerId { get; set; }
        public long Quantity { get; set; }
    }
}
