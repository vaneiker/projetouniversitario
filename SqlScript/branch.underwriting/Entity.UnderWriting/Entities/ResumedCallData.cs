using System;

namespace Entity.UnderWriting.Entities
{
    public class ResumedCallData
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CallLogId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CallerIdNumber { get; set; }
        public string IncomingNumber { get; set; }
        public string OutgoingNumber { get; set; }
        public string CallerIDName { get; set; }
        public string RecordingFile { get; set; }
        public string Duration { get; set; }

        public enum CallTimePeriod
        {
            TwoHoursFromDate,
            AllDayCalls,
            FromDateTimeToCurrent
        }
    }

    
}
