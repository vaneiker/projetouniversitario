using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{
    public partial class UCTextboxDates : UC
    {
        public string SetTitles
        {

            set
            {
                lblDrownDawnTitles.Text = value;
            }

        }

        public int OptionId
        {
            get
            {
                int result = -1;

                if (ViewState["OptionId"] != null)
                {
                    result = (int)ViewState["OptionId"];
                }

                return result;
            }
            set
            {
                ViewState["OptionId"] = value;
            }
        }

        public TextBox Value
        {
            get
            {
                TextBox txt = null;

                var ListControls = this.Controls;

                foreach (Control ctrl in ListControls)
                {
                    if (ctrl is TextBox)
                    {
                        txt = ctrl as TextBox;
                        break;
                    }
                }

                return txt;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}