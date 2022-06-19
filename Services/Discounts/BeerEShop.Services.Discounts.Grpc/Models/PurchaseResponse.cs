using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Discounts.Grpc.Models
{
    public class PurchaseResponse
    {
      public long status { get; set; }
        public string Description { get; set; }
        public long percentage { get; set; }
    }
}
