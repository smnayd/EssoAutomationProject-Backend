using EssoOtomationProject.DTOs;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public RegisterCommand(string username, string password, string firstname, string lastname, string email)
        {
            UserName = username;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

