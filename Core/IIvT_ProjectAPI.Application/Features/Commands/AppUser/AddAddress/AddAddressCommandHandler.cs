using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.AddAddress
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommandRequest, GetAddressDto>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public AddAddressCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<GetAddressDto> Handle(AddAddressCommandRequest request, CancellationToken cancellationToken)
            => await _userService.AddAddressAsync(_mapper.Map<CreateAddressDto>(request));
        
    }
}
