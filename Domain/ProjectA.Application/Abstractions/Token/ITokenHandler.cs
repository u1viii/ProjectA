using ProjectA.Application.DTOs.Token;

namespace ProjectA.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO_Token CreateAccessToken(int minute);
        string CreateRefreshToken();
    }
}
