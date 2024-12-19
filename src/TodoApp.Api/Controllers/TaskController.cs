using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Queries.Tasks;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController(IMediator _mediator) : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast111")]
        public IActionResult Get([FromQuery] GetallTaskQueryRequest getallTaskQueryRequest)
        {
            var result = _mediator.Send(getallTaskQueryRequest);
            return Ok(result);
        }
    }
}
