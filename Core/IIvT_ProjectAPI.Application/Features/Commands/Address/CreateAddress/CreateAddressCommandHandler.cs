using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Address.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, GetAddressDto>
    {
        readonly IAddressService _addressService;
        readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task<GetAddressDto> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
            => await _addressService.AddAddressAsync(_mapper.Map<CreateAddressDto>(request));
        
    }
}
