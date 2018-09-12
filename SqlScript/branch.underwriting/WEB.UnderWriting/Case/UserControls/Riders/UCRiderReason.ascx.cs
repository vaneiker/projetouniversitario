using System;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Riders
{
    public partial class UCRiderReason :UC
    {
        

        //IRider RiderManager
        //{
        //    get { return diManager.RiderManager; }
        //}


        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void FillData(int riderId, int riderTypeId)
        {
            txtNewCommentRiderReason.Text = string.Empty;
            txtComment.Text = string.Empty;

            var Corp_Id=Service.Corp_Id;
            var Region_Id=Service.Region_Id;
            var Country_Id=Service.Country_Id;
            var Domesticreg_Id=Service.Domesticreg_Id;
            var State_Prov_Id=Service.State_Prov_Id;
            var City_Id=Service.City_Id;
            var Office_Id=Service.Office_Id;
            var Case_Seq_No=Service.Case_Seq_No;
            var Hist_Seq_No=Service.Hist_Seq_No;


            var comments = Services.RiderManager.GetAllRiderComments(Corp_Id, Region_Id, Country_Id, Domesticreg_Id, State_Prov_Id, City_Id, Office_Id, Case_Seq_No, Hist_Seq_No, riderTypeId, riderId);

            foreach(var comment in comments)
                txtComment.Text +=comment.CommentDate+"\n"+comment.CommentIssuedByName+"\n"+comment.CommentBody+"\n\n";

            hdnRiderId.Value = riderId.ToString();
            hdnRiderTypeId.Value = riderTypeId.ToString();
        }

    

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var comment = new Entity.UnderWriting.Entities.Rider.Comment
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                RiderTypeId = int.Parse(hdnRiderTypeId.Value),
                Riderid = int.Parse(hdnRiderId.Value),
                CommentBody = txtNewCommentRiderReason.Text,
                UserId = Service.Underwriter_Id,
                CommentIssuedBy = Service.Underwriter_Id
            };


            Services.RiderManager.InsertComment(comment);

                FillData(int.Parse(hdnRiderId.Value), int.Parse(hdnRiderTypeId.Value));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           (this.Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRiderInformation").FindControl("hfRiderReason") as HiddenField).Value = "false";
        }
    }
}