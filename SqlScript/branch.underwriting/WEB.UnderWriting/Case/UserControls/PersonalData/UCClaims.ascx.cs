using System;

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class UCClaims : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        { }

        public void FillData(Entity.UnderWriting.Entities.Contact contactInfo)
        {
            this.DateOfDeathTxt.Text = contactInfo.DeceaseDate.HasValue ? contactInfo.DeceaseDate.Value.ToString("dd/MM/yyyy") : "";
            this.DateNotifiedTxt.Text = contactInfo.NotifiedDate.HasValue ? contactInfo.NotifiedDate.Value.ToString("dd/MM/yyyy") : "";

            this.CauseOfDeathTxt.Text = contactInfo.DeceaseCause;
            this.DateCompleteTxt.Text = contactInfo.CompletedDate.HasValue ? contactInfo.CompletedDate.Value.ToString("dd/MM/yyyy") : "";
            this.RemarksTxt.Text = contactInfo.Remarks;
        }

        void UnderWriting.Common.IUC.ViewStateModeControl(bool Mode)
        {
            throw new NotImplementedException();
        }


        public void clearData()
        {
            throw new NotImplementedException();
        }
    }
}