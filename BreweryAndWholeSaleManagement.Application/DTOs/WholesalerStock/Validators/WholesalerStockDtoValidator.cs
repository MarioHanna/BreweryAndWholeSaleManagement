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
        public int _requestedQuantity { get; set; }

        public WholesalerStockDtoValidator(IWholesalerStockRepository wholesalerStockRepository,int requestedQuantity)
        {
            _wholesalerStockRepository = wholesalerStockRepository;
            _requestedQuantity = requestedQuantity;

            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("The beer must be sold by the wholesaler.");

            RuleFor(p => p.Quantity)
                .GreaterThan(_requestedQuantity)
                .WithMessage("The number of beers ordered cannot be greater than the wholesaler's stock.");
        }
    }
}
