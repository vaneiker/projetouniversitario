using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class SaleNoticeXmlProvider: XmlProvider
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

            SaleNoticeXml saleNoticeXml =
                new SaleNoticeXml()
                {
                    Contract_address1 = _dataFields.FirstOrDefault(x => x.IdField == 11)?.DatoStr,
                    Traslations_Street = _dataFields.FirstOrDefault(x => x.IdField == 12)?.DatoStr,
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Loan_expirationDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ToString("dd/MM/yyyy"),
                    Loan_expirationDateString = loanInfoDataResult.SingleResult.Loan_expirationDate.ToLetters(),
                    Publications_PublicationDate = _dataFields.FirstOrDefault(x => x.IdField == 13)?.DatoDat.ConvertToString(),
                    Publications_Name = _dataFields.FirstOrDefault(x => x.IdField == 14)?.DatoStr,
                    Vehicle_Type = loanInfoDataResult.SingleResult.Vehicle_Type,
                    Vehicle_Make = loanInfoDataResult.SingleResult.Vehicle_make,
                    Vehicle_Model = loanInfoDataResult.SingleResult.Vehicle_model,
                    Vehicle_color = loanInfoDataResult.SingleResult.Vehicle_color,
                    Vehicle_Year = loanInfoDataResult.SingleResult.Vehicle_Year,
                    Vehicle_Chasis = loanInfoDataResult.SingleResult.Vehicle_Chasis,
                    Vehicle_plate = loanInfoDataResult.SingleResult.Vehicle_plate,
                    Vehicle_enrollment = loanInfoDataResult.SingleResult.Vehicle_enrollment,
                    Transaction_court = _dataFields.FirstOrDefault(x => x.IdField == 16)?.DatoStr,
                    Transaction_DocumentId = DocumentId,
                    Transaction_AddressTo = _dataFields.FirstOrDefault(x => x.IdField == 17)?.DatoStr
                };

            return
                Encoding.UTF8.GetBytes(saleNoticeXml.GetString());
        }
        #endregion
    }
}
