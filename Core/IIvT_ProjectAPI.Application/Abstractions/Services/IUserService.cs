using IIvT_ProjectAPI.Application.Common.Pagination;
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
        Task<PagedResponse<ListUserDto>> GetAllUsers(PagedRequest pagedRequest);
        Task<string[]> GetRolesToUserAsync(string userIdOrName);
        Task<TokenDto> LoginAsync(string usernameOrEmail, string password);
        Task<BaseResponseDto> CreateAsync(CreateUserDto user);
        Task<(IdentityResult Result, TokenDto? Token)> RefreshTokenAsync(string refreshToken);
        Task AssignRoleToUser(string userId, string[] roles);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);

    }
}
