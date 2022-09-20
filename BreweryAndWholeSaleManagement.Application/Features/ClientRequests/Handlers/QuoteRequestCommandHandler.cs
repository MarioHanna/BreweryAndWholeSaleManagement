using BreweryAndWholeSaleManagement.Application.DTOs.Request;
using BreweryAndWholeSaleManagement.Application.Features.ClientRequests.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.ClientRequests.Handlers
{
    public class QuoteRequestCommandHandler : IRequestHandler<QuoteRequestCommand, QuoteRequestResultDto>
    {
        public Task<QuoteRequestResultDto> Handle(QuoteRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
