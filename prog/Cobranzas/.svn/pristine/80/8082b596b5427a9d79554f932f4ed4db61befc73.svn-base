using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.EntityLayer;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    /// <summary>
    /// 
    /// </summary>
    class PaymentIntimacionXmlProvider : IDocumentsXmlProvider
    {
        #region Fields

        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// proveedor de datos que le permite a esta clase 
        /// obtener los valores necesarios para contruir 
        /// el respectivo documento XML
        /// </summary>
        private LoanManager _DataManager;

        #endregion

        #region Function
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// La finalidad de este metodo es establecer un proveedor de datos
        /// que le permite a esta clase obtener los valores necesarios para 
        /// contruir el respectivo documento XML
        /// </summary>
        /// <param name="DataManager"></param>
        public void SetDataManager(IBaseLogic<Loan> DataManager)
        {
            _DataManager = (DataManager as LoanManager);
        }

        /// <summary>
        /// vbarrera |08 Feb 2019
        /// Invoque este metodo para obtener el binario del documetno xml respectivo
        /// </summary>
        /// <returns></returns>
        public byte[] GetXml()
        {
            PaymentIntimacionXml paymentIntimacionXml
                = new PaymentIntimacionXml()
                {
                    Contract_address1 = "C/ 4TA, NO. 61, VILLA AZUCARERA, SAN PEDRO DE MACORIS, SAN PEDRO DE MACORÍS",
                    Traslations_Street = "C/ A numero B. Ens. Julieta, Santo Domingo. DN.",
                    Client_name = "Joel Solis",
                    Client_address1 = "C/ 4TA, NO. 61, VILLA AZUCARERA, SAN PEDRO DE MACORIS, SAN PEDRO DE MACORÍS",
                    Loan_loanAmount = "100",
                    Loan_loanAmountString = "CIEN",
                    Loan_expirationDate = "01/12/2019",
                    Loan_expirationDateString = "Primer día del mes de Diciembre del dos mil diez y diecinueve",
                    Loan_startDate = "01/12/2019",
                    Loan_startDateString = "Primer día del mes de Diciembre del dos mil diez y diecinueve",
                    Vehicle_Type = "Sedan",
                    Vehicle_Make = "Toyota",
                    Vehicle_Model = "Corolla",
                    Vehicle_color = "Negro",
                    Vehicle_Year = "2012",
                    Vehicle_Chasis = "02637066",
                    Vehicle_plate = "p0267085",
                    Vehicle_enrollment = "p0267085",
                    Contract_PageCountDocPackage = "5",
                    Contract_PageCountAttachments = "12",
                    Transaction_court = "San Isidro"
                };

            return
                Encoding.UTF8.GetBytes(paymentIntimacionXml.GetString());
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class PaymentIntimacionXml
    {
        #region Fields 
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Variable privada que contiene la estructura del documento XML.
        /// Contiene comodines encerrados en corchetes (Ej.: [wildcard_name]) que seran reemplazados por
        /// los valores reales
        /// </summary>
        string _strXml 
            = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SYSTEM_KREDISI><dataset><Contract><address1>[Contract_address1]</address1><Loan><Client><Traslations><Street>[Traslations_Street]</Street></Traslations><name>[Client_name]</name><address1>[Client_address1]</address1></Client><loanAmount>[Loan_loanAmount]</loanAmount><loanAmountString>[Loan_loanAmountString]</loanAmountString><expirationDate>[Loan_expirationDate]</expirationDate><expirationDateString>[Loan_expirationDateString]</expirationDateString><startDate>[Loan_startDate]</startDate><startDateString>[Loan_startDateString]</startDateString></Loan><Vehicle><Type>[Vehicle_Type]</Type><Make>[Vehicle_Make]</Make><Model>[Vehicle_Model]</Model><color>[Vehicle_color]</color><Year>[Vehicle_Year]</Year><Chasis>[Vehicle_Chasis]</Chasis><plate>[Vehicle_plate]</plate><enrollment>[Vehicle_enrollment]</enrollment></Vehicle><PageCountDocPackage>[Contract_PageCountDocPackage]</PageCountDocPackage><PageCountAttachments>[Contract_PageCountAttachments]</PageCountAttachments></Contract><Transaction><court>[Transaction_court]</court><DocumentId>1648501059</DocumentId></Transaction></dataset></SYSTEM_KREDISI>";
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

        public string Client_address1
        {
            set
            {
                _strXml = _strXml.Replace("[Client_address1]", value);
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

        public string Loan_startDate
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_startDate]", value);
            }
        }

        public string Loan_startDateString
        {
            set
            {
                _strXml = _strXml.Replace("[Loan_startDateString]", value);
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

        public string Contract_PageCountDocPackage
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_PageCountDocPackage]", value);
            }
        }

        public string Contract_PageCountAttachments
        {
            set
            {
                _strXml = _strXml.Replace("[Contract_PageCountAttachments]", value);
            }
        }

        public string Transaction_court
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_court]", value);
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
