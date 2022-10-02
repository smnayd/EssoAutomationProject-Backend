using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly EssoContext _context;

        public DeleteUserCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var check = await _context.User.FirstOrDefaultAsync(u => u.Id == request.Id);
            if (request.Id <= 0)
            {
                throw new Exception("You entered wrong number. Id has to be greater than 0.");
            }
            else if (check == null)
            {
                throw new Exception("This data is not in the database. We cannot delete it.");
            }
            _context.User.Remove(check);
            await _context.SaveChangesAsync();
            return check;
        }
    }
}
