using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IStorageService _storageService;
        //readonly IMediaFileWriteRepository _mediaFileWriteRepository;
        readonly IProductMediaFileWriteRepository _productMediaFileWriteRepository;

        public UploadProductImageCommandHandler(IStorageService storageService, IMediaFileWriteRepository mediaFileWriteRepository, IProductMediaFileWriteRepository productMediaFileWriteRepository)
        {
            _storageService = storageService;
            //_mediaFileWriteRepository = mediaFileWriteRepository;
            _productMediaFileWriteRepository = productMediaFileWriteRepository;
        }


        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {

            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("product-images", request.Files);

            await _productMediaFileWriteRepository.AddRangeAsync(result.Select(r => new ProductMediaFile
            {
                Id = Guid.NewGuid(),
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Showcase = false,
                ProductId = Guid.Parse(request.Id),
                FileTpye = _storageService.GetFileType(r.fileName)
            }).ToList());


            return new();
        }
    }
}
