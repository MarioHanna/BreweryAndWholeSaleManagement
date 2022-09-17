using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BeerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<BeerController>/5
        [HttpGet("GetBeerListByBrewery/{BreweryId}")]
        public async Task<ActionResult<List<BeerDto>>> GetBeerListByBrewery(int BreweryId)
        {
            var BeerList = await _mediator.Send(new GetBeerListByBreweryRequest
            {
                BreweryId = BreweryId
            });

            return Ok(BeerList);
        }

        // POST api/<BeerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BeerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BeerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
