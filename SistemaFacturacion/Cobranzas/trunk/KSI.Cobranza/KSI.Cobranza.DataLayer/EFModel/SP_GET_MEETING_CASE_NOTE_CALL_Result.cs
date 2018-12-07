//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KSI.Cobranza.DataLayer.EFModel
{
    using System;
    
    public partial class SP_GET_MEETING_CASE_NOTE_CALL_Result
    {
        public long relatedContactId { get; set; }
        public int MeetingTypeId { get; set; }
        public int MeetingSubTypeId { get; set; }
        public int MeetingCaseId { get; set; }
        public long accountId { get; set; }
        public int MeetingStatusId { get; set; }
        public Nullable<int> ReasonId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public int MeetingCaseNoteId { get; set; }
        public Nullable<int> PriorityId { get; set; }
        public Nullable<int> ServiceChannelId { get; set; }
        public Nullable<int> OriginatedById { get; set; }
        public int MeetingCaseNoteCallId { get; set; }
        public Nullable<long> CaseNumber { get; set; }
        public Nullable<System.DateTime> MeetingDate { get; set; }
        public string MeetingShortNote { get; set; }
        public Nullable<int> CallAssignedId { get; set; }
        public string NotifiedToEmail { get; set; }
        public Nullable<bool> Notified { get; set; }
        public Nullable<int> AttemptNo { get; set; }
        public string MeetingDesc { get; set; }
        public string MeetingSubDesc { get; set; }
        public string ReasonDesc { get; set; }
        public string DepartamentDesc { get; set; }
        public string CategoryDesc { get; set; }
        public string PriorityDesc { get; set; }
        public string ServiceChannelDesc { get; set; }
        public string Note { get; set; }
        public Nullable<System.TimeSpan> CallDuration { get; set; }
        public Nullable<System.DateTime> CallStart { get; set; }
        public Nullable<System.DateTime> CallStop { get; set; }
        public string DialedNumber { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string FullPathFile { get; set; }
        public string CallLogId { get; set; }
        public string CallRexUserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CallAssingName { get; set; }
        public string CreatedUserName { get; set; }
        public string ModifiedUserName { get; set; }
        public string FullName { get; set; }
        public string account { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> ModiDate { get; set; }
        public int CreateUsrId { get; set; }
        public Nullable<int> ModiUsrId { get; set; }
        public string hostName { get; set; }
        public Nullable<System.DateTime> MeetingClosedDate { get; set; }
        public Nullable<long> QueueId { get; set; }
    }
}
