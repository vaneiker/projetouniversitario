using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Common
{
    public partial class UCPopTeamCommunication : WEB.UnderWriting.Common.UC
    {
        //INote NoteManager
        //{
        //    get { return diManager.NoteManager; }
        //}


       // UnderWritingDIManager diManager = new UnderWritingDIManager();
        DropDownManager DropDowns = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void FillData()
        {

            Entity.UnderWriting.Entities.Note communicationTeamHeader = new Entity.UnderWriting.Entities.Note();
            communicationTeamHeader.CorpId = Service.Corp_Id;
            communicationTeamHeader.RegionId = Service.Region_Id;
            communicationTeamHeader.CountryId = Service.Country_Id;
            communicationTeamHeader.DomesticregId = Service.Domesticreg_Id;
            communicationTeamHeader.StateProvId = Service.State_Prov_Id;
            communicationTeamHeader.CityId = Service.City_Id;
            communicationTeamHeader.OfficeId = Service.Office_Id;
            communicationTeamHeader.CaseSeqNo = Service.Case_Seq_No;
            communicationTeamHeader.HistSeqNo = Service.Hist_Seq_No;
            communicationTeamHeader.OriginatedById = Service.Underwriter_Id;

            var data = Services.NoteManager.GetTeamCommunicationHeader(communicationTeamHeader);

            gvTeamComunication.DataSource = data;
            gvTeamComunication.DataBind();

            if (gvTeamComunication.BottomPagerRow != null)
            {
                var totalItems = (Literal)gvTeamComunication.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = data.ToList().Count + "";
            }
            setPagerIndex(gvTeamComunication);


        }



        public void FillDrop()
        {
            var ddlParticipantSource = DropDowns.GetDropDown(DropDownType.Participant, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId, userId: Service.Underwriter_Id);

            ddlParticipantAddNew.DataSource = ddlParticipantSource;
            ddlParticipantAddNew.DataBind();

        }

        public void ClearData()
        {

            txtTMMessage.Text = String.Empty;
            txtTMSubject.Text = String.Empty;
            ddlParticipantAddNew.SelectedIndex = -1;
            chkConfidential.Checked = false;

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.CorpId = Service.Corp_Id;
            note.RegionId = Service.Region_Id;
            note.CountryId = Service.Country_Id;
            note.DomesticregId = Service.Domesticreg_Id;
            note.StateProvId = Service.State_Prov_Id;
            note.CityId = Service.City_Id;
            note.OfficeId = Service.Office_Id;
            note.CaseSeqNo = Service.Case_Seq_No;
            note.HistSeqNo = Service.Hist_Seq_No;
            note.NoteName = txtTMSubject.Text;
            note.NoteBody = txtTMMessage.Text;
            note.Confidential = chkConfidential.Checked;
            note.ReferenceTypeId = 14;

            note.UserId = Service.Underwriter_Id;
            note.OriginatedById = Service.Underwriter_Id;

            var idNote = Services.NoteManager.Insert(note);

            var participants = (from ListItem li in ddlParticipantAddNew.Items
                where li.Selected == true
                select new Note
                {
                    CorpId = idNote.CorpId, RegionId = idNote.RegionId, CountryId = idNote.CountryId, DomesticregId = idNote.DomesticregId, StateProvId = idNote.StateProvId, CityId = idNote.CityId, OfficeId = idNote.OfficeId, CaseSeqNo = idNote.CaseSeqNo, HistSeqNo = idNote.HistSeqNo, NoteId = idNote.NoteId, UserId = Service.Underwriter_Id, OriginatedById = int.Parse(li.Value)
                }).ToList();

            participants.Add(new Note()
            {
                CorpId = idNote.CorpId,
                RegionId = idNote.RegionId,
                CountryId = idNote.CountryId,
                DomesticregId = idNote.DomesticregId,
                StateProvId = idNote.StateProvId,
                CityId = idNote.CityId,
                OfficeId = idNote.OfficeId,
                CaseSeqNo = idNote.CaseSeqNo,
                HistSeqNo = idNote.HistSeqNo,
                NoteId = idNote.NoteId,
                UserId = Service.Underwriter_Id,
                OriginatedById = Service.Underwriter_Id

            });


            Services.NoteManager.InsertParticipant(participants);

            FillData();
            ClearData();
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

        protected void gvTeamComunication_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTeamComunication.PageIndex = e.NewPageIndex;
            gvTeamComunication.DataBind();
            FillData();
        }

        protected void gvTeamComunication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.CssClass = "tabla_box";
            }
        }

        protected void lnkNoteNameTeamCommunication_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((WebControl)sender).NamingContainer;
            var NoteId = int.Parse(gvTeamComunication.DataKeys[gridRow.RowIndex]["NoteId"].ToString());

            var communicationTeamThread = new Note
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
                NoteId = NoteId
            };

            var participants = Services.NoteManager.GetTeamCommunicationParticipant(communicationTeamThread);
            var ddlParticipantSource = DropDowns.GetDropDown(DropDownType.Participant, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId, userId:Service.Underwriter_Id).Where(c => participants.All(x => x.OriginatedById != int.Parse(c.Value)));
            var data = Services.NoteManager.GetTeamCommunicationThread(communicationTeamThread);

            TextBox txtMessageThread = (gridRow.FindControl("txtMessageThread") as TextBox);
            Literal lblMessageThread = (gridRow.FindControl("lblMessageThread") as Literal);
            Literal ltrParticipants = (gridRow.FindControl("ltrParticipants") as Literal);
            ListBox ddlParticipantComment = (gridRow.FindControl("ddlParticipantComment") as ListBox);
           
            ddlParticipantComment.DataSource = ddlParticipantSource;
            ddlParticipantComment.DataBind();

            txtMessageThread.Text = String.Empty;
            lblMessageThread.Text = String.Empty;

            foreach (Note thread in data)
            {
                lblMessageThread.Text += "<p>" + thread.DateAdded + "<br>" +
                                        "<strong>" + thread.OriginatedByName + " </strong> " + "<br>" +
                                        thread.NoteBody + "</p>" + "<br>" + "<br>";
            }



            
            ltrParticipants.Text = "";

            foreach (Note participant in participants)
            {
                ltrParticipants.Text += participant.OriginatedByName + "<br>";
            }



        }


       

        protected void btnAddCommentThread_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var NoteId = int.Parse(gvTeamComunication.DataKeys[gridRow.RowIndex]["NoteId"].ToString());
            ListBox ddlParticipantComment = (gridRow.FindControl("ddlParticipantComment") as ListBox);
            TextBox txtMessageThread = (gridRow.FindControl("txtMessageThread") as TextBox);
            
            Entity.UnderWriting.Entities.Note commentThread = new Entity.UnderWriting.Entities.Note();
            commentThread.CorpId = Service.Corp_Id;
            commentThread.RegionId = Service.Region_Id;
            commentThread.CountryId = Service.Country_Id;
            commentThread.DomesticregId = Service.Domesticreg_Id;
            commentThread.StateProvId = Service.State_Prov_Id;
            commentThread.CityId = Service.City_Id;
            commentThread.OfficeId = Service.Office_Id;
            commentThread.CaseSeqNo = Service.Case_Seq_No;
            commentThread.HistSeqNo = Service.Hist_Seq_No;
            commentThread.NoteId = NoteId;
            commentThread.Comment = txtMessageThread.Text;
            commentThread.OriginatedById = Service.Underwriter_Id;
            commentThread.UserId = Service.Underwriter_Id;

            Services.NoteManager.InsertComment(commentThread);

            List<Entity.UnderWriting.Entities.Note> participants = new List<Entity.UnderWriting.Entities.Note>();

            foreach (ListItem li in ddlParticipantComment.Items)
            {
                if (li.Selected == true)
                {
                    participants.Add(
                        new Entity.UnderWriting.Entities.Note
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
                            NoteId = NoteId,
                            UserId = Service.Underwriter_Id,
                            OriginatedById = int.Parse(li.Value)

                        });

                }
            }


            Services.NoteManager.InsertParticipant(participants);
            txtMessageThread.Text = String.Empty;
            lnkNoteNameTeamCommunication_Click(sender, null);

        }




    }
}