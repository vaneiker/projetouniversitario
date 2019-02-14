using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectorsModule.ell;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.Linq;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void generateInvoice()
        //{
        //    var ps = new CollectorsModule.bll.Services.PaymentsService();
        //    List<Invoice> listaInv = new List<Invoice>();
        //    listaInv.Add(new Invoice
        //    {
        //        Company = "Atlantica",
        //        Rnc = "01",
        //        Address = "Santo Domingo",
        //        Fax = "8097383141",
        //        Telephone = "8097383141",
        //        PayDate = DateTime.Now.ToShortDateString(),
        //        Time = String.Format("{0:t}", DateTime.Now),
        //        PaymentNumber = "PMT0000001",
        //        FullName = "Prueba",
        //        Amount = 15,
        //        Policy_No = "05-123254-2015",
        //        Amount_desc = Collectors.Helpers.Numalet.ToCardinal(15.00),
        //        WayToPay = "CreditCard",
        //        Cashier = "epimentel"
        //    });
        //    listaInv.Add(new Invoice
        //    {
        //        Company = "Atlantica",
        //        Rnc = "01",
        //        Address = "Santo Domingo",
        //        Fax = "8097383141",
        //        Telephone = "8097383141",
        //        PayDate = DateTime.Now.ToShortDateString(),
        //        Time = String.Format("{0:t}", DateTime.Now),
        //        PaymentNumber = "PMT0000002",
        //        FullName = "Prueba",
        //        Amount = 20,
        //        Policy_No = "05-123254-2015",
        //        Amount_desc = Collectors.Helpers.Numalet.ToCardinal(20.00),
        //        WayToPay = "CreditCard",
        //        Cashier = "epimentel"
        //    });
        //    string templatePath = "C:\\Personal Repository\\Repositorio de Proyectos\\Atlanvisor\\Modulo de cajeras\\CollectorsModule\\CollectorsModule\\CollectorsModule\\Content\\resources\\Invoice.html";
        //    HtmlDocument doc = new HtmlDocument();
        //    doc.Load(templatePath);
        //    var result = ps.generateInvoiceHTML(listaInv, doc);
        //}
        

        //[TestMethod]
        //public void testNode()
        //{
        //    var htmlStr = "<b>bold_one</b><strong>strong</strong><b>bold_two</b>";
        //    var doc = new HtmlDocument();
        //    doc.LoadHtml(htmlStr);

        //    var query = doc.DocumentNode.Descendants("b");
        //    foreach (var item in query.ToList())
        //    {
        //        var newNodesStr = "some text <b>node</b> <strong>another node</strong>";
        //        var newHeadNode = HtmlNode.CreateNode(newNodesStr);
        //        item.ParentNode.ReplaceChild(newHeadNode.ParentNode, item);
        //    }
        //}
        
        [TestMethod]
        public void nextTag()
        {
            try
            {
                string UserName = "acarvajal";
                apiKT.ktService svc = new apiKT.ktService();
                apiKT.Parameters parameters = new apiKT.Parameters()
                {
                    apiURL = null,
                    callingID = null,
                    companyID = null,
                    drawer = null,
                    password = null,
                    userName = ((string.IsNullOrEmpty(UserName) || UserName == "acarvajal") ? null : UserName),
                    siteName = null,
                    barcode = null
                };
                var code = svc.nextBarcodeByUser(UserName, parameters);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        [TestMethod]
        public void tagDocument()
        {
            string UserName = "lecruz";
            string currentTag = "232387132";
            #region Call KwikTag Service
            ktBridge.BridgeClient ws = new ktBridge.BridgeClient();

            var tags = new List<ktBridge.EstructureTags>();
            tags.Add(new ktBridge.EstructureTags { Property = "Company ID", Value = ("Atlantica Insurance S.A." ?? "Atlantica Insurance S.A.").ToString() });
            tags.Add(new ktBridge.EstructureTags { Property = "Receipt", Value = "PYMNT000000325603" });
            tags.Add(new ktBridge.EstructureTags { Property = "Credit Card ID", Value = ("" ?? string.Empty).ToUpper() });
            tags.Add(new ktBridge.EstructureTags { Property = "Customer ID", Value = "1-05-440451" });
            tags.Add(new ktBridge.EstructureTags { Property = "File Name", Value = "Scanned" });
            tags.Add(new ktBridge.EstructureTags { Property = "Comments", Value = string.Empty });
            ktBridge.EstructureTags[] tagging = new ktBridge.EstructureTags[tags.Count];
            ktBridge.EstructureParameters parameters = new ktBridge.EstructureParameters {
                apiURL = null,
                callingID = null,
                companyID = null,
                drawer = null,
                password = null,
                userName = ((string.IsNullOrEmpty(UserName) || UserName == "lecruz") ? null : UserName),
                siteName = null,
                barcode = (!string.IsNullOrEmpty(currentTag)) ? (int.Parse(currentTag) - 1).ToString() : null
            };

            for (int i = 0; i < tags.Count; i++)
            {
                tagging[i] = new ktBridge.EstructureTags { Property = tags[i].Property, Value = tags[i].Value };
            }
            var result = ws.Tag(tagging, parameters);
            #endregion
        }

        [TestMethod]
        public void NextBarcode()
        {
            ktBridge.BridgeClient ws = new ktBridge.BridgeClient();
            string username = "ISANTOS";
            var parameters = new ktBridge.EstructureParameters
            {
                apiURL = null,
                callingID = null,
                companyID = null,
                drawer = null,
                password = null,
                userName = ((string.IsNullOrEmpty(username) || username == "ISANTOS") ? null : username),
                siteName = null,
                barcode = null
            };
            var barcode = ws.NextBarcodeByUser(username, parameters);
        }
    }
}
