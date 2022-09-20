using BreweryAndWholeSaleManagement.Application.DTOs.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.ClientRequests.Requests
{
    public class QuoteRequestCommand : IRequest<QuoteRequestResultDto>
    {
        public ClientRequestDto clientRequestDto { get; set; }
    }
}
