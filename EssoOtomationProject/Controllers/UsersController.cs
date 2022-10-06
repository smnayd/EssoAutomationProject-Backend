using AutoMapper;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EssoOtomationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
=======
                return BadRequest(ex);
>>>>>>> 67d43f943a2034e933274a7bc9358cebce6c2c28
            }
            
            
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByIdQuery { Id = id });
                return Ok(result);
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
=======
                return BadRequest(ex);
>>>>>>> 67d43f943a2034e933274a7bc9358cebce6c2c28
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> PutUser([FromBody] User user)
        {
            try
            {
                var command = new UpdateUserCommand() { UpdateUser = user };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
=======
                return BadRequest(ex);
>>>>>>> 67d43f943a2034e933274a7bc9358cebce6c2c28
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
=======
                return BadRequest(ex);
>>>>>>> 67d43f943a2034e933274a7bc9358cebce6c2c28
            }
            

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var command = new DeleteUserCommand() { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
=======
                return BadRequest(ex);
>>>>>>> 67d43f943a2034e933274a7bc9358cebce6c2c28
            }
            
        }

    }
}


