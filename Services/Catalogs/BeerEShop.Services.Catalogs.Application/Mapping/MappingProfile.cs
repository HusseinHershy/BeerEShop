using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Features;
using BeerEShop.Services.Catalogs.Application.Features.Breweries;
using BeerEShop.Services.Catalogs.Domain.Entities;
using BeerEShop.Services.Catalogs.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Breweries 
            CreateMap<Brewery, BreweryVM>().ReverseMap()
                         .ForMember(dest => dest.BreweryId, opt => opt.MapFrom(src => src.BreweryId))
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));



            #endregion

            #region Beer 
            CreateMap<BeerStatus, BeerStatusVM>().ReverseMap();
                         ;
            #endregion
            #region Beer 
            CreateMap<Beer, BeerVM>().ReverseMap()
                         .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
                         .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                         .ForMember(dest => dest.AlcoholContent, opt => opt.MapFrom(src => src.AlcoholContent))
                         .ForMember(dest => dest.SellingPrice, opt => opt.MapFrom(src => src.SellingPrice))
                         .ForMember(dest => dest.Brewery, opt => opt.MapFrom(src => src.Brewery))
                         .ForMember(dest => dest.BreweryId, opt => opt.MapFrom(src => src.BreweryId))
                         .ForMember(dest => dest.BeerStatus, opt => opt.MapFrom(src => src.BeerStatus))
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            #endregion
        }
    }
}