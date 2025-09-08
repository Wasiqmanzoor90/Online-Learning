
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using MyApiProject.Controller;
using MyApiProject.Data;
using MyApiProject.DTO;
using MyApiProject.Interface;

namespace MyApiProject.Service.AuthService;


public class UserService(SqlDbContext dbContext, IJsonToken tokenservice, IHttpContextAccessor httpContextAccessor) : IUser
{
    private readonly SqlDbContext _dbcontext = dbContext;
    private readonly IJsonToken _tokenservice = tokenservice;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;



    public async Task<bool> RegisterUserAsync(UserDto userDto)
    {
        try
        {
            var findUser = await _dbcontext.Users.FirstOrDefaultAsync(e => e.Email == userDto.Email);
            if (findUser != null)
            {
                return false;
            }
            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password

            };
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

             throw new Exception("server error"+ ex.Message);
        }
    }
    




     public async Task<string?> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var findUser = await _dbcontext.Users.FirstOrDefaultAsync(e => e.Email == loginDto.Email);
            if (findUser == null)
            {
                return null;
            }
            var pass = BCrypt.Net.BCrypt.Verify(loginDto.Password,findUser.Password);
            if (!pass)
            {
                return null;
            }

            var token = _tokenservice.CreateToken(findUser.UserId, findUser.Username, findUser.Email);

            // Set cookie in response
            var response = _httpContextAccessor.HttpContext?.Response;
            response?.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // Set to true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddHours(10)
            });
            return token;
        }
        catch (Exception ex)
        {

            throw new Exception("server error" + ex.Message);
        }
    }
}