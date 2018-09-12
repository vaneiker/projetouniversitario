using System;
using System.Collections.Generic;

namespace ReinsuranceComm.UnderWriting.Model
{
    public class MessageEntity
    {
        public string StepSeqReference { get; set; }
        public string Html { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public bool HasAttachment { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }

        public class Attachment
        {
            public string Filename { get; set; }
            public byte[] Binary { get; set; }
            public int DocTypeId { get; set; }
            public int DocCategoryId { get; set; }
        }
    }
}
