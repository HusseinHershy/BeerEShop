using AutoMapper;
using BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder;
using EShop.Shared.EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Mapping
{
    public class MappingProfile : Profile
    {
        	public MappingProfile()
		{
			CreateMap<CreateOrderEvent, CreateOrderCommand>().ReverseMap()
				 .ForMember(dest => dest.orderItems, opt => opt.MapFrom(src => src.orderItems))
				.ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.WholesalerId));
			
			CreateMap<BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder.CreateOrderItem, EShop.Shared.EventBus.Messages.Events.CreateOrderItem>().ReverseMap()
				 .ForMember(dest => dest.BeerId, opt => opt.MapFrom(src => src.BeerId))
				 .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
				.ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
		}
	}
    }

