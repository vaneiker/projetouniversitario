using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.EntityLayer;
using Jass.Utilities;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentIntimacionXmlProvider : XmlProvider
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

            PaymentIntimacionXml paymentIntimacionXml
                = new PaymentIntimacionXml()
                {
                    Contract_address1 = _dataFields.FirstOrDefault(x => x.IdField == 1)?.DatoStr,
                    Traslations_Street = _dataFields.FirstOrDefault(x => x.IdField == 2)?.DatoStr,
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Client_address1 = loanInfoDataResult.SingleResult.Client_address1,
                    Loan_loanAmount = loanInfoDataResult.SingleResult.Loan_loanAmount.ToString(),
                    Loan_loanAmountString = loanInfoDataResult.SingleResult.Loan_loanAmount.ToLetters(true, false),
                    Loan_expirationDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ToString("dd/MM/yyyy"),
                    Loan_expirationDateString = loanInfoDataResult.SingleResult.Loan_expirationDate.ToLetters(),
                    Loan_startDate = loanInfoDataResult.SingleResult.Loan_startDate.ToString("dd/MM/yyyy"),
                    Loan_startDateString = loanInfoDataResult.SingleResult.Loan_startDate.ToLetters(),
                    Vehicle_Type = loanInfoDataResult.SingleResult.Vehicle_Type,
                    Vehicle_Make = loanInfoDataResult.SingleResult.Vehicle_make,
                    Vehicle_Model = loanInfoDataResult.SingleResult.Vehicle_model,
                    Vehicle_color = loanInfoDataResult.SingleResult.Vehicle_color,
                    Vehicle_Year = loanInfoDataResult.SingleResult.Vehicle_Year,
                    Vehicle_Chasis = loanInfoDataResult.SingleResult.Vehicle_Chasis,
                    Vehicle_plate = loanInfoDataResult.SingleResult.Vehicle_plate,
                    Vehicle_enrollment = loanInfoDataResult.SingleResult.Vehicle_enrollment,
                    Contract_PageCountDocPackage = _dataFields.FirstOrDefault(x => x.IdField == 4)?.DatoInt?.ToString(),
                    Contract_PageCountAttachments = _dataFields.FirstOrDefault(x => x.IdField == 5)?.DatoInt?.ToString(),
                    Transaction_court = _dataFields.FirstOrDefault(x => x.IdField == 3)?.DatoStr,
                    Transaction_DocumentId = DocumentId
                };

            return
                Encoding.UTF8.GetBytes(paymentIntimacionXml.GetString());
        }
        #endregion
    }
}
