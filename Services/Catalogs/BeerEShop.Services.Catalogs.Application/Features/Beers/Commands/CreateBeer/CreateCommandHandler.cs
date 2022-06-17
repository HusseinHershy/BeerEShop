using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using BeerEShop.Services.Catalogs.Application.Exceptions;
using BeerEShop.Services.Catalogs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.CreateBeer
{
   public class CreateBeerCommandHandler : IRequestHandler<CreateBeerCommand, BeerVM>
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBeerCommandHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<BeerVM> Handle(CreateBeerCommand request, CancellationToken cancellationToken)
        {
            var BreweryResult = await _unitOfWork.BreweryRepository.GetByIdAsync(request.BreweryId);
            if (BreweryResult == null)
            {
                throw new NotFoundException(nameof(BreweryVM), request.BreweryId);
            }
            var newBeer = _unitOfWork.BeerRepository.Add(Beer.Create(request.Name,request.AlcoholContent,request.Volume,request.Price,request.SellingPrice,request.BreweryId));
            await _unitOfWork.CompleteAsync();
            var CreatedEntity = _mapper.Map<BeerVM>(newBeer);


            return CreatedEntity;
        }
    }
    }

