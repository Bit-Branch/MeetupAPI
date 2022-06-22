using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventsManagement.Application.Responses;
using EventsManagement.Application.Settings;

namespace EventsManagement.Application.Services
{
    public class JwtService
    {
        private readonly JwtSettings _options;

        public JwtService(IOptions<JwtSettings> options)
        {
            _options = options.Value;
        }

        public string CreateToken(string claimSid, string claimName)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, claimName),
                new(ClaimTypes.Sid, claimSid)
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey)),
                SecurityAlgorithms.HmacSha256
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_options.ExpireIn),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
