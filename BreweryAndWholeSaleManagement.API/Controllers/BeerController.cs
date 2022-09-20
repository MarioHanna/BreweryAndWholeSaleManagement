using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Commands;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryAndWholeSaleManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BeerController>
        [HttpGet("GetBeerList")]
        public async Task<ActionResult<List<BeerDto>>> GetAsync()
        {
            var BeerList = await _mediator.Send(new GetBeerListRequest());

            return Ok(BeerList);
        }

        // GET api/<BeerController>/5
        [HttpGet("GetBeerListByBrewery/{BreweryId}")]
        public async Task<ActionResult<List<BeerListDTO>>> GetBeerListByBrewery(int BreweryId)
        {
            var BeerList = await _mediator.Send(new GetBeerListByBreweryRequest
            {
                BreweryId = BreweryId
            });

            return Ok(BeerList);
        }

        // POST api/<BeerController>
        [HttpPost("AddNewBeer")]
        public async Task<ActionResult<int>> Post([FromBody] CreateBeerDto createBeerDto)
        {
            var command = new CreateBeerCommand { CreateBeerDto = createBeerDto };
            var Id = await _mediator.Send(command);
            return Ok(Id);
        }

        //// PUT api/<BeerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<BeerController>/5
        [HttpDelete("DeleteBeer/{BeerId}")]
        public async Task<ActionResult> Delete(int BeerId)
        {
            var command = new DeleteBeerCommand { Id = BeerId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
