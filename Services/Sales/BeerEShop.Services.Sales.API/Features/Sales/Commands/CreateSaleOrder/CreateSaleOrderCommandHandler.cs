using AutoMapper;
using BeerEShop.Services.Sales.API.ModelsDTO;
using BeerEShop.Services.Sales.API.Repositories;
using BeerEShop.Services.Wholesalers.API.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder
{
    public class CreateSaleOrderCommandHandler : IRequestHandler<CreateSaleOrderCommand, bool>
    {
        private readonly SaleDbContext _dbContext;
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;


        public CreateSaleOrderCommandHandler(SaleDbContext dbContext, ISaleRepository saleRepository,IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<bool> Handle(CreateSaleOrderCommand request, CancellationToken cancellationToken)
        {
            var CreatedEntity = _mapper.Map<SaleOrder>(request);

           await _saleRepository.CreateSaleOrder(CreatedEntity);
            return true;
        }
    }
}