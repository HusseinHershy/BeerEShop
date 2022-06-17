using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Beers.Queries.GetBeer
{
    public class GetBeerQueryHandler : IRequestHandler<GetBeerQuery, BeerVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBeerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
   
        public async Task<BeerVM> Handle(GetBeerQuery request, CancellationToken cancellationToken)
        {

            var Result = await _unitOfWork.BeerRepository.GetBeerById(request.BeerId);
            return _mapper.Map<BeerVM>(Result);


        }
    }
}
