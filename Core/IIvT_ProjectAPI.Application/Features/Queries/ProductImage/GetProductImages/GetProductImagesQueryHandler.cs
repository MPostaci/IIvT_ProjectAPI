using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.ProductImage.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        readonly IStorageService _storageService;
        readonly IProductMediaFileReadRepository _productMediaFileReadRepository;
        readonly IConfiguration _configuration;

        public GetProductImagesQueryHandler(IStorageService storageService, IConfiguration configuration, IProductMediaFileReadRepository productMediaFileReadRepository)
        {
            _storageService = storageService;
            _configuration = configuration;
            _productMediaFileReadRepository = productMediaFileReadRepository;
        }

        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var files = _productMediaFileReadRepository.Table.Where(x => x.ProductId == Guid.Parse(request.Id))
                .Select(x => new GetProductImagesQueryResponse()
                {
                    Id = x.Id.ToString(),
                    FileName = x.FileName,
                    Path = x.Path
                }).ToList();

            return files;
        }
    }
}
