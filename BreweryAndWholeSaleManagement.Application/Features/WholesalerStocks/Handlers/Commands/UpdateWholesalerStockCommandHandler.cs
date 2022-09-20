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
        private readonly IWholesalerStockRepository _wholesalerStockRepository;
        private readonly IMapper _mapper;

        public UpdateWholesalerStockCommandHandler(IWholesalerStockRepository wholesalerStockRepository, IMapper mapper)
        {
            _wholesalerStockRepository = wholesalerStockRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWholesalerStockCommand request, CancellationToken cancellationToken)
        {
            var oWholesalerStock = await _wholesalerStockRepository.Get(request.updateWholesalerStockDto.Id);

            if (oWholesalerStock is null)
                throw new Exception(nameof(oWholesalerStock));

            _mapper.Map(request.updateWholesalerStockDto, oWholesalerStock);

            await _wholesalerStockRepository.Update(oWholesalerStock);

            return Unit.Value;
        }
    }
}
