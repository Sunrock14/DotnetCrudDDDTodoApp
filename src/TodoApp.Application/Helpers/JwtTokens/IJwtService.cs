namespace TodoApp.Application.Helpers.JwtToken;

public interface IJwtService
{
    public string GenerateJwtToken(User user);
    public string ValidateJwtToken(string token);
}
