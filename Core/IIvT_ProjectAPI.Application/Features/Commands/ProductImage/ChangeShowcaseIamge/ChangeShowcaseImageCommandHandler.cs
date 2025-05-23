using IIvT_ProjectAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.ChangeShowcaseIamge
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        readonly IProductMediaFileWriteRepository _productMediaFileWriteRepository;

        public ChangeShowcaseImageCommandHandler(IProductMediaFileWriteRepository productMediaFileWriteRepository)
        {
            _productMediaFileWriteRepository = productMediaFileWriteRepository;
        }

        public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            _productMediaFileWriteRepository.Table.FirstOrDefault(x => x.Id == Guid.Parse(request.Id)).Showcase = true;

            return new();
        }
    }
}
