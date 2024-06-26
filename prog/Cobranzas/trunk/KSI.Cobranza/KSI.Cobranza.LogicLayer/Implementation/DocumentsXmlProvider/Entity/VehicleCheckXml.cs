﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleCheckXml
    {
        #region Fields 
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Variable privada que contiene la estructura del documento XML.
        /// Contiene comodines encerrados en corchetes (Ej.: [wildcard_name]) que seran reemplazados por
        /// los valores reales
        /// </summary>
        private string _strXml
            = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SYSTEM_KREDISI><dataset><Transaction><DocumentId>[Transaction_DocumentId]</DocumentId><court>[Transaction_court]</court></Transaction><Contract><Loan><Client><name>[Client_name]</name><Witness><name>[Witness_name]</name></Witness></Client><requestedAmount>[Loan_requestedAmount]</requestedAmount><requestedAmountString>[Loan_requestedAmountString]</requestedAmountString><loanAmount>[Loan_loanAmount]</loanAmount><loanAmountString>[Loan_loanAmountString]</loanAmountString><id>[Loan_id]</id><expirationDate>[Loan_expirationDate]</expirationDate><expirationDateString>[Loan_expirationDateString]</expirationDateString><Sheriff><Name>[Sheriff_Name]</Name><City>[Sheriff_City]</City></Sheriff><Hearing><HearingDate>[Hearing_HearingDate]</HearingDate></Hearing><cityOfResidence>[Loan_cityOfResidence]</cityOfResidence></Loan><contractDate>[Contract_contractDate]</contractDate><issuedDate>[Contract_issuedDate]</issuedDate><issuedDateString>[Contract_issuedDateString]</issuedDateString><Vehicle><Type>[Vehicle_Type]</Type><Make>[Vehicle_Make]</Make><Model>[Vehicle_Model]</Model><color>[Vehicle_color]</color><Year>[Vehicle_Year]</Year><Chasis>[Vehicle_Chasis]</Chasis><plate>[Vehicle_plate]</plate><enrollment>[Vehicle_enrollment]</enrollment><ConfiscationDate>[Vehicle_ConfiscationDate]</ConfiscationDate></Vehicle><BookNumber>[Contract_BookNumber]</BookNumber><id>[Contract_id]</id><Lawyer><name>[Lawyer_name]</name><enrollment>[Lawyer_enrollment]</enrollment></Lawyer></Contract></dataset></SYSTEM_KREDISI>";
        #endregion

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Utilizar estas propiedades para reemplazar cada uno de los comodines
        /// por el su valor verdadero
        /// </summary>
        #region Properties
        public string Transaction_DocumentId
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_DocumentId]", value);
            }
        }

        public string Transaction_court
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_court]", value);
            }
        }

        public string Client_name
        {
            set
            {
                _strXml = _strXml.Replace("[Client_name]", value);
            }
        }

        public string Witness_name
        {
            set
            {
                _strXml = _strXml.Replace("[Witness_name]", value);
            }
        }

        public string Loan_requestedAmount
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_requestedAmount]", value);
            }
        }

        public string Loan_requestedAmountString
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_requestedAmountString]", value);
            }
        }

        public string Loan_loanAmount
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_loanAmount]", value);
            }
        }

        public string Loan_loanAmountString
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_loanAmountString]", value);
            }
        }

        public string Loan_id
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_id]", value);
            }
        }

        public string Loan_expirationDate
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_expirationDate]", value);
            }
        }

        public string Loan_expirationDateString
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_expirationDateString]", value);
            }
        }

        public string Sheriff_Name
        {
            set
            {
                _strXml = _strXml.Replace("[Sheriff_Name]", value);
            }
        }

        public string Sheriff_City
        {
            set
            {
                _strXml = _strXml.Replace("[Sheriff_City]", value);
            }
        }

        public string Hearing_HearingDate
        {
            set
            {
                _strXml = _strXml.Replace("[Hearing_HearingDate]", value);
            }
        }

        public string Loan_cityOfResidence
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_cityOfResidence]", value);
            }
        }

        public string Contract_contractDate
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_contractDate]", value);
            }
        }

        public string Contract_issuedDate
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_issuedDate]", value);
            }
        }

        public string Contract_issuedDateString
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_issuedDateString]", value);
            }
        }

        public string Vehicle_Type
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_Type]", value);
            }
        }

        public string Vehicle_Make
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_Make]", value);
            }
        }

        public string Vehicle_Model
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_Model]", value);
            }
        }

        public string Vehicle_color
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_color]", value);
            }
        }

        public string Vehicle_Year
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_Year]", value);
            }
        }

        public string Vehicle_Chasis
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_Chasis]", value);
            }
        }

        public string Vehicle_plate
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_plate]", value);
            }
        }

        public string Vehicle_enrollment
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_enrollment]", value);
            }
        }

        public string Vehicle_ConfiscationDate
        {
            set
            {
                _strXml = _strXml.Replace("[Vehicle_ConfiscationDate]", value);
            }
        }

        public string Contract_BookNumber
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_BookNumber]", value);
            }
        }

        public string Contract_id
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_id]", value);
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
