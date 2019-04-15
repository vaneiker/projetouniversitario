using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class JudgmentAdjudicationNoticeXmlProvider : XmlProvider
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

            JudgmentAdjudicationNoticeXml paymentIntimacionXml
                = new JudgmentAdjudicationNoticeXml()
                {
                    Contract_address1 = _dataFields.FirstOrDefault(x => x.IdField == 53)?.DatoStr,
                    Traslations_Street = _dataFields.FirstOrDefault(x => x.IdField == 54)?.DatoStr,
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Loan_loanNo = _dataFields.FirstOrDefault(x => x.IdField == 55)?.DatoStr,
                    Loan_expirationDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ToString("dd/MM/yyyy"),
                    Sheriff_Name = _dataFields.FirstOrDefault(x => x.IdField == 57)?.DatoStr,
                    Sheriff_Title = _dataFields.FirstOrDefault(x => x.IdField == 58)?.DatoStr,
                    Contract_PageCountDocPackage = _dataFields.FirstOrDefault(x => x.IdField == 59)?.DatoInt?.ToString(),
                    Transaction_DocumentId = DocumentId
                };

            return
                Encoding.UTF8.GetBytes(paymentIntimacionXml.GetString());
        }
        #endregion
    }
}
