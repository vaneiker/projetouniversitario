using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class JudgmentAdjudicationNoticeXml
    {
        #region Fields 
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Variable privada que contiene la estructura del documento XML.
        /// Contiene comodines encerrados en corchetes (Ej.: [wildcard_name]) que seran reemplazados por
        /// los valores reales
        /// </summary>
        private string _strXml
            = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SYSTEM_KREDISI><dataset><Contract><address1>[Contract_address1]</address1><Loan><Client><Traslations><Street>[Traslations_Street]</Street></Traslations><name>[Client_name]</name></Client><loanNo>[Loan_loanNo]</loanNo><expirationDate>[Loan_expirationDate]</expirationDate><Sheriff><Name>[Sheriff_Name]</Name><Title>[Sheriff_Title]</Title></Sheriff></Loan><PageCountDocPackage>[Contract_PageCountDocPackage]</PageCountDocPackage></Contract><Transaction><DocumentId>[Transaction_DocumentId]</DocumentId></Transaction></dataset></SYSTEM_KREDISI>";
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

        public string Traslations_Street
        {
            set
            {
                _strXml = _strXml.Replace("[Traslations_Street]", value);
            }
        }

        public string Client_name
        {
            set
            {
                _strXml = _strXml.Replace("[Client_name]", value);
            }
        }

        public string Loan_loanNo
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_loanNo]", value);
            }
        }

        public string Loan_expirationDate
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_expirationDate]", value);
            }
        }

        public string Sheriff_Name
        {
            set
            {
                _strXml = _strXml.Replace("[Sheriff_Name]", value);
            }
        }

        public string Sheriff_Title
        {
            set
            {
                _strXml = _strXml.Replace("[Sheriff_Title]", value);
            }
        }

        public string Contract_PageCountDocPackage
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_PageCountDocPackage]", value);
            }
        }

        public string Transaction_DocumentId
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_DocumentId]", value);
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
