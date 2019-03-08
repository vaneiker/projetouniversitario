using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace StateTrustGlobal.ViewModels//STL.VirtualOffice.Infrastructure.Mail
{
    public class AttachedFiles
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DocumentTypeID { get; set; }
        public string DocumentType { get; set; }
        public byte[] DocumentBin { get; set; }
        public bool IsEmbedded { get; set; }
        public string ContentID { get; set; }
        public string DocumentDesc { get; set; }
        public string DocumentName { get; set; }
        public int DocumentId { get; set; }
    }

}
