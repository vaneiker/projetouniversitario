using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Helpers
{

    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class PosTraceListener : CustomTraceListener
    {

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if (data is PosLogEntry)
                this.Write(data);
            else if (data is LogEntry && this.Formatter != null)
            {
                this.WriteLine(this.Formatter.Format(data as LogEntry));
            }
            else
            {
                this.WriteLine(data.ToString());
            }
        }

        public override void Write(string message)
        {
            PosLogEntry log = new PosLogEntry();
            log.Message = message;
            this.Write(log);
        }

        public override void Write(object o)
        {
            var service = DependencyResolver.Current as Unity.Mvc4.UnityDependencyResolver;
            var model = service.GetService<PosModel>();
            var logEntry = o as PosLogEntry;
            model.LogEntries.Add(logEntry);
            try
            {
                Task t = model.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public override void WriteLine(string message)
        {
            PosLogEntry log = new PosLogEntry();
            log.Message = message;
            this.Write(log);
        }
    }
}