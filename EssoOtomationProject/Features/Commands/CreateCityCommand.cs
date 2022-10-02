using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class CreateCityCommand : IRequest<City>
    {
        public City City { get; set; }
    }
}
