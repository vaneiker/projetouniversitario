using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.NotesComments
{
    public partial class UCNotesComments : UC, IUC
    {
        readonly DropDownManager _dropDowns = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            if (pnGridView.Visible) return;
            var ddlReference = this.Parent.FindControl("ddlReference") as DropDownList;
            if (ddlReference.SelectedIndex < 0)
            {
                this.MessageBox("You must select a Reference, please try again.", Title: "Required Field");
                return;
            }


            var note = new Entity.UnderWriting.Entities.Note
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
                ReferenceTypeId = int.Parse(ddlReference.SelectedValue),
                NoteName = txtTitleNote.Text,
                NoteBody = txtBodyNote.Text,
                UserId = Service.Underwriter_Id,
                OriginatedById = Service.Underwriter_Id
            };
            //Valores de prueba hasta que se ponga la seguridad

            Services.NoteManager.Insert(note);

            FillData(false);

            gridMode();

            txtTitleNote.Text = "";
            txtBodyNote.Text = "";
        }

        public void cancel()
        {
            txtTitleNote.Text = "";
            txtBodyNote.Text = "";
            gridMode();

        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }
        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        public void FillData(bool fromLeft )
        {

            var notes = Services.NoteManager.GetAll(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
                    Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No);

            gvNoteComments.DataSource = notes;
            gvNoteComments.DataBind();

            if (gvNoteComments.BottomPagerRow != null)
            {
                var totalItems = (Literal)gvNoteComments.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = notes.ToList().Count + "";
            }
            setPagerIndex(gvNoteComments);

           
            txtTitleNote.Text = "";
            txtBodyNote.Text = "";

            if (fromLeft)
                btnAddNote_Click(null, null);
            else
                gridMode();
        }

        public void FillDdl()
        {
            var ddlReference = this.Parent.FindControl("ddlReference") as DropDownList;
            _dropDowns.GetDropDown(ref ddlReference, Language.English, DropDownType.NoteReference, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void addMode()
        {
            pnGridView.Visible = false;
            pnAddNote.Visible = true;
            pnAddNoteButton.Visible = false;
        }

        private void gridMode()
        {
            pnAddNote.Visible = false;
            pnGridView.Visible = true;
            pnAddNoteButton.Visible = true;
            var pnText = this.Parent.FindControl("pnText") as Panel;
            var pnReferenceDdl = this.Parent.FindControl("pnReference") as Panel;
            pnText.Visible = true;
            pnReferenceDdl.Visible = false;
        }

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            var pnText = this.Parent.FindControl("pnText") as Panel;
            var pnReferenceDdl = this.Parent.FindControl("pnReference") as Panel;
            var ddlReference = this.Parent.FindControl("ddlReference") as DropDownList;
            pnText.Visible = false;
            pnReferenceDdl.Visible = true;
            ddlReference.SelectedIndex = ddlReference.Items.Count > 0 ? 0 : -1;
            addMode();
        }

        protected void lnkReference_Click(object sender, EventArgs e)
        {
            hfCommentInfo.Value = "true";

            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            var noteId = gvNoteComments.DataKeys[row.RowIndex].Values[0].ToString();
            UCCommentInfo.FillData(int.Parse(noteId));
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


        protected void gvNoteComments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNoteComments.PageIndex = e.NewPageIndex;
            gvNoteComments.DataBind();
            FillData(false);
            setPagerIndex(gvNoteComments);
        }

        protected void gvNoteComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            // when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#689324'");

            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        protected void BTNSaveTabs_Click(object sender, EventArgs e)
        {
            save();
        }




        public void FillData()
        {
            throw new NotImplementedException();
        }
    }
}