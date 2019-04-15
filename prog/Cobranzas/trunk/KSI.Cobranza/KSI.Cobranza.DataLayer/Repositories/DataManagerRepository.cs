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
    public class DataManagerRepository : BaseRepository, IBaseRepository<DataField>, IDBOperation<Movement>
    {
        public DataManagerRepository(DbContext dbContext) : base(dbContext)
        { }

        public ResultRepository Add(Movement entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Delete(Movement entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Edit(Movement entity)
        {
            throw new NotImplementedException();
        }

        public DataField FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataField> GetAll(long? entityId = default(long?))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="IdMovement"></param>
        /// <returns></returns>
        public IEnumerable<DataFieldGroup> GetDataFieldGroup(long QueueId, int IdMovement)
        {
            return _dbContext.SP_GET_GROUP_FIELD(IdMovement, QueueId)
                .Select(x => new DataFieldGroup() {
                    IdFieldGroup = x.IdFieldGroup,
                    FieldGroupName = x.FieldGroupName,
                    FieldGroupDescripcion = x.FieldGroupDescripcion,
                    cssClassContent = x.cssClassContent,
                    cssClassPanel = x.cssClassPanel,
                    HtmlTitle = x.HtmlTitle,
                    cssClassIcon = x.cssClassIcon,
                    HtmlValidationQuestion = x.HtmlValidationQuestion,
                    Ordinal = x.Ordinal
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="IdMovement"></param>
        /// <returns></returns>
        public IEnumerable<DataField> GetDataField(long QueueId, int IdFieldGroup, int Sequence)
        {
            return _dbContext.SP_GET_DATA_FIELD(QueueId, IdFieldGroup, Sequence)
                .Select(x => new DataField()
                {
                    IdField = x.IdField,
                    FieldName = x.FieldName,
                    IdFieldType = x.IdFieldType,
                    FieldTypeName = x.FieldTypeName,
                    ColumnName = x.ColumnName,
                    OrderForm = x.OrderForm,
                    cssClass = x.cssClass,
                    IdFieldGroup = x.IdFieldGroup,
                    IsMoney = x.IsMoney,
                    IsPercent = x.IsPercent,
                    FormatString = x.FormatString,
                    IsReadOnly = x.IsReadOnly,
                    IsVisibleCrud = x.IsVisibleCrud,
                    IsVisibleGrid = x.IsVisibleGrid,
                    QueueId = x.QueueId,
                    Sequence = x.Sequence,
                    DatoStr = x.DatoStr,
                    DatoNum = x.DatoNum,
                    DatoInt = x.DatoInt,
                    DatoDat = x.DatoDat,
                    DatoBit = x.DatoBit,
                    DatoText = x.DatoText,
                    IdCatalogHeader = x.IdCatalogHeader,
                    Code = x.Code
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataField"></param>
        /// <returns></returns>
        public ResultRepository SaveDataField(DataField dataField)
        {
            return _dbContext.SP_SET_CASEDATA(
                dataField.QueueId,
                dataField.Sequence,
                dataField.IdField, 
                dataField.FieldName, 
                dataField.DatoStr, 
                dataField.DatoNum,
                dataField.DatoInt,
                dataField.DatoDat,
                dataField.DatoBit,
                dataField.DatoText, 
                dataField.IdCatalogHeader, dataField.Code,
                dataField.CreateDate,
                dataField.CreateUsr,
                dataField.ModiDate,
                dataField.ModiUsr,
                dataField.Active,
                dataField.IsDeleted
                ).Select(x => new ResultRepository()
                {
                    Action = x.Action,
                    entityId = 0
                }).FirstOrDefault();
        }
    }
}
