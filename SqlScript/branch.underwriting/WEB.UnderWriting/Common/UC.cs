using System;

namespace WEB.UnderWriting.Common
{
    public class UC : System.Web.UI.UserControl
    {
        public string policy { get; set; }

        public void ViewStateModeControl(bool Mode = true)
        {
            EnableViewState = Mode;
            ViewStateMode = Mode ? System.Web.UI.ViewStateMode.Enabled : System.Web.UI.ViewStateMode.Disabled;
        }

        public Services Service
        {
            get
            {
                return Session["ID"] != null ?  new Services(Session["ID"].ToString()) : new  Services();
            }
        }
        /// <summary>
        /// Author       : Lic. Carlos Ml. Lebron
        /// Created Date : 11-25-2014
        /// Limpiar todos los componetes del usercontrol
        /// </summary>
        protected void ClearControls()
        {
            ControlsUtility.ClearAll(this.Controls);
        }
    }
}