using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Handlers
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly EssoContext _context;

        public UpdateCountryCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            _context.Country.Update(request.UpdateCountry);
            await _context.SaveChangesAsync();
            return request.UpdateCountry;
        }
    }
}
