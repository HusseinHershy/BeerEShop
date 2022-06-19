using AutoMapper;
using BeerEShop.Services.Sales.API.ModelsDTO;
using BeerEShop.Services.Wholesalers.API.Features.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API.Mapping
{
    public class MappingProfile : Profile
    {
        	public MappingProfile()
		{
			CreateMap<SaleOrder, CreateSaleOrderCommand>().ReverseMap()
				 .ForMember(dest => dest.SaleOrderItems, opt => opt.MapFrom(src => src.orderItems))
				 .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
				 .ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.WholesalerId))
				.ForMember(dest => dest.WholesalerId, opt => opt.MapFrom(src => src.WholesalerId));
			
			CreateMap<SaleOrderItem, CreateOrderItem>().ReverseMap()
				 .ForMember(dest => dest.BeerId, opt => opt.MapFrom(src => src.BeerId))
				 .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
				.ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
		}
	}
    }

