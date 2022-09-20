using BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock;
using BreweryAndWholeSaleManagement.Application.Features.WholesalerStocks.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryAndWholeSaleManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalerStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WholesalerStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //// GET: api/<WholesalerStockController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<WholesalerStockController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<WholesalerStockController>
        [HttpPost("CreateWholesalerStock")]
        public async Task<ActionResult<int>> Post([FromBody] CreateWholesalerStockDto createWholesalerStockDto)
        {
            var command = new CreateWholesalerStockCommand { createWholesalerStockDto = createWholesalerStockDto };
            var Id = await _mediator.Send(command);
            return Ok(Id);
        }

        // PUT api/<WholesalerStockController>/5
        [HttpPut("UpdateWholesalerStock")]
        public async Task<ActionResult> Put([FromBody] UpdateWholesalerStockDto wholesalerStockDto)
        {
            var command = new UpdateWholesalerStockCommand { updateWholesalerStockDto = wholesalerStockDto };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
