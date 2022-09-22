using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request.Validators
{
    public class ClientRequestDtoValidator : AbstractValidator<ClientRequestDto>
    {
        public ClientRequestDtoValidator()
        {
            RuleFor(p => p.BeerRequestList.Count)
                .GreaterThan(0)
                .WithMessage("The order cannot be empty");

            RuleFor(p => p.BeerRequestList).Must(p => !IsDuplicate(p))
                .WithMessage("There can't be any duplicate in the order");
        }

        private bool IsDuplicate(List<BeerRequestDto> beerRequestList)
        {
            return beerRequestList.GroupBy(n => n.WholesalerId & n.BeerId).Any(c => c.Count() > 1);
        }
    }
}
