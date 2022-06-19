using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands
{
    public class AvailableInStock
    {
        public long Status { get; set; }
        public long WholselerId { get; set; }
        public long BeerId { get; set; }
        public long Availablequantity { get; set; }
    }
}
