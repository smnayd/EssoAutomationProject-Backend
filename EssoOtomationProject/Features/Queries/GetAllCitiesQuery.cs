using EssoOtomationProject.Filter;
using EssoOtomationProject.Models;
using EssoOtomationProject.Wrappers;
using MediatR;

namespace EssoOtomationProject.Features.Queries
{
    public class GetAllCitiesQuery : IRequest<Response<List<City>>>
    {
        public PaginationFilter Filter { get; set; }
    }
}
