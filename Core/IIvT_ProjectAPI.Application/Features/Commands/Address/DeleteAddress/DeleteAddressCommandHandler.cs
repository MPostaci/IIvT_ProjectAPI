using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        readonly IAddressService _addressService;

        public DeleteAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _addressService.DeleteAddressAsync(request.AddressId);

            return new()
            {
                Success = result,
                Message = result ? "Address Deleted Successfully" : "Address couldn't deleted please try again later."
            };
        }
    }
}
