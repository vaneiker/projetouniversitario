using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class IndexFileTxt
    {
        private string _strTxt;

        public IndexFileTxt()
        {
            _strTxt 
                = Properties.Resources.Onbase_IndexFile;
        }

        public string DocTypeName
        {
            set
            {
                _strTxt = _strTxt.Replace("[DocTypeName]", value);
            }
        }

        public string DOCID
        {
            set
            {
                _strTxt = _strTxt.Replace("[DOCID]", value);
            }
        }

        public string DocDate
        {
            set
            {
                _strTxt = _strTxt.Replace("[DocDate]", value);
            }
        }

        public string Nombre_de_Cliente
        {
            set
            {
                _strTxt = _strTxt.Replace("[Nombre_de_Cliente]", value);
            }
        }

        public string tipoIdentificacion
        {
            set
            {
                _strTxt = _strTxt.Replace("[tipoIdentificacion]", value);
            }
        }

        public string Numero_de_Prestamo
        {
            set
            {
                _strTxt = _strTxt.Replace("[Numero_de_Prestamo]", value);
            }
        }

        public string FechaAutorizacion
        {
            set
            {
                _strTxt = _strTxt.Replace("[FechaAutorizacion]", value);
            }
        }

        public string FechaFinal
        {
            set
            {
                _strTxt = _strTxt.Replace("[FechaFinal]", value);
            }
        }

        public string Identificacion
        {
            set
            {
                _strTxt = _strTxt.Replace("[Identificacion]", value);
            }
        }

        public string Full_Path
        {
            set
            {
                _strTxt = _strTxt.Replace("[Full_Path]", value);
            }
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener el documento en formato string
        /// </summary>
        /// <returns>Documento en formato string</returns>
        public string GetString()
        {
            return _strTxt;
        }
    }
}
