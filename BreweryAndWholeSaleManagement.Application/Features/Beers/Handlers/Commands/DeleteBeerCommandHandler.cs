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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBeerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = await _unitOfWork.BeerRepository.Get(request.Id);
            await _unitOfWork.BeerRepository.Delete(beer);
            return Unit.Value;
        }
    }
}
