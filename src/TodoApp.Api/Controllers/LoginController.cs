using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>  
    /// Tüm kullanıcıları listeler.  
    /// </summary>  
    /// <returns>Kullanıcıların listesi</returns>  
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersRequest());
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir kullanıcıyı ID ile getirir.  
    /// </summary>  
    /// <param name="id">Kullanıcının ID'si</param>  
    /// <returns>Kullanıcı bilgileri</returns>  
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetUserByIdRequest { Id = id });
        return Ok(result);
    }

    /// <summary>  
    /// Yeni bir kullanıcı ekler.  
    /// </summary>  
    /// <param name="addUserRequest">Kullanıcı bilgileri</param>  
    /// <returns>Eklenen kullanıcının bilgileri</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> AddNewUser([FromBody] AddUserRequest addUserRequest)
    {
        var result = await _mediator.Send(addUserRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Mevcut bir kullanıcıyı günceller.  
    /// </summary>  
    /// <param name="updateUserRequest">Güncellenecek kullanıcı bilgileri</param>  
    /// <returns>Güncellenen kullanıcının bilgileri</returns>  
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
    {
        var result = await _mediator.Send(updateUserRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir kullanıcıyı ID ile siler.  
    /// </summary>  
    /// <param name="id">Silinecek kullanıcının ID'si</param>  
    /// <returns>Silme işleminin sonucu</returns>  
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteUserByIdRequest { Id = id });
        return Ok(result);
    }
}

public class GetAllUsersRequest : IRequest<List<UserDto>>
{
    public string? UsernameFilter { get; set; } = null;
    public string? EmailFilter { get; set; } = null;
    public string SortBy { get; set; } = "Id";
    public bool IsAscending { get; set; } = true;
    public int Size { get; set; } = 10;
    public int Page = 1;
}

public class GetUserByIdRequest : IRequest<UserDto>
{
    public int Id { get; set; }
}

public class AddUserRequest : IRequest<UserDto>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UpdateUserRequest : IRequest<UserDto>
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class DeleteUserByIdRequest : IRequest<bool>
{
    public int Id { get; set; }
}

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}