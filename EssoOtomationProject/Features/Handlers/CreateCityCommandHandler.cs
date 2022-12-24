using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, City>
    {
        private readonly EssoContext _context;

        public CreateCityCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var check = await _context.City.FirstOrDefaultAsync(c => c.Name == request.City.Name);

            _context.City.Add(request.City);
            await _context.SaveChangesAsync();
            return request.City;
        }
    }
}
