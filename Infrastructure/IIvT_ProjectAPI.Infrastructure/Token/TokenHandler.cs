using IIvT_ProjectAPI.Application.Abstractions.Token;
using IIvT_ProjectAPI.Application.DTOs.Token;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IIvT_ProjectAPI.Infrastructure.Token
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(AppUser appUser)
        {
            TokenDto token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.AccessTokenExpiration = DateTime.UtcNow
                .AddMinutes(Convert.ToDouble(_configuration["Token:AccessTokenExpiration"]));

            JwtSecurityToken securityToken = new(new JwtHeader(signingCredentials),
                new JwtPayload(
                    issuer: _configuration["Token:Issuer"],
                    audience: _configuration["Token:Audience"],
                    notBefore: DateTime.UtcNow,
                    expires: token.AccessTokenExpiration,
                    claims: new List<Claim> { new(ClaimTypes.Name, appUser.UserName) }
                ));

            JwtSecurityTokenHandler tokenHandler = new();

            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] bytes = new byte[32];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
                
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
