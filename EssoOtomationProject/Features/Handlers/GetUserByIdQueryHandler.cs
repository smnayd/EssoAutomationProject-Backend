using EssoOtomationProject.Data;
using EssoOtomationProject.Features.Queries;
using EssoOtomationProject.Models;
using MediatR;

namespace EssoOtomationProject.Features.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly EssoContext _context;

        public GetUserByIdQueryHandler(EssoContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.User.FindAsync(request.Id);
            return result;
        }
    }
}
