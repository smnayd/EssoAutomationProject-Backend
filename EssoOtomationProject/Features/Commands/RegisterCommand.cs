using EssoOtomationProject.DTOs;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public RegisterCommand(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

