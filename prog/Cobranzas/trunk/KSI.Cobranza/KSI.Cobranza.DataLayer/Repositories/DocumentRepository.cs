using KSI.Cobranza.DataLayer.Interfaces;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class DocumentRepository : BaseRepository, IBaseRepository<Document>, IDBOperation<Document>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public DocumentRepository(DbContext dbContext) 
            : base(dbContext)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Document FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public IEnumerable<Document> GetAll(long? entityId = default(long?))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vbarrera | 06 Feb 2019
        /// Invoque para obtener la lista de documentos
        /// relacionados a un queue (QueueId)
        /// </summary>
        /// <param name="QueueId">Id del queue</param>
        /// <returns></returns>
        public IEnumerable<Document> Get(long QueueId)
        {
            return
                _dbContext.SP_GET_DOCUMENT(null, QueueId, null)
                .Select(x => new Document()
                {
                    QueueId = x.QueueId,
                    IdRequirement = x.IdRequirement,
                    Sequence = x.Sequence,
                    IdRequirementCategory = x.IdRequirementCategory,
                    RequirementCategory = x.RequirementCategory,
                    IdFormType = x.IdFormType,
                    FormType = x.FormType,
                    IdContractType = x.IdContractType,
                    ContractType = x.ContractType,
                    IdDocumentType = x.IdDocumentType,
                    DocumentType = x.DocumentType,
                    RequirementName = x.RequirementName,
                    Description = x.Description,
                    IsMandatory = x.IsMandatory,
                    NameKey = x.NameKey,
                    DocumentId = x.DocumentId,
                    IsGeneratedBySystem = x.IsGeneratedBySystem,
                    IsUploadedBySystem = x.IsUploadedBySystem,
                    OrderGrid = x.OrderGrid,
                    ModelNameForGeneration = x.ModelNameForGeneration,
                    ModelNameForDownload = x.ModelNameForDownload,
                    DocumentName = x.DocumentName,
                    Extension = x.Extension,
                    Path = x.Path,
                    Validated = x.Validated,
                    ValidateUsr = x.ValidateUsr,
                    IsValid = x.IsValid,
                    Comment = x.Comment,
                    IdShortAnswer = x.IdShortAnswer,
                    Observation = x.Observation,
                });
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener un documento en especifico tomando en cuenta el queue/caso
        /// </summary>
        /// <param name="QueueId">Id del queue</param>
        /// <param name="IdRequirement">Id del documento requerido</param>
        /// <returns></returns>
        public Document Get(int IdRequirement, long? QueueId)
        {
            return
                _dbContext.SP_GET_DOCUMENT(IdRequirement, QueueId, null)
                .Select(x => new Document()
                {
                    QueueId = x.QueueId,
                    IdRequirement = x.IdRequirement,
                    Sequence = x.Sequence,
                    IdRequirementCategory = x.IdRequirementCategory,
                    RequirementCategory = x.RequirementCategory,
                    IdFormType = x.IdFormType,
                    FormType = x.FormType,
                    IdContractType = x.IdContractType,
                    ContractType = x.ContractType,
                    IdDocumentType = x.IdDocumentType,
                    DocumentType = x.DocumentType,
                    RequirementName = x.RequirementName,
                    Description = x.Description,
                    IsMandatory = x.IsMandatory,
                    NameKey = x.NameKey,
                    DocumentId = x.DocumentId,
                    IsGeneratedBySystem = x.IsGeneratedBySystem,
                    IsUploadedBySystem = x.IsUploadedBySystem,
                    OrderGrid = x.OrderGrid,
                    ModelNameForGeneration = x.ModelNameForGeneration,
                    ModelNameForDownload = x.ModelNameForDownload,
                    DocumentName = x.DocumentName,
                    Extension = x.Extension,
                    Path = x.Path,
                    Validated = x.Validated,
                    ValidateUsr = x.ValidateUsr,
                    IsValid = x.IsValid,
                    Comment = x.Comment,
                    IdShortAnswer = x.IdShortAnswer,
                    Observation = x.Observation,
                }).FirstOrDefault();
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener un documento en especifico sin considerar el queue/caso
        /// </summary>
        /// <param name="IdRequirement">Id del documento requerido</param>
        /// <returns></returns>
        public Document Get(int IdRequirement)
        {
            return
                _dbContext.SP_GET_DOCUMENT(IdRequirement, null, null)
                .Select(x => new Document()
                {
                    QueueId = x.QueueId,
                    IdRequirement = x.IdRequirement,
                    Sequence = x.Sequence,
                    IdRequirementCategory = x.IdRequirementCategory,
                    RequirementCategory = x.RequirementCategory,
                    IdFormType = x.IdFormType,
                    FormType = x.FormType,
                    IdContractType = x.IdContractType,
                    ContractType = x.ContractType,
                    IdDocumentType = x.IdDocumentType,
                    DocumentType = x.DocumentType,
                    RequirementName = x.RequirementName,
                    Description = x.Description,
                    IsMandatory = x.IsMandatory,
                    NameKey = x.NameKey,
                    DocumentId = x.DocumentId,
                    IsGeneratedBySystem = x.IsGeneratedBySystem,
                    IsUploadedBySystem = x.IsUploadedBySystem,
                    OrderGrid = x.OrderGrid,
                    ModelNameForGeneration = x.ModelNameForGeneration,
                    ModelNameForDownload = x.ModelNameForDownload,
                    DocumentName = x.DocumentName,
                    Extension = x.Extension,
                    Path = x.Path,
                    Validated = x.Validated,
                    ValidateUsr = x.ValidateUsr,
                    IsValid = x.IsValid,
                    Comment = x.Comment,
                    IdShortAnswer = x.IdShortAnswer,
                    Observation = x.Observation,
                }).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ResultRepository Add(Document entity)
        {
            return _dbContext.SP_SET_DOCUMENT(
                entity.Active, // Active
                entity.Comment, // Comment
                entity.CreateDate, // CreateDate
                entity.CreateUsr, // CreateUsr
                entity.Extension, // Extension
                entity.IdRequirement, // IdRequirement
                entity.IdShortAnswer, // IdShortAnswer
                entity.IsDeleted, // IsDeleted
                entity.IsValid, // IsValid
                entity.ModiDate, // ModiDate
                entity.ModiUsr, // ModiUsr
                entity.RequirementName, // Name
                entity.Observation, // Observation
                entity.Path, // Path
                entity.QueueId, // QueueId
                entity.Sequence, // Sequence
                entity.Validated, // Validated
                entity.ValidateUsr  // ValidateUsr
                )
                .Select(x => new ResultRepository()
                {
                    Action = x.Action,
                    entityId = 0
                })
                .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ResultRepository Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vbarrera | 26 Feb 2019
        /// Inserta o edita un documento
        /// Tabla [Loans].[TH].[Document]
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// NOTA: No retorna ID porque la tabla posee llave compuesta 
        /// y los elementos que componen la llave son enviados como parametros al proceso almacenado
        /// </returns>
        public ResultRepository Edit(Document entity)
        {
            return _dbContext.SP_SET_DOCUMENT(
                entity.Active, // Active
                entity.Comment, // Comment
                entity.CreateDate, // CreateDate
                entity.CreateUsr, // CreateUsr
                entity.Extension, // Extension
                entity.IdRequirement, // IdRequirement
                entity.IdShortAnswer, // IdShortAnswer
                entity.IsDeleted, // IsDeleted
                entity.IsValid, // IsValid
                entity.ModiDate, // ModiDate
                entity.ModiUsr, // ModiUsr
                entity.RequirementName, // Name
                entity.Observation, // Observation
                entity.Path, // Path
                entity.QueueId, // QueueId
                entity.Sequence, // Sequence
                entity.Validated, // Validated
                entity.ValidateUsr  // ValidateUsr
                )
                .Select(x => new ResultRepository() {
                    Action = x.Action,
                    entityId = 0
                })
                .FirstOrDefault();
        }
    }
}
