using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<long>
    {
        public long WholesalerId { get; set; }
        public List<CreateOrderItem> orderItems { get; set; }
    }
    public class CreateOrderItem
    {
        public long BeerId { get; set; }
        public long Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public CreateOrderItem(long beerId, long quantity, decimal unitPrice)
        {
            this.BeerId = beerId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }
    }
}