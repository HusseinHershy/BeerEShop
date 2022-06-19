using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  
namespace BeerEShop.Services.Sales.API.ModelsDTO
{
    public class SaleOrder
    {
        public long WholesalerId { get; set; }
        public long CustomerId { get; set; }
        public long Discount { get; set; }
       
        public List<SaleOrderItem> SaleOrderItems { get; set; }
    }
    public class SaleOrderItem
    {
        public long BeerId { get; set; }
        public long Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public SaleOrderItem(long beerId, long quantity, decimal unitPrice)
        {
            this.BeerId = beerId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }
    }
}

