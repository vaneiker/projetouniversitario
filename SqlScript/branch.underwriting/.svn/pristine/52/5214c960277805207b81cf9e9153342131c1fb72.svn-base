using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CallRex.UnderWriting.CallRexClientService;
using Entity.UnderWriting.Entities;
using RecordedCallContainer = Entity.UnderWriting.Entities.RecordedCallContainer;

namespace CallRex.UnderWriting
{
    public class CallRexClient
    {
        readonly ClientServiceClient _proxy;

        public CallRexClient(string endPointConfigName = "CustomBinding_IClientService")
        {
            _proxy = new ClientServiceClient(endPointConfigName);
        }

        public List<RecordedCallContainer> GetCallsByCRUserId(String userId, DateTime beginDate, DateTime endDate)
        {
            var usersGuid = new List<Guid>() { new Guid(userId) };
            var temp = _proxy.GetRecordedCalls(usersGuid.ToArray(), beginDate, endDate, 0, 999999, CallDirection.Both, null, null, null, new Guid(), null).ToList();

            var result = ConvertRecordedCallContainer(temp);

            return
                result;
        }

        public List<RecordedCallContainer> GetCallsByCRUserId(String userId, DateTime date)
        {
            var beginDate = date.Date;
            var endDate = date.AddHours(23.9999);

            return
                this.GetCallsByCRUserId(userId, beginDate, endDate);
        }

        public List<ResumedCallData> GetResumedCallDataCRUserId(String userId, DateTime date, ResumedCallData.CallTimePeriod timePeriod, int? recordsNumber = null, bool DescOrder = true)
        {
            var returnData = new List<ResumedCallData>();
            var beginDate = timePeriod.ToString().ToLower() == "alldaycalls" ? date.Date : (timePeriod.ToString().ToLower() == "twohoursfromdate" ? date.AddHours(-2) : date);
            var endDate = timePeriod.ToString().ToLower() == "alldaycalls" ? date.AddHours(23.9999) : (timePeriod.ToString().ToLower() == "twohoursfromdate" ? date : DateTime.Now);

            var callRexData = this.GetCallsByCRUserId(userId, beginDate, endDate);


            if (callRexData != null && callRexData.Any())
            {
                returnData.AddRange(callRexData.Select(item => new ResumedCallData()
                {
                    UserId = item.UserID.ToString(), UserName = item.FirstName + " " + item.LastName, CallLogId = item.CallLogID.ToString(), StartTime = item.CallStart, EndTime = item.CallStop, IncomingNumber = item.CallerIDNo, OutgoingNumber = item.DialedNumber, CallerIDName = item.CallerIDName, RecordingFile = item.FileName, Duration = item.CallDuration.ToString(), CallerIdNumber = item.CallerIDNo
                }));
            }

            if (recordsNumber == null) return returnData;
            returnData = DescOrder ? returnData.OrderByDescending(r => r.StartTime).Take(recordsNumber.Value).ToList() : returnData.OrderBy(r => r.StartTime).Take(recordsNumber.Value).ToList();

            return  returnData;
        }

        private List<RecordedCallContainer> ConvertRecordedCallContainer(List<CallRexClientService.RecordedCallContainer> value)
        {
            List<RecordedCallContainer> result;

            if (value != null && value.Any())
            {
                result = new List<RecordedCallContainer>(1);

                foreach (var item in value)
                {
                    RecordedCallContainer.RecordingFlagValue[] temprfv;
                    if (item.RecordingFlagValues != null && item.RecordingFlagValues.Any())
                    {
                        temprfv = new RecordedCallContainer.RecordingFlagValue[item.RecordingFlagValues.Length];

                        for (var i = 0; i < item.RecordingFlagValues.Length; i++)
                        {
                            temprfv[i] = new RecordedCallContainer.RecordingFlagValue
                            {
                                FlagId = item.RecordingFlagValues[i].FlagId,
                                FlagName = item.RecordingFlagValues[i].FlagName,
                                FlagValue = item.RecordingFlagValues[i].FlagValue,
                                Id = item.RecordingFlagValues[i].Id,
                                RecordingId = item.RecordingFlagValues[i].RecordingId
                            };
                        }
                    }
                    else
                        temprfv = null;

                    result.Add(new RecordedCallContainer
                    {
                        CallDuration = item.CallDuration,
                        CallID = item.CallID,
                        CallLogID = item.CallLogID,
                        CallStart = item.CallStart,
                        CallStop = item.CallStop,
                        CallerIDName = item.CallerIDName,
                        CallerIDNo = item.CallerIDNo,
                        DNIS = item.DNIS,
                        DialedNumber = item.DialedNumber,
                        Extension = item.Extension,
                        FileHash = item.FileHash,
                        FileLocation = item.FileLocation,
                        FileName = item.FileName,
                        FirstName = item.FirstName,
                        FromCallLogID = item.FromCallLogID,
                        IsRecordingChainSegment = item.IsRecordingChainSegment,
                        LastName = item.LastName,
                        RecordedBy = item.RecordedBy,
                        RecordingFlagValues = temprfv,
                        ToCallLogID = item.ToCallLogID,
                        User = new RecordedCallContainer.UserListItem
                            {
                                AgentID = item.User.AgentID,
                                Department = item.User.Department,
                                DeviceName = item.User.DeviceName,
                                Extension = item.User.Extension,
                                FirstName = item.User.FirstName,
                                HasAgentEvalLicense = item.User.HasAgentEvalLicense,
                                HasCallRecordingLicense = item.User.HasCallRecordingLicense,
                                HasComputerRecordingLicense = item.User.HasComputerRecordingLicense,
                                HasDemandRecordingLicense = item.User.HasDemandRecordingLicense,
                                IsActive = item.User.IsActive,
                                IsAgent = item.User.IsAgent,
                                IsDevice = item.User.IsDevice,
                                LastName = item.User.LastName,
                                Location = item.User.Location,
                                UserID = item.User.UserID
                            },
                        UserID = item.UserID,
                        XferFrom = item.XferFrom
                    });
                }
            }
            else
                result = null;

            return
                result;
        }
    }
}
