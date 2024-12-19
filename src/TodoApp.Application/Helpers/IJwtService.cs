namespace TodoApp.Application.Helpers;

public interface IJwtService
{
    public string GenerateJwtToken(User user);
    public string ValidateJwtToken(string token);
}
