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
    public class SaleNoticeXml
    {
        #region Fields 
        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Variable privada que contiene la estructura del documento XML.
        /// Contiene comodines encerrados en corchetes (Ej.: [wildcard_name]) que seran reemplazados por
        /// los valores reales
        /// </summary>
        //private string _strXml
        //    = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SYSTEM_KREDISI><dataset><Contract><address1>Foo</address1><Loan><Client><Traslations><Street>Foo</Street></Traslations><name>Foo</name></Client><expirationDate>01/01/2019</expirationDate><expirationDateString>foo</expirationDateString></Loan><Publications><PublicationDate>01/12/2019</PublicationDate><Name>Foo</Name></Publications><Vehicle><Type>Foo</Type><Make>Foo</Make><Model>Foo</Model><color>Foo</color><Year>2012</Year><Chasis>Foo</Chasis><plate>Foo</plate><enrollment>Foo</enrollment></Vehicle></Contract><Transaction><court>Foo</court><DocumentId>1648501061</DocumentId><AddressTo>Foo</AddressTo></Transaction></dataset></SYSTEM_KREDISI>";
        private string _strXml
            = "<?xml version =\"1.0\" encoding=\"UTF-8\"?><SYSTEM_KREDISI><dataset><Contract><address1>[Contract_address1]</address1><Loan><Client><Traslations><Street>[Traslations_Street]</Street></Traslations><name>[Client_name]</name></Client><expirationDate>[Loan_expirationDate]</expirationDate><expirationDateString>[Loan_expirationDateString]</expirationDateString></Loan><Publications><PublicationDate>01/12/2019</PublicationDate><Name>[Publications_Name]</Name></Publications><Vehicle><Type>[Vehicle_Type]</Type><Make>[Vehicle_Make]</Make><Model>[Vehicle_Model]</Model><color>[Vehicle_color]</color><Year>[Vehicle_Year]</Year><Chasis>[Vehicle_Chasis]</Chasis><plate>[Vehicle_plate]</plate><enrollment>[Vehicle_enrollment]</enrollment></Vehicle></Contract><Transaction><court>[Transaction_court]</court><DocumentId>[Transaction_DocumentId]</DocumentId><AddressTo>[Transaction_AddressTo]</AddressTo></Transaction></dataset></SYSTEM_KREDISI>";
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

        public string Publications_PublicationDate
        {
            set
            {
                _strXml = _strXml.Replace("[Publications_PublicationDate]", value);
            }
        }

        public string Publications_Name
        {
            set
            {
                _strXml = _strXml.Replace("[Publications_Name]", value);
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

        public string Transaction_AddressTo
        {
            set
            {
                _strXml = _strXml.Replace("[Transaction_AddressTo]", value);
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
