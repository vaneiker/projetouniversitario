using Entity.UnderWriting.Entities;
using System;
using System.Configuration;
using System.Linq;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class ResultPayCardNet : BasePageOnly
    {
        private Payment.Provider.Log getDataLog(String OrderId)
        {
            var DataLogPayment = ObjServices.oPaymentManager.GetPaymentLog(new Payment.Provider.Log
            {
                OrderId = OrderId
            });

            return DataLogPayment;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.itemResponsePayApi result = null;
            string logDesc;

            try
            {
                result = new Utility.itemResponsePayApi
                {
                    CreditCardNumber = Request.Form["CreditCardNumber"],
                    ResponseCode = Request.Form["ResponseCode"],
                    AuthorizationCode = Request.Form["AuthorizationCode"],
                    RetrivalReferenceNumber = Request.Form["RetrivalReferenceNumber"],
                    OrdenID = Request.Form["OrdenId"],
                    TransactionID = Request.Form["TransactionId"]
                };

                if (!IsPostBack)
                    PayProcess(result);
            }
            catch (Exception ex)
            {
                var DataLogPayment = getDataLog(result.OrdenID);
                logDesc = "{0}\n------------------------------------------\n{1}\n------------------------------------------\n{2}";
                //Loguear Error
                ObjServices.oPaymentManager.InsertPaymentLog(new Payment.Provider.Log
                {
                    LogTypeId = Utility.LogTypeId.Exception.ToInt(),
                    CorpId = DataLogPayment.CorpId,
                    CompanyId = DataLogPayment.CompanyId,
                    ProjectId = DataLogPayment.ProjectId,
                    OrderId = DataLogPayment.OrderId,
                    LogDesc = string.Format(logDesc, ex.Message, ex.InnerException, ex.StackTrace)
                });

                messageResponse.InnerText = ex.Message;
            }

        }

        private void PayProcess(Utility.itemResponsePayApi itemRespponse)
        {
            var providerID = ConfigurationManager.AppSettings["ProviderId"].ToInt();
            var dataResponseCode = ObjServices.GettingDropData(Utility.DropDownType.ProviderResponseCode,
                                                           ProviderId: providerID
                                                          );

            var jsonResult = Utility.serializeToJSON<Utility.itemResponsePayApi>(itemRespponse);

            var DataLogPayment = ObjServices.oPaymentManager.GetPaymentLog(new Payment.Provider.Log
            {
                OrderId = itemRespponse.OrdenID
            });

            //Loguear la respuesta de carnet
            ObjServices.oPaymentManager.InsertPaymentLog(new Payment.Provider.Log
            {
                LogTypeId = Utility.LogTypeId.Response.ToInt(),
                CorpId = DataLogPayment.CorpId,
                CompanyId = DataLogPayment.CompanyId,
                ProjectId = DataLogPayment.ProjectId,
                OrderId = DataLogPayment.OrderId,
                LogDesc = jsonResult
            });

            var ResponseCode = itemRespponse.ResponseCode.NTrim();

            var Transaction = ObjServices.oPaymentManager.GetProviderTransactionByOrderId(new Payment.Provider.Transaction
            {
                OrderId = DataLogPayment.OrderId
            });

            Transaction.TransactionId = itemRespponse.TransactionID;
            Transaction.CreditCardNumber = itemRespponse.CreditCardNumber;
            Transaction.ResponseCode = ResponseCode;
            Transaction.AuthorizationCode = itemRespponse.AuthorizationCode;
            Transaction.RetrievalReferenceNumber = itemRespponse.RetrivalReferenceNumber;
            Transaction.UserId = null;

            ObjServices.oPaymentManager.SetProviderTransaction(Transaction);

            if (ResponseCode == "00")
            {
                ObjServices.oPaymentManager.SetPaymentDetailStatusByOrderId(new Payment.ApplyPaymentDetail
                {
                    OrderId = DataLogPayment.OrderId,
                    PaymentStatusId = Utility.PaymentStatus.Approved.ToInt(),
                    UserId = -1
                });
            }

            messageResponse.InnerText = dataResponseCode.FirstOrDefault(x =>
                                                                        x.ResponseCode == itemRespponse.ResponseCode
                                                                       ).ResponseDesc;                              
        }
    }
}