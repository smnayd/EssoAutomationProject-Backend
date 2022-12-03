using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly EssoContext _context;

        public CreateCountryCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var check = await _context.Country.FirstOrDefaultAsync(c => c.Name == request.Country.Name);
            if (check != null)
            {
                throw new InvalidOperationException("You cannot add the same value");
            }
            _context.Country.Add(request.Country);
            await _context.SaveChangesAsync();
            return request.Country;

        }

    }
}
