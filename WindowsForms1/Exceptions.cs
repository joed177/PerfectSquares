using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms1
{
    public class NotAFractionException : ApplicationException
    {
        public NotAFractionException(string aMessage) :

               base(aMessage)
        { }

    }
    public class NotAnIntegerException : ApplicationException
    {
        public NotAnIntegerException(string aMessage) : base(aMessage) { }
    }

    public class NotAMixedNumberException : ApplicationException
    {
        public NotAMixedNumberException(string aMessage) : base(aMessage) { }
    }
    public class NoBoardBigEnoughException : ApplicationException
    {
        public NoBoardBigEnoughException(string aMessage) : base(aMessage) { }
    }

}
