using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class PledgeRequirementRequestXmlProvider : XmlProvider
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

            var foo = _dataFields.FirstOrDefault(x => x.IdField == 45)?.DatoDat.ConvertToString();

            PledgeRequirementRequestXml pledgeRequirementRequestXml
                = new PledgeRequirementRequestXml()
                {
                    Transaction_court = _dataFields.FirstOrDefault(x => x.IdField == 52)?.DatoStr,
                    Transaction_DocumentId = DocumentId,
                    Client_id = loanInfoDataResult.SingleResult.IdentificationNumber,
                    Client_name = loanInfoDataResult.SingleResult.Client_name,
                    Client_address1 = loanInfoDataResult.SingleResult.Client_address1,
                    Loan_requestedAmount = loanInfoDataResult.SingleResult.Loan_loanAmount.ToString(), // Monto Inicial del Prestamo en Letras y Numeros
                    Loan_requestedAmountString = loanInfoDataResult.SingleResult.Loan_loanAmount.ToLetters(true, false), // Monto Inicial del Prestamo en Letras y Numeros
                    Loan_loanAmount = loanInfoDataResult.SingleResult.Loan_loanAmount.ToString(),
                    Loan_loanAmountString = loanInfoDataResult.SingleResult.Loan_loanAmount.ToLetters(true, false),
                    Loan_id = _dataFields.FirstOrDefault(x => x.IdField == 41)?.DatoStr, // Numero de inscripcion 
                    Loan_expirationDate = loanInfoDataResult.SingleResult.Loan_expirationDate.ConvertToString(),
                    Loan_expirationDateString = loanInfoDataResult.SingleResult.Loan_expirationDate.ToLetters(),
                    Sheriff_Name = _dataFields.FirstOrDefault(x => x.IdField == 42)?.DatoStr, // Nombre del Alguacil que realizo la notificacion
                    Sheriff_City = _dataFields.FirstOrDefault(x => x.IdField == 43)?.DatoStr, // Demarcacion a la que pertenece el alguacil
                    Loan_cityOfResidence = _dataFields.FirstOrDefault(x => x.IdField == 44)?.DatoStr, // Localidad donde se solicita el vehiculo en requerimiento a prenda
                    Contract_contractDate = _dataFields.FirstOrDefault(x => x.IdField == 45)?.DatoDat.ConvertToString(), // Fecha del Contrato en Letras y Numeros
                    /**
                     * TODO
                     * Consultar de donde viene este campo
                     */
                    Contract_issuedDate = "01/01/2019",// Fecha del calculo del saldo en letras y numeros
                    Contract_issuedDateString = "[Contract_issuedDateString]",
                    Vehicle_Type = loanInfoDataResult.SingleResult.Vehicle_Type,
                    Vehicle_Make = loanInfoDataResult.SingleResult.Vehicle_make,
                    Vehicle_Model = loanInfoDataResult.SingleResult.Vehicle_model,
                    Vehicle_color = loanInfoDataResult.SingleResult.Vehicle_color,
                    Vehicle_Year = loanInfoDataResult.SingleResult.Vehicle_Year,
                    Vehicle_Chasis = loanInfoDataResult.SingleResult.Vehicle_Chasis,
                    Vehicle_plate = loanInfoDataResult.SingleResult.Vehicle_plate,
                    Vehicle_enrollment = loanInfoDataResult.SingleResult.Vehicle_enrollment,
                    Vehicle_enrollmentIssuedDate = _dataFields.FirstOrDefault(x => x.IdField == 46)?.DatoDat.ConvertToString(), // Fecha de Emision de la Matricula
                    Contract_BookNumber = _dataFields.FirstOrDefault(x => x.IdField == 47)?.DatoStr, // Libro en el que fue inscrito el contrato
                    Contract_id = _dataFields.FirstOrDefault(x => x.IdField == 48)?.DatoStr, // Numero de Acto de Intimacion de Pago
                };

            return
                Encoding.UTF8.GetBytes(pledgeRequirementRequestXml.GetString());
        }
        #endregion
    }
}
