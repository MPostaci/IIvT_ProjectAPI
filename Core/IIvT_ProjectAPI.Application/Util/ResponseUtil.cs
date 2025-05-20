using IIvT_ProjectAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Util
{
    public static class ResponseUtil
    {
        public static BaseResponseDto ResponseResult(int result)
        {
            return new()
            {
                Status = result > 0,
                Message = result > 0 ? "Done" : "Error"
            };
        }
    }
}
