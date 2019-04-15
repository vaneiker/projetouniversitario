using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public class DocumentsInventoryXmlProvider : XmlProvider
    {
        #region Function

        /// <summary>
        /// vbarrera |08 Feb 2019
        /// Invoque este metodo para obtener el binario del documetno xml respectivo
        /// </summary>
        /// <returns></returns>
        public override byte[] GetXml()
        {
            return
                Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\"?><SYSTEM_KREDISI><dataset><Transaction><court>[Transaction_court]</court><DocumentId>1648501079</DocumentId></Transaction><Contract><address1>[Contract_address1]</address1><Lawyer><name>[Lawyer_name]</name><enrollment>000000</enrollment></Lawyer><Loan><Client><name>[Client_name]</name></Client><expirationDate>01/01/2019</expirationDate></Loan></Contract><DocumentList><ActNumber>[DocumentList_ActNumber]</ActNumber><ActDate>01/01/2019</ActDate><Sheriff>[DocumentList_Sheriff]</Sheriff><SheriffCity>[DocumentList_SheriffCity]</SheriffCity><NewsPaper>[DocumentList_NewsPaper]</NewsPaper><PublicationDateString>[DocumentList_PublicationDateString]</PublicationDateString><Court>[DocumentList_Court]</Court><DocumentActDate>01/01/2019</DocumentActDate><Description>1</Description></DocumentList></dataset></SYSTEM_KREDISI>");
        }
        #endregion
    }
}
