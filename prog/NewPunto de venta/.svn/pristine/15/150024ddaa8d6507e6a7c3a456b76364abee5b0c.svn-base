using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.Helpers
{
    public class ValidationErrorException:Exception
    {

        public IList<string> ErrorMessages { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public ValidationErrorException(IList<string> errors): base(string.Join("\n", errors))
        {
            ErrorMessages = errors;
        }

    }
}