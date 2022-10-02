using EssoOtomationProject.DTOs;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class LoginCommand : IRequest<AuthenticationDto>
    {
        public LoginCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
