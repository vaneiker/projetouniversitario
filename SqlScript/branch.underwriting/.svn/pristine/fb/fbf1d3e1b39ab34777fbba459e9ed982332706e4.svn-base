using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.DReview.UserControl.DReview
{
    public partial class WUCCompareEdit : UC, IUC
    {
        public delegate void ManageTabsHandler(object sender, EventArgs e);
        public event ManageTabsHandler ManageTabs;

        public delegate void FillDropDocumentByTabHandler(List<Utility.DocumentItem> items, string keySelected = null);
        public event FillDropDocumentByTabHandler FillDocByTab;

        public void save() { }
        public void edit() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void ClearData() { }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvCompareEdit.SetFilterSettings();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            CompareEdit.InnerHtml = Resources.COMPAREEDIT.Capitalize();
            PolicyNumber.InnerHtml = Resources.PolicyNoLabel;
            InsuredName.InnerHtml = Resources.InsuredName;
            btnClose.Value = Resources.Close.Capitalize();
        }

        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            IEnumerable<DataReview.DocumentToReview> data;

             data = IsPostBack
                ? ObjServices.oDataReviewManager.GetDocumentsToReview(new Entity.UnderWriting.Entities.Policy.Parameter
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            DomesticregId = ObjServices.Domesticreg_Id,
                            StateProvId = ObjServices.State_Prov_Id,
                            CityId = ObjServices.City_Id,
                            OfficeId = ObjServices.Office_Id,
                            CaseSeqNo = ObjServices.Case_Seq_No,
                            HistSeqNo = ObjServices.Hist_Seq_No,
                            LanguageId = ObjServices.Language.ToInt()
                        }).ToList()
                : new List<DataReview.DocumentToReview>(1).AsEnumerable();

            e.KeyExpression = gvCompareEdit.KeyFieldName;
            e.QueryableSource = data.AsQueryable();

            if (!data.isNullReferenceObject() && data.Any())
            {
                var tempPaymentId = data.FirstOrDefault(x => x.PaymentId.HasValue);

                ObjServices.PaymentId = !tempPaymentId.isNullReferenceObject()
                                           ? tempPaymentId.PaymentId.HasValue
                                               ? tempPaymentId.PaymentId.Value
                                               : -1
                                           : -1;
            }
        }

        protected void SetVariables(int RowIndex, DevExpress.Web.ASPxGridView Grid)
        {
            ObjServices.KeyNameProduct = Grid.GetKeyFromAspxGridView("ProductNameKey", RowIndex, string.Empty).ToString();
            (this.Page as BasePage).setIsFuneral();

            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            if (productBehavior.ToInt() == -1)
                productBehavior = Utility.ProductBehavior.None;

            ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
        }

        public void FillData()
        {
            gvCompareEdit.DataBind();
            gvCompareEdit.SetFilterSettings();
        }

        public void Initialize(String InsuredName)
        {
            ViewState["iscrossingTabs"] = null;
            Session["SelectedDoc"] = null;
            txtInsuredName.Text = InsuredName;
            Initialize();
        }

        public void Initialize()
        {
            txtPolicyNumber.Text = ObjServices.Policy_Id;
            FillData();
        }

        public IEnumerable<DataReview.DocumentToReview> getDocuments()
        {
            var Result = ObjServices.oDataReviewManager.GetDocumentsToReview(new Entity.UnderWriting.Entities.Policy.Parameter()
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                LanguageId = ObjServices.Language.ToInt()
            }).ToList();

            return Result;
        }

        public dynamic getAllDocument()
        {
            var Data = getDocuments();

            var DocumentsTab = Data.Select(y => new
                {
                    DocumentDesc = y.NameDesc,
                    key = "{\"DocumentId\":\"" + y.DocumentId +
                          "\",\"DocCategoryId\":\"" + y.DocCategoryId +
                          "\",\"DocTypeId\":\"" + y.DocTypeId +
                          "\"}"
                }).Distinct().ToList();

            return DocumentsTab;
        }

        public List<Utility.DocumentItem> getDocumentByTab(int Tab)
        {
            var Data = getDocuments();

            //Documentos por tab
            var DocumentsTab = Data.Where(x => x.TabId == Tab).Select(y => new Utility.DocumentItem()
             {
                 DocumentDesc = y.NameDesc,             
                 key = "{\"DocumentId\":\"" + y.DocumentId +
                       "\",\"DocCategoryId\":\"" + y.DocCategoryId +
                       "\",\"DocTypeId\":\"" + y.DocTypeId +
                       "\",\"IsReviewed\":\"" + y.IsReviewed.ToString() +
                       "\",\"TabId\":\"" + y.TabId +
                       "\",\"ContactId\":\"" + y.ContactId +
                       "\",\"FunctionalitySeqNo\":\"" + (y.FunctionalitySeqNo.HasValue ? y.FunctionalitySeqNo.ToString() : "-1") +
                       "\",\"FunctionalityId\":\"" + y.FunctionalityId +
                       "\",\"ProjectId\":\"" + y.ProjectId +
                       "\",\"PaymentDetId\":\"" + (y.PaymentDetId.HasValue ? y.PaymentDetId.ToString() : "-1") +
                       "\"}"
             }).ToList();

            return DocumentsTab;
        }

        protected void gvCompareEdit_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            var Grid = ((DevExpress.Web.ASPxGridView)sender);

            int RowIndex = e.VisibleIndex;

            SetVariables(RowIndex, sender as DevExpress.Web.ASPxGridView);
            var DocumentId = Grid.GetKeyFromAspxGridView("DocumentId", RowIndex);
            var DocCategoryId = Grid.GetKeyFromAspxGridView("DocCategoryId", RowIndex);
            var DocTypeId = Grid.GetKeyFromAspxGridView("DocTypeId", RowIndex);
            var IsReviewed = Grid.GetKeyFromAspxGridView("IsReviewed", RowIndex);
            var TabId = Grid.GetKeyFromAspxGridView("TabId", RowIndex);
            var FunctionalityId = Grid.GetKeyFromAspxGridView("FunctionalityId", RowIndex);
            var ProjectId = Grid.GetKeyFromAspxGridView("ProjectId", RowIndex);
            var PaymentDetId = Grid.GetKeyFromAspxGridView("PaymentDetId", RowIndex);
            var FunctionalitySeqNo = Grid.GetKeyFromAspxGridView("FunctionalitySeqNo", RowIndex);
            var NameDesc = Grid.GetKeyFromAspxGridView("NameDesc", RowIndex);

            var key = "{\"DocumentId\":\"" + DocumentId +
                      "\",\"DocCategoryId\":\"" + DocCategoryId +
                      "\",\"DocTypeId\":\"" + DocTypeId +
                      "\",\"IsReviewed\":\"" + IsReviewed.ToString() +
                      "\",\"TabId\":\"" + TabId +
                      "\",\"FunctionalitySeqNo\":\"" + FunctionalitySeqNo +
                      "\",\"FunctionalityId\":\"" + FunctionalityId +
                      "\",\"ProjectId\":\"" + ProjectId +
                      "\",\"PaymentDetId\":\"" + PaymentDetId +
                      "\"}";

            ViewState["iscrossingTabs"] = false;

            Session["SelectedDoc"] = NameDesc;

            Button Boton = null;

            var Container = ((DReviewContainer)this.Parent.Parent.Parent.Parent);

            switch (Commando)
            {
                case "compare_edit":
                    var Tab = int.Parse(gvCompareEdit.GetKeyFromAspxGridView("TabId", RowIndex).ToString());

                    ObjServices.TabSelected = (Utility.Tab)Utility.getEnumTypeFromValue(typeof(Utility.Tab), Tab);

                    String strTab;

                    switch (ObjServices.TabSelected)
                    {
                        case Utility.Tab.ClientInfo:
                            strTab = "btnClientInfo";
                            break;
                        case Utility.Tab.OwnerInfo:
                            strTab = "btnOwnerInfo";
                            break;
                        case Utility.Tab.PlanPolicy:
                            strTab = "btnPlanPolicy";
                            break;
                        case Utility.Tab.Beneficiaries:
                            strTab = "btnBeneficiaries";
                            break;
                        case Utility.Tab.Payment:
                            strTab = "btnPayment";
                            break;
                        case Utility.Tab.HealthDeclaration:
                            strTab = "btnQuestionaries";
                            break;
                        case Utility.Tab.Compliance:
                            strTab = "btnCompliance";
                            break;
                        default: strTab = string.Empty;
                            break;
                    }

                    Boton = (Button)this.Parent.FindControl(strTab);
                    (Container.FindControl("hdnCurrentTab") as HiddenField).Value = Boton.ID;
                    ManageTabs(Boton, null);
                    break;
            }

            (Container.FindControl("hdnShowCompareEdit") as HiddenField).Value = "false";
            (Container.FindControl("mpeCompareEdit") as AjaxControlToolkit.ModalPopupExtender).Hide();
            Container.setActiveView(1);

            this.ExcecuteJScript("$('#btnRefreshHiddenField').click();");
        }

        protected void gvCompareEdit_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        protected void gvCompareEdit_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridViewAfterPerformCallbackEventArgs e)
        {

        }

        protected void btnRefreshHiddenField_Click(object sender, EventArgs e)
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");
            var hdnisFuneral = bodyContent.FindControl("hfisFuneral");
            var udpAddNewClient = bodyContent.FindControl("udpAddNewClient");

            if (!hdnisFuneral.isNullReferenceControl())
            {
                (hdnisFuneral as HiddenField).Value = ObjServices.KeyNameProduct;
                if (!udpAddNewClient.isNullReferenceControl())
                    (udpAddNewClient as UpdatePanel).Update();
            }
        }
    }
}