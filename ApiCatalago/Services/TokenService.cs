using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ApiCatalago.Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration configuration)
        {
            
            var key = configuration.GetSection("JWT").GetValue<string>("SecretKey") ?? string.Empty;
            

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
