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
        readonly IMediaFileReadRepository _mediaFileReadRepository;
        readonly IConfiguration _configuration;

        public GetProductImagesQueryHandler(IStorageService storageService, IMediaFileReadRepository mediaFileReadRepository, IConfiguration configuration)
        {
            _storageService = storageService;
            _mediaFileReadRepository = mediaFileReadRepository;
            _configuration = configuration;
        }

        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            //var x = _mediaFileReadRepository.GetWhere()
            //    .Select(x => new GetProductImagesQueryResponse()
            //    {
            //        Id = x.Id.ToString(),
            //        FileName = x.FileName,
            //        Path = x.Path
            //    }).ToList();
            //todo productimage

            return new List<GetProductImagesQueryResponse>();

                //Path = $"{configuration["BaseStorageUrl"]}/{p.Path}"
    }
    }
}
