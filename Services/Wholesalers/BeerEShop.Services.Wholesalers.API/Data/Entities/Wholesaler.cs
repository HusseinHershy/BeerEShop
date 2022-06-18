using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.Domain.Entities
{
    public class Wholesaler
    {
       
        public long WholesalerId { get; set; }
        public string Name { get; set; }
        public string PhoneNbr { get; set; }
        public string Website { get; set; }
        public string EmailAddress { get; set; }
        public string StoreLocation { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #region Ctor
        public Wholesaler()
        {
            this.Inventories = new HashSet<Inventory>();
        }
        public Wholesaler(string name, string phoneNbr, string website, string emailAddress, string storeLocation)
        {
            this.Name = name;
            this.PhoneNbr = phoneNbr;
            this.Website = website;
            this.EmailAddress = emailAddress;
            this.StoreLocation = storeLocation;
            this.Inventories = new HashSet<Inventory>();
        }
        #endregion
    }
}
