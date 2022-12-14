using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Commands
{
    public class CreateBeerCommand : IRequest<int>
    {
        public CreateBeerDto CreateBeerDto { get; set; }
    }
}
