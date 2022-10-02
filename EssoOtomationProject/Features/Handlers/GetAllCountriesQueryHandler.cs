using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Filter;
using EssoOtomationProject.Models;
using EssoOtomationProject.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, Response<List<Country>>>
    {
        private readonly EssoContext _context;

        public GetAllCountriesQueryHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Country>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new PaginationFilter(request.Filter.PageNumber, request.Filter.PageSize);
            var pagedData = await _context.Country
                .OrderBy(c => c.Id)
                .Skip((validFilter.PageNumber - 1) * (int)validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            return new PagedResponse<List<Country>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
