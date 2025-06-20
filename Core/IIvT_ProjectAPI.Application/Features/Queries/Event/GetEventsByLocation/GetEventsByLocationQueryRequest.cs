﻿using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByLocation
{
    public class GetEventsByLocationQueryRequest : PagedRequest, IRequest<PagedResponse<ListEventDto>>, IQueryRequest
    {
        public string City { get; set; }
        public string? District { get; set; }
        public string? Neighborhood { get; set; }
    }
}