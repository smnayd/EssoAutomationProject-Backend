using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class DeleteCityCommand : IRequest<City>
    {
        public int Id { get; set; }
    }
}
