using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>  
    /// Kullanıcı kaydı yapar.  
    /// </summary>  
    /// <param name="registerRequest">Kullanıcı kayıt bilgileri</param>  
    /// <returns>Kayıt işleminin sonucu</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        // Kayıt işlemi için mediator kullanımı  
        var result = await _mediator.Send(registerRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Kullanıcı giriş yapar ve JWT token döner.  
    /// </summary>  
    /// <param name="loginRequest">Kullanıcı giriş bilgileri</param>  
    /// <returns>JWT token</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        // Giriş işlemi için mediator kullanımı  
        var result = await _mediator.Send(loginRequest);
        return Ok(result);
    }

    /// <summary>  
    /// JWT token yeniler.  
    /// </summary>  
    /// <param name="refreshTokenRequest">Yenileme token bilgileri</param>  
    /// <returns>Yeni JWT token</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
    {
        // Token yenileme işlemi için mediator kullanımı  
        var result = await _mediator.Send(refreshTokenRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Kullanıcıyı sistemden çıkış yapar (Refresh token iptali gibi işlemler yapılabilir).  
    /// </summary>  
    /// <returns>Çıkış işleminin sonucu</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> Logout()
    {
        // Çıkış işlemi için mediator kullanımı  
        var result = await _mediator.Send(new LogoutRequest());
        return Ok(result);
    }
}

//Geçici olarak bur kalsın
public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; }
}


public class LogoutRequest
{
}