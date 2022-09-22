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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBeerListByBreweryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BeerListDTO>> Handle(GetBeerListByBreweryRequest request, CancellationToken cancellationToken)
        {
            var beerList = await _unitOfWork.BeerRepository.GetBeerListByBrewery(request.BreweryId);
            return _mapper.Map<List<BeerListDTO>>(beerList);
        }
    }
}
