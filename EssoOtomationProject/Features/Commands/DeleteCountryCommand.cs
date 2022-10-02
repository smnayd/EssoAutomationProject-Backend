using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Commands
{
    public class DeleteCountryCommand : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
