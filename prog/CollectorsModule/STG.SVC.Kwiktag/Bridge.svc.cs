using STG.DLL.KwikTag.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STG.SVC.Kwiktag
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bridge" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Bridge.svc or Bridge.svc.cs at the Solution Explorer and start debugging.
    public class Bridge : IBridge
    {
        public bool Testing
        {
            get { return ((ConfigurationManager.AppSettings["DEF::Testing"] ?? "0") == "1"); }
        }

        public String Tag(List<STG.DLL.KwikTag.Library.Estructure.Tags> tags, STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            #region Mockups for testing
            if (Testing)
            {
                tags.Clear();
                tags.Add(new Estructure.Tags { Property = "Company ID", Value = "Atlantica Insurance S.A." });
                tags.Add(new Estructure.Tags { Property = "Receipt", Value = "PYMNT000000341873" });
                tags.Add(new Estructure.Tags { Property = "Credit Card ID", Value = "" });
                tags.Add(new Estructure.Tags { Property = "Customer ID", Value = "22-05-512533" });
                tags.Add(new Estructure.Tags { Property = "File Name", Value = "Scanned" });
                tags.Add(new Estructure.Tags { Property = "Comments", Value = "" });

                parameters = new STG.DLL.KwikTag.Library.Estructure.Parameters
                {
                    apiURL = null,
                    callingID = null,
                    companyID = null,
                    drawer = null,
                    password = null,
                    userName = "afeliz",
                    siteName = null,
                    barcode = "232385507"
                };
            }
            #endregion
            var result = Tagging.Create(tags, parameters);
            return result;
        }

        public KwikTagSDKLibrary.XmlReturns.XferDocumentDetails RetrieveImageDetails(STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            #region Mockups for testing
            if (Testing)
                parameters = new STG.DLL.KwikTag.Library.Estructure.Parameters()
                {
                    apiURL = null,
                    callingID = null,
                    password = null,
                    userName = null,
                    barcode = "205417118"
                };
            #endregion
            var results = Tagging.RetrieveImageDetails(parameters);
            return results;
        }

        public KwikTagSDKLibrary.XmlReturns.XferImage RetrieveImageFile(STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            #region Mockups for testing
            if (Testing)
                parameters = new STG.DLL.KwikTag.Library.Estructure.Parameters()
                {
                    apiURL = null,
                    callingID = null,
                    password = null,
                    userName = null,
                    barcode = "230551629"
                };
            #endregion
            var results = Tagging.RetrieveImageFile(parameters);
            return results;
        }

        public String NextBarcodeByUser(string userName, STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            #region Mockups for testing
            if (Testing)
            {
                userName = "ecampos";
                parameters = new STG.DLL.KwikTag.Library.Estructure.Parameters()
                {
                    apiURL = null,
                    callingID = null,
                    password = null,
                    userName = null,
                    barcode = null
                };
            }
            #endregion
            var results = Tagging.NextBarcodeByUser(userName, parameters);
            return results;
        }

        public String IndexFile()
        {
            var result = Tagging.Index();
            return result;
        }

        public String DrawersListByUser(string userName, STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            #region Mockups for testing
            if (Testing)
            {
                userName = "acarvajal";
                parameters = new STG.DLL.KwikTag.Library.Estructure.Parameters()
                {
                    apiURL = null,
                    callingID = null,
                    password = null,
                    userName = null,
                    barcode = null
                };
            }
            #endregion  
            var result = Tagging.DrawersListByUser(userName, parameters);
            return string.Empty;
        }
    }
}
