using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Abstractions.Token;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.Token;
using IIvT_ProjectAPI.Application.DTOs.User;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.Repositories;
using System.Linq;
using E = IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IIvT_ProjectAPI.Persistence.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IMapper _mapper;
        readonly IAddressService _addressService;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IUserAddressWriteRepository _userAddressWriteRepository;
        readonly IUserAddressReadRepository _userAddressReadRepository;
        readonly IAddressReadRepository _addressReadRepository;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IConfiguration configuration, IMapper mapper, IEndpointReadRepository endpointReadRepository, IAddressService addressService, IHttpContextAccessor httpContextAccessor, IUserAddressWriteRepository userAddressWriteRepository, IUserAddressReadRepository userAddressReadRepository, IAddressReadRepository addressReadRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _mapper = mapper;
            _endpointReadRepository = endpointReadRepository;
            _addressService = addressService;
            _httpContextAccessor = httpContextAccessor;
            _userAddressWriteRepository = userAddressWriteRepository;
            _userAddressReadRepository = userAddressReadRepository;
            _addressReadRepository = addressReadRepository;
        }

        public async Task<AppUser> ContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User.Identity?.Name;

            var user = await _userManager.FindByNameAsync(username)
                ?? throw new NotFoundUserException();

            return user;
        }

        public async Task<PagedResponse<ListUserDto>> GetAllUsers(PagedRequest pagedRequest)
            => await _userManager.Users.ToPagedListAsync<AppUser, ListUserDto>(_mapper, pagedRequest);


        public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            AppUser user = await _userManager.FindByIdAsync(userIdOrName) ??
                await _userManager.FindByNameAsync(userIdOrName);


            if (user != null)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);

                return roles.ToArray();
            }
            return Array.Empty<string>();
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

            throw new Exception("Username or password is wrong.");
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

        public async Task AssignRoleToUser(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var usersRoles = await _userManager.GetRolesAsync(user);

                await _userManager.RemoveFromRolesAsync(user, usersRoles);

                await _userManager.AddToRolesAsync(user, roles);
            }
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {

            
            var userRoles = await GetRolesToUserAsync(name);

            if (!userRoles.Any())
                return false;


            E.Endpoint? endpoint = await _endpointReadRepository.Table
                .Include(e => e.IdentityRoleEndpoints)
                    .ThenInclude(e => e.Role)
                .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null)
                return false;


            var endpointRoles = endpoint.IdentityRoleEndpoints.Select(r => r.Role.Name);

            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole == endpointRole)
                    {
                        return true;
                    }
            }

            return false;
        }

        public async Task<PagedResponse<GetAddressDto>> GetUserSavedAdresses(PagedRequest pagedRequest)
        {
            var userId = (await ContextUser()).Id;

            // Query addresses directly from the database to get an IQueryable
            var addressesQuery = _userAddressReadRepository
                .GetWhere(x => x.UserId == userId)
                .Include(x => x.Address)
                .Select(x => x.Address);

            return await addressesQuery.ToPagedListAsync<Address, GetAddressDto>(_mapper, pagedRequest);
        }

        public async Task<GetAddressDto> AddAddressAsync(CreateAddressDto dto)
        {
            var user = await ContextUser();

            var addedAddress = await _addressService.AddAddressAsync(dto);

            bool isAddressExist = await _userAddressReadRepository.AnyAsync(x => x.AddressId == addedAddress.Id);

            if (isAddressExist)
                throw new Exception("Address already exist");

            UserAddress userAddress = new()
            {
                Id = Guid.NewGuid(),
                AddressId = addedAddress.Id,
                UserId = user.Id,
            };

            await _userAddressWriteRepository.AddAsync(userAddress);

            user.Addresses.Add(userAddress);

            await _userManager.UpdateAsync(user);

            return addedAddress;
        }
    }
}
