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

namespace BeerEShop.Services.Catalogs.Application.Features.Breweries.Commands.DeleteBeer
{
   public class DeleteBeerCommandHandler : IRequestHandler<DeleteBeerCommand, BeerVM>
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBeerCommandHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<BeerVM> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var BeerResult = await _unitOfWork.BeerRepository.GetByIdAsync(request.BearId);
            if (BeerResult == null)
            {
                throw new NotFoundException(nameof(BeerVM), request.BearId);
            }
            BeerResult.ChangeStatus(Domain.ValueObjects.BeerStatus.Unavailable);
            
            await _unitOfWork.CompleteAsync();
            var UpdateEntity = _mapper.Map<BeerVM>(BeerResult);


            return UpdateEntity;
        }
    }
    }

