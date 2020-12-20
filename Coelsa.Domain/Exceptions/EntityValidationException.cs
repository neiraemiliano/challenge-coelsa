using System;
using System.Collections.Generic;
using System.Text;

namespace Coelsa.Domain.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException() : base()
        {

        }
        public EntityValidationException(string message) : base(message)
        {

        }
    }
}
