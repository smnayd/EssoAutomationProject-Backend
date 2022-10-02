using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public User UpdateUser { get; set; }
    }
}
