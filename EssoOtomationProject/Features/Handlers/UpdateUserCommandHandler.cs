using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly EssoContext _context;

        public UpdateUserCommandHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _context.User.Update(request.UpdateUser);
            await _context.SaveChangesAsync();
            return request.UpdateUser;

        }
    }
}
