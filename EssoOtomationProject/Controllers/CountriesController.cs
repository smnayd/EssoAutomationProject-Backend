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
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Response<Country>>> GetAllCountry([FromQuery] PaginationFilter filter)
        {
            try
            {
                var result = await _mediator.Send(new GetAllCountriesQuery() { Filter = filter });
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCountryByIdQuery { Id = id });
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> PutCountry([FromBody] Country country)
        {
            try
            {
                var command = new UpdateCountryCommand() { UpdateCountry = country };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Country>> PostCountry([FromBody] Country country)
        {
            try
            {
                var command = new CreateCountryCommand() { Country = country };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var command = new DeleteCountryCommand() { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
