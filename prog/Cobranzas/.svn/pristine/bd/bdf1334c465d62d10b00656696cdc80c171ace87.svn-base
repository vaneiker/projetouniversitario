using KSI.Cobranza.Web.Common.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class CorrespondenceViewModels : BaseViewModels
    {
        public CorrespondenceViewModels() 
        {
            HasSelectedAnyEmail = false;
        }
        
        [MustBeTrue(ErrorMessage = "Debe generar el template a enviar")]
        public bool HasGenerateTemplateBySent { get; set; }
        [MustBeTrue(ErrorMessage="Debe seleccionar al menos un correo")]
        public bool HasSelectedAnyEmail { get; set; }                        
        [Required(ErrorMessage = "El campo tipo de documento es requerido")]
        public int DocumentTypeId { get; set; }
        [Required(ErrorMessage = "El campo grupo de documento es requerido")]
        public int DocumentGroupId { get; set; }
        [Required(ErrorMessage = "Debe elegir un documento a adjuntar")]
        public bool? HasLoadedFile { get; set; }          
        [Required(ErrorMessage = "Debes generar el documento previamente, presione el boton generar template")]
        public bool? HasGenereateTemplate { get; set; }
        public List<TemplateDocument> TemplateDocuments { get; set; } 
        
        [RequiredIf("HasSelectedPrimaryCustomer", true, ErrorMessage = "El campo cliente primario es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email no valido para el campo cliente primario")]
        public string PrimaryCustomer { get; set; }   
        public bool HasSelectedPrimaryCustomer { get; set; }   

        [RequiredIf("HasSelectedSecundaryCustomer", true, ErrorMessage = "El campo cliente secundario es requerido")]        
        [EmailAddress(ErrorMessage = "Formato de Email no valido para el campo cliente secundario")]
        public string SecundaryCustomer { get; set; }
        public bool HasSelectedSecundaryCustomer { get; set; } 

        [RequiredIf("HasSelectedPrimaryAgent", true, ErrorMessage = "El campo agente primario es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email no valido para el campo agente primario")]
        public string PrimaryAgent { get; set; }
        public bool HasSelectedPrimaryAgent { get; set; }  

        [RequiredIf("HasSelectedOffice", true, ErrorMessage = "El campo oficina es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email no valido para el campo oficina")]
        public string Office { get; set; }
        public bool HasSelectedOffice { get; set; }   

        [RequiredIf("HasSelectedProvider", true, ErrorMessage = "El campo proveedor es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email no valido para el campo proveedor")]
        public string Provider { get; set; }
        public bool HasSelectedProvider { get; set; }  
        [RequiredIf("HasSelectedExtra", true, ErrorMessage = "El campo extra es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email no valido para el campo extra")]
        public string Extra { get; set; }
        public bool HasSelectedExtra { get; set; }  
        [RequiredIf("HasSelectedDepartment", true, ErrorMessage = "El campo Departamento es requerido")]
        public string Department { get; set; }        
        public bool HasSelectedDepartment { get; set; } 
        //[Required(ErrorMessage="El campo Asunto es requerido")]
        public int? SubjectId { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> Departments { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> Subjects { get; set; } 
        [RequiredIf("HasSelectedTracingType", true, ErrorMessage = "El campo Asignar seguimiento es requerido")]
        public int? TracingTypeId { get; set; }
        public bool HasSelectedTracingType { get; set; } 
        public IEnumerable<BaseViewModels.KeyValue> TracingTypes { get; set; }
        public DateTime? TracingDate { get; set; }
        public string Tracinghour { get; set; }
        public List<AttachedFiles> AttachedFiles { get; set; }
        public IEnumerable<KeyValue> DocumentsTypes { get; set; }
        public IEnumerable<KeyValue> DocumentsGroup { get; set; }  
        public long? templateSentRelatedFileId { get; set; }
        public long? templateSentId { get; set; }
        public short? SelectedTemplateId { get; set; }
        public long? RooTemplateSentId { get; set; }
        public double? MontoApagar { get; set; }
        public DateTime? StartDate { get; set; }
        public long? accountId { get; set; }
        public string LoanType { get; set; }
        public long? CustomerId { get; set; }
        public long? CaseNumber { get; set; }
        public long LoanNumber { get; set; }
        public string ProductType { get; set; }
        public string CaseType { get; set; }   

        [MustBeTrue(ErrorMessage="Debe selercionar principal")]
        public bool HasSelectPrincipal { get; set; }

        public string PrincipalCustomer { get; set; }
        public bool SendPrincipalCustomer { get; set; }

        public string PrincipalAgent { get; set; }
        public bool SendPrincipalAgent { get; set; }

        public string PrincipalOffice { get; set; }
        public bool SendPrincipalOffice { get; set; }

        public string NumeroCuota { get; set; }
    }

    public class AttachedFiles
    {
        public long? accountId { get; set; }
        public long? templateSentId { get; set; }
        public long? templateSentRelatedFileId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDesc { get; set; }        
        public string FileName { get; set; }
        public string DocumentPath { get; set; }
        public string documentGroupName { get; set; }
        public decimal? sizeFile { get; set; }
    }    
      
    public class TemplateDocument
    {
        public short TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateCode { get; set; }
        public string PartialViewName { get; set; }
        public string Description { get; set; }
        public string DocumentNameKey { get; set; }
    }
}