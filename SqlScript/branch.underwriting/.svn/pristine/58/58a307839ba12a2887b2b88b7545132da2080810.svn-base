using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Products
{
    public partial class UCTransport : UC, IUC
    {
        public delegate void ExportToPDFHandler(byte[] pdfFile, string FileName);
        public event ExportToPDFHandler ExportToPdf;
        public void ExportPDF(byte[] pdfFile, string FileName)
        {
            ExportToPdf(pdfFile, FileName);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerMyPreviewPDF.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"];
            UCEndosoCesionAlliedLines.ExportToPdf += ExportPDF;
            UCEndosoCesionAlliedLines.BindGrid += BindGrid;

            UCTransportDetail.BindGrid += FillData;

            var showPopCoverages = hdnTransportCoverages.Value == "true";
            if (showPopCoverages)
                ModalPopupCoverage.Show();

            var showNavyPop = hdnPopTransportDetail.Value == "true";
            if (showNavyPop)
                mpeTransportDetail.Show();

            if (hdnEndosoPopup.Value == "true")
                ModalPopupEndoso.Show();

            if (IsPostBack) return;
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }
        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }
        public void save()
        {
            throw new NotImplementedException();
        }
        public void edit()
        {
            throw new NotImplementedException();
        }
        private void FillDataCoverage()
        {
            UCCoverages.Initialize();
        }

        protected void gvAlliedLinesDetail_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            var UniqueTransportId = grid.GetKeyFromAspxGridView("UniqueTransportId", e.VisibleIndex).ToInt();
            var insuredAmount = grid.GetKeyFromAspxGridView("InsuredAmount", e.VisibleIndex).ToInt();

            switch (Command)
            {
                case "BlackList":
                    if (!ObjServices.IsValidateBlackListCot)
                    {
                        this.MessageBox(Resources.BlackListUserValidateAlert);
                        return;
                    }

                    hdnPopBlackList.Value = "true";
                    WUCBlackListValidation.Initialize();
                    ModalPopupBlackList.Show();
                    break;
                case "EditTransport":
                    //Popup para ver la información detallada de la propiedad
                    var SelectedRecord = ObjServices.GetDataTransport(UniqueTransportId);
                    UCTransportDetail.oTransport = SelectedRecord.FirstOrDefault();
                    UCTransportDetail.Initialize();
                    hdnPopTransportDetail.Value = "true";
                    mpeTransportDetail.Show();

                    this.ExcecuteJScript("addClassDoble();");
                    break;
                case "Coverage":
                    hdnTransportCoverages.Value = "true";
                    UCCoverages.UniqueId = UniqueTransportId;
                    FillDataCoverage();
                    ModalPopupCoverage.Show();
                    break;
                case "Endoso":
                    #region Endoso
                    UCEndosoCesionAlliedLines.Initialize();
                    UCEndosoCesionAlliedLines.UniqueId = UniqueTransportId;
                    UCEndosoCesionAlliedLines.InsuredAmount = insuredAmount;
                    UCEndosoCesionAlliedLines.FillData();
                    hdnEndosoPopup.Value = "true";
                    ModalPopupEndoso.Show();
                    #endregion
                    break;
                default:
                    break;
            }
        }

        public void FillData()
        {
            gvTransportDetail.DatabindAspxGridView(ObjServices.GetDataTransport());
            var PolicyNoMainCol = gvTransportDetail.getThisColumn("PolicyNumberMain");
            if (PolicyNoMainCol != null)
                PolicyNoMainCol.Visible = !string.IsNullOrEmpty(ObjServices.PolicyNoMain);

            var BlackListCol = gvTransportDetail.getThisColumn("BlackList");
            if (BlackListCol != null)
                BlackListCol.Visible = ObjServices.BlackListHasProblem;
        }
        public void BindGrid() { FillData(); }
        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void ClearData()
        {

        }

        protected void gvTransportDetail_PreRender(object sender, EventArgs e)
        {
            var Grid = (sender as DevExpress.Web.ASPxGridView);
            //Traducir las columnas
            Grid.TranslateColumnsAspxGrid();
        }
    }
}