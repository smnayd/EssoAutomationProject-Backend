using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Queries
{
    public class GetCountryByIdQuery : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
