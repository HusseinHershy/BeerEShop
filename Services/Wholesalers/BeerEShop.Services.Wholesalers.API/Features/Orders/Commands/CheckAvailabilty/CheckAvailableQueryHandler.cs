using BeerEShop.Services.Wholesalers.API.Data;
using BeerEShop.Services.Wholesalers.API.Exceptions;
using BeerEShop.Services.Wholesalers.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CheckAvailabilty
{
    public class CheckAvailableQueryHandler : IRequestHandler<CheckAvailableQuery, AvailableInStock>
    {
        private readonly WholesalerDbContext _dbContext;
     



        public CheckAvailableQueryHandler(WholesalerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }

        public async Task<AvailableInStock> Handle(CheckAvailableQuery request, CancellationToken cancellationToken)
        {
            var Result = await _dbContext.inventories.Where(p => p.BeerId == request.BeerId && p.WholesalerId == request.WholesalerId).SingleOrDefaultAsync();
           if (Result == null)
            {
                throw new NotFoundException(nameof(Inventory), request.WholesalerId);
            }
            var response = new AvailableInStock();

            if (Result.Quantity > request.Quantity)
            {
                response.Status = 1;
                response.Availablequantity = Result.Quantity;
                response.BeerId = request.BeerId;
                response.WholselerId = request.WholesalerId;

            }
           else
            {
                response.Status = 0;
                response.Availablequantity = Result.Quantity;
                response.BeerId = request.BeerId;
                response.WholselerId = request.WholesalerId;
            }
            return response;
        }
    }
}
