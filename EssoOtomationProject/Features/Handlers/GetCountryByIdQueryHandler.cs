using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Handlers
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly EssoContext _context;

        public GetCountryByIdQueryHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Country.FindAsync(request.Id);
            return result;
        }
    }
}
