using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.Domain.Entities
{
   public class OrderItem
    {
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public long BeerId { get; set; }
        public long Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

       
      

    }
}
