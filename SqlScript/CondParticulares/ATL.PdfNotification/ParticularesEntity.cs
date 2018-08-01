using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATL.PdfNotification
{
    [Serializable]
    public class Poliza
    {    
        private  string DocumentoId;
        private  string NumeroPoliza;
        private  string url;
        private  string Celular;
        
         public string pDocumentoId
             {
             get { return DocumentoId; }
             set { DocumentoId = value; }
             }
            public  string pNumeroPoliza
            {
                get { return NumeroPoliza; }
                set { NumeroPoliza = value; }
            }

            public  string pUrl
            {
                get { return url; }
                set { url = value; }
            }
          
            public  string pCelular
            {
                get { return Celular; }
                set { Celular = value; }
            }                    
    }
}
