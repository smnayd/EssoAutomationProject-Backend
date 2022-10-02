using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Queries
{
    public class GetCityByIdQuery : IRequest<City>
    {
        public int Id { get; set; }
    }
}
