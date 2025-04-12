using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiCatalago.Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration configuration)
        {
            
            var key = configuration.GetSection("JWT").GetValue<string>("SecretKey") ?? string.Empty;
            var privateKey = Encoding.UTF8.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(privateKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(30);
            var token = new JwtSecurityToken(
                issuer: configuration.GetSection("JWT").GetValue<string>("Issuer"),
                audience: configuration.GetSection("JWT").GetValue<string>("Audience"),
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );
            return token;

        }
        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
