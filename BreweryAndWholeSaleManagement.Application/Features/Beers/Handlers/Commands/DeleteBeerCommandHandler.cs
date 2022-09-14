using AutoMapper;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Commands;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.Beers.Handlers.Commands
{
    public class DeleteBeerCommandHandler : IRequestHandler<DeleteBeerCommand>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public DeleteBeerCommandHandler(IBeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = await _beerRepository.Get(request.Id);
            await _beerRepository.Delete(beer);
            return Unit.Value;
        }
    }
}
