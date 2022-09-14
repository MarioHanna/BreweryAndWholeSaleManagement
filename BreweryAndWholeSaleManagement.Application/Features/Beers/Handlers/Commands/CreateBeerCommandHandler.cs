using AutoMapper;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Commands;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.Beers.Handlers.Commands
{
    public class CreateBeerCommandHandler : IRequestHandler<CreateBeerCommand, int>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public CreateBeerCommandHandler(IBeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = _mapper.Map<Beer>(request.CreateBeerDto);
            beer = await _beerRepository.Add(beer);
            return beer.Id;
        }
    }
}
