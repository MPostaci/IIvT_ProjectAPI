using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Category.GetContentTypes
{
    public class GetContentTypesQueryHandler : IRequestHandler<GetContentTypesQueryRequest, GetContentTypesQueryResponse>
    {
        readonly ICategoryService _categoryService;

        public GetContentTypesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetContentTypesQueryResponse> Handle(GetContentTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetContentTypes();

            return new()
            {
                ContentTypes = result
            };
        }
    }
}
