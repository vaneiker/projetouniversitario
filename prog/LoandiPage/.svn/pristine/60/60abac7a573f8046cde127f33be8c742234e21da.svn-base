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

        public ActionResult Index(string m = "")
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

                //notificando llamada a la cuenta de servicio configurada
                SendNotificationCallBack(redirect); //esto esta comentado hasta que la url de la llamada esté funcionando

                if (CandSendCallback)
                {
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
                AccountTo = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_TO_CALLBACK").Value;
                AccountFrom = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_SENDER_CALLBACK").Value;

                var subject = string.Concat("Llamada generada desde el Punto de Venta de Auto para el cliente ", redirect.FirstNames, " ", redirect.LastNames);
                var body = string.Concat("Por este medio le informamos que el cliente <strong>", redirect.FirstNames, " ", redirect.LastNames,
                    "</strong> ha solicitado desde el Punto de Venta de Auto una llamada automática al Teléfono ",
                      redirect.CntCode != null
                    ? "Móvil: <strong>" + redirect.CntCode + redirect.CityCode + redirect.NumToCall + "</strong>"
                    : "Fijo: <strong>" + redirect.CityCode + redirect.NumToCall + "</strong>",
                    !string.IsNullOrEmpty(redirect.BL) ? "<br> Asistencia para una póliza de seguro: <strong>" + redirect.BL + "</strong>" : "",
                    !string.IsNullOrEmpty(redirect.Email) ? "<br> Su correo electrónico es: <strong>" + redirect.Email + "</strong>" : "",
                    !string.IsNullOrEmpty(redirect.Message)
                    ? "<br> Su comentario es: <strong>" + redirect.Message + "</strong>"
                    :
                    "");

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

        public JsonResult getClientIpInfo(string ip = "", string m = "")
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);

            bool success = true;
            string message = "";
            int id = 0;
            string description = null;
            bool processAll = false;

            if (!string.IsNullOrEmpty(m))
            {
                processAll = true;
            }

            try
            {
                WebClient client = new WebClient();

                // Make an api call and get response.
                string url = string.Format("https://tools.keycdn.com/geo.json?host={0}", ip);
                string response = client.DownloadString(url);
                //Deserialize response JSON
                Utility.GeoRootObject ipdata = Utility.deserializeJSON<Utility.GeoRootObject>(response);
                if (ipdata.status == "error")
                {
                    success = false;
                    message = ipdata.description;
                    //throw new Exception(ipdata.description);
                }
                else
                {
                    //aqui guardar el json generado
                    LogVisits param = new LogVisits();

                    if (processAll)
                    {
                        var decode = Utility.Decode(m);
                        var spl = decode.Split('|');

                        id = Convert.ToInt32(spl[0]);
                        description = spl[1];
                    }

                    param.contactFormId = id;
                    param.iP = ip; //ipdata.data.geo.ip;
                    param.iPInfo = response;
                    param.system = "Landing Page";

                    oCallBackManager.SetLogVisits(param);

                }
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.ToString();
            }

            return Json(new { success = success, message = message, medio = m }, JsonRequestBehavior.AllowGet);

        }

    }
}



