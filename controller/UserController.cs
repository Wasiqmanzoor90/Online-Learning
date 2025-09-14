
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.Data;
using MyApiProject.DTO;
using MyApiProject.Interface;
using MyApiProject.Model;


namespace MyApiProject.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUser user) : ControllerBase
{

    private readonly IUser _user = user;


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        var res = await _user.RegisterUserAsync(userDto);
        if (!res)
        {
            return BadRequest("User with this email already exists.");
        }

        return Ok("User registered successfully.");
    }


    

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _user.LoginAsync(loginDto);
        if (string.IsNullOrEmpty(token))
        {
            return BadRequest("Invalid email or password.");
        }

        return Ok(new { message = "Login sucessfull", token, role = loginDto.Roles.ToString()});
    }
}