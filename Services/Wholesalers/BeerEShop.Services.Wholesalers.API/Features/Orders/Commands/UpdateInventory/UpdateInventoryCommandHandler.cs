using AutoMapper;
using BeerEShop.Services.Wholesalers.API.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.UpdateInventory
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, long>
    {
        private readonly WholesalerDbContext _dbContext;
        private readonly IMapper _mapper;



        public UpdateInventoryCommandHandler(WholesalerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<long> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {

            
                var inTB = _dbContext.inventories.Where(s => s.BeerId == request.BeerId).FirstOrDefault();
            if (inTB != null)
            {
                // Modifying existing record
                inTB.Quantity = request.Quantity;
            }
            await _dbContext.SaveChangesAsync();
            return inTB.Quantity;
        }
            
        }
    }

