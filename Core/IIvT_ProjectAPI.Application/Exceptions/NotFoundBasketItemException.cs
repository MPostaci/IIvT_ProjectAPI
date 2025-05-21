using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Exceptions
{
    public class NotFoundBasketItemException : Exception
    {
        public NotFoundBasketItemException() : base("Basket item not found.")
        {
        }

        public NotFoundBasketItemException(string? message) : base(message)
        {
        }

        public NotFoundBasketItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
