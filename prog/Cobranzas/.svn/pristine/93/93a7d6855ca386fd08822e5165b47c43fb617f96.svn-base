using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.EntityLayer;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class BreakdownXmlProvider : XmlProvider
    {
        #region Function
        /// <summary>
        /// vbarrera |08 Feb 2019
        /// Invoque este metodo para obtener el binario del documetno xml respectivo
        /// </summary>
        /// <returns></returns>
        public override byte[] GetXml()
        {
            ResultLogic<Loan.LoanInfo> loanInfoDataResult
                = _DataManager.GetLoanInfo(QueueId);

            if (loanInfoDataResult.SingleResult == null)
                throw new Exception("The accountId was not found in the table [loancollateral]");

            BreakdownXml breakdownXml
                = new BreakdownXml()
                {
                    Contract_address1 = _dataFields.FirstOrDefault(x => x.IdField == 7)?.DatoStr,
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Loan_ExpeditionDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ToString("dd/MM/yyyy"),
                    Loan_loanNo = _dataFields.FirstOrDefault(x => x.IdField == 10)?.DatoStr,
                    Lawyer_name = _dataFields.FirstOrDefault(x => x.IdField == 9)?.DatoStr,
                    Lawyer_enrollment = "--",
                    Transaction_court = _dataFields.FirstOrDefault(x => x.IdField == 6)?.DatoStr,
                    Transaction_DocumentId = DocumentId,
                    /**
                     * TODO
                     * Debe desarrollarse lista multiselectiva
                     */
                    PaymentOptions_PaymentDate = "01/01/2019"
                };

            return
                Encoding.UTF8.GetBytes(breakdownXml.GetString());
        }
        #endregion
    }
}
