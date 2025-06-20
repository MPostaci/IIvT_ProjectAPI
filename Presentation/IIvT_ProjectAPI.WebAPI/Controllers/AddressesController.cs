﻿using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.Features.Commands.Address.CreateAddress;
using IIvT_ProjectAPI.Application.Features.Commands.Address.DeleteAddress;
using IIvT_ProjectAPI.Application.Features.Commands.Address.UpdateAddress;
using IIvT_ProjectAPI.Application.Features.Queries.Address.GetCities;
using IIvT_ProjectAPI.Application.Features.Queries.Address.GetDistrictsByCityId;
using IIvT_ProjectAPI.Application.Features.Queries.Address.GetNeighborhoodsByDistrictId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cities")]
        public Task<List<CityLookupDto>> GetCities([FromRoute] GetCitiesQueryRequest request) =>
        _mediator.Send(request);

        [HttpGet("districts/{CityId}")]
        public Task<List<DistrictLookupDto>> GetDistricts([FromRoute] GetDistrictsByCityIdQueryRequest request) =>
            _mediator.Send(request);

        [HttpGet("neighborhoods/{DistrictId}")]
        public Task<List<NeighborhoodLookupDto>> GetNeighborhoods([FromRoute] GetNeighborhoodsByDistrictIdQueryRequest request) =>
            _mediator.Send(request);

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Addresses, ActionType.Writing, "Create Address")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);

        }

        [HttpPut]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Addresses, ActionType.Updating, "Update Address")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{AddressId}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Addresses, ActionType.Deleting, "Delete Address")]
        public async Task<IActionResult> DeleteAddress([FromRoute] DeleteAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
