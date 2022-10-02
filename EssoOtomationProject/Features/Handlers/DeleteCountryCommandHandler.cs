using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Country>
    {
        private readonly EssoContext _context;

        public DeleteCountryCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var check = await _context.Country.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (request.Id <= 0)
            {
                throw new Exception("You entered wrong number. Id has to be greater than 0.");
            }
            else if (check == null)
            {
                throw new Exception("This data is not in the database. We cannot delete it.");
            }
            _context.Country.Remove(check);
            await _context.SaveChangesAsync();
            return check;
        }
    }
}
