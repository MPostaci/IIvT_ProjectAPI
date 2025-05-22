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
        readonly IMediaFileWriteRepository _mediaFileWriteRepository;

        public UploadProductImageCommandHandler(IStorageService storageService, IMediaFileWriteRepository mediaFileWriteRepository)
        {
            _storageService = storageService;
            _mediaFileWriteRepository = mediaFileWriteRepository;
        }


        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {

            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("product-images", request.Files);

            await _mediaFileWriteRepository.AddRangeAsync(result.Select(r => new MediaFile
            {
                Id = Guid.NewGuid(),
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
            }).ToList());

            return new();


            //List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.FormFileCollection);


            //P.Product product = await _productReadRepository.GetByIdAsync(request.Id);

            //await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new P.ProductImageFile
            //{
            //    FileName = r.fileName,
            //    Path = r.pathOrContainerName,
            //    Storage = _storageService.StorageName,
            //    Products = new List<P.Product>() { product }
            //}).ToList());

            //await _productImageFileWriteRepository.SaveAsync();

            //return new();
        }
    }
}
