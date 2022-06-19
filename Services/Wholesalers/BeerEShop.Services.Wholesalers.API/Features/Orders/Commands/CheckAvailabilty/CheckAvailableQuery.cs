using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CheckAvailabilty
{
    public class CheckAvailableQuery : IRequest<AvailableInStock>
    {
      public  long BeerId { get; set; }
        public long WholesalerId { get; set; }
        public long Quantity { get; set; }
    }
}
