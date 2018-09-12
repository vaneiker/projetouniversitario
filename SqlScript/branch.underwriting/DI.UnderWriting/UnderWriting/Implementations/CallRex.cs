using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class CallRexBll : ICallRex
    {
        private CallRexManager _callRex;

        public CallRexBll()
        {
            _callRex = new CallRexManager();
        }

        IEnumerable<RecordedCallContainer> ICallRex.GetCallsByCRUserId(string userId, DateTime beginDate, DateTime endDate)
        {
            return
                _callRex.GetCallsByCRUserId(userId, beginDate, endDate);
        }

        IEnumerable<RecordedCallContainer> ICallRex.GetCallsByCRUserId(string userId, DateTime date)
        {
            return
                _callRex.GetCallsByCRUserId(userId, date);
        }

        IEnumerable<ResumedCallData> ICallRex.GetResumedCallDataCRUserId(string userId, DateTime date, ResumedCallData.CallTimePeriod timePeriod, int? recordsNumber, bool DescOrder)
        {
            return
                _callRex.GetResumedCallDataCRUserId(userId, date, timePeriod, recordsNumber, DescOrder);
        }
    }

    public class CallRexWS : ICallRex
    {
        IEnumerable<RecordedCallContainer> ICallRex.GetCallsByCRUserId(string userId, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        IEnumerable<RecordedCallContainer> ICallRex.GetCallsByCRUserId(string userId, DateTime date)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ResumedCallData> ICallRex.GetResumedCallDataCRUserId(string userId, DateTime date, ResumedCallData.CallTimePeriod timePeriod, int? recordsNumber, bool DescOrder)
        {
            throw new NotImplementedException();
        }
    }

}
