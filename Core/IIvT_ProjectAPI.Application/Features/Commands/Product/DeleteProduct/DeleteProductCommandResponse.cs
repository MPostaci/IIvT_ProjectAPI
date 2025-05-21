using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandResponse
    {
        public bool State { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
