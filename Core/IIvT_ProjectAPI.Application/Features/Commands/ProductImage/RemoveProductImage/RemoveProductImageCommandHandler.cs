using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {

        readonly IStorageService _storageService;
        readonly IProductMediaFileReadRepository _productMediaFileReadRepository;
        readonly IProductMediaFileWriteRepository _productMediaFileWriteRepository;

        public RemoveProductImageCommandHandler(IStorageService storageService, IProductMediaFileWriteRepository productMediaFileWriteRepository, IProductMediaFileReadRepository productMediaFileReadRepository)
        {
            _storageService = storageService;
            _productMediaFileWriteRepository = productMediaFileWriteRepository;
            _productMediaFileReadRepository = productMediaFileReadRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var file = await _productMediaFileReadRepository.GetByIdAsync(request.Id)
                ?? throw new Exception("File not found");

            _productMediaFileWriteRepository.Remove(file);


            await _storageService.DeleteAsync(file.Path);

            return new();
        }
    }
}
