using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiCatalago.Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration configuration)
        {
            throw new NotImplementedException();
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
    {
    }
}
