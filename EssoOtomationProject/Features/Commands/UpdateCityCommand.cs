using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class UpdateCityCommand : IRequest<City>
    {
        public City UpdateCity { get; set; }
    }
}
