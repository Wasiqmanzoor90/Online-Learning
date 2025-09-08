using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyApiProject.Interface;

namespace MyApiProject.Service.TokenService;

public class TokenService : IJsonToken
{

    private readonly string _secretkey;
    public TokenService(IConfiguration configuration)
    {
        _secretkey = configuration["JWT:SecretKey"] ?? throw new InvalidOperationException("JWT Secret Key is missing in configuration.");
    }

    public string CreateToken(Guid Id, string Username, string Email)
    {
        try
        {
            var tokeHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_secretkey);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Email, Email)
            }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokeHandler.CreateToken(tokendescriptor);
            return tokeHandler.WriteToken(token);
        }
        catch (Exception ex)
        {

            throw new Exception("Server error: " + ex.Message);
        }
    }

    public Guid VerifyToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_secretkey);
            var validToken = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key)

            };
            var principal = tokenHandler.ValidateToken(token, validToken, out var validatedToken);
            var useridclaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (useridclaim != null)
            {
                return new Guid(useridclaim.Value);
            }

            else
            {
                throw new Exception("User ID not found in token.");


            }
        }
        catch (Exception ex)
        {

            throw new Exception("Server error: " + ex.Message);
        }
    }
}
