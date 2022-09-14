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
    public class GetBeerListRequestHandler : IRequestHandler<GetBeerListRequest, List<BeerDto>>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public GetBeerListRequestHandler(IBeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task<List<BeerDto>> Handle(GetBeerListRequest request, CancellationToken cancellationToken)
        {
            var beerList = await _beerRepository.GetAll();
            return _mapper.Map<List<BeerDto>>(beerList);
        }
    }
}
