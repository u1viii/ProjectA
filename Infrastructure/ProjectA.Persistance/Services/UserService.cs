using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.Abstractions.Token;
using ProjectA.Application.DTOs.AppUsers;
using ProjectA.Application.DTOs.Token;
using ProjectA.Application.Exceptions;
using ProjectA.Application.Exceptions.CategoryExceptions;
using ProjectA.Application.Exceptions.UserExceptions;
using ProjectA.Core.Entities;
using ProjectA.Core.Entities.Identity;
using System.Collections.ObjectModel;

namespace ProjectA.Persistance.Services
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager { get; }
        SignInManager<AppUser> _singInManager { get; }
        ITokenHandler _tokenHandler { get; }
        ICategoryService _categoryService { get; }

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> singInManager,
            ITokenHandler tokenHandler,
            ICategoryService categoryService)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _tokenHandler = tokenHandler;
            _categoryService = categoryService;
        }

        public async Task<DTO_Token> LoginAsync(DTO_UserLogin login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.UsernameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(login.UsernameOrEmail);
                if (user is null)
                {
                    throw new AuthenticationException("Login ve ya shifre yalnishdir");
                }
            }
            if (!await _userManager.CheckPasswordAsync(user, login.Password))
                throw new AuthenticationException("Login ve ya shifre yalnishdir");
            var result = await _singInManager.PasswordSignInAsync(user, login.Password, true, true);
            if (!result.Succeeded)
            {
                throw new AuthenticationException();
            }
            DTO_Token token = _tokenHandler.CreateAccessToken(45, user);
            user.RefreshTokenExpires = token.Expires.AddMinutes(15);
            user.RefreshToken = token.RefreshToken;
            return token;
        }

        public async Task<DTO_Token> RefreshTokenLoginAsync(DTO_UserRefreshTokenLogin refreshTokenLogin)
        {
            refreshTokenLogin = refreshTokenLogin ?? throw new ArgumentNullException();
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshTokenLogin.RefreshToken);
            user = user ?? throw new ArgumentNullException();
            if (user.RefreshTokenExpires <= DateTime.UtcNow) throw new TokenExpiredException();
            DTO_Token token = _tokenHandler.CreateAccessToken(45, user);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpires = token.Expires.AddMinutes(15);
            return token;
        }

        public async Task<bool> RegisterAsync(DTO_UserRegister register)
        {
            if (register.IsCustomer == null && register.IsSupplier == null)
            {
                throw new UserCreateFailedException("Istifadechinin en az 1 rola sahib olmalidir");
            }
            if (!await _categoryService.ContainsAsync(c => register.CategoryIds.Contains(c.Id)))
            {
                throw new CategoryNotFoundException();
            }

            Collection<AppUserCategory> appUserCategories = new Collection<AppUserCategory>();

            AppUser user = new AppUser
            {
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                UserName = register.Username,
                IsMale = register.IsMale,
                PhoneNumber = register.Number,
                Company = register.Company,
                Position = register.Position,
                TIN = register.TIN,
                IsCustomer = register.IsCustomer,
                IsSupplier = register.IsSupplier
            };
            foreach (var catId in register.CategoryIds)
            {
                appUserCategories.Add(new AppUserCategory { CategoryId = catId, AppUser = user });
            }
            user.AppUserCategories = appUserCategories;
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                throw new UserCreateFailedException();
            }
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            user = user ?? throw new ArgumentNullException();
            return await RemoveAsync(user);
        }

        public async Task<bool> RemoveAsync(AppUser user)
        {
            user = user ?? throw new ArgumentNullException();
            if (await _userManager.FindByNameAsync(user.Email) == null) throw new UserNotFoundException();
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
