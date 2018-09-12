namespace Web.SubmittedPolicies.Common.Classes
{
    public class Uc : System.Web.UI.UserControl
    {
        public Common.PolicyKeyItem PolicyKey
        {
            get
            {
                return (Common.PolicyKeyItem)ViewState["PolicyKey"];
            }
            set { ViewState["PolicyKey"] = value; }
        }
        public void ViewStateModeControl(bool mode = true)
        {
            EnableViewState = mode;
            ViewStateMode = mode ? System.Web.UI.ViewStateMode.Enabled : System.Web.UI.ViewStateMode.Disabled;
        }
    }
}