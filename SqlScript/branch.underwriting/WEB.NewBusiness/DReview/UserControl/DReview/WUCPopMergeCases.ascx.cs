using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.DReview.UserControl.DReview
{
    public partial class WUCPopMergeCases : UC, IUC
    {
        public delegate void FillDataHandler();
        public event FillDataHandler FillDataReview;

        public bool isExpanded
        {
            get
            {
                return ViewState["isExpanded"].ToBoolean();
            }
            set
            {
                ViewState["isExpanded"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            ExportingSelectedRecords.InnerHtml = Resources.ExportRecordsSelectedMergeLabel.ToUpper();
            NewCaseInformation.InnerHtml = Resources.NEWCASEINFORMATION.ToUpper();
            btnSave.Text = Resources.Export2;
            btnClose.Value = Resources.Close;
        }

        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }

        IEnumerable<int> ContactIds;

        public List<Entity.UnderWriting.Entities.DataReview.ContactMerge> TemData = new List<Entity.UnderWriting.Entities.DataReview.ContactMerge>();

        public List<Entity.UnderWriting.Entities.DataReview.ContactMerge> oTemData
        {
            get
            {
                var result = ViewState["oData"] == null ?
                    new List<Entity.UnderWriting.Entities.DataReview.ContactMerge>() :
                    ViewState["oData"] as List<Entity.UnderWriting.Entities.DataReview.ContactMerge>;

                return result;
            }

            set
            {
                List<Entity.UnderWriting.Entities.DataReview.ContactMerge> tempList = null;

                if (value != null)
                {
                    var result = ViewState["oData"] != null ? (List<Entity.UnderWriting.Entities.DataReview.ContactMerge>)ViewState["oData"]
                                                            :
                                                            new List<Entity.UnderWriting.Entities.DataReview.ContactMerge>();

                    tempList = new List<Entity.UnderWriting.Entities.DataReview.ContactMerge>(result);

                    tempList.AddRange(value);
                }

                ViewState["oData"] = tempList;
            }
        }

        public void ClearData()
        {
            oTemData = null;
            ViewState["RowId"] = null;
            ViewState["MasterContactId"] = null;
            gridMaster.DetailRows.CollapseAllRows();
        }

        public IEnumerable<DataReview.ContactMerge> getDataDetailSession(IEnumerable<DataReview.ContactMerge> data)
        {
            return data;
        }

        public IEnumerable<DataReview.ContactMerge> FillDataDetailSession(int masterContactId)
        {
            var data = oTemData.Where(x => x.ContactIdMergeOwner == masterContactId);
            return data;
        }

        public List<DataReview.ContactMerge> getDataDetail(IEnumerable<int> ContactIds, bool Searching)
        {
            var dataDetail = new List<DataReview.ContactMerge>(0);

            if (Searching)
            {
                try
                {
                    IEnumerable<DataReview.ContactMerge> data;

                    data = ObjServices.oDataReviewManager.GetContactMergeMath(ContactIds, ObjServices.Language.ToInt());
                    dataDetail = data
                                    .Select(x =>
                                        {
                                            x.Ids = !x.Ids.isNullReferenceObject()
                                                        ? x.Ids.Replace(",", "<br />")
                                                        : x.Ids;
                                            return x;
                                        })
                                    .ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            isExpanded = false;
            return dataDetail;
        }

        public bool Search()
        {
            var result = ViewState["Search"].ToBoolean();
            return result;
        }

        public IEnumerable<DataReview.ContactMerge> GetDataMaster(IEnumerable<DataReview.ContactMerge> data)
        {
            return data;
        }

        public IEnumerable<DataReview.ContactMerge> FillDataMaster(
                                                                   int Corp_Id,
                                                                   int Region_Id,
                                                                   int Country_Id,
                                                                   int Domesticreg_Id,
                                                                   int State_Prov_Id,
                                                                   int City_Id,
                                                                   int Office_Id,
                                                                   int Case_Seq_No,
                                                                   int Hist_Seq_No
                                                                  )
        {
            IEnumerable<DataReview.ContactMerge> data = null;

            if (Search())
            {
                data = ObjServices.oDataReviewManager.GetContactMerge(new Policy.Parameter()
                {
                    CorpId = Corp_Id,
                    RegionId = Region_Id,
                    CountryId = Country_Id,
                    DomesticregId = Domesticreg_Id,
                    StateProvId = State_Prov_Id,
                    CityId = City_Id,
                    OfficeId = Office_Id,
                    CaseSeqNo = Case_Seq_No,
                    HistSeqNo = Hist_Seq_No,
                    LanguageId = ObjServices.Language.ToInt()
                }).Select(x =>
                {
                    x.Ids = !x.Ids.isNullReferenceObject() ? x.Ids.Replace(",", "<br />") : x.Ids;
                    return x;
                });

                ContactIds = data.Select(x => x.ContactId);
                TemData = getDataDetail(ContactIds, true).ToList();
                oTemData = TemData;
            }

            return data;
        }

        public void FillData()
        {
            gridMaster.DataBind();
            hdnSelectedContact.Value = "";
        }

        public void Initialize()
        {
            ViewState["Search"] = "true";
            ClearData();
            FillData();
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            var grandChildGrid = (sender as ASPxGridView);
            ViewState["MasterContactId"] = grandChildGrid.GetMasterRowKeyValue();
            var template = (GridViewDetailRowTemplateContainer)grandChildGrid.Parent;
            var childGrid = template.Grid;
            childGrid.SetFilterSettings();
            grandChildGrid.TranslateColumnsAspxGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var message = string.Format(Resources.DontSentToUnderwritingMessage, ObjServices.Policy_Id);

            if (!string.IsNullOrEmpty(hdnSelectedContact.Value))
            {
                var dataSelected = Utility.deserializeJSON<List<Utility.itemSelectContact>>(hdnSelectedContact.Value);

                var ListSelection = new List<DataReview.DRCase>();

                foreach (var item in dataSelected)
                {
                    var Case = new DataReview.DRCase()
                    {
                        CorpId = ObjServices.Corp_Id,
                        RegionId = ObjServices.Region_Id,
                        CountryId = ObjServices.Country_Id,
                        DomesticRegId = ObjServices.Domesticreg_Id,
                        StateProvId = ObjServices.State_Prov_Id,
                        CityId = ObjServices.City_Id,
                        OfficeId = ObjServices.Office_Id,
                        CaseSeqNo = ObjServices.Case_Seq_No,
                        HistSeqNo = ObjServices.Hist_Seq_No,
                        CurrentContactId = item.currentContact,
                        NewContactId = item.NewContact,
                        UserId = ObjServices.UserID.Value
                    };

                    ListSelection.Add(Case);
                }

                var result = ObjServices.oDataReviewManager.SendToUnderwriting(ListSelection).FirstOrDefault();

                if (result.StatusCode > -1)
                {
                    this.MessageBox(string.Format(Resources.SentToUnderwritingMessage, ObjServices.Policy_Id),
                        Title: RESOURCE.UnderWriting.NewBussiness.Resources.Warning);
                    hdnSelectedContact.Value = string.Empty;
                    CheckIds.Value = string.Empty;
                    FillDataReview();
                }
                else
                    this.MessageBox(message, Title: RESOURCE.UnderWriting.NewBussiness.Resources.Warning);
            }
            else
                this.MessageBox(message, Title: RESOURCE.UnderWriting.NewBussiness.Resources.Warning);

        }

        protected void MasterDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = FillDataMaster(ObjServices.Corp_Id,
                                                       ObjServices.Region_Id,
                                                       ObjServices.Country_Id,
                                                       ObjServices.Domesticreg_Id,
                                                       ObjServices.State_Prov_Id,
                                                       ObjServices.City_Id,
                                                       ObjServices.Office_Id,
                                                       ObjServices.Case_Seq_No,
                                                       ObjServices.Hist_Seq_No
                                                       );
        }

        protected void DetailDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = FillDataDetailSession(ViewState["MasterContactId"].ToInt());
        }

        protected void gridMaster_DetailRowExpandedChanged(object sender, ASPxGridViewDetailRowEventArgs e)
        {
            var RowIndex = e.VisibleIndex;
            isExpanded = (e.Expanded);
        }

        protected void gridMaster_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        protected void detailGrid_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}