using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Queries.GetBrewery
{
    public class GetBreweryQueryHandler : IRequestHandler<GetBreweryQuery, BreweryVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBreweryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
   
        public async Task<BreweryVM> Handle(GetBreweryQuery request, CancellationToken cancellationToken)
        {

            var Result = await _unitOfWork.BreweryRepository.GetBreweryById(request.BreweryId);
            return _mapper.Map<BreweryVM>(Result);


        }
    }
}
