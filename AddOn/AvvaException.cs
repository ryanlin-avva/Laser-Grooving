using System;

namespace Velociraptor.AddOn
{
    class AvvaException : Exception
    {
        public AvvaException(string description)
            : base(description)
        {
            if (description == null) throw new ArgumentNullException("description");
        }

        public AvvaException(string description, Exception inner)
            : base(description, inner)
        {
            if (description == null) throw new ArgumentNullException("description");
            if (inner == null) throw new ArgumentNullException("inner");
        }
    }
}
