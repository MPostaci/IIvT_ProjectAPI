using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.DeleteAddress
{
    public class DeleteUserAddressCommandRequest : IRequest<DeleteUserAddressCommandResponse>, ICommandRequest
    {
        public string AddressId { get; set; }
    }
}