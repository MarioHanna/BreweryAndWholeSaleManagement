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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBeerListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BeerDto>> Handle(GetBeerListRequest request, CancellationToken cancellationToken)
        {
            var beerList = await _unitOfWork.BeerRepository.GetAll();
            return _mapper.Map<List<BeerDto>>(beerList);
        }
    }
}
