using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Discounts.Grpc.Models
{
    public class PurchaseDetails
    {
        public long quantity { get; set; }
        public PurchaseDetails(long quantity)
        {
            this.quantity = quantity;
        }
    }
}
