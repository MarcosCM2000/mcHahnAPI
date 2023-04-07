using mcHahn.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace mcHahn.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(int id, string name)
        {
            var signingCredentials = new SigningCredentials(

                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
                SecurityAlgorithms.HmacSha256
            );
            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, name),
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };
            var securityToken = new JwtSecurityToken(
                issuer: "mcHahn",
                audience: null,
                claims: claims,
                notBefore: null,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken( securityToken );
        }
    }
}
