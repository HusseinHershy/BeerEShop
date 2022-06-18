using AutoMapper;
using BeerEShop.Services.Wholesalers.API.Data;
using BeerEShop.Services.Wholesalers.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly WholesalerDbContext _dbContext;
        private readonly IMapper _mapper;



        public CreateOrderCommandHandler(WholesalerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var items = request.orderItems.Select(i =>
               new OrderItem
               {
                   BeerId = i.BeerId,
                   Quantity = i.Quantity,
                   UnitPrice = i.UnitPrice
               }).ToList();

            var order = new Order
            {
                orderItems = items,
                WholesalerId = request.WholesalerId,
                TotalAmount = items.Sum(s => s.TotalPrice)
            };
            _dbContext.Orders.Add(order);
            foreach (var item in items)
            {
                var inTB = _dbContext.inventories.Where(s => s.BeerId == item.BeerId).FirstOrDefault();
                if (inTB != null)
                {
                    // Modifying existing record
                    inTB.Quantity += item.Quantity;
                }
                else
                {
                    // Adding a new record
                    _dbContext.inventories.Add(new Inventory() { Quantity = item.Quantity, BeerId = item.BeerId, WholesalerId = request.WholesalerId }); /* set another properties */
                };
            }
            await _dbContext.SaveChangesAsync();
            return order.OrderId;
        }
    }
}