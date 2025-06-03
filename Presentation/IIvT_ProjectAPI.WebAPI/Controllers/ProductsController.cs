using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.DTOs.Product;
using IIvT_ProjectAPI.Application.Features.Commands.Product.CreateProduct;
using IIvT_ProjectAPI.Application.Features.Commands.Product.DeleteProduct;
using IIvT_ProjectAPI.Application.Features.Commands.Product.UpdateProduct;
using IIvT_ProjectAPI.Application.Features.Commands.ProductImage.ChangeShowcaseIamge;
using IIvT_ProjectAPI.Application.Features.Commands.ProductImage.RemoveProductImage;
using IIvT_ProjectAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using IIvT_ProjectAPI.Application.Features.Queries.Product.GetAllProducts;
using IIvT_ProjectAPI.Application.Features.Queries.Product.GetByIdProduct;
using IIvT_ProjectAPI.Application.Features.Queries.ProductImage.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest request)
        {
            ListProductDto result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Products, ActionType.Writing, "Create Product")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Products, ActionType.Updating, "Update Product")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Products, ActionType.Deleting, "Delete Product")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        // ----- Image Operations ----- \\

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetImages([FromRoute] GetProductImagesQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Products, ActionType.Writing, "Upload Product File")]
        public async Task<IActionResult> UploadFile([FromForm] UploadProductImageCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("[action]/{Id}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Products, ActionType.Deleting, "Delete Product File")]
        public async Task<IActionResult> RemoveFile([FromRoute] RemoveProductImageCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]/{Id}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Products, ActionType.Updating, "Change Product Showcase Image")]
        public async Task<IActionResult> ChangeShowcaseImage([FromRoute] ChangeShowcaseImageCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
