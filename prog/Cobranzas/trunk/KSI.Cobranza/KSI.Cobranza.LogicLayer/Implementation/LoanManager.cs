using KSI.Cobranza.DataLayer;
using KSI.Cobranza.DataLayer.Repositories;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class LoanManager : BaseManager, IBaseLogic<Loan>
    {
        private LoanRepository _loanRepository;

        public LoanManager()
        {
            _loanRepository = SingletonUnitOfWork.Instance.LoanRepository;
        }

        /// <summary>
        /// Get Payment Plan List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.LoanQueue> GetLoansInQueue(Nullable<int> QueueTypeId, Nullable<int> AssingToId, Nullable<int> VendorId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.LoanQueue> _Result;

            try
            {
                var data = _loanRepository.GetLoansInQueue(QueueTypeId, AssingToId, VendorId);
                _Result = new ResultLogic<Loan.LoanQueue> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.LoanQueue> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Payment Plan List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.PaymentPlan> GetPaymentPlan(Nullable<long> accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.PaymentPlan> _Result;

            try
            {
                var data = _loanRepository.GetPaymentPlan(accountId);
                _Result = new ResultLogic<Loan.PaymentPlan> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.PaymentPlan> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get  Codeudor List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.codeudor> GetCodeudor(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.codeudor> _Result;

            try
            {
                var data = _loanRepository.GetCodeudor(accountId);
                _Result = new ResultLogic<Loan.codeudor> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.codeudor> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Policy Information
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.PolicyInformation> GetPolicyInformation(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.PolicyInformation> _Result;

            try
            {
                var data = _loanRepository.GetPolicyInformation(accountId);
                _Result = new ResultLogic<Loan.PolicyInformation> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.PolicyInformation> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Policy Information
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.QuotaInformation> GetReceipOfPayment(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.QuotaInformation> _Result;

            try
            {
                var data = _loanRepository.GetReceipOfPayment(accountId);
                _Result = new ResultLogic<Loan.QuotaInformation> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.QuotaInformation> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Guarantee List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Guarantee> GetLoanGuarantee(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Guarantee> _Result;

            try
            {
                var data = _loanRepository.GetLoanGuarantee(accountId);
                _Result = new ResultLogic<Loan.Guarantee> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Guarantee> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Loan information
        /// </summary>
        /// <param name="searchType"></param>
        /// <param name="searchValue"></param>
        /// <param name="identificationNumber"></param>
        /// <returns></returns>
        public ResultLogic<Loan> GetLoanInformation(string clienteName, string identificationNumber, Nullable<long> quotationId, Nullable<long> accountId, string collateralReference, string ChasisNumber)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan> _Result;

            try
            {
                var data = _loanRepository.GetLoanInformation(clienteName, identificationNumber, quotationId, accountId, collateralReference, ChasisNumber);
                _Result = new ResultLogic<Loan> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Loan Detail
        /// </summary>
        /// <param name="quotationId"></param>
        /// <param name="loanNumber"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Detail> GetLoanDetail(long? quotationId, int? loanNumber, long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Detail> _Result;

            try
            {
                var data = _loanRepository.GetLoanDetailInformation(quotationId, loanNumber, accountId);
                _Result = new ResultLogic<Loan.Detail> { entity = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Detail> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collateralId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Vehicle> GetVehicleDetail(Nullable<long> collateralId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Vehicle> _Result;

            try
            {
                var data = _loanRepository.GetVehicleDetail(collateralId);
                _Result = new ResultLogic<Loan.Vehicle> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Vehicle> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dateStatement"></param>
        /// <param name="idTipo"></param>
        /// <returns></returns>
        public ResultLogic<Loan.paymentProjection> GetProjectedStatement(Nullable<long> accountId, Nullable<System.DateTime> dateStatement, Nullable<int> idTipo, Nullable<decimal> montoPago)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.paymentProjection> _Result;

            try
            {
                var data = _loanRepository.GetProjectedStatement(accountId, dateStatement, idTipo, montoPago);
                _Result = new ResultLogic<Loan.paymentProjection> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.paymentProjection> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        ///  Genrar la cabecera del envio del template
        /// </summary>
        /// <param name="templateSentId"></param>
        /// <param name="templateId"></param>
        /// <param name="accountId"></param>
        /// <param name="clienteId"></param>
        /// <param name="sendDate"></param>
        /// <param name="clientName"></param>
        /// <param name="documentPath"></param>
        /// <param name="documentName"></param>
        /// <param name="emails"></param>
        /// <param name="comments"></param>
        /// <param name="isActive"></param>
        /// <param name="isSendToClient"></param>
        /// <param name="isSendToOffice"></param>
        /// <param name="isSendToAgent"></param>
        /// <param name="caseDepartmentID"></param>
        /// <param name="caseDate"></param>
        /// <param name="caseHour"></param>
        /// <param name="caseComment"></param>
        /// <param name="caseNo"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Correspondence.RelatedDocuments.ResultHeader> SetTemplate(Nullable<long> templateSentId, Nullable<short> templateId, Nullable<long> accountId, Nullable<long> clienteId, Nullable<System.DateTime> sendDate, string clientName, string documentPath, string documentName, string emails, string comments, Nullable<bool> isActive, Nullable<bool> isSendToClient, Nullable<bool> isSendToOffice, Nullable<bool> isSendToAgent, Nullable<int> caseDepartmentID, Nullable<System.DateTime> caseDate, Nullable<System.TimeSpan> caseHour, string caseComment, Nullable<long> caseNo, Nullable<int> userId, string userName)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Correspondence.RelatedDocuments.ResultHeader> _Result;

            try
            {
                var data = _loanRepository.SetTemplate(templateSentId, templateId, accountId, clienteId, sendDate, clientName, documentPath, documentName, emails, comments, isActive, isSendToClient, isSendToOffice, isSendToAgent, caseDepartmentID, caseDate, caseHour, caseComment, caseNo, userId, userName);
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments.ResultHeader> { entity = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments.ResultHeader> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Elimina un archivo adjunto
        /// </summary>
        /// <param name="templateSentId"></param>
        /// <param name="templateSentRelatedFileId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Correspondence.RelatedDocuments.DeleteResult> DeleteRelateFile(Nullable<long> templateSentId, Nullable<long> templateSentRelatedFileId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Correspondence.RelatedDocuments.DeleteResult> _Result;

            try
            {
                var data = _loanRepository.DeleteRelateFile(templateSentId, templateSentRelatedFileId);
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments.DeleteResult> { entity = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments.DeleteResult> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Generar el detalle del envio del template
        /// </summary>
        /// <param name="templateSentRelatedFileId"></param>
        /// <param name="templateSentId"></param>
        /// <param name="documentTypeGroupId"></param>
        /// <param name="documentPath"></param>
        /// <param name="documentName"></param>
        /// <param name="comments"></param>
        /// <param name="isActive"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Correspondence.RelatedDocuments.ResultDetail> SetTemplateRelatedFile(Nullable<long> templateSentRelatedFileId, Nullable<long> templateSentId, Nullable<int> documentTypeGroupId, string documentPath, string documentName, string comments, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<decimal> sizeFile)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Correspondence.RelatedDocuments.ResultDetail> _Result;

            try
            {
                var data = _loanRepository.SetTemplateRelatedFile(templateSentRelatedFileId, templateSentId, documentTypeGroupId, documentPath, documentName, comments, isActive, userId, userName, sizeFile);
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments.ResultDetail> { entity = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments.ResultDetail> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relatedContactId"></param>
        /// <param name="meetingTypeId"></param>
        /// <param name="meetingSubTypeId"></param>
        /// <param name="meetingCaseId"></param>
        /// <param name="meetingCaseNoteId"></param>
        /// <param name="meetingCaseNoteFileId"></param>
        /// <param name="documentTypeGroupId"></param>
        /// <param name="documentPath"></param>
        /// <param name="documentName"></param>
        /// <param name="comments"></param>
        /// <param name="isActive"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="sizeFile"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Cases.Detail.File> SetMeetingCaseFile(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> meetingCaseNoteFileId, Nullable<int> documentTypeGroupId, string documentPath, string documentName, string comments, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<decimal> sizeFile)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases.Detail.File> _Result;

            try
            {
                var data = _loanRepository.SetMeetingCaseFile(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, meetingCaseNoteFileId, documentTypeGroupId, documentPath, documentName, comments, isActive, userId, userName, sizeFile);
                _Result = new ResultLogic<Loan.Cases.Detail.File> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases.Detail.File> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="relatedContactId"></param>
        /// <param name="meetingTypeId"></param>
        /// <param name="meetingSubTypeId"></param>
        /// <param name="meetingCaseId"></param>
        /// <param name="meetingCaseNoteId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Cases.Detail.File> GetMeetingCaseFile(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases.Detail.File> _Result;

            try
            {
                var data = _loanRepository.GetMeetingCaseFile(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId);
                _Result = new ResultLogic<Loan.Cases.Detail.File> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases.Detail.File> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        #region cobranza
        public ResultLogic<Loan.PaymentAndDebts> GetPaymentAndDebt(Nullable<long> accountId = null, Nullable<DateTime> FDateDebt = null
            , Nullable<DateTime> TDateDebt = null, Nullable<DateTime> FDatePay = null, Nullable<DateTime> TDatePay = null)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.PaymentAndDebts> _Result;

            try
            {
                var data = _loanRepository.GetPaymentAndDebt(accountId, FDateDebt, TDateDebt, FDatePay, TDatePay);
                _Result = new ResultLogic<Loan.PaymentAndDebts> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.PaymentAndDebts> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        public ResultLogic<Loan.CardDomitiliation> GetLoanDomiciliationCard(Nullable<long> accountId, Nullable<long> clientId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.CardDomitiliation> _Result;

            try
            {
                var data = _loanRepository.GetLoanDomiciliationCard(accountId, clientId);

                _Result = new ResultLogic<Loan.CardDomitiliation> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.CardDomitiliation> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }
        public ResultLogic<Loan.CardDomitiliation> SetDomitiliatonCard(Nullable<long> clientId, Nullable<int> cardTypeId, string lastFourDigits, string cardNumber, Nullable<System.DateTime> expirationDate, string cVV2, string cardHolder, string expirationDateMMYYYY, Nullable<bool> isActive, Nullable<int> userId, Nullable<long> accountId, Nullable<bool> isMain, Nullable<bool> applyRange, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo, Nullable<bool> isActiveLoan)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.CardDomitiliation> _Result;

            try
            {
                var data = _loanRepository.SetDomitiliatonCard(clientId,
                                                               cardTypeId,
                                                               lastFourDigits,
                                                               cardNumber,
                                                               expirationDate,
                                                               cVV2,
                                                               cardHolder,
                                                               expirationDateMMYYYY,
                                                               isActive,
                                                               userId,
                                                               accountId,
                                                               isMain,
                                                               applyRange,
                                                               dateFrom,
                                                               dateTo,
                                                               isActiveLoan
                                                               );

                _Result = new ResultLogic<Loan.CardDomitiliation> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.CardDomitiliation> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }


        /// <summary>
        /// Obtiene los datos de la correspondencia de una cuenta
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Correspondence> GetLoanCorrespondence(Nullable<long> accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Correspondence> _Result;

            try
            {
                var data = _loanRepository.GetLoanCorrespondence(accountId);

                _Result = new ResultLogic<Loan.Correspondence> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Correspondence> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Obtiene una lista de documentos relacionados a la correspondencia
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Correspondence.RelatedDocuments> GetTemplateRelatedFile(Nullable<long> templateId, Nullable<long> accountId, Nullable<long> templateSentId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Correspondence.RelatedDocuments> _Result;

            try
            {
                var data = _loanRepository.GetTemplateRelatedFile(templateId, accountId, templateSentId);

                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Correspondence.RelatedDocuments> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Obtiene una lista de plantillas para las correspondencias
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Template> GetTemplate(Nullable<long> templateId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Template> _Result;

            try
            {
                var data = _loanRepository.GetTemplate(templateId);

                _Result = new ResultLogic<Loan.Template> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Template> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Procesar uno o mas pagos con tarjeta de credito o debito
        /// </summary>
        /// <param name="creditDebitDirectPaymentId"></param>
        /// <param name="accountId"></param>
        /// <param name="cardTypeId"></param>
        /// <param name="directPaymentStatusId"></param>
        /// <param name="cardNumber"></param>
        /// <param name="lastFourDigits"></param>
        /// <param name="cardName"></param>
        /// <param name="yearExpiration"></param>
        /// <param name="monthExpiration"></param>
        /// <param name="quotaAmount"></param>
        /// <param name="balance"></param>
        /// <param name="amountPaid"></param>
        /// <param name="datePaid"></param>
        /// <param name="dateProcessedCard"></param>
        /// <param name="dateProcessedEasybank"></param>
        /// <param name="authorizationNumber"></param>
        /// <param name="receiptNumberEasybank"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ResultLogic<Loan.CreditDebitDirectPayment> SetCreditDebitDirectPayment(Nullable<long> creditDebitDirectPaymentId, Nullable<long> accountId, Nullable<int> cardTypeId, Nullable<int> directPaymentStatusId, string cardNumber, string lastFourDigits, string cardName, Nullable<int> yearExpiration, Nullable<int> monthExpiration, Nullable<decimal> quotaAmount, Nullable<decimal> balance, Nullable<decimal> amountPaid, Nullable<System.DateTime> datePaid, Nullable<System.DateTime> dateProcessedCard, Nullable<System.DateTime> dateProcessedEasybank, string authorizationNumber, string receiptNumberEasybank, Nullable<int> userId, string userName)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.CreditDebitDirectPayment> _Result;

            try
            {
                var data = _loanRepository.SetCreditDebitDirectPayment(creditDebitDirectPaymentId,
                                                                       accountId,
                                                                       cardTypeId,
                                                                       directPaymentStatusId,
                                                                       cardNumber,
                                                                       lastFourDigits,
                                                                       cardName,
                                                                       yearExpiration,
                                                                       monthExpiration,
                                                                       quotaAmount,
                                                                       balance,
                                                                       amountPaid,
                                                                       datePaid,
                                                                       dateProcessedCard,
                                                                       dateProcessedEasybank,
                                                                       authorizationNumber,
                                                                       receiptNumberEasybank,
                                                                       userId,
                                                                       userName
                                                               );

                _Result = new ResultLogic<Loan.CreditDebitDirectPayment> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.CreditDebitDirectPayment> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }
        #endregion
        public ResultLogic<Loan> GetAll(long? entityId = null)
        {
            throw new NotImplementedException();
        }

        public BaseResultLogic<Loan> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public Result Add(Loan entity)
        {
            throw new NotImplementedException();
        }

        public Result Delete(Loan entity)
        {
            throw new NotImplementedException();
        }

        public Result Edit(Loan entity)
        {
            throw new NotImplementedException();
        }

        public ResultLogic<Loan.Cases> GetMeetingCase(Nullable<long> relatedContactId, Nullable<long> accountId, Nullable<long> caseNumber, Nullable<int> meetingStatusId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases> _Result;

            try
            {
                var data = _loanRepository.GetMeetingCase(relatedContactId, accountId, caseNumber, meetingStatusId);
                _Result = new ResultLogic<Loan.Cases> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases> { result = new Result(ex, MethodName) };
            }

            return
                _Result;

        }

        public ResultLogic<Loan.Cases.Detail> GetMeetingCaseNote(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases.Detail> _Result;

            try
            {
                var data = _loanRepository.GetMeetingCaseNote(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId);
                _Result = new ResultLogic<Loan.Cases.Detail> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases.Detail> { result = new Result(ex, MethodName) };
            }

            return
                _Result;

        }

        public ResultLogic<Loan.Cases.Detail.Calls> GetMeetingCaseNoteCall(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases.Detail.Calls> _Result;

            try
            {
                var data = _loanRepository.GetMeetingCaseNoteCall(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId);
                _Result = new ResultLogic<Loan.Cases.Detail.Calls> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases.Detail.Calls> { result = new Result(ex, MethodName) };
            }

            return
                _Result;

        }

        public ResultLogic<Loan.Cases> SetMeetingCase(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<long> accountId, Nullable<int> meetingStatusId, Nullable<int> reasonId, Nullable<int> departmentId, Nullable<int> categoryId, Nullable<long> caseNumber, Nullable<System.DateTime> meetingDate, string meetingShortNote, Nullable<int> callAssignedId, string notifiedToEmail, Nullable<bool> notified, Nullable<int> attemptNo, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<System.DateTime> meetingClosedDate, Nullable<int> queueId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases> _Result;

            try
            {
                var data = _loanRepository.SetMeetingCase(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, accountId, meetingStatusId, reasonId, departmentId, categoryId, caseNumber, meetingDate, meetingShortNote, callAssignedId, notifiedToEmail, notified, attemptNo, isActive, userId, userName, meetingClosedDate, queueId);
                _Result = new ResultLogic<Loan.Cases> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases> { result = new Result(ex, MethodName) };
            }

            return
                _Result;

        }

        public ResultLogic<Loan.Cases> SetMeetingNote(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> priorityId, Nullable<int> serviceChannelId, Nullable<int> originatedById, string note, Nullable<bool> isActive, Nullable<int> userId, string userName)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases> _Result;

            try
            {
                var data = _loanRepository.SetMeetingNote(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, priorityId, serviceChannelId, originatedById, note, isActive, userId, userName);
                _Result = new ResultLogic<Loan.Cases> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        public ResultLogic<Loan.Cases.Detail.Calls> SetMeetingCall(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> meetingCaseNoteCallId, Nullable<System.TimeSpan> callDuration, Nullable<System.DateTime> callStart, Nullable<System.DateTime> callStop, string dialedNumber, string extension, string fileName, string fullPathFile, string callLogId, string callRexUserId, string userFirstName, string userLastName, Nullable<bool> isActive, Nullable<int> userId, string userName)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Cases.Detail.Calls> _Result;

            try
            {
                var data = _loanRepository.SetMeetingCall(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, meetingCaseNoteCallId, callDuration, callStart, callStop, dialedNumber, extension, fileName, fullPathFile, callLogId, callRexUserId, userFirstName, userLastName, isActive, userId, userName);
                _Result = new ResultLogic<Loan.Cases.Detail.Calls> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Cases.Detail.Calls> { result = new Result(ex, MethodName) };
            }

            return
                _Result;

        }

        public ResultLogic<Loan.Queue> SetQueue(Nullable<long> queueId, Nullable<long> accountId, Nullable<int> queueTypeId, Nullable<int> distributionId, Nullable<int> submittedByDepartmentId, Nullable<int> transferredFromDepartmentId, Nullable<int> queueStatusId, Nullable<long> vendorId, Nullable<long> assingToId, Nullable<long> transactionPaymentPlanId, Nullable<int> queueSourceId, string accountReference, Nullable<int> daysLate, Nullable<System.DateTime> actionDate, Nullable<System.DateTime> endDate, Nullable<bool> isActive, string cOMMENTS, Nullable<int> userId, string userName)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Queue> _Result;

            try
            {
                var data = _loanRepository.SetQueue(queueId, accountId, queueTypeId, distributionId, submittedByDepartmentId, transferredFromDepartmentId, queueStatusId, vendorId, assingToId, transactionPaymentPlanId, queueSourceId, accountReference, daysLate, actionDate, endDate, isActive, cOMMENTS, userId, userName);
                _Result = new ResultLogic<Loan.Queue> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Queue> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        public ResultLogic<Loan.CallUser> GetUsersCall(Nullable<int> securityUserId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.CallUser> _Result;

            try
            {
                var data = _loanRepository.GetUsersCall(securityUserId);
                _Result = new ResultLogic<Loan.CallUser> { SingleResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.CallUser> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        #region Documents

        /// <summary>
        /// vbarrera | 06 Feb 2019
        /// Invoque para obtener la lista de documentos
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Document> GetDocument(long accountId)
        {
            ResultLogic<Loan.Document> _Result;

            try
            {
                _Result = new ResultLogic<Loan.Document> {
                    dataResult = _loanRepository.GetDocuments(accountId), result = new Result(null, null) };
            }
            catch(Exception ex)
            {
                _Result = new ResultLogic<Loan.Document> {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name) };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener un documento en especifico
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="IdRequirement"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Document> GetDocument(long accountId, int IdRequirement)
        {
            ResultLogic<Loan.Document> _Result;

            try
            {
                _Result = new ResultLogic<Loan.Document>
                {
                    SingleResult = _loanRepository.GetDocuments(accountId, IdRequirement),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Document>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        #endregion
    }
}
