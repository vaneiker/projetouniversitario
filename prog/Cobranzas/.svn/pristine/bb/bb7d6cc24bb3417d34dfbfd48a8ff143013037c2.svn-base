using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    public class CrudMovement : MovementBusinessModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CrudMovement()
        {
            Response = new Response();
        }

        /// <summary>
        /// 
        /// </summary>
        protected DataManager _dataManager = new DataManager();

        /// <summary>
        /// 
        /// </summary>
        public List<DataFieldGroup> DataFieldsGroups { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Response Response { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            ResultLogic<DataFieldGroup> dataFieldGroupDataResult 
                = _dataManager.GetDataFieldGroup(QueueId, MovementEntityModel.IdMovement);

            if (dataFieldGroupDataResult.result.HasError)
                throw new Exception(dataFieldGroupDataResult.result.ErrorDescription);

            DataFieldsGroups = dataFieldGroupDataResult.dataResult.ToList();

            DataFieldsGroups.ForEach(dataField => {

                ResultLogic<DataField> dataFieldDataResult 
                    = _dataManager.GetDataField(QueueId, dataField.IdFieldGroup);

                if (dataFieldDataResult.result.HasError)
                    throw new Exception(dataFieldDataResult.result.ErrorDescription);

                dataField.DataFields = dataFieldDataResult.dataResult.ToList();
            });
        }

        #region Get Setting for Mvc Web controls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataField"></param>
        /// <returns></returns>
        public object GetSettings(DataField dataField)
        {
            string CssClass;

            if (dataField.IdFieldType == 6)
                CssClass = string.Empty;
            else
                CssClass = "form-control";

            if (dataField.IsReadOnly)
                return new
                {
                    @class = CssClass,
                    @readonly = "true"
                };
            else
                return new { @class = CssClass };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataField"></param>
        /// <returns></returns>
        public object GetSettingsForDateTime(DataField dataField)
        {
            if (dataField.IsReadOnly)
                return new
                {
                    @class = "form-control DataManager_Crud_DatePicker",
                    @readonly = "true"
                };
            else
                return new { @class = "form-control DataManager_Crud_DatePicker" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataField"></param>
        /// <returns></returns>
        public object GetSettingsForDecimal(DataField dataField)
        {
            if (dataField.IsReadOnly)
                return new
                {
                    @class = "form-control",
                    @readonly = "true",
                    @Value = string.Format("{0:0.00}", dataField.DatoNum)
                };
            else
                return new
                {
                    @class = "form-control",
                    @Value = string.Format("{0:0.00}", dataField.DatoNum)
                };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataField"></param>
        /// <returns></returns>
        public object GetSettingsForDropDownList(DataField dataField)
        {
            if (dataField.IsReadOnly)
                return new
                {
                    @class = "form-control",
                    @readonly = "true"
                };
            else
                return new { @class = "form-control" };
        }
        #endregion
    }
}
