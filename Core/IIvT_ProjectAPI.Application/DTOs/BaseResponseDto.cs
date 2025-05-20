using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs
{
    public class BaseResponseDto
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
    }
}
