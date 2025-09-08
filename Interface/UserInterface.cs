

using MyApiProject.DTO;

namespace MyApiProject.Interface;

public interface IUser
{
    Task<bool> RegisterUserAsync(UserDto userDto);
    Task<string?> LoginAsync(LoginDto loginDto);
}