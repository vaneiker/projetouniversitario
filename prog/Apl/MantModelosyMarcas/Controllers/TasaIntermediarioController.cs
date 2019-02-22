using StateTrustGlobal.Data;
using StateTrustGlobal.Helpers;
using StateTrustGlobal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MantModelosyMarcas.Controllers
{

    public class TasaIntermediarioController : BaseController
    {
        DataAccess DataAccess = new DataAccess();
        SendEmail SendEmail = new SendEmail();

        string subject = System.Configuration.ConfigurationManager.AppSettings["SubjectIndice"];
        string MensajeIndice = System.Configuration.ConfigurationManager.AppSettings["MensajeIndice"];
        string emailTo = System.Configuration.ConfigurationManager.AppSettings["ToEmail"];
        string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
        string CopiaEmail = System.Configuration.ConfigurationManager.AppSettings["CopiaEmail"];
        string CopiaOcultaEmail = System.Configuration.ConfigurationManager.AppSettings["CopiaOcultaEmail"];


        //
        // GET: /TasaIntermediario/
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ViewBag.CurrentPage = "TasaIntermediario";
                Session["UserName"] = GetCurrentUserName();
                Session["Active"] = "Active";

                if (Session["UserName"] == null)
                {
                    Session.Add("UserName", GetCurrentUserName());
                }
                else
                {
                    Session["UserName"] = GetCurrentUserName();
                }
                
                var MostrarDatos = DataAccess.Mostrar_Intermediarios();
                return View(MostrarDatos);
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al Mostrar los Intermediarios!!", "");
                LoggerHelper.Log(GetCurrentUserName(), "TasaIntermediario", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index", "TasaIntermediario");
            }

        }
        [HttpGet]
        public ActionResult BuscarIntermediario(string Search)
        {
            try
            {
                ViewBag.CurrentPage = "TasaIntermediario";
                ViewBag.Mostrar = false;
                ViewBag.Iniciar = true;
                return View();
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al Mostrar el Intermediario o Codigo Incorrecto !!", "");
                LoggerHelper.Log(GetCurrentUserName(), "TasaIntermediario", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index", "TasaIntermediario");
            }
        }

        [HttpPost]
        public ActionResult BuscarIntermediario(TasaIntermediario tasaIntermedairio, string Search)
        {
            try
            {
                ViewBag.CurrentPage = "TasaIntermediario";
                var Mostrar = DataAccess.Mostrar_Intermediarios(Convert.ToInt32(Search));
                if (Mostrar.Count() > 0)
                {
                    Session["codigoIntermediario"] = Mostrar.ToList()[0].codigo;
                    Session["NombreIntermediario"] = Mostrar.ToList()[0].NombreVendedor;

                    ViewBag.Mostrar = true;
                    ViewBag.Iniciar = false;
                    return View();
                }
                else
                {
                    Danger(string.Format("Código introducido es incorrecto <b>{0}</b>", DataAccess.MsgSql), true);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al Mostrar el Intermediario o Codigo Incorrecto!!", "");
                LoggerHelper.Log(GetCurrentUserName(), "TasaIntermediario", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index", "TasaIntermediario");
            }

        }
        [HttpPost]
        public ActionResult AgregarTasa()
        {
            try
            {
                ViewBag.CurrentPage = "TasaIntermediario";
                var codigo = Session["codigoIntermediario"].ToString();
                var usuario = Session["UserName"].ToString();
                if (Session["UserName"] == null)
                    Session.Add("UserName", usuario);
                else
                    Session["UserName"] = usuario;

                DataAccess.Agregar_TasaIntermediarios(Convert.ToInt32(codigo), usuario);

                if (DataAccess.MsgSql != "Listo!!!")
                {
                    Danger(string.Format("<b>{0}</b>", DataAccess.MsgSql), true);
                    return RedirectToAction("Index");
                }
                else
                {
                    string realUserName = GetCurrentUserFullName() + " (" + usuario + ")";
                    string msg = string.Format(MensajeIndice, "<b>" + Session["NombreIntermediario"].ToString() + "</b>", "<b>" + Session["codigoIntermediario"].ToString() + "</b>", "<b>" + realUserName + "</b>");
                    Success(string.Format("<b>{0}</b>", DataAccess.MsgSql), true);

                    /*enviar correo*/
                    SendEmail.SendVirtualOfficeMail(emailTo, FromEmail, subject, msg, CopiaEmail, CopiaOcultaEmail);
                    /**/
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error agregando la tasa al Intermediario!!", "");
                LoggerHelper.Log(GetCurrentUserName(), "TasaIntermediario", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index", "BuscarIntermediario");
            }
        }
    }
}