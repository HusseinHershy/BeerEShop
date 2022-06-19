using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API.Data.Entities
{
    public class Customer
    {
        public long CutomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<SaleOrder> SaleOrders { get; set; }

        public Customer()
        {
            this.SaleOrders = new HashSet<SaleOrder>();
        }
        public Customer(string name, string phoneNumber, string emailAddress)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.SaleOrders = new HashSet<SaleOrder>();
        }

    }
}
