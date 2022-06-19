﻿using BeerEShop.Services.Discounts.Grpc.Protos;
using System;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API.GrpcServices
{
    public class DiscountGrpcService  
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<PurchaseResponseModel> GetDiscount(PurchaseDetailsModel purchaseDetailsModel)
        {
            return await _discountProtoService.GetDiscountAsync(purchaseDetailsModel);
        }
    }
}
