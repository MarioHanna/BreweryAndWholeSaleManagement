using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Commands
{
    public class DeleteBeerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
