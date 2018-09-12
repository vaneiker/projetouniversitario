using System;

namespace WEB.UnderWriting.Dashboard.UserControls.AlertRerport
{
    public partial class WUCGraph : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.ViewStateModeControl(bool Mode)
        {
            this.EnableViewState = Mode;

            this.ViewStateMode = Mode ? System.Web.UI.ViewStateMode.Enabled : System.Web.UI.ViewStateMode.Disabled; ;
        }


        public void clearData()
        {
            throw new NotImplementedException();
        }
    }
}