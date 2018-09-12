using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanDocument
{
    public partial class UCPolicyPlanDocument : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {

        //IPolicy PolicyManager
        //{
        //    get { return diManager.PolicyManager; }
        //}

        //IPayment PaymentManager
        //{
        //    get { return diManager.PaymentManager; }
        //}


        DropDownManager DropDowns = new DropDownManager();
        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            var policyDocuments = Services.PolicyManager.GetCategoryDocument(Service.Corp_Id,
                                                                             Service.Region_Id,
                                                                             Service.Country_Id,
                                                                             Service.Domesticreg_Id,
                                                                             Service.State_Prov_Id,
                                                                             Service.City_Id,
                                                                             Service.Office_Id,
                                                                             Service.Case_Seq_No,
                                                                             Service.Hist_Seq_No,
                                                                             null,
                                                                             null,
                                                                             Service.LanguageId);

            gvPolicyDocument.DataSource = policyDocuments.Where(x => x.HasDocument == true).ToList();
            gvPolicyDocument.DataBind();

            if (gvPolicyDocument.BottomPagerRow != null)
            {
                var totalItems = (Literal)gvPolicyDocument.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = policyDocuments.ToList().Count + "";
            }

            setPagerIndex(gvPolicyDocument);
        }

        public void FillDdl()
        {
            Tools.GettingAllDropsJSON(ref ddlDocumentType,
                                      DropDownType.PolicyDocument,
                                      "DocCategoryDesc",
                                      corpId: Service.Corp_Id,
                                      regionId: Service.Region_Id,
                                      countryId: Service.Country_Id,
                                      domesticregId: Service.Domesticreg_Id,
                                      stateProvId: Service.State_Prov_Id,
                                      cityId: Service.City_Id,
                                      officeId: Service.Office_Id,
                                      caseSeqNo: Service.Case_Seq_No,
                                      histSeqNo: Service.Hist_Seq_No);

            ddlDocumentType.Items.Insert(0, new ListItem("All Documents", "-1"));
        }

        public void DisableLinkButton(LinkButton linkButton, string disable_class)
        {
            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }

        void setPagerIndex(GridView gv)
        {
            if (gv.BottomPagerRow != null)
            {
                var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
                var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
                var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
                var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
                var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
                var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


                var count = gv.PageCount;
                var index = gv.PageIndex + 1;

                indexText.Text = index.ToString();
                totalText.Text = count.ToString();

                if (index == 1)
                {
                    DisableLinkButton(lnkPrev, "prev_dis");
                    DisableLinkButton(lnkFirst, "rewd_dis");
                }
                else if (index == count)
                {
                    DisableLinkButton(lnkNext, "next_dis");
                    DisableLinkButton(lnkLast, "fwrd_dis");

                }
            }
        }

        public class item
        {
            public int DocTypeId { get; set; }
            public int DocCategoryId { get; set; }
            public int Counts { get; set; }
        }

        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<Entity.UnderWriting.Entities.Policy.CategoryDocument> policyDocuments = null;

            if (ddlDocumentType.SelectedValue == "-1")
            {
                policyDocuments = Services.PolicyManager.GetCategoryDocument(Service.Corp_Id,
                                                                             Service.Region_Id,
                                                                             Service.Country_Id,
                                                                             Service.Domesticreg_Id,
                                                                             Service.State_Prov_Id,
                                                                             Service.City_Id,
                                                                             Service.Office_Id,
                                                                             Service.Case_Seq_No,
                                                                             Service.Hist_Seq_No,
                                                                             null,
                                                                             null,
                                                                             Service.LanguageId);
            }
            else
            {
                var x = Tools.deserializeJSON<item>((sender as DropDownList).SelectedValue);
                policyDocuments = Services.PolicyManager.GetCategoryDocument(Service.Corp_Id,
                                                                             Service.Region_Id,
                                                                             Service.Country_Id,
                                                                             Service.Domesticreg_Id,
                                                                             Service.State_Prov_Id,
                                                                             Service.City_Id,
                                                                             Service.Office_Id,
                                                                             Service.Case_Seq_No,
                                                                             Service.Hist_Seq_No,
                                                                             x.DocTypeId,
                                                                             x.DocCategoryId,
                                                                             Service.LanguageId);
            }

            gvPolicyDocument.DataSource = policyDocuments.Where(x => x.HasDocument == true).ToList();
            gvPolicyDocument.DataBind();

            setPagerIndex(gvPolicyDocument);
        }

        protected void lnkPdf_Click(object sender, EventArgs e)
        {
            int rowId = ((GridViewRow)(((LinkButton)sender).NamingContainer)).RowIndex;
            var dataKey = gvPolicyDocument.DataKeys[rowId];

            if (dataKey != null)
            {
                if (dataKey.Values != null)
                {
                    var DocTypeId = int.Parse(dataKey.Values["DocTypeId"].ToString());
                    var DocCategoryId = int.Parse(dataKey.Values["DocCategoryId"].ToString());
                    var DocumentId = int.Parse(dataKey.Values["DocumentId"].ToString());


                    string documentType = "D";
                    Services ServicesOn = new Services();
                    Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                    {
                        CorpId = Service.Corp_Id,
                        RegionId = Service.Region_Id,
                        CountryId = Service.Country_Id,
                        DomesticregId = Service.Domesticreg_Id,
                        StateProvId = Service.State_Prov_Id,
                        CityId = Service.City_Id,
                        OfficeId = Service.Office_Id,
                        CaseSeqNo = Service.Case_Seq_No,
                        HistSeqNo = Service.Hist_Seq_No 
                    };
                    byte[] pdfOnBase = ServicesOn.ViewFileFromOnBase(Add,documentType, DocCategoryId, DocTypeId);

                    if (pdfOnBase == null)
                    {
                        var document = Services.PaymentManager.GetDocument(Service.Corp_Id,
                                                                           Service.Region_Id,
                                                                           Service.Country_Id,
                                                                           Service.Domesticreg_Id,
                                                                           Service.State_Prov_Id,
                                                                           Service.City_Id,
                                                                           Service.Office_Id,
                                                                           Service.Case_Seq_No,
                                                                           Service.Hist_Seq_No,
                                                                           DocCategoryId,
                                                                           DocTypeId,
                                                                           DocumentId);

                        if (document != null)
                        {
                            if (document.DocumentBinary == null)
                            {
                                string message = "This document has no attachment, please try with another one.";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'FILE NOT FOUND');", true);
                                return;
                            }
                            else
                            {
                                ShowPDFControl(document.DocumentBinary);
                            }
                        }
                    }
                    else
                    {
                        ShowPDFControl(pdfOnBase);
                    }
                }
            }
        }

        protected void gvPolicyDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPolicyDocument.PageIndex = e.NewPageIndex;
            gvPolicyDocument.DataBind();
            FillData();
            setPagerIndex(gvPolicyDocument);
        }

        private void ShowPDFControl(byte[] pdfFile)
        {
            var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("mpPdfViewer");
            var popUp = ((Common.UCShowPDFPopup)Page.Master.FindControl("UCShowPDFPopup"));

            if (ModalPopUp != null && popUp != null)
            {
                popUp.LoadPDFPreview(pdfFile);
                ModalPopUp.Show();
                this.ExcecuteJScript("$(\"#UCShowPDFPopup_upPaymentPdfViewer\").append(CreateNewPopFrame())");
            }
        }

        protected void gvPolicyDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                using (LinkButton lnkPdf = e.Row.FindControl("lnkPdf") as LinkButton)
                {
                    if (!lnkPdf.Equals(null))
                    {
                        OrderedDictionary DataKeys = gvPolicyDocument.DataKeys[e.Row.RowIndex].Values as OrderedDictionary;
                        if (!DataKeys.Equals(null) && !DataKeys.Values.Equals(null))
                        {
                            lnkPdf.CssClass = bool.Parse(DataKeys["HasDocument"].ToString()) ? "pdf_ico" : string.Empty;
                        }
                    }
                }
            }
        }
    }
}