using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    class PublicAuctionSaleNoticeXmlProvider : XmlProvider
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

            PublicAuctionSaleNoticeXml publicAuctionSaleNoticeXml
                = new PublicAuctionSaleNoticeXml() {
                    Transaction_court = _dataFields.FirstOrDefault(x => x.IdField == 33)?.DatoStr,
                    Transaction_AddressTo = _dataFields.FirstOrDefault(x => x.IdField == 34)?.DatoStr,
                    Loan_expirationDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ConvertToString(),
                    Loan_expirationDateString = loanInfoDataResult.SingleResult.Loan_expirationDate.ToLetters(),
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Client_nationality = "[Client_nationality]",
                    Client_civilStatus = "[Client_civilStatus]",
                    Client_id = loanInfoDataResult.SingleResult.IdentificationNumber,
                    Client_address1 = loanInfoDataResult.SingleResult.Client_address1,
                    Spends_Amount = "100",
                    Spends_AmountString = 100m.ToLetters(true, false),
                    Loan_loanNo = _dataFields.FirstOrDefault(x => x.IdField == 22)?.DatoStr,
                    Sheriff_Name = _dataFields.FirstOrDefault(x => x.IdField == 36)?.DatoStr,
                    Sheriff_City = _dataFields.FirstOrDefault(x => x.IdField == 37)?.DatoStr,
                    Loan_loanAmount = loanInfoDataResult.SingleResult.Loan_loanAmount.ToString(),
                    Loan_loanAmountString = loanInfoDataResult.SingleResult.Loan_loanAmount.ToLetters(true, false),
                    Vehicle_Type = loanInfoDataResult.SingleResult.Vehicle_Type,
                    Vehicle_Make = loanInfoDataResult.SingleResult.Vehicle_make,
                    Vehicle_Model = loanInfoDataResult.SingleResult.Vehicle_model,
                    Vehicle_color = loanInfoDataResult.SingleResult.Vehicle_color,
                    Vehicle_Year = loanInfoDataResult.SingleResult.Vehicle_Year,
                    Vehicle_Chasis = loanInfoDataResult.SingleResult.Vehicle_Chasis,
                    Vehicle_plate = loanInfoDataResult.SingleResult.Vehicle_plate,
                    Vehicle_enrollment = loanInfoDataResult.SingleResult.Vehicle_enrollment,
                    Contract_contractDate = _dataFields.FirstOrDefault(x => x.IdField == 45)?.DatoDat.ConvertToString(), // Fecha del Contrato en Letras y Numeros
                    Contract_issuedDate = "01/01/2019",
                    Contract_issuedDateString = "[Contract_issuedDateString]",
                    Lawyer_name = _dataFields.FirstOrDefault(x => x.IdField == 40)?.DatoStr,
                    Lawyer_enrollment = "[Lawyer_enrollment]",
                    Contract_ContractDateString = _dataFields.FirstOrDefault(x => x.IdField == 35).DatoDat.ConvertToString(),
                    Transaction_DocumentId = DocumentId
                };

            return
                Encoding.UTF8.GetBytes(publicAuctionSaleNoticeXml.GetString());
        }
        #endregion
    }
}