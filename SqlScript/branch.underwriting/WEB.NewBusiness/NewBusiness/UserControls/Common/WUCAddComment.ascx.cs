using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.ReadyToReview;


namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCAddComment : UC, IUC
    {
        public void edit() { }
        public void FillData() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            btnSave.Text = Resources.Save;
            Comment.InnerHtml = Resources.Comment;
            btnCancel.Value = Resources.Cancel;
        }

        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            save();
        }

        public void save()
        {
            if (!string.IsNullOrWhiteSpace(CommentTxt.Text))
            {
                ObjServices.oCaseManager.InsertComment(new Case.Comment()
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
                    CommentTypeId = 1,//NewBusiness Comment                 
                    Comments = CommentTxt.Text.Trim(),
                    UserId = ObjServices.UserID.Value
                });

                var result = ObjServices.oCaseManager.SendToReject(ObjServices.GetCurrentCase());

                var oWUCReadyToReview = this.Page.Master.FindControl("bodyContent").FindControl("WUCReadyToReview");

                if (oWUCReadyToReview != null)
                    (oWUCReadyToReview as WUCReadyToReview).FillData();

                var hdnShowPopReject = oWUCReadyToReview.FindControl("hdnShowPopReject");

                if (hdnShowPopReject != null)
                    (hdnShowPopReject as HiddenField).Value = "false"; 

                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.RejectedCase,Title:ObjServices.Language == Utility.Language.en?"Warning":"Advertencia");

            }
        }

        public void Initialize()
        {
            ClearData();
        }

        public void ClearData()
        {
            Utility.ClearAll(this.pnForm.Controls);

            var oWUCReadyToReview = this.Page.Master.FindControl("bodyContent").FindControl("WUCReadyToReview");

            var udpReadyToReview = oWUCReadyToReview.FindControl("udpReadyToReview");

            if (udpReadyToReview != null)
                (udpReadyToReview as UpdatePanel).Update();

            udpAddComment.Update();
        }
    }
}