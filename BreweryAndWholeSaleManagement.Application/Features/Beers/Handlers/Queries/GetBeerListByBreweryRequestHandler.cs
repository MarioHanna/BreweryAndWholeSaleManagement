using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Queries;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.Beers.Handlers.Queries
{
    public class GetBeerListByBreweryRequestHandler : IRequestHandler<GetBeerListByBreweryRequest, List<BeerListDTO>>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public GetBeerListByBreweryRequestHandler(IBeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task<List<BeerListDTO>> Handle(GetBeerListByBreweryRequest request, CancellationToken cancellationToken)
        {
            var beerList = await _beerRepository.GetBeerListByBrewery(request.BreweryId);
            return _mapper.Map<List<BeerListDTO>>(beerList);
        }
    }
}
