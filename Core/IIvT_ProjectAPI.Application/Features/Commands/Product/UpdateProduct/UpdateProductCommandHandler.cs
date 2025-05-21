using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Product;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductService _productService;
        readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _productService.UpdateProductAsync(_mapper.Map<UpdateProductDto>(request));

            return new()
            {
                State = result,
                Message = result ? "Product updated successfully" : "Product could not be updated"
            };
        }
    }
}
