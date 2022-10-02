using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Filter;
using EssoOtomationProject.Models;
using EssoOtomationProject.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, Response<List<City>>>
    {
        private readonly EssoContext _context;

        public GetAllCitiesQueryHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<Response<List<City>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new PaginationFilter(request.Filter.PageNumber, request.Filter.PageSize);
            var pagedData = await _context.City
                .OrderBy(x => x.Id)
                .Skip((validFilter.PageNumber - 1) * (int)validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var result = new PagedResponse<List<City>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            return result;
        }
    }
}
