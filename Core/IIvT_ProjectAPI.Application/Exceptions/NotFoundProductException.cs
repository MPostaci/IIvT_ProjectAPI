﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Exceptions
{
    public class NotFoundProductException : Exception
    {
        public NotFoundProductException() : base("Product not found.")
        {
        }

        public NotFoundProductException(string? message) : base(message)
        {
        }

        public NotFoundProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
