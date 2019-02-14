using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STG.SVC.Kwiktag
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBridge" in both code and config file together.
    [ServiceContract]
    public interface IBridge
    {

        [OperationContract]
        String Tag(List<STG.DLL.KwikTag.Library.Estructure.Tags> tags, STG.DLL.KwikTag.Library.Estructure.Parameters parameters);

        [OperationContract]
        KwikTagSDKLibrary.XmlReturns.XferImage RetrieveImageFile(STG.DLL.KwikTag.Library.Estructure.Parameters parameters);

        [OperationContract]
        KwikTagSDKLibrary.XmlReturns.XferDocumentDetails RetrieveImageDetails(STG.DLL.KwikTag.Library.Estructure.Parameters parameters);

        [OperationContract]
        String NextBarcodeByUser(string userName, STG.DLL.KwikTag.Library.Estructure.Parameters parameters);

        [OperationContract]
        String IndexFile();

        [OperationContract]
        String DrawersListByUser(string userName, STG.DLL.KwikTag.Library.Estructure.Parameters parameters);
    }
}
