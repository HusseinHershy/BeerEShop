using BeerEShop.Services.Discounts.Grpc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Discounts.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        public async Task<PurchaseResponse> GetDiscount(PurchaseDetails purchaseDetails)
        {
            PurchaseResponse purchaseResponse = new PurchaseResponse();
            switch (purchaseDetails.quantity)
            {
                case <= 10:
                    purchaseResponse.status = 0;
                    purchaseResponse.Description = "Non Discount is Done";
                    purchaseResponse.percentage = 0;
                    break;
                case > 10 and <= 20:
                    purchaseResponse.status = 1;
                    purchaseResponse.Description = "Discount 10%";
                    purchaseResponse.percentage = 10;
                    break;
                case > 20:
                    purchaseResponse.status = 1;
                    purchaseResponse.Description = "Discount 20%";
                    purchaseResponse.percentage = 20;
                    break;
            }
             return purchaseResponse;
            }
        }
    }

