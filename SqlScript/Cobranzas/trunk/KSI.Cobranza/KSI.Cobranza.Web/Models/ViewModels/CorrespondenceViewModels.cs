using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class CorrespondenceViewModels : BaseViewModels
    {
        public string CaseNumber { get; set; }
        public string LoanNumber { get; set; }
        public string ProductType { get; set; }
        public string CaseType { get; set; }
        public string Department { get; set; }
        public string PrincipalCustomer { get; set; }
        public string PrincipalAgent { get; set; }
        public string PrincipalOffice { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentGroupId { get; set; } 
        public List<TemplateDocument> TemplateDocuments { get; set; }
        public MailInformation MailInformation { get; set; }      
        public Tracing Tracing { get; set; }
        public List<AttachedFiles> AttachedFiles { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> DocumentsTypes { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> DocumentsGroup { get; set; }
    }

    public class AttachedFiles
    {
        public int DocumentTypeId { get; set; }
        public int DocumentTypeDesc { get; set; }        
        public string FileName { get; set; }        
    }

    public class Tracing
    {
        public int TracingTypeId { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> TracingTypes { get; set; }
        public DateTime TracingDate { get; set; }
        public string Tracinghour { get; set; }

    }

    public class MailInformation
    {
        public string PrimaryCustomer { get; set; }
        public string SecundaryCustomer { get; set; }
        public string PrimaryAgent { get; set; }
        public string Office { get; set; }
        public string Provider { get; set; }
        public string Extra { get; set; }
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> Departments { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> Subjects { get; set; }
    }

    public class TemplateDocument
    {
        public string DocumentName { get; set; }
    }
}