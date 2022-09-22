using BreweryAndWholeSaleManagement.Application.DTOs.Request;
using BreweryAndWholeSaleManagement.Application.Features.ClientRequests.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreweryAndWholeSaleManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("RequestQuote")]
        public async Task<ActionResult<QuoteRequestResultDto>> Post([FromBody] ClientRequestDto clientRequestDto)
        {
            var command = new QuoteRequestCommand { clientRequestDto = clientRequestDto};
            QuoteRequestResultDto quoteRequestResultDto = await _mediator.Send(command);
            return Ok(quoteRequestResultDto);
        }
    }
}
