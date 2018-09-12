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
    public partial class UCBail : UC, IUC
    {
        public delegate void ExportToPDFHandler(byte[] pdfFile, string FileName);
        public event ExportToPDFHandler ExportToPdf;
        public void ExportPDF(byte[] pdfFile, string FileName)
        {
            ExportToPdf(pdfFile, FileName);
        }

        private void HideOrShow(String Product)
        {
            var DataConfig = ObjServices.GettingDropData(
                                                        Utility.DropDownType.ProjectConfigurationValue,
                                                        corpId: ObjServices.Corp_Id,
                                                        pProjectId: int.Parse(System.Configuration.ConfigurationManager.AppSettings["ProjectIdNewBusiness"])
                                                        );

            if (DataConfig != null)
            {
                var DataFields = DataConfig.FirstOrDefault(h => h.Namekey == Product);
                if (DataFields != null)
                {
                    var Fields = DataFields.ConfigurationValue.Split(',');

                    foreach (DevExpress.Web.GridViewColumn item in gvBailDetail.Columns)
                        item.Visible = false;

                    foreach (var item in Fields)
                    {
                        var Column = gvBailDetail.Columns[item];

                        if (Column != null)
                        {
                            Column.Visible = true;
                        }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerMyPreviewPDF.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"];
            UCEndosoCesionAlliedLines.ExportToPdf += ExportPDF;
            UCEndosoCesionAlliedLines.BindGrid += BindGrid;

            UCBailDetail.BindGrid += FillData;

            var showPopCoverages = hdnBailCoverages.Value == "true";
            if (showPopCoverages)
                ModalPopupCoverage.Show();

            var showBailPop = hdnPopBailDetail.Value == "true";
            if (showBailPop)
                mpeBailDetail.Show();

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
            var UniqueBailId = grid.GetKeyFromAspxGridView("UniqueBailId", e.VisibleIndex).ToInt();
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
                case "EditBail":
                    //Popup para ver la información detallada de la propiedad
                    var SelectedRecord = ObjServices.GetDataBail(UniqueBailId);
                    UCBailDetail.oBail = SelectedRecord.FirstOrDefault();
                    UCBailDetail.Initialize();
                    hdnPopBailDetail.Value = "true";
                    mpeBailDetail.Show();
                    this.ExcecuteJScript("addClassDoble();");
                    break;
                case "Coverage":
                    hdnBailCoverages.Value = "true";
                    UCCoverages.UniqueId = UniqueBailId;
                    FillDataCoverage();
                    ModalPopupCoverage.Show();
                    break;
                case "Endoso":
                    #region Endoso
                    UCEndosoCesionAlliedLines.Initialize();
                    UCEndosoCesionAlliedLines.UniqueId = UniqueBailId;
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
            var dataBail = ObjServices.GetDataBail();
            gvBailDetail.DatabindAspxGridView(dataBail);
            var colProductDesc = dataBail.FirstOrDefault();
            if (colProductDesc != null)
            {                                                            
                string productDesc = "Grid_" + colProductDesc.ProductDesc.Replace(" ", "");
                HideOrShow(productDesc);
            }

            var PolicyNoMainCol = gvBailDetail.getThisColumn("PolicyNumberMain");
            if (PolicyNoMainCol != null)
            {
                PolicyNoMainCol.Visible = !string.IsNullOrEmpty(ObjServices.PolicyNoMain);
            }

            var BlackListCol = gvBailDetail.getThisColumn("BlackList");
            if (BlackListCol != null)
                BlackListCol.Visible = ObjServices.BlackListHasProblem;
            
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void BindGrid() { FillData(); }

        public void ClearData()
        {

        }
        protected void gvBailDetail_PreRender(object sender, EventArgs e)
        {
            var Grid = (sender as DevExpress.Web.ASPxGridView);
            //Traducir las columnas
            Grid.TranslateColumnsAspxGrid();
        }
    }
}