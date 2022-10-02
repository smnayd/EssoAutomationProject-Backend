using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
