using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>, ICommandRequest
    {
        public string? Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
