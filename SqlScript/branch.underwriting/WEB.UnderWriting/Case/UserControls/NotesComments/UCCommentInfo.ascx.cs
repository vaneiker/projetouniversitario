using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.NotesComments
{
    public partial class NoteComments : UC,IUC
    {

        //INote NoteManager
        //{
        //    get { return diManager.NoteManager; }
        //}

        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var comment = new Note
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId =  Service.City_Id,
                OfficeId =  Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                NoteId = int.Parse(hdnNoteId.Value),
                Comment = string.IsNullOrWhiteSpace(txtNewComment.Text) ? string.Empty : txtNewComment.Text.Trim(),
                OriginatedById = Service.Underwriter_Id,
                UserId = Service.Underwriter_Id
            };
            //Valores de prueba hasta que se ponga la seguridad

            Services.NoteManager.InsertComment(comment);

            FillData(int.Parse(hdnNoteId.Value));
        }


        public void FillData(int noteId)
        {
            clearData();

            var comments = Services.NoteManager.GetAllComment(Service.Corp_Id, Service.Region_Id, Service.Country_Id,
                Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, noteId);

            if (comments != null && comments.Any())
            {
                var firstComment = comments.OrderBy(c => c.DateAdded).First();

                txtDateStarted.Text = firstComment.DateAdded.ToString();
                txtStarted.Text = firstComment.OriginatedByName;

                //DateModifiedLast and OriginatedByNameLast are the same in all row results
                txtDateModified.Text = firstComment.DateModifiedLast.HasValue
                                        ? firstComment.DateModifiedLast.Value.ToString()
                                        : string.Empty;

                txtLastModified.Text = firstComment.OriginatedByNameLast;
            }

            foreach (var note in comments)
                txtComments.Text += note.DateAdded + "\n" + note.OriginatedByName + "\n" + note.NoteBody + "\n\n";

            hdnNoteId.Value = noteId.ToString();
        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.save()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.FillData()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }



        public void clearData()
        {
            txtComments.Text = "";
            txtDateStarted.Text = "";
            txtStarted.Text = "";
            txtNewComment.Text = "";
            txtDateModified.Text = "";
            txtLastModified.Text = "";
        }
    }
}