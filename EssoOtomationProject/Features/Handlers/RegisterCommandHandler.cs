using AutoMapper;
using EssoOtomationProject.Data;
using EssoOtomationProject.DTOs;
using EssoOtomationProject.Features.Commands;
using EssoOtomationProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Features.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
    {
        private readonly EssoContext _context;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(EssoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            var check = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (check == null)
            {
                user.Email = request.Email;
                user.Password = request.Password;
                user.Name = request.Name;
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<RegisterDto>(user);
            }

            return null;
        }
    }
}
