using KSI.Cobranza.LogicLayer;
using KSI.Cobranza.LogicLayer.Implementation;
using KSI.Cobranza.LogicLayer.Implementation.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSI.Cobranza.Web.Controllers
{
    public class DataManagerController : BaseController
    {
        #region Fields
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// Le concede a este controlador acceso a la data
        /// </summary>
        DataManager _dataManager = new DataManager();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// vbarrera | 19 Mar 2019
        /// Guarda los campos de datos
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(CrudFormMovement movement)
        {
            try
            {
                movement.DataFieldsGroups?.ForEach(dataFieldGroup => {

                    dataFieldGroup.DataFields?.ForEach(dataField => {

                        dataField.CreateDate = DateTime.Now;
                        dataField.CreateUsr = Usuario.UserID;
                        dataField.ModiDate = DateTime.Now;
                        dataField.ModiUsr = Usuario.UserID;

                        Result result 
                            = _dataManager.SaveDataField(dataField);

                        if (result.HasError)
                            throw new Exception(result.ErrorDescription);
                    });
                });

                movement.Run();
                movement.Response.State = true;
            }
            catch (Exception exception)
            {
                movement.Response.Message = exception.Message;
            }

            return Json(movement.Response, JsonRequestBehavior.AllowGet);
        }
    }
}