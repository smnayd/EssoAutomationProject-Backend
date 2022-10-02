using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
