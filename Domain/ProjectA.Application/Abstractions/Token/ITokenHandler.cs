using ProjectA.Application.DTOs.Token;
using ProjectA.Core.Entities.Identity;

namespace ProjectA.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO_Token CreateAccessToken(int minute, AppUser user);
        string CreateRefreshToken();
    }
}
