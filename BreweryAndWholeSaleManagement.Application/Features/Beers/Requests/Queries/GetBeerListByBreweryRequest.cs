using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Queries
{
    public class GetBeerListByBreweryRequest : IRequest<List<BeerDto>>
    {
        public int BreweryId { get; set; }
    }
}
