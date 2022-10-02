using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Handlers
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, City>
    {
        private readonly EssoContext _context;

        public GetCityByIdQueryHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.City.FindAsync(request.Id);
            return result;
        }
    }
}
