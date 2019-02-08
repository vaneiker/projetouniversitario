using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class NotesViewModels : BaseViewModels
    {
        public long? CustomerId { get; set; }
        public int CaseStatusId { get; set; }
        public long? accountId { get; set; }
        public string CustomerName { get; set; }
        public string LoanNumber { get; set; }
        public IEnumerable<Cases> Cases { get; set; }
        public CasesDetailViewModels CasesDetailViewModels { get; set; }
    }

    public class Cases
    {
        public string CaseKey { get; set; }
        public long? CaseNumber { get; set; }
        public DateTime? CaseDate { get; set; }
        public DateTime? OpeningCase { get; set; }
        public string ClosingCase { get; set; }
        public string CaseType { get; set; }
        public string CategoryCase { get; set; }
        public string AboutCase { get; set; }
        public string User { get; set; }
        public int CaseStatusId { get; set; }
        public string Status { get; set; }
        public long? Recording { get; set; }
        public int? NoteNumber { get; set; }
        public string Priority { get; set; }

    }

    public class CasesDetailViewModels
    {
        public IEnumerable<string> Notes { get; set; }
        public IEnumerable<CasesAttachedFiles> attachedFiles { get; set; }
        public IEnumerable<CasesAttachedCalls> attachedCalls { get; set; }
    }

    public class CasesAttachedFiles
    {
        public int FileNumber { get; set; }
        public string UrlFilePath { get; set; }
        public int? MeetingCaseNoteFileId { get; set; }        
        public string FileName { get; set; }
    }

    public class CasesAttachedCalls
    {
        public string PhoneNumber { get; set; }
        public TimeSpan? Duration { get; set; }
    }

}