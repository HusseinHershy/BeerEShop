using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API.Data.Entities
{
    public class SaleOrder
    {
        public long SaleOrderId { get; set; }
        public long WholesalerId { get; set; }
        public long CustomerId { get; set; }
        public List<SaleOrderItem> SaleOderItems { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
