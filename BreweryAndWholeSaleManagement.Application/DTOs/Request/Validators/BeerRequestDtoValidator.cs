using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request.Validators
{
    public class BeerRequestDtoValidator : AbstractValidator<BeerRequestDto>
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IWholesalerRepository _wholesalerRepository;

        public BeerRequestDtoValidator(
            IWholesalerRepository wholesalerRepository,
            IBeerRepository beerRepository)
        {
            _wholesalerRepository = wholesalerRepository;
            _beerRepository = beerRepository;

            RuleFor(p => p.WholesalerId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var wholesalerExists = await _wholesalerRepository.Exists(id);
                    return wholesalerExists;
                })
                .WithMessage("The {PropertyName} must exist.");

            RuleFor(p => p.BeerId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var BeerExists = await _beerRepository.Exists(id);
                    return BeerExists;
                })
                .WithMessage("The {PropertyName} must exist.");

        }
    }
}
