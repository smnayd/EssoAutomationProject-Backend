using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Filter;
using EssoOtomationProject.Models;
using EssoOtomationProject.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            try
            {
                var result = await _mediator.Send(new GetAllCitiesQuery() { Filter = filter });
                return Ok(result);
            }
            catch(Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); ;

            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCityByIdQuery { Id = id });
                return Ok(result);
            }
            catch(Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> PutCity([FromBody] City city)
        {
            try
            {
                var command = new UpdateCityCommand() { UpdateCity = city };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
            
        }

        [HttpPost("Create")]
        public async Task<ActionResult<City>> PostCity([FromBody] City city)
        {
            try
            {
                var command = new CreateCityCommand() { City = city };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
            
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var command = new DeleteCityCommand() { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

            }
            
        }
    }
}
