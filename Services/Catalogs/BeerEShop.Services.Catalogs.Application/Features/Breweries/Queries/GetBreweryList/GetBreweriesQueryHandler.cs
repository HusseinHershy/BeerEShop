using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Queries.GetBreweryList
{
   public class GetBreweriesQueryHandler : IRequestHandler<GetBreweriesQuery, List<BreweryVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBreweriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<List<BreweryVM>> Handle(GetBreweriesQuery request, CancellationToken cancellationToken)
        {

            var Result = await _unitOfWork.BreweryRepository.GetBreweries();
            return _mapper.Map<List<BreweryVM>>(Result);


        }
    }
}
