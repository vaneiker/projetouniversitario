using KwikTagSDKLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace STG.DLL.KwikTag.Library
{
    public class Tagging
    {
        public static string _apiUrl = (ConfigurationManager.AppSettings["apiURL"] ?? "http://atl-srv41/APIV2").ToString();
        public static string _callingId = (ConfigurationManager.AppSettings["callingID"] ?? "cf4bf1ea-af06-458c-b555-ba6996023c62").ToString();
        public static string _userName = (ConfigurationManager.AppSettings["adminUser"] ?? "Administrator").ToString();
        public static string _password = (ConfigurationManager.AppSettings["adminPass"] ?? "system").ToString();
        public static string _sitename = (ConfigurationManager.AppSettings["siteName"] ?? "Atlantica Insurance S.A.").ToString();
        public static string _company = (ConfigurationManager.AppSettings["company"] ?? "Atlantica Insurance S.A.").ToString();
        public static string _companyID = (ConfigurationManager.AppSettings["companyID"] ?? "SC968512").ToString();
        public static string _drawer = (ConfigurationManager.AppSettings["defaultDrawer"] ?? "Sales Cash Receipts Entry").ToString();
        public static string _retrievalTagsXml = "<Company ID>Atlantica</Company ID>";
        //public static string _filename = "C:\\Users\\epimentel\\Documents\\Visual Studio 2013\\Projects\\apiKT\\packages\\FileTesting.pdf";

        public static string Create(List<STG.DLL.KwikTag.Library.Estructure.Tags> tags, STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            //Objects for configuration and authorization
            KwikTagSDKLibrary.XmlReturns.ConfigReturn oConfig = new KwikTagSDKLibrary.XmlReturns.ConfigReturn();
            KwikTagSDKLibrary.Authentication oAuth = new KwikTagSDKLibrary.Authentication((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId));
            oConfig = oAuth.AuthenticateKwikTagUserAccount((parameters.userName ?? _userName), (parameters.password ?? _password));
            string _token = oConfig.Token;
            //Generating barcode object
            KwikTagSDKLibrary.Barcode oBarcode = new KwikTagSDKLibrary.Barcode((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId), _token, (parameters.userName ?? _userName));
            KwikTagDocumentModel ktDocument = new KwikTagDocumentModel();
            KwikTagSDKLibrary.FieldList ktDocumentFieldList = new KwikTagSDKLibrary.FieldList();

            //Adding tags to Document object
            foreach (var tag in tags)
            {
                ktDocumentFieldList.Items.Add(new KwikTagSDKLibrary.TagField() { Name = tag.Property, TagValue = tag.Value });
                ktDocument.TagList.Add(new KwikTagSDKLibrary.TagField() { Name = tag.Property, TagValue = tag.Value });
            }
            ktDocument.FieldList.Add(ktDocumentFieldList);

            //Generating next barcode
            var nextBarcode = oBarcode.RetrieveNext(parameters.barcode);
            if (nextBarcode.Success)
            {
                ktDocument.Barcode = nextBarcode.Data.ToString();
                //Assinging drawer and sitename
                ktDocument.Drawer = (parameters.drawer ?? _drawer);
                ktDocument.SiteName = (parameters.siteName ?? _sitename);

                //Generate object document and tag the document to KT
                KwikTagSDKLibrary.Document oDoc = new KwikTagSDKLibrary.Document((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId), _token, (parameters.userName ?? _userName));
                var tagDoc = oDoc.Tag(ktDocument, 0);
            }
            //Building XML response
            tags.Add(new STG.DLL.KwikTag.Library.Estructure.Tags { Property = "Barcode", Value = ktDocument.Barcode });
            Regex re = new Regex("[;\\\\/:*?\"<>|&']");
            foreach (var tag in tags)
            {
                tag.Property = re.Replace(tag.Property, string.Empty).Replace(" ", string.Empty);
            }

            XElement xlmResponse = new XElement("KwikTag", tags.Select(i => new XElement(i.Property, i.Value)));

            return xlmResponse.ToString();
        }

        public static KwikTagSDKLibrary.XmlReturns.XferDocumentDetails RetrieveImageDetails(STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {

            KwikTagSDKLibrary.XmlReturns.ConfigReturn result = new KwikTagSDKLibrary.XmlReturns.ConfigReturn();
            Authentication oAuth = new Authentication((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId));
            result = oAuth.AuthenticateKwikTagUserAccount((parameters.userName ?? _userName), (parameters.password ?? _password));
            KwikTagSDKLibrary.XmlReturns.ConfigReturn oConfigReturn = new KwikTagSDKLibrary.XmlReturns.ConfigReturn();
            oConfigReturn = result;
            if (oConfigReturn.Success)
            {
                Search oSearch = new Search((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId), oConfigReturn.Token, (parameters.userName ?? _userName));
                List<KwikTagSDKLibrary.XmlReturns.XferDocumentDetails> oSearchResult = new List<KwikTagSDKLibrary.XmlReturns.XferDocumentDetails>();
                oSearchResult = oSearch.BasicSearch(parameters.barcode);
                if (oSearchResult.Count > 0)
                {
                    var retorno = oSearchResult.OrderByDescending(x => x.DateScanned).FirstOrDefault();
                    return retorno;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Devuelve el archivo de imagen en base al barcode enviado
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static KwikTagSDKLibrary.XmlReturns.XferImage RetrieveImageFile(STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            KwikTagSDKLibrary.XmlReturns.ConfigReturn result = new KwikTagSDKLibrary.XmlReturns.ConfigReturn();
            Authentication oAuth = new Authentication((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId));
            result = oAuth.AuthenticateKwikTagUserAccount((parameters.userName ?? _userName), (parameters.password ?? _password));
            KwikTagSDKLibrary.XmlReturns.ConfigReturn oConfigReturn = new KwikTagSDKLibrary.XmlReturns.ConfigReturn();
            oConfigReturn = result;
            KwikTagSDKLibrary.Document oDoc = new KwikTagSDKLibrary.Document((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId), oConfigReturn.Token, (parameters.userName ?? _userName));
            var image = oDoc.RetrieveImage(parameters.barcode, (parameters.companyID ?? _companyID), -1);
            return image;
        }

        public static string NextBarcodeByUser(string userName, STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            //Generating barcode object
            KwikTagSDKLibrary.Barcode oBarcode = new KwikTagSDKLibrary.Barcode((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId), null, (userName ?? _userName));

            //Generating next barcode
            var nextBarcode = oBarcode.RetrieveNext(parameters.barcode);
            if (nextBarcode.Success)
                return nextBarcode.Data.ToString();
            else
                return string.Empty;
        }

        public static string DrawersListByUser(string userName, STG.DLL.KwikTag.Library.Estructure.Parameters parameters)
        {
            KwikTagSDKLibrary.Drawer dw = new Drawer((parameters.apiURL ?? _apiUrl), (parameters.callingID ?? _callingId), null, (userName ?? _userName));
            var result = dw.RetrieveList(_companyID);
            return string.Empty;
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <returns></returns>
        public static string Index()
        {
            List<string> tags = new List<string>();
            tags.Add("1");
            XElement xmlTags = new XElement("Properties", tags.Select(i => new XElement("Company_ID", i)));

            KwikTagSDKLibrary.XmlReturns.ConfigReturn oConfig = new KwikTagSDKLibrary.XmlReturns.ConfigReturn();
            KwikTagSDKLibrary.Authentication oAuth = new KwikTagSDKLibrary.Authentication(_apiUrl, _callingId);
            oConfig = oAuth.AuthenticateKwikTagUserAccount(_userName, _password);
            string _token = oConfig.Token;
            KwikTagSDKLibrary.Barcode oBarcode = new KwikTagSDKLibrary.Barcode(_apiUrl, _callingId, _token, _userName);
            ktBarcode.Barcode bc = new ktBarcode.Barcode();
            ktDocument.Document svc = new ktDocument.Document();
            string _barcode = oBarcode.RetrieveNext().Data.ToString();

            #region Barcode from web service
            //var _barcodeResponse = bc.RetrieveNext(_company, _userName, _password, string.Empty);
            //var doc = XDocument.Load(new StringReader(_barcodeResponse));

            //var _bc = doc
            //    .Descendants("KwikTag")
            //    .Descendants("Barcode")
            //    .Select(x => new
            //    {
            //        BarCode = x.Element("Number").Value,
            //    })
            //    .FirstOrDefault();
            //if(bc!= null)
            //    _barcode = _bc.BarCode;
            #endregion

            if (string.IsNullOrEmpty(_barcode))
                return "Error generating Barcode";
            var idx = svc.Index(_companyID, _userName, _password, _drawer, _barcode,
                                xmlTags.ToString(), 0, string.Empty, string.Empty, string.Empty,
                                4, string.Empty, string.Empty, true, true, string.Empty,
                                string.Empty, string.Empty, false, false, "pdf", false,
                                0, false);

            return ("Barcode: " + _barcode + "|| Index: " + idx.ToString());
        }

    }
}
