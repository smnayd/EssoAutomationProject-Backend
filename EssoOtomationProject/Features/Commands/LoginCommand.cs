using EssoOtomationProject.DTOs;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class LoginCommand : IRequest<AuthenticationDto>
    {
        public LoginCommand(string username, string password)
        {
            Name = username;
            Password = password;
        }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
