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
    public partial class WUCAddFollowUpComment : UC, IUC
    {
        System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e){}
        public void ReadOnlyControls(bool isReadOnly){}
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang){
            Policy.InnerHtml = Resources.PolicyLabel;
            User.InnerHtml = Resources.USER;
            InitiatedDate.InnerHtml = Resources.initiateddate;
            DocumentName.InnerHtml = Resources.DocumentName;
            Comment.InnerHtml = Resources.Comment;
            btnSave.Text = Resources.Save;
            btnCancel.Value = Resources.Cancel;
        }

        public void save(){}
        public void edit(){}

        public void FillDrop(dynamic data)
        {
            ddlDocumentName.DataSource = data;
            ddlDocumentName.DataTextField = "DocumentDesc";
            ddlDocumentName.DataValueField = "key";
            ddlDocumentName.DataBind();

            var ddlDocument = (DropDownList)this.Parent.FindControl("ddlDocument");
            var itemSelect = ddlDocumentName.Items.FindByText(ddlDocument.SelectedItem.Text);
            ddlDocumentName.SelectIndexByValue(itemSelect.Value);
        }        

        public void FillData()
        {
            txtPolicy.Text = ObjServices.Policy_Id;
            txtUser.Text = ObjServices.UserName;
            txtInitiatedDate.Text = DateTime.Now.ToString();
        }

        public void Initialize()
        {
            ClearData();        
            FillData();
            udpAddFollowUp.Update();
        }

        public void ClearData()
        {
            this.ClearControls();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var objItem = Serializer.Deserialize<Utility.itemDocument>(ddlDocumentName.SelectedValue);

            if (!string.IsNullOrEmpty(txtComment.Text))
            {
                if (!objItem.RequirementId.HasValue || objItem.RequirementId.Value == -1 )
                {
                    ObjServices.oNote.Insert(new Entity.UnderWriting.Entities.Note()
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
                        ReferenceTypeId = 8,
                        NoteName = "DataReview",
                        OriginatedById = ObjServices.UserID.Value,
                        NoteBody = ddlDocumentName.SelectedItem.Text + "\n" + txtComment.Text.Trim(),
                        UserId = ObjServices.UserID.Value
                    });
                }
                else
                {
                    ObjServices.oRequirementManager.InsertComunication(new Entity.UnderWriting.Entities.Requirement.Comunication()
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
                        ContactId = objItem.ContactId,
                        RequirementCatId = objItem.RequirementCatId.Value,
                        RequirementTypeId = objItem.RequirementTypeId.Value,
                        RequirementId = objItem.RequirementId.Value,
                        ComunicationId = -1,
                        Comment = txtComment.Text.Trim(),
                        CommentBy = ObjServices.UserID.Value,
                        UserId = ObjServices.UserID.Value,
                        CommentDate = DateTime.Now
                    });

                }

                Utility.ExcecuteJScript(this, "$('#dvAddFollowUpComment').dialog('close');");  
            } 
        }        
    }
}