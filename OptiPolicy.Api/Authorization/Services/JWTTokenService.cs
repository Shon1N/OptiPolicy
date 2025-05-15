using Microsoft.IdentityModel.Tokens;
using OptiPolicy.Api.Authorization.Services.Interfaces;
using OptiPolicy.Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OptiPolicy.Api.Authorization.Services
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly IConfiguration _config;
        public JWTTokenService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GenerateJwtToken(UserDto user, DateTime expiryDate)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("aud", _config.GetSection("AppSettings:Audience").Value),
                new Claim("iss", _config.GetSection("AppSettings:Issuer").Value)
            };

            var permissions = user.UserGroups.SelectMany(x => x.Group.GroupPermissions.Select(x => x.Permission.Name));

            foreach (var permission in permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, permission));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiryDate,
                SigningCredentials = creds,
                Audience = _config.GetSection("AppSettings:Audience").Value,
                Issuer = _config.GetSection("AppSettings:Issuer").Value
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
