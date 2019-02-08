using KSI.Cobranza.Web.Common.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class MeetingNoteViewModels : BaseViewModels
    {
        public int originatedById { get; set; }
        public long? accountId { get; set; }
        public long? relatedContactId { get; set; }
        public int? meetingCaseId { get; set; }
        public int? meetingCaseNoteId { get; set; }
        public string LoanNumber { get; set; }
        public string ProcessStatus { get; set; }
        public string CustomerName { get; set; }
        public bool IsNewCase { get; set; }
        [Display(Name="Servicio")]
        [Required(ErrorMessage = "El campo Servicio es requerido.")]
        public int ServiceId { get; set; }
        public IEnumerable<KeyValue> Services { get; set; }
        [Required(ErrorMessage = "El campo Canal del Servicio es requerido.")]
        public int ChannelServiceId { get; set; }
        public IEnumerable<KeyValue> ChannelServices { get; set; }
        [Required(ErrorMessage = "El campo Sub Servicio es requerido.")]
        public int SubServiceId { get; set; }
        public IEnumerable<KeyValue> SubServices { get; set; }
        [Required(ErrorMessage = "El campo Categoria es requerido.")]
        public int CategoryId { get; set; }
        public IEnumerable<KeyValue> Categories { get; set; }
        [Required(ErrorMessage = "El campo Razon Contacto es requerido.")]
        public int ContactReasonId { get; set; }
        public IEnumerable<KeyValue> ContactReason { get; set; }
        [Required(ErrorMessage = "El campo Tipo de contacto es requerido.")]
        public int ContactTypeId { get; set; }
        public IEnumerable<KeyValue> ContactType { get; set; }
        [Required(ErrorMessage = "El campo Estatus es requerido.")]
        public int CasesStatusId { get; set; }
        public IEnumerable<KeyValue> StatusCases { get; set; }
        public long? CaseId { get; set; }
        public IEnumerable<KeyValue> Cases { get; set; }
        [Required(ErrorMessage = "El campo Prioridad es requerido.")]
        public int PriorityId { get; set; }
        public IEnumerable<KeyValue> Priority { get; set; }
        [Required(ErrorMessage = "El campo Nota es requerido.")]
        public string Note { get; set; }
        //[RequiredIf("ApplyToAttachedFiles", true, ErrorMessage = "Debes adjuntar por lo menos un archivo")]
        public string HasAttachedFiles { get; set; }
        public bool ApplyToAttachedFiles { get; set; }
        //[RequiredIf("ApplyToAttachedCall", true, ErrorMessage = "Debes adjuntar por lo menos una llamada")]
        public string HasAttachedCall { get; set; }
        public bool ApplyToAttachedCall { get; set; }
        public string CallsSelected { get; set; }     

        [RequiredIf("HasSelectedTracing", true, ErrorMessage = "El campo Seguimiento automatico es requerido.")]
        public DateTime? Automatictracing { get; set; }
        public bool HasSelectedTracing { get; set; }          
        
        [RequiredIf("HasSelectedTracing", true, ErrorMessage = "El campo Asignar Seguimiento es requerido.")]
        public int? DepartmentId { get; set; }
        public IEnumerable<KeyValue> Departments { get; set; }

        [RequiredIf("HasSelectedTracing", true, ErrorMessage = "El campo Tipo de Queue es requerido.")]
        public int? QueueTypeId { get; set; }
        public IEnumerable<KeyValue> QueueType { get; set; }

        [RequiredIf("HasSelectedTracing", true, ErrorMessage = "El campo Comentarios es requerido.")]
        public string Comments { get; set; }
    }

    public class AttachedFilesViewModels : BaseViewModels
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public IEnumerable<KeyValue> DocumentsTypes { get; set; }
        public IEnumerable<KeyValue> DocumentsGroup { get; set; }
        public int? meetingCaseNoteFileId { get; set; }
        [Required(ErrorMessage = "El campo tipo de documento es requerido")]
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDesc { get; set; }
        [Required(ErrorMessage = "El campo tipo de Grupo de documento es requerido")]
        public int DocumentGroupId { get; set; }
        public string documentGroupName { get; set; }
        [MustBeTrue(ErrorMessage = "Debe elegir un documento a adjuntar")]
        public bool HasLoadedFile { get; set; }
        public string FileName { get; set; }
        public string DocumentPath { get; set; }
        public decimal? sizeFile { get; set; }
    }

    public class PhoneCallViewModels : BaseViewModels
    {
        public string RealPathCallToPlay { get; set; }
        public string KeyCall { get; set; }
        public string CallDuration { get; set; }
        public string CallerIDName { get; set; }
        public string CallerIDNo { get; set; }
        public string CallID { get; set; }
        public string CallLogID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CallStart { get; set; }
        public DateTime CallStop { get; set; }
        public string Department { get; set; }
        public string DialedNumber { get; set; }
        public string DNIS { get; set; }
        public string Extension { get; set; }
        public string FileHash { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string FirstName { get; set; }
        public string FromCallLogID { get; set; }
        public bool IsRecordingChainSegment { get; set; }
        public bool IsStereo { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string RecordedBy { get; set; }
        public string RecorderUtcOffset { get; set; }
        public bool Rejected { get; set; }
        public string ToCallLogID { get; set; }
        public string UserID { get; set; }
        public string XferFrom { get; set; }
        public string FullName { get; set; }
    }
}