using System;
using System.Collections.Generic;
using CallRex.UnderWriting;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class CallRexManager
    {
        private CallRexClient _callRexClient;

        public CallRexManager()
        {
            _callRexClient = new CallRexClient();
        }
        public CallRexManager(string endPointConfigName)
        {
            _callRexClient = new CallRexClient(endPointConfigName);
        }

        public IEnumerable<RecordedCallContainer> GetCallsByCRUserId(string userId, DateTime beginDate, DateTime endDate)
        {
            IEnumerable<RecordedCallContainer> result;

            result = _callRexClient.GetCallsByCRUserId(userId, beginDate, endDate);

            return
                result;
        }
        public IEnumerable<RecordedCallContainer> GetCallsByCRUserId(string userId, DateTime date)
        {
            IEnumerable<RecordedCallContainer> result;

            result = _callRexClient.GetCallsByCRUserId(userId, date);

            return
                result;
        }
        public IEnumerable<ResumedCallData> GetResumedCallDataCRUserId(string userId, DateTime date, ResumedCallData.CallTimePeriod timePeriod, int? recordsNumber = null, bool DescOrder = true)
        {
            IEnumerable<ResumedCallData> result;

            result = _callRexClient.GetResumedCallDataCRUserId(userId, date, timePeriod, recordsNumber, DescOrder);

            return
                result;
        }
    }
}
