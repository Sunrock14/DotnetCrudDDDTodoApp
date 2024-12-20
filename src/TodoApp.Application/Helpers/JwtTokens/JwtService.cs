using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TodoApp.Application.Helpers.JwtToken;

public class JwtManager : IJwtService
{
    //TODO : Appsetting'e taşınacak
    private string secret = "asdlkşgjasd";

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(GenerateClaims(user)),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string ValidateJwtToken(string token)
    {
        if (token == null)
            return null;
        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            },
            out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var username = jwtToken.Claims.First(x => x.Type == "username").Value;

            return username;
        }
        catch
        {
            return null;
        }
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        // TODO : Diğer bilgiler eklenebilir
        var claims = new ClaimsIdentity(new[] {
            new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.FirstName),
        }); ;

        return claims;
    }
}
