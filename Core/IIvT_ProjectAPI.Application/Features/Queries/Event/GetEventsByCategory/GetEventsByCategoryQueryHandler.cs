using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByCategory
{
    public class GetEventsByCategoryQueryHandler : IRequestHandler<GetEventsByCategoryQueryRequest, PagedResponse<ListEventDto>>
    {
        public Task<PagedResponse<ListEventDto>> Handle(GetEventsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
