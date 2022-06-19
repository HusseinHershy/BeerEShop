using BeerEShop.Services.Discounts.Grpc.Models;
using BeerEShop.Services.Discounts.Grpc.Protos;
using BeerEShop.Services.Discounts.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Discounts.Grpc
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountService( IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository)); ;
        }

        public override async Task<PurchaseResponseModel> GetDiscount(PurchaseDetailsModel request, ServerCallContext context)
        {
            PurchaseDetails purchase = new PurchaseDetails(request.Quantity);
            var resp = await _discountRepository.GetDiscount(purchase);
            var PurchaseResponseModel = new PurchaseResponseModel();
            PurchaseResponseModel.Description = resp.Description;
            PurchaseResponseModel.Percentage = resp.percentage;
            PurchaseResponseModel.Status = resp.status;
            return PurchaseResponseModel;
        }
    }
}
