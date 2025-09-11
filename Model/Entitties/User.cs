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
        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }
        public Role Role { get; set; } = Role.Client;

        public ICollection<Result> Results { get; set; } = new List<Result>(); //lis one user can multiple result
        public ICollection<Question> Question { get; set; } = new List<Question>();

     }
}