using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, City>
    {
        private readonly EssoContext _context;

        public DeleteCityCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var check = await _context.City.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (request.Id <= 0)
            {
                throw new Exception("You entered wrong number. Id has to be greater than 0.");
            }
            else if (check == null)
            {
                throw new Exception("This data is not in the database. We cannot delete it.");
            }
            _context.City.Remove(check);
            await _context.SaveChangesAsync();
            return check;

        }
    }
}
