using System.Web.UI;

namespace WEB.ConfirmationCall.Common
{
    public class UC : System.Web.UI.UserControl
    {
        public Services _services = new Services();

        public void ViewStateModeControl(bool Mode)
        {
            this.EnableViewState = Mode;
            if (Mode == true)
                this.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
            else
                this.ViewStateMode = System.Web.UI.ViewStateMode.Disabled;
        }

        /// <summary>
        /// Author       : Lic. Carlos Ml. Lebron
        /// Created Date : 11-25-2014
        /// Limpiar todos los componetes del usercontrol
        /// </summary>
        protected void ClearControls(Control ExcludeControl)
        {
            Utility.ClearAll(this.Controls, ExcludeControl);
        }

        protected void CleanControls(Control ListControls)
        {
            Utility.ClearAll(ListControls.Controls);
        }

        /// <summary>
        /// Author       : Lic. Carlos Ml. Lebron
        /// Created Date : 11-25-2014
        /// Limpiar todos los componetes del usercontrol
        /// </summary>
        protected void ClearControls()
        {
            Utility.ClearAll(this.Controls);
        }

        /// <summary>
        /// Author       : Lic. Carlos Ml. Lebron
        /// Created Date : 12-01-2014
        /// </summary>
        /// <param name="readOnly"></param>
        protected void ReadOnly(ControlCollection controls, bool readOnly)
        {
            Utility.EnableControls(controls, readOnly);
        }
    }
}