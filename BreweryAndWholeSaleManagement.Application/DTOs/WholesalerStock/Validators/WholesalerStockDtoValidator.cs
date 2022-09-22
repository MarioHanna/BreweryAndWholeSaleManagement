using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock.Validators
{
    public class WholesalerStockDtoValidator : AbstractValidator<WholesalerStockDto>
    {
        private readonly IWholesalerStockRepository _wholesalerStockRepository;

        public WholesalerStockDtoValidator(IWholesalerStockRepository wholesalerStockRepository)
        {
            _wholesalerStockRepository = wholesalerStockRepository;


        }
    }
}
