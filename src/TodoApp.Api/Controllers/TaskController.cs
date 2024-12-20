using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Queries.Tasks;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(IMediator _mediator) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllTask([FromQuery] GetallTaskQueryRequest getallTaskQueryRequest)
    {
        var result = await _mediator.Send(getallTaskQueryRequest);
        return Ok(result);
    }
}
