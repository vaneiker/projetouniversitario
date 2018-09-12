using System;
using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface ICallRex
    {
        IEnumerable<RecordedCallContainer> GetCallsByCRUserId(string userId, DateTime beginDate, DateTime endDate);
        IEnumerable<RecordedCallContainer> GetCallsByCRUserId(string userId, DateTime date);
        IEnumerable<ResumedCallData> GetResumedCallDataCRUserId(string userId, DateTime date, ResumedCallData.CallTimePeriod timePeriod, int? recordsNumber = null, bool DescOrder = true);
    }
}
