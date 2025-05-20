using IIvT_ProjectAPI.Application.DTOs;
using IIvT_ProjectAPI.Application.DTOs.Token;
using IIvT_ProjectAPI.Application.DTOs.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<TokenDto> LoginAsync(string usernameOrEmail, string password);
        Task<BaseResponseDto> CreateAsync(CreateUserDto user);
        Task<(IdentityResult Result, TokenDto? Token)> RefreshTokenAsync(string refreshToken);
    }
}
