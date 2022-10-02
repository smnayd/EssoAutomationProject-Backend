using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Handlers
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, City>
    {
        private readonly EssoContext _context;

        public UpdateCityCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            _context.City.Update(request.UpdateCity);
            await _context.SaveChangesAsync();
            return request.UpdateCity;
        }
    }
}
