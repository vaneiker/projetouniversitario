using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class BreakdownXml
    {
        #region Fields 
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Variable privada que contiene la estructura del documento XML.
        /// Contiene comodines encerrados en corchetes (Ej.: [wildcard_name]) que seran reemplazados por
        /// los valores reales
        /// </summary>
        private string _strXml
            = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SYSTEM_KREDISI><dataset><Contract><address1>[Contract_address1]</address1><Loan><Client><name>[Client_name]</name></Client><ExpeditionDate>[Loan_ExpeditionDate]</ExpeditionDate><loanNo>[Loan_loanNo]</loanNo></Loan><Lawyer><name>[Lawyer_name]</name><enrollment>[Lawyer_enrollment]</enrollment></Lawyer></Contract><Transaction><court>[Transaction_court]</court><DocumentId>[Transaction_DocumentId]</DocumentId></Transaction><Quotation><PaymentOptions><PaymentDate>[PaymentOptions_PaymentDate]</PaymentDate></PaymentOptions></Quotation></dataset></SYSTEM_KREDISI>";
        #endregion

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Utilizar estas propiedades para reemplazar cada uno de los comodines
        /// por el su valor verdadero
        /// </summary>
        #region Properties
        public string Contract_address1
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_address1]", value);
            }
        }

        public string Client_name
        {
            set
            {
                _strXml = _strXml.Replace("[Client_name]", value);
            }
        }

        public string Loan_ExpeditionDate
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_ExpeditionDate]", value);
            }
        }

        public string Loan_loanNo
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_loanNo]", value);
            }
        }

        public string Lawyer_name
        {
            set
            {
                _strXml = _strXml.Replace("[Lawyer_name]", value);
            }
        }

        public string Lawyer_enrollment
        {
            set
            {
                _strXml = _strXml.Replace("[Lawyer_enrollment]", value);
            }
        }

        public string Transaction_court
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_court]", value);
            }
        }

        public string Transaction_DocumentId
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_DocumentId]", value);
            }
        }

        public string PaymentOptions_PaymentDate
        {
            set
            {
                _strXml = _strXml.Replace("[PaymentOptions_PaymentDate]", value);
            }
        }

        #endregion

        #region Function
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener el documento XML
        /// </summary>
        /// <returns>Documento XML en formato texto</returns>
        public string GetString()
        {
            return _strXml;
        }
        #endregion
    }
}
