using BeerEShop.Services.Discounts.Grpc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Discounts.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<PurchaseDetails> GetDiscount(string productName);
    }
}
