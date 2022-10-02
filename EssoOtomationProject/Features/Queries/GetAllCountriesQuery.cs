using EssoOtomationProject.Filter;
using EssoOtomationProject.Models;
using EssoOtomationProject.Wrappers;
using MediatR;

namespace EssoOtomationProject.Features.Queries
{
    public class GetAllCountriesQuery : IRequest<Response<List<Country>>>
    {
        public PaginationFilter Filter { get; set; }
    }
    
}
