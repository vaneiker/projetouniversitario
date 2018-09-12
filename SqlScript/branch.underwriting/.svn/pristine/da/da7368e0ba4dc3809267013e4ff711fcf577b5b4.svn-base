using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.DReview.UserControl.DReview
{
    public partial class WUCPopRejectToReadyReview : UC, IUC
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
            PolicyNumber.InnerHtml = Resources.PolicyNoLabel;
            User.InnerHtml = Resources.USER;
            InsuredName.InnerHtml = Resources.InsuredName;
            PlanName.InnerHtml = Resources.PlanName;
            Comment.InnerHtml = Resources.Comment;
            RejectReason.InnerHtml = Resources.RejectReason;
            btnReject.Text = Resources.Save;
            btnCancel.Value = Resources.Cancel;
        }

        public void save()
        {
            var ListError = new List<Utility.Errors>();
            var ListMessage = new List<Utility.ListTabError>();

            if (!string.IsNullOrWhiteSpace(txtComment.Text))
            {
                var Result = RejectCase();

                if (Result.Result)
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
                        Comments = "Reject Reason:" + ddlRejectReason.SelectedItem.Text + "\n" + txtComment.Text.Trim(),
                        UserId = ObjServices.UserID.Value
                    });

                    this.ExcecuteJScript("$('#dvCommentReject').dialog('close')");
                    ((DReviewContainer)this.Parent).FillData();
                }
                else
                {

                    var item = new Utility.Errors();
                    item.Policy = txtPolicyNumber.Text;
                    var vErrors = Result.ResultMessage.Split(',');
                    for (int x = 0; x < vErrors.Length; x++)
                        item.MessageErrorList.Add((x + 1).ToString() + "-" + vErrors[x] + RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted);

                    ListError.Add(item);

                    if (ListError.Any())
                    {
                        foreach (var vitem in ListError)
                        {
                            var temp = new Utility.ListTabError();
                            temp.Policy = RESOURCE.UnderWriting.NewBussiness.Resources.ErrorPolicyNumber + " \"" + item.Policy + ":\"" + "<br/>";
                            temp.Errors = string.Join("<br/>", item.MessageErrorList.ToArray());
                            ListMessage.Add(temp);
                        }

                        var Message = new StringBuilder();

                        Message.Append("<br/>");

                        foreach (var pitem in ListMessage)
                        {
                            Message.Append("<br/>");
                            Message.Append(pitem.Policy);
                            Message.Append("<br/>");
                            Message.Append(pitem.Errors);
                            Message.Append("<br/>");
                        }
                        var Title = RESOURCE.UnderWriting.NewBussiness.Resources.ErrorInCase;
                        var func = "CustomDialogMessageEx('" + Message.ToString() + "',500,350,true,'" + Title + "');";
                        this.ExcecuteJScript(func);
                    }
                }
            }
        }

        private Case.CaseResult RejectCase()
        {

            var Result = ObjServices.oCaseManager.SendToReview(new Case()
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
                UserId = ObjServices.UserID.Value,
                ProjectId = ObjServices.getCurrentProyect(),
                StatusChangeTypeId = 7 //DataReview to ReadyToReview
            });

            return Result;
        }

        public void FillDrop()
        {
            //Llenar el dropDpown de Generos
            ObjServices.GettingAllDrops(ref ddlRejectReason,
                                    Utility.DropDownType.RejectReason,
                                    "RejectReasonDesc",
                                    "RejectReasonId",
                                     GenerateItemSelect: true                                
                                   );
        }

        public void Initialize()
        {
            FillDrop();
            FillData();
        }

        public void Initialize(String PolicyNumber, String UserName, String InsuredName, String PlanName)
        {
            ClearData();
            txtPolicyNumber.Text = PolicyNumber;
            txtUser.Text = UserName;
            txtInsuredName.Text = InsuredName;
            txtPlanName.Text = PlanName;
            Initialize();
            udpRejectToReadyReview.Update();
        }

        public void ClearData()
        {
            ClearControls();

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}