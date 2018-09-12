using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.UnderWriting.Common.Model
{
    [DataContract]
    public class ReturnMessageData
    {
        public ReturnMessageData()
        {
            Status = StatusProcess.Error;
            ListMessage = new List<string>();
        }

        [DataMember]
        public StatusProcess Status { get; set; }

        [DataMember]
        public IList<string> ListMessage { get; set; }

        public enum StatusProcess
        {
            Error,
            Success
        }
    }
}
