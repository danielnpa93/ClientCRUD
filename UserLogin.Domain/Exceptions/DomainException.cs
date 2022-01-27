using System;
using System.Collections.Generic;

namespace UserLogin.Domain.Exceptions
{
    public class DomainException:Exception
    {
        private List<string> _errors;
        public IReadOnlyList<string> Errors => _errors;

        public DomainException()
        {

        }

        public DomainException(string errorMessage, List<string> errors): base(errorMessage)
        {
            _errors = errors;
        }

        public DomainException(string errorMessage) : base (errorMessage)
        {

        }

        public DomainException(string errorMessage, Exception exception): base(errorMessage, exception)
        {

        }



    }
}
