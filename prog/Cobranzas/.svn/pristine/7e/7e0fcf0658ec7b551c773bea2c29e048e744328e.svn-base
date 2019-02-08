using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer
{
    /// <summary>
    /// This class represent the result of the operation executed
    /// </summary>
    public class Result
    {
        public bool HasError { get; set; }
        public string ErrorDescription { get; set; }
        public string Action { get; set; }
        public long? entityId { get; set; }

        public Result(Exception e = null, string methodName = null)
        {
            this.ErrorDescription = (e != null) ? string.Format("Method {0} ExceptionMessage {1} InnerException {2} TraceStack {3}", methodName, e.Message, e.InnerException != null ? e.InnerException.Message : "", e.StackTrace)
                                                : string.Empty;
            this.HasError = e != null;

        }
    }
}
