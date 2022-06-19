using BeerEShop.Services.Sales.API.ModelsDTO;
using BeerEShop.Services.Wholesalers.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using modelEntities =  BeerEShop.Services.Sales.API.Data.Entities;
namespace BeerEShop.Services.Sales.API.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SaleDbContext _dbContext;

        public SaleRepository(SaleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
     

        }
        public async Task<Boolean> CreateSaleOrder(ModelsDTO.SaleOrder saleOrder)
        {
            var items = saleOrder.SaleOrderItems.Select(i =>
             new modelEntities.SaleOrderItem
             {
                 BeerId = i.BeerId,
                 Quantity = i.Quantity,
                 UnitPrice = i.UnitPrice
             }).ToList();

            var order = new modelEntities.SaleOrder
            {
                SaleOderItems = items,
                WholesalerId = saleOrder.WholesalerId,
                TotalAmount = items.Sum(s => s.TotalPrice)
            };
           await _dbContext.SaleOrders.AddAsync(order);
            return true;
            }
            
        }
    }

