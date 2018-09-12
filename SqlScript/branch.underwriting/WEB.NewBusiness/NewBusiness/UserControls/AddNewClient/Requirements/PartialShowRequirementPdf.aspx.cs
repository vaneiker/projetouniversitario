using DI.UnderWriting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Requirements
{
    public partial class PartialShowRequirementPdf : BasePage
    {

        

 
        protected void Page_Load(object sender, EventArgs e)
        {
          //this.pdfViewerPdfPopUp.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();

          //  var ContactID = 0;
          //  var CategoryID = 0;
          //  var TypeID = 0;
          //  var ID = 0;
          //  var DocId = 0;
          //  if (Request.QueryString["ContactID"] != null)
          //  {
          //      if (Request.QueryString["ContactID"].ToString() != "undefined")
          //          ContactID = int.Parse(Request.QueryString["ContactID"].ToString());
          //  }
          //  if (Request.QueryString["CategoryID"] != null)
          //  {
          //      if (Request.QueryString["CategoryID"].ToString() != "undefined")
          //          CategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
          //  }
          //  if (Request.QueryString["TypeID"] != null)
          //  {
          //      if (Request.QueryString["TypeID"].ToString() != "undefined")
          //          TypeID = int.Parse(Request.QueryString["TypeID"].ToString());
          //  }
          //  if (Request.QueryString["ID"] != null)
          //  {
          //      if (Request.QueryString["ID"].ToString() != "undefined")
          //          ID = int.Parse(Request.QueryString["ID"].ToString());
          //  }

          //  if (Request.QueryString["DocId"] != null)
          //  {
          //      if (Request.QueryString["DocId"].ToString() != "undefined")
          //          DocId = int.Parse(Request.QueryString["DocId"].ToString());
          //  }

          //  if (ContactID > 0 && CategoryID > 0 && TypeID > 0 && ID > 0 && DocId > 0)
          //  {

          //      var document = ObjServices.oRequirementManager.GetDocument(
          //                            ObjServices.Corp_Id,
          //                            ObjServices.Region_Id,
          //                            ObjServices.Country_Id,
          //                            ObjServices.Domesticreg_Id,
          //                            ObjServices.State_Prov_Id,
          //                            ObjServices.City_Id,
          //                            ObjServices.Office_Id,
          //                            ObjServices.Case_Seq_No,
          //                            ObjServices.Hist_Seq_No,
          //                            ContactID,
          //                            CategoryID,
          //                            TypeID,
          //                            ID,
          //                            DocId
          //                   );

          //      if (document != null && document.DocumentBinary != null)
          //      {
          //          this.pdfViewerPdfPopUp.PdfSourceBytes = document.DocumentBinary;
          //          this.pdfViewerPdfPopUp.DataBind();
          //      }


          //  }  

        }

        [WebMethod()]
        public string GetDocumentPath(int ContactID, int CategoryID, int TypeID, int ID, int DocId)
        {

            if (ContactID > 0 && CategoryID > 0 && TypeID > 0 && ID > 0 && DocId > 0)
            {
                var document = ObjServices.oRequirementManager.GetDocument(
                     ObjServices.Corp_Id,
                     ObjServices.Region_Id,
                     ObjServices.Country_Id,
                     ObjServices.Domesticreg_Id,
                     ObjServices.State_Prov_Id,
                     ObjServices.City_Id,
                     ObjServices.Office_Id,
                     ObjServices.Case_Seq_No,
                     ObjServices.Hist_Seq_No,
                     ContactID,
                     CategoryID,
                     TypeID,
                     ID,
                     DocId
            );

                string tempFilePath = HttpContext.Current.Server.MapPath("~/TempFiles");
                var fileName = Utility.GetSerialId() + "~~" + document.DocumentName;
                var savePath = tempFilePath + "\\" + fileName;
                File.WriteAllBytes(fileName, document.DocumentBinary);
                string ret = string.Concat("~/TempFiles/", document.DocumentName);
            } 
            return "htlloo";
        }
    }
}