using System.Collections.Generic;

namespace EShop.Shared.EventBus.Messages.Events
{
    
        public class CreateOrderEvent : IntegrationBaseEvent
        {
            public long WholesalerId { get; set; }
            public List<CreateOrderItem> orderItems { get; set; }
        }
        public class CreateOrderItem
        {
            public long BeerId { get; set; }
            public long Quantity { get; set; }
            public decimal UnitPrice { get; set; }

            public CreateOrderItem(long beerId, long quantity, decimal unitPrice)
            {
                this.BeerId = beerId;
                this.Quantity = quantity;
                this.UnitPrice = unitPrice;
            }
        }
    }

