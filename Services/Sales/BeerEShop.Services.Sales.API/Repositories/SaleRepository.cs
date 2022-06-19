using BeerEShop.Services.Discounts.Grpc.Protos;
using BeerEShop.Services.Sales.API.GrpcServices;
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
        public readonly DiscountGrpcService _discountGrpcService;

        public SaleRepository(SaleDbContext dbContext, DiscountGrpcService discountGrpcService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));


        }
        public async Task<Boolean> CreateSaleOrder(ModelsDTO.SaleOrder saleOrder)
        {
            PurchaseDetailsModel CheckDiscount = new PurchaseDetailsModel();
            CheckDiscount.Quantity = saleOrder.SaleOrderItems.Sum(e => e.Quantity);
            var response = await _discountGrpcService.GetDiscount(CheckDiscount);
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
                TotalAmount = response.Status ==0 ? items.Sum(s => s.TotalPrice) : (response.Percentage / 100) * items.Sum(s => s.TotalPrice),
                 CustomerId = saleOrder.CustomerId,
                  Discount = response.Percentage,
                Amount =  items.Sum(s => s.TotalPrice)


            };
           await _dbContext.SaleOrders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return true;
            }
            
        }
    }

