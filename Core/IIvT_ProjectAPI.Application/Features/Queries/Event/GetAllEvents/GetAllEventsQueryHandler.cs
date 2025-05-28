using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQueryRequest, PagedResponse<ListEventDto>>
    {
        public Task<PagedResponse<ListEventDto>> Handle(GetAllEventsQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
