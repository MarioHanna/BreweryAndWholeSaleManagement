using BreweryAndWholeSaleManagement.Application.DTOs.Request;
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
        public async Task<ActionResult<int>> Post([FromBody] ClientRequestDto clientRequestDto)
        {
            var command = "";
            var Id = await _mediator.Send(command);
            return Ok(Id);
        }
    }
}
