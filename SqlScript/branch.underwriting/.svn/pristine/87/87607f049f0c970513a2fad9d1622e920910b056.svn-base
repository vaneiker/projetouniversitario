using System;

namespace Entity.UnderWriting.Entities
{
    public class RecordedCallContainer
    {
        public TimeSpan CallDuration { get; set; }
        public string CallID { get; set; }
        public Guid CallLogID { get; set; }
        public DateTime CallStart { get; set; }
        public DateTime CallStop { get; set; }
        public string CallerIDName { get; set; }
        public string CallerIDNo { get; set; }
        public string DNIS { get; set; }
        public string DialedNumber { get; set; }
        public string Extension { get; set; }
        public string FileHash { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string FirstName { get; set; }
        public Guid FromCallLogID { get; set; }
        public bool IsRecordingChainSegment { get; set; }
        public string LastName { get; set; }
        public string RecordedBy { get; set; }
        public RecordingFlagValue[] RecordingFlagValues { get; set; }
        public Guid ToCallLogID { get; set; }
        public UserListItem User { get; set; }
        public Guid UserID { get; set; }
        public string XferFrom { get; set; }

        public class RecordingFlagValue
        {
            public Guid FlagId { get; set; }
            public string FlagName { get; set; }
            public string FlagValue { get; set; }
            public Guid Id { get; set; }
            public Guid RecordingId { get; set; }
        }

        public class UserListItem
        {
            public string AgentID { get; set; }
            public string Department { get; set; }
            public string DeviceName { get; set; }
            public string Extension { get; set; }
            public string FirstName { get; set; }
            public bool HasAgentEvalLicense { get; set; }
            public bool HasCallRecordingLicense { get; set; }
            public bool HasComputerRecordingLicense { get; set; }
            public bool HasDemandRecordingLicense { get; set; }
            public bool IsActive { get; set; }
            public bool IsAgent { get; set; }
            public bool IsDevice { get; set; }
            public string LastName { get; set; }
            public string Location { get; set; }
            public Guid UserID { get; set; }            
        }
    }
}
