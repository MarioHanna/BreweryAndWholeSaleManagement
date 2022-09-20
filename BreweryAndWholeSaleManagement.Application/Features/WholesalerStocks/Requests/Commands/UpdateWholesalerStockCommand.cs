using BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.WholesalerStocks.Requests.Commands
{
    public class UpdateWholesalerStockCommand : IRequest<Unit>
    {
        public UpdateWholesalerStockDto updateWholesalerStockDto { get; set; }
    }
}
