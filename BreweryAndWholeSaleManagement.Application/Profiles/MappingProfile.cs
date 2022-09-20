using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs;
using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock;
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
            CreateMap<Beer, CreateBeerDto>().ReverseMap();
            CreateMap<Beer, BeerListDTO>().ReverseMap();

            CreateMap<Brewery, BreweryDto>().ReverseMap();

            CreateMap<Wholesaler, WholesalerDto>().ReverseMap();

            CreateMap<WholesalerStock, WholesalerStockDto>().ReverseMap();
            CreateMap<WholesalerStock, CreateWholesalerStockDto>().ReverseMap();
        }
    }
}
