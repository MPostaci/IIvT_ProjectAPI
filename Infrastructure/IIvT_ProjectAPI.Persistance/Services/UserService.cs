using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Abstractions.Token;
using IIvT_ProjectAPI.Application.DTOs;
using IIvT_ProjectAPI.Application.DTOs.Token;
using IIvT_ProjectAPI.Application.DTOs.User;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }
        public async Task<BaseResponseDto> CreateAsync(CreateUserDto user)
        {
            if (user.Password != user.ConfirmPassword)
                throw new PasswordsNotMatchingException();

            IdentityResult result = await _userManager.CreateAsync(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
            }, user.Password);

            BaseResponseDto response = new() { Status = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User Created Successfully";
            else
                foreach (IdentityError error in result.Errors)
                    response.Message += error.Description + " ";

            return response;
        }

        public async Task<TokenDto> LoginAsync(string usernameOrEmail, string password)
        {
            AppUser user = await _userManager.FindByEmailAsync(usernameOrEmail) ??
            await
            _userManager.FindByNameAsync(usernameOrEmail) ??
            throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                TokenDto token = _tokenHandler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(_configuration["Token:RefreshTokenExpiration"])
                );

                await _userManager.UpdateAsync(user);


                return new()
                {
                    AccessToken = token.AccessToken,
                    AccessTokenExpiration = token.AccessTokenExpiration,
                    RefreshToken = token.RefreshToken,
                };
            }

            throw new AuthenticationErrorException();
        }

        public async Task<(IdentityResult Result, TokenDto? Token)> RefreshTokenAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken) 
                ?? throw new NotFoundUserException();


            if (user.RefreshTokenExpiration < DateTime.UtcNow)
                throw new TokenExpiredException();


            TokenDto token = _tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(_configuration["Token:RefreshTokenExpiration"])
                );

            IdentityResult result = await _userManager.UpdateAsync(user);

            if(!result.Succeeded)
                return (result, null);

            return (result, token);
        }
    }
}
