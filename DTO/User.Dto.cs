using System.ComponentModel.DataAnnotations;
using MyApiProject.Model.Enum;

namespace MyApiProject.DTO;
  public class UserDto
    {
      
        public required string Username { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

public class LoginDto
{
  [EmailAddress]
  public required string Email { get; set; }
  public required string Password { get; set; }
    public Role Roles { get; set; }
    }
    //ok