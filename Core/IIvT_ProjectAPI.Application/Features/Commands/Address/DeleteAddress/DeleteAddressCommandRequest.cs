using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>, ICommandRequest
    {
        public string AddressId { get; set; }
    }
}