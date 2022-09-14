using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs;
using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Beer, BeerDto>().ReverseMap();
            CreateMap<Brewery, BreweryDto>().ReverseMap();
            CreateMap<Wholesaler, WholesalerDto>().ReverseMap();
            CreateMap<WholesalerStock, WholesalerStockDto>().ReverseMap();
        }
    }
}
