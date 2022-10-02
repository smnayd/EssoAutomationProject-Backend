using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Filter;
using EssoOtomationProject.Models;
using EssoOtomationProject.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EssoOtomationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Response<City>>> GetAllCity([FromQuery] PaginationFilter filter)
        {
            var result = await _mediator.Send(new GetAllCitiesQuery() { Filter = filter });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var result = await _mediator.Send(new GetCityByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> PutCity([FromBody] City city)
        {
            var command = new UpdateCityCommand() { UpdateCity = city };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<City>> PostCity([FromBody] City city)
        {
            var command = new CreateCityCommand() { City = city };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var command = new DeleteCityCommand() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
