using AutoMapper;
using BreweryAndWholeSaleManagement.Application.Features.WholesalerStocks.Requests.Commands;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.WholesalerStocks.Handlers.Commands
{
    public class UpdateWholesalerStockCommandHandler : IRequestHandler<UpdateWholesalerStockCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWholesalerStockCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWholesalerStockCommand request, CancellationToken cancellationToken)
        {
            var oWholesalerStock = await _unitOfWork.wholesalerStockRepository.Get(request.updateWholesalerStockDto.Id);

            if (oWholesalerStock is null)
                throw new Exception(nameof(oWholesalerStock));

            _mapper.Map(request.updateWholesalerStockDto, oWholesalerStock);

            await _unitOfWork.wholesalerStockRepository.Update(oWholesalerStock);

            return Unit.Value;
        }
    }
}
