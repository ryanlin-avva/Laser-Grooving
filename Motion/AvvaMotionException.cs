using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avva.MotionFramework
{
    class AvvaMotionException : Exception
    {
        public AvvaMotionException(string description)
        : base(description)
        {
            if (description == null) throw new ArgumentNullException("description");
        }

        public AvvaMotionException(string description, Exception inner)
            : base(description, inner)
        {
            if (description == null) throw new ArgumentNullException("description");
            if (inner == null) throw new ArgumentNullException("inner");
        }
    }
}
