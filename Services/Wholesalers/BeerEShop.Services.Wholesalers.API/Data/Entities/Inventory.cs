using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.Domain.Entities
{
    public class Inventory
    {
        public long InventoryId { get; set; }
        public long WholesalerId { get; set; }
        public long BeerId { get; set; }
        public long Quantity { get; set; }
        public virtual  Wholesaler Wholesaler { get; set; }


    }
}
