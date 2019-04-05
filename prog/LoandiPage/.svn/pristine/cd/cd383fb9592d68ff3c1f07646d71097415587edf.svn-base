using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Xml;
using CustomerCallBack.CustomCode;
using Entity.Entities;

namespace CustomerCallBack.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public bool SendCallback(Callback redirect)
        {
            string stcUrl = "";
            string numToCall = "";
            try
            {
                #region Generando llamada automatica
                numToCall = redirect.CntCode != null ? redirect.CntCode + redirect.CityCode + redirect.NumToCall : redirect.CityCode + redirect.NumToCall;

                //Verifico si esta activado el envio de la llamada con el parametro de base de datos 
                var ParameterIndicator = oDropDownManager.GetParameter("PARAMETER_KEY_SEND_CUSTOMER_CALLBACK").Value;
                var CandSendCallback = (Convert.ToInt32(ParameterIndicator) > 0);

                var parameter = new Callback
                {
                    NumToCall = numToCall,
                    FirstNames = redirect.FirstNames,
                    LastNames = redirect.LastNames,
                    Reference = redirect.Reference,
                    PhoneType = redirect.PhoneType.GetValueOrDefault()
                };

                var LogResult = oCallBackManager.SetCallBack(parameter);

                if (CandSendCallback)
                {

                    //notificando llamada a la cuenta de servicio configurada
                    SendNotificationCallBack(redirect); //esto esta comentado hasta que la url de la llamada esté funcionando



                    var UrlBase = oDropDownManager.GetParameter("PARAMETER_KEY_NEX_URL_CALBACK_SERVICES").Value;

                    string queryString =
                                 "NextURL=" + UrlBase +
                                 "&NumToCall=" + numToCall;

                    stcUrl = string.Format(oDropDownManager.GetParameter("PARAMETER_KEY_URL_CALBACK_SERVICES").Value, numToCall);


                    var webRequest = WebRequest.Create(stcUrl);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    var byteArray = Encoding.UTF8.GetBytes(queryString);
                    webRequest.ContentLength = byteArray.Length;
                    var dataStream = webRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }
                #endregion
                return true;
            }

            catch (Exception ex)
            {
                //LoggerHelper.Log(CommonEnums.Categories.Error, "CustomerCallback", 0, "Error posteando la llamada a los agentes de servicios", ex.Message, ex);
                return false;
            }
        }

        public void SendNotificationCallBack(Callback redirect)
        {
            var AccountTo = "";
            var AccountFrom = "";
            try
            {
                AccountTo = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_TO_CALLBACK").Value; //"jamador@statetrustlife.com, csoriano@statetrustlife.com,robispo@statetrustlife.com";
                AccountFrom = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_SENDER_CALLBACK").Value;

                var subject = string.Concat("Llamada generada desde el Punto de Venta de Auto para el cliente ", redirect.FirstNames, " ", redirect.LastNames);
                var body = string.Concat("Por este medio le informamos que el cliente ", redirect.FirstNames, " ", redirect.LastNames, " ha solicitado desde el Punto de Venta de Auto una llamada automática al teléfono ", redirect.CntCode != null ? " Móvil " + redirect.CntCode + redirect.CityCode + redirect.NumToCall : "Fijo " + redirect.CityCode + redirect.NumToCall, !string.IsNullOrEmpty(redirect.PolicyNum) ? " con relación a su póliza No. " + redirect.PolicyNum : "");

                List<string> destinatariosListError = new List<string>();

                foreach (var e in AccountTo.Split(','))
                {
                    destinatariosListError.Add(e);
                }

                SendEmailHelper.SendMail(AccountFrom, destinatariosListError, subject, body, null);
            }
            catch (Exception ex)
            {
                //LoggerHelper.Log(CommonEnums.Categories.Error, "CustomerCallBack", 0, "Error enviando correo a los angentes de servicio sobre llamada telefonica en PVV", ex.Message, ex);
            }
        }

        public ActionResult GetPhoneTypes()
        {
            IEnumerable<Entity.Entities.Generic> result = null;

            try
            {
                result = oDropDownManager.GetDropDown(CommonEnums.DropDownType.PHONETYPES.ToString()).ToList();
            }
            catch (Exception ex)
            {
                //LoggerHelper.Log(CommonEnums.Categories.Error, "CustomerCallBack", 0, "Error buscando los tipos de teléfonos", ex.Message, ex);
            }
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}



