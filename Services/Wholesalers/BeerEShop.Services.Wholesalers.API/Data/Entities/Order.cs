using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.Domain.Entities
{
    public class Order
    {
        public long OrderId { get; set; }
        public long WholesalerId { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Wholesaler Wholesaler { get; set; }


    }
}
