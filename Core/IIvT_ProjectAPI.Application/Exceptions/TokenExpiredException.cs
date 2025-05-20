using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Exceptions
{
    public class TokenExpiredException : Exception
    {
        public TokenExpiredException() : base("Please login again")
        {
        }

        public TokenExpiredException(string? message) : base(message)
        {
        }

        public TokenExpiredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
