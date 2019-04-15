using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    class VehicleCheckXmlProvider: XmlProvider
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

            VehicleCheckXml publicAuctionSaleNoticeXml
                = new VehicleCheckXml()
                {
                    Transaction_DocumentId = DocumentId,
                    Transaction_court = _dataFields.FirstOrDefault(x => x.IdField == 19)?.DatoStr,
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Witness_name = _dataFields.FirstOrDefault(x => x.IdField == 49)?.DatoStr,
                    Loan_requestedAmount = loanInfoDataResult.SingleResult.Loan_loanAmount.ToString(), // Monto Inicial del Prestamo en Letras y Numeros
                    Loan_requestedAmountString = loanInfoDataResult.SingleResult.Loan_loanAmount.ToLetters(true, false), // Monto Inicial del Prestamo en Letras y Numeros
                    Loan_loanAmount = loanInfoDataResult.SingleResult.Loan_loanAmount.ToString(),
                    Loan_loanAmountString = loanInfoDataResult.SingleResult.Loan_loanAmount.ToLetters(true, false),
                    Loan_id = _dataFields.FirstOrDefault(x => x.IdField == 50)?.DatoStr,
                    Loan_expirationDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ConvertToString(),
                    Loan_expirationDateString = loanInfoDataResult.SingleResult.Loan_expirationDate.ToLetters(),
                    Sheriff_Name = _dataFields.FirstOrDefault(x => x.IdField == 24)?.DatoStr,
                    Sheriff_City = _dataFields.FirstOrDefault(x => x.IdField == 25)?.DatoStr,
                    Hearing_HearingDate = _dataFields.FirstOrDefault(x => x.IdField == 27)?.DatoDat.ConvertToString(),
                    Loan_cityOfResidence = _dataFields.FirstOrDefault(x => x.IdField == 29)?.DatoStr,
                    Contract_contractDate = _dataFields.FirstOrDefault(x => x.IdField == 20)?.DatoDat.ConvertToString(),
                    Contract_issuedDate = "01/01/2019",
                    Contract_issuedDateString = "[Contract_issuedDateString]",
                    Vehicle_Type = loanInfoDataResult.SingleResult.Vehicle_Type,
                    Vehicle_Make = loanInfoDataResult.SingleResult.Vehicle_make,
                    Vehicle_Model = loanInfoDataResult.SingleResult.Vehicle_model,
                    Vehicle_color = loanInfoDataResult.SingleResult.Vehicle_color,
                    Vehicle_Year = loanInfoDataResult.SingleResult.Vehicle_Year,
                    Vehicle_Chasis = loanInfoDataResult.SingleResult.Vehicle_Chasis,
                    Vehicle_plate = loanInfoDataResult.SingleResult.Vehicle_plate,
                    Vehicle_enrollment = loanInfoDataResult.SingleResult.Vehicle_enrollment,
                    Vehicle_ConfiscationDate = _dataFields.FirstOrDefault(x => x.IdField == 26)?.DatoDat.ConvertToString(),
                    Contract_BookNumber = _dataFields.FirstOrDefault(x => x.IdField == 21)?.DatoStr,
                    Contract_id = _dataFields.FirstOrDefault(x => x.IdField == 51)?.DatoStr,
                    Lawyer_name = _dataFields.FirstOrDefault(x => x.IdField == 31)?.DatoStr,
                    Lawyer_enrollment = "[Lawyer_enrollment]"
                };

            return
                Encoding.UTF8.GetBytes(publicAuctionSaleNoticeXml.GetString());
        }
        #endregion
    }
}
