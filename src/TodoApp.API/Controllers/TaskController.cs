using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Commands.Users.UserCreate;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            var result = _mediator.Send(createUserCommandRequest);  
            return Ok(result);
        }
    }
}
