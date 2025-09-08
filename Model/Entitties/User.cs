using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MyApiProject.Model.Entitties;
using MyApiProject.Model.Enum;

namespace MyApiProject.Controller
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public required string Username{ get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }
        public Role Role { get; set; } = Role.Client;

        public Result? Result { get; set; }
     }
}