using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallRex.UnderWriting.CallRexClientService;
using System.Configuration;

namespace CallRex.UnderWriting
{
    public class CallRexClient
    {
        ClientServiceClient proxy;
        string connectionString;

        public class ResumedCallData
        {
            public String UserId { get; set; }
            public String UserName { get; set; }
            public String CallLogId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public String IncomingNumber { get; set; }
            public String OutgoingNumber { get; set; }
            public String CallerIDName { get; set; }
            public String RecordingFile { get; set; }
            public String Duration { get; set; }
        }

        public CallRexClient(string connStringName = "SecurityConString", string endPointConfigName = "CustomBinding_IClientService")
        {
            proxy = new ClientServiceClient(endPointConfigName);
            connectionString = ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
        }

        public List<RecordedCallContainer> GetCallsByCRUserId(String userId, DateTime beginDate, DateTime endDate)
        {
            List<RecordedCallContainer> result;
            /*Original*/
            var usersGuid = new List<Guid>() { new Guid(userId) };
            /*Modificado Franklin 30-09-2016*/
            //var usersGuid = new List<Guid>() { Guid.NewGuid() };

            try
            {
                result = proxy.GetRecordedCalls(usersGuid.ToArray(), beginDate, endDate, 0, 999999, CallDirection.Both, null, null, null, new Guid(), null).ToList();
            }
            catch
            {
                result = new List<RecordedCallContainer>();
            }

            return result;
        }

        public List<RecordedCallContainer> GetCallsByCRUserId(String userId, DateTime date)
        {
            var beginDate = date.Date;
            var endDate = date.AddHours(23.9999);

            return this.GetCallsByCRUserId(userId, beginDate, endDate);
        }

        public List<ResumedCallData> GetResumedCallDataCRUserId(String userId, DateTime date)
        {
            var returnData = new List<ResumedCallData>();
            var beginDate = date.Date;
            var endDate = date.AddHours(23.9999);

            var callRexData = this.GetCallsByCRUserId(userId, beginDate, endDate);

            foreach (var item in callRexData)
            {
                returnData.Add(new ResumedCallData()
                    {
                        UserId = item.UserID.ToString(),
                        UserName = item.FirstName + " " + item.LastName,
                        CallLogId = item.CallLogID.ToString(),
                        StartTime = item.CallStart,
                        EndTime = item.CallStop,
                        IncomingNumber = item.CallerIDNo,
                        OutgoingNumber = item.DialedNumber,
                        CallerIDName = item.CallerIDName,
                        RecordingFile = item.FileName,
                        Duration = item.CallDuration.ToString()
                    }
                );
            }

            return new List<ResumedCallData>();
        }
    }
}
