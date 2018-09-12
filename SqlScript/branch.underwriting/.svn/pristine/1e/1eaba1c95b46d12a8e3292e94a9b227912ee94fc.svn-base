using System;
using WEB.ConfirmationCall.Common;

namespace WEB.ConfirmationCall.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public Services _services = new Services();

        #region Properties
        WEB.ConfirmationCall.Common.ContactType ContactTypeId
        {
            get
            {
                var ContactTypeId = Session["ConfirmationCall.ContactTypeId"];
                return ContactTypeId == null ? WEB.ConfirmationCall.Common.ContactType.None : (WEB.ConfirmationCall.Common.ContactType)(byte)ContactTypeId;
            }
            set
            {
                Session["ConfirmationCall.ContactTypeId"] = (byte)value;
            }
        }

        int ContactId
        {
            get
            {
                var contactId = Session["Dashboard.ContactId"];
                return contactId == null ? 0 : Session["Dashboard.ContactId"].ToInt();
            }
            set
            {
                Session["Dashboard.ContactId"] = value;
            }
        }
        #endregion

        #region Methods
        public void FillData()
        {

        }
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        #endregion
    }
}