using EssoOtomationProject.Data;
using EssoOtomationProject.DTOs;
using EssoOtomationProject.Features.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EssoOtomationProject.Features.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationDto>
    {
        private readonly EssoContext _context;
        private readonly IConfiguration _config;

        public LoginCommandHandler(EssoContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthenticationDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usernameCheck = await _context.User.FirstOrDefaultAsync(u => u.UserName == request.UserName);
            var passwordCheck = await _context.User.FirstOrDefaultAsync(u => u.Password == request.Password);
            if (usernameCheck == null && passwordCheck == null)
            {
                return new AuthenticationDto { HasError = true };
            }

            var secureKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var securityKey = new SymmetricSecurityKey(secureKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(_config["Jwt:Audience"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            var newToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new AuthenticationDto { Token = newToken };

        }
    }
}
