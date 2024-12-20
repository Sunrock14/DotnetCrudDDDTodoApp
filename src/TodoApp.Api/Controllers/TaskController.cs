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
    /// Tüm görevleri listeler.  
    /// </summary>  
    /// <param name="getAllTaskQueryRequest">Filtreleme ve sýralama için isteðe baðlý parametreler</param>  
    /// <returns>Görevlerin listesi</returns>  
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllTasks([FromQuery] GetAllTaskQueryRequest getAllTaskQueryRequest)
    {
        var result = await _mediator.Send(getAllTaskQueryRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Yeni bir görev ekler.  
    /// </summary>  
    /// <param name="addTaskRequest">Görev bilgileri</param>  
    /// <returns>Eklenen görevin bilgileri</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> AddNewTask([FromBody] AddTaskRequest addTaskRequest)
    {
        var result = await _mediator.Send(addTaskRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Mevcut bir görevi günceller.  
    /// </summary>  
    /// <param name="updateTaskRequest">Güncellenecek görev bilgileri</param>  
    /// <returns>Güncellenen görevin bilgileri</returns>  
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest updateTaskRequest)
    {
        var result = await _mediator.Send(updateTaskRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir görevi siler.  
    /// </summary>  
    /// <param name="id">Silinecek görevin ID'si</param>  
    /// <returns>Silme iþleminin sonucu</returns>  
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteTask([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteTaskRequest { Id = id });
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir görevi ID ile getirir.  
    /// </summary>  
    /// <param name="id">Görevin ID'si</param>  
    /// <returns>Görevin bilgileri</returns>  
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetTaskById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetTaskByIdRequest { Id = id });
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir görevi bir kullanýcýya atar.  
    /// </summary>  
    /// <param name="assignTaskRequest">Görev ve kullanýcý bilgileri</param>  
    /// <returns>Atama iþleminin sonucu</returns>  
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