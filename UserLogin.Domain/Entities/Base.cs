using System.Collections.Generic;

namespace UserLogin.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        private protected List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract void Validate();

    }
}
