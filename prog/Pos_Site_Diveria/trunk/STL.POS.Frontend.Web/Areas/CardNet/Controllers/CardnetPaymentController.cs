using STL.POS.Data;
using STL.POS.Frontend.Web.Areas.CardNet.Models;
using STL.POS.Frontend.Web.Helpers;
using STL.POS.WsProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Areas.CardNet.Controllers
{
    public class CardNetPaymentController : Controller
    {
        private PosModel dataAccess;
        private CoreProxy coreProxy;
        public CardNetPaymentController(PosModel da, CoreProxy cp)
        {
            dataAccess = da;
            coreProxy = cp;
        }



        [HttpPost]
        public ActionResult DummyAuthorization(FormCollection formData)
        {
            ViewBag.ReturnUrlOk = formData["ReturnUrl"];
            ViewBag.ReturnUrlCancel = formData["CancelUrl"];
            ViewBag.ResponseCode = DateTime.Now.Millisecond % 37;
            ViewBag.RetrivalReferenceNumber = DateTime.Now.Millisecond;
            ViewBag.TransactionId = formData["TransactionId"];
            ViewBag.OrdenId = formData["OrdenId"];
            return View();

        }

        [AjaxHandleError]
        public ActionResult GeneratePostFormForAuthorization(int quotationId)
        {
            var quotation = dataAccess.Quotations.Where(q => q.Id == quotationId).FirstOrDefault();
            if (quotation != null)
            {
                var model = new RequestAuthModel();
                var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                                Request.ApplicationPath.TrimEnd('/');
                model.AcquiringInstitutionCode = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_ACQUIRING_INSTITUTION_CODE).Value;
                model.Amount = (quotation.AmountToPayEnteredByUser.GetValueOrDefault(0m) * 100).ToString("000000000000");
                model.CancelUrl = baseUrl + Url.Action("AuthorizationCancelled", "PosAuto", new { Area = "Auto", id= quotationId });
                model.CardnetUrl = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_PAYMENT_URL).Value;
                model.CurrencyCode = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_CURRENCY_CODE).Value;
                model.Ipclient = Request.UserHostAddress;
                model.MerchantName = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_MERCHANT_NAME).Value.PadRight(40, ' ');
                model.MerchantNumber = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_MERCHANT_NUMBER).Value.PadRight(15, ' ');
                model.MerchantNumber_amex = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_MERCHANT_NUMBER_AMEX).Value;
                model.MerchantTerminal = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_MERCHANT_TERMINAL).Value;
                model.MerchantTerminal_amex = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_MERCHANT_TERMINAL_AMEX).Value;
                model.MerchantType = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_MERCHANT_TYPE).Value;
                model.OrdenId = quotation.Id.ToString();
                model.PageLanguaje = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_PAGE_LANGUAGE).Value;
                model.ReturnUrl = baseUrl + Url.Action("AuthorizationAnswered", "PosAuto", new { Area = "Auto" });
                model.Tax = (quotation.TotalISC.GetValueOrDefault(0) * 100).ToString("000000000000");
                model.TransactionId = quotation.QuotationDailyNumber.ToString("d0").PadLeft(6, '0');
                model.CardnetUrl = dataAccess.GetParameter(Parameter.PARAMETER_KEY_CARDNET_PAYMENT_URL).Value;
                return PartialView("AuthorizationForm", model);
            }
            else
                throw new Exception("Cotización no encontrada");


        }

    }
}