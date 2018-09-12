using System;

namespace WEB.ConfirmationCall.Models
{
    public class Task
    {
        public int CorpId { get; set; }
        public int ContactId { get; set; }
        public int CallMeetingId { get; set; }
        public DateTime Date { get; set; }
        public string TimeHour { get; set; }
        public string TimeMinutes { get; set; }
        public string TimePeriod { get; set; }
        public string RelatedTo { get; set; }
        public string Note { get; set; }
    }

}