using AutoMapper;
using BeerEShop.Services.Catalogs.Application.Features.Breweries;
using BeerEShop.Services.Catalogs.Domain.Entities;
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
        }
    }
}