using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Exceptions
{
    public class PasswordsNotMatchingException : Exception
    {
        public PasswordsNotMatchingException() : base("Passwords not matching")
        {
        }

        public PasswordsNotMatchingException(string? message) : base(message)
        {
        }

        public PasswordsNotMatchingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
