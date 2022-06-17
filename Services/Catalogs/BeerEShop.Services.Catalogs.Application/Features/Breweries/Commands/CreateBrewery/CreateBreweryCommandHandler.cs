using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using BeerEShop.Services.Catalogs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBrewery
{
   public class CreateBreweryCommandHandler : IRequestHandler<CreateBreweryCommand, BreweryVM>
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBreweryCommandHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<BreweryVM> Handle(CreateBreweryCommand request, CancellationToken cancellationToken)
        {
         
            var newBrewery = _unitOfWork.BreweryRepository.Add(new Brewery(request.Name));
            await _unitOfWork.CompleteAsync();
            var CreatedEntity = _mapper.Map<BreweryVM>(newBrewery);


            return CreatedEntity;
        }
    }
    }

