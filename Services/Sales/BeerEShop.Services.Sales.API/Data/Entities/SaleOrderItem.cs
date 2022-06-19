using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API.Data.Entities
{
    public class SaleOrderItem
    {
        public long SaleOrderItemId { get; set; }
        public long SaleOrderId { get; set; }
        public long BeerId { get; set; }
        public long Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
