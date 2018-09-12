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

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class UCNotesComments : UC, IUC
    {
        public delegate void FillDataHanlder();
        public event FillDataHanlder FillDataReview;

        public void ClearData() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void edit() { }
        protected void Page_Load(object sender, EventArgs e) { }

        private Boolean _AllowAddComment = true;

        public Boolean AllowAddComment
        {
            set
            {
                _AllowAddComment = value;
                pnButtonAdd.Visible = _AllowAddComment;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            CancelNotes.Value = Resources.AddComment;
            btnClose.Value = Resources.Close;
            btnSave.Text = Resources.Save;
            btnCancel.Value = Resources.Cancel;
            txtNewComment.Attributes.Add("placeholder", Resources.AddComment + "...");
        }

        public void save()
        {
            var currentCase = ObjServices.GetCurrentCase();

            if (!string.IsNullOrEmpty(txtNewComment.Text))
            {
                var comment = new Entity.UnderWriting.Entities.Case.Comment()
                {
                    CorpId = currentCase.CorpId,
                    RegionId = currentCase.RegionId,
                    CountryId = currentCase.CountryId,
                    DomesticregId = currentCase.DomesticregId,
                    StateProvId = currentCase.StateProvId,
                    CityId = currentCase.CityId,
                    CaseSeqNo = currentCase.CaseSeqNo,
                    HistSeqNo = currentCase.HistSeqNo,
                    OfficeId = currentCase.OfficeId,
                    UserId = currentCase.UserId,
                    Comments = txtNewComment.Text,
                    CommentTypeId = 1//Comment Type NewBussines
                };

                ObjServices.oCaseManager.InsertComment(comment);
                FillData();

                if (ObjServices.IsDataReviewMode)
                    FillDataReview();

                //this.ExcecuteJScript("$('#hdnShowPopComment').val('false');");
            }
        }

        public void FillData()
        {
            var currentCase = ObjServices.GetCurrentCase();

            var builder = new StringBuilder();

            var comments = ObjServices.oCaseManager.GetAllComments(currentCase);

            foreach (var note in comments)
                builder.Append(note.CommentDate + "\n" + note.UserName + "\n" + note.Comments + "\n" + "______________________________________________________________________________________\n" + "\n\n");

            txtComments.Text = builder.ToString();
        }

        public void Initialize()
        {
            FillData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

    }
}