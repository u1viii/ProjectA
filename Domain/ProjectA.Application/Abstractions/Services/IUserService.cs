using ProjectA.Application.DTOs.AppUsers;
using ProjectA.Application.DTOs.Token;
using ProjectA.Core.Entities.Identity;

namespace ProjectA.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(DTO_UserRegister register);
        Task<DTO_Token> LoginAsync(DTO_UserLogin login);
        Task<DTO_Token> RefreshTokenLoginAsync(DTO_UserRefreshTokenLogin refreshTokenLogin);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> RemoveAsync(AppUser user);
    }
}
