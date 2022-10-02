using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class CreateCountryCommand : IRequest<Country>
    {
        public Country Country { get; set; }
    }
}
