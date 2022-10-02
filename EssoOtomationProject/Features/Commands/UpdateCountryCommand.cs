using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class UpdateCountryCommand : IRequest<Country>
    {
        public Country UpdateCountry { get; set; }
    }
}
