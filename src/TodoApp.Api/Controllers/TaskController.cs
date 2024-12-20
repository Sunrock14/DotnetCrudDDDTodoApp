using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>  
    /// T�m g�revleri listeler.  
    /// </summary>  
    /// <param name="getAllTaskQueryRequest">Filtreleme ve s�ralama i�in iste�e ba�l� parametreler</param>  
    /// <returns>G�revlerin listesi</returns>  
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllTasks([FromQuery] GetAllTaskQueryRequest getAllTaskQueryRequest)
    {
        var result = await _mediator.Send(getAllTaskQueryRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Yeni bir g�rev ekler.  
    /// </summary>  
    /// <param name="addTaskRequest">G�rev bilgileri</param>  
    /// <returns>Eklenen g�revin bilgileri</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> AddNewTask([FromBody] AddTaskRequest addTaskRequest)
    {
        var result = await _mediator.Send(addTaskRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Mevcut bir g�revi g�nceller.  
    /// </summary>  
    /// <param name="updateTaskRequest">G�ncellenecek g�rev bilgileri</param>  
    /// <returns>G�ncellenen g�revin bilgileri</returns>  
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest updateTaskRequest)
    {
        var result = await _mediator.Send(updateTaskRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir g�revi siler.  
    /// </summary>  
    /// <param name="id">Silinecek g�revin ID'si</param>  
    /// <returns>Silme i�leminin sonucu</returns>  
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteTask([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteTaskRequest { Id = id });
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir g�revi ID ile getirir.  
    /// </summary>  
    /// <param name="id">G�revin ID'si</param>  
    /// <returns>G�revin bilgileri</returns>  
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetTaskById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetTaskByIdRequest { Id = id });
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir g�revi bir kullan�c�ya atar.  
    /// </summary>  
    /// <param name="assignTaskRequest">G�rev ve kullan�c� bilgileri</param>  
    /// <returns>Atama i�leminin sonucu</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> AssignTaskToUser([FromBody] AssignTaskRequest assignTaskRequest)
    {
        var result = await _mediator.Send(assignTaskRequest);
        return Ok(result);
    }
}


public class GetAllTaskQueryRequest
{
    public string? Filter { get; set; }
    public string? SortBy { get; set; }
    public bool? IsAscending { get; set; }
}

public class AddTaskRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }
}

public class UpdateTaskRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }
}

public class DeleteTaskRequest
{
    public int Id { get; set; }
}

public class GetTaskByIdRequest
{
    public int Id { get; set; }
}

public class AssignTaskRequest
{
    public int TaskId { get; set; }
    public int UserId { get; set; }
}