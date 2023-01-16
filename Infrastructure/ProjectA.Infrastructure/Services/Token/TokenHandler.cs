using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectA.Application.Abstractions.Token;
using ProjectA.Application.DTOs.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProjectA.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DTO_Token CreateAccessToken(int minute)
        {
            DTO_Token token = new DTO_Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SigningKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            token.Expires = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires:token.Expires,
                notBefore:DateTime.UtcNow,
                signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            token.AccessToken = handler.WriteToken(securityToken);
            return token;
        }
    }
}
