using AutoMapper;
using BreweryAndWholeSaleManagement.Application.Features.WholesalerStocks.Requests.Commands;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.WholesalerStocks.Handlers.Commands
{
    public class CreateWholesalerStockCommandHandler : IRequestHandler<CreateWholesalerStockCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWholesalerStockCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateWholesalerStockCommand request, CancellationToken cancellationToken)
        {
            var wholesalerStock = _mapper.Map<WholesalerStock>(request.createWholesalerStockDto);
            wholesalerStock = await _unitOfWork.wholesalerStockRepository.Add(wholesalerStock);
            return wholesalerStock.Id;
        }
    }
}
