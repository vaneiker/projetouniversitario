using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{
    public partial class UCCheckBoxWithText : UC
    {
        
        public int OptionId_TXT
        {
            get
            {
                int result = -1;

                if (ViewState["OptionId_TXT"] != null)
                {
                    result = (int)ViewState["OptionId_TXT"];
                }

                return result;
            }
            set
            {
                ViewState["OptionId_TXT"] = value;
            }
        }
        public TextBox Value_TXT
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

        public System.Web.UI.HtmlControls.HtmlGenericControl div
        {
            get
            {
                System.Web.UI.HtmlControls.HtmlGenericControl txt = null;

                var ListControls = this.Controls;

                foreach (Control ctrl in ListControls)
                {
                    if (ctrl is System.Web.UI.HtmlControls.HtmlGenericControl)
                    {
                        txt = ctrl as System.Web.UI.HtmlControls.HtmlGenericControl;
                        break;
                    }
                }

                return txt;
            }

        }

        
        public CheckBox ValueCheckBox
        {
            get
            {
                return cbCheckBoxItem;
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

        public void fillDrop(List<Questionnaire.Option> Options)
        {

            var dt = (from n in Options
                      select n).FirstOrDefault();
            if (Options.Count >0)
            {
                OptionId_TXT = dt.OptionId.Value;
                lblDrownDawnTitles.Text = dt.OptionLabel;
                if (dt.DateAnswer.HasValue)
                    Value_TXT.Text = dt.DateAnswer.ToString();
            }
            else
            {
                OptionId_TXT = -1;
                lblDrownDawnTitles.Text = "";
            }
        }

        public void setCheck(bool res)
        {

            //Panel1.Visible = res;
            cbCheckBoxItem.Checked = res;


        }
        protected void cbCheckBoxItem_CheckedChanged(object sender, EventArgs e)
        {
            //Panel1.Visible = cbCheckBoxItem.Checked;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}