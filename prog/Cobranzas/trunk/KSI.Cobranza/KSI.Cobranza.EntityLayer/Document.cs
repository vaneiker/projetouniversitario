using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KSI.Cobranza.EntityLayer
{
    /// <summary>
    /// vbarrera | 14 Feb 2019
    /// Entidad para los documentos.
    /// La estructura de esta clase esta basada en el resultado
    /// del proceso almacenado [TH].[SP_GET_DOCUMENT]
    /// </summary>
    public class Document
    {
        #region Output properties
        public int IdRequirementCategory { get; set; }
        public string RequirementCategory { get; set; }
        public int IdFormType { get; set; }
        public string FormType { get; set; }
        public int IdContractType { get; set; }
        public string ContractType { get; set; }
        public int IdDocumentType { get; set; }
        public string DocumentType { get; set; }
        public string RequirementName { get; set; }
        public string Description { get; set; }
        public bool IsMandatory { get; set; }
        public string NameKey { get; set; }
        public string DocumentId { get; set; }
        public bool IsGeneratedBySystem { get; set; }
        public bool IsUploadedBySystem { get; set; }
        public int OrderGrid { get; set; }
        public string ModelNameForGeneration { get; set; }
        public string ModelNameForDownload { get; set; }
        #endregion

        #region Input properties
        public DateTime CreateDate { get; set; }
        public int CreateUsr { get; set; }
        public DateTime? ModiDate { get; set; }
        public int? ModiUsr { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        #region Input and output properties
        public long QueueId { get; set; }
        public int IdRequirement { get; set; }
        public int Sequence { get; set; }
        public string DocumentName { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public bool Validated { get; set; }
        public Nullable<int> ValidateUsr { get; set; }
        public bool IsValid { get; set; }
        public string Comment { get; set; }
        public Nullable<int> IdShortAnswer { get; set; }
        public string Observation { get; set; }
        #endregion
    }
}
