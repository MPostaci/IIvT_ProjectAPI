using IIvT_ProjectAPI.Application.DTOs.Token;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public TokenDto Token { get; set; }
    }
}