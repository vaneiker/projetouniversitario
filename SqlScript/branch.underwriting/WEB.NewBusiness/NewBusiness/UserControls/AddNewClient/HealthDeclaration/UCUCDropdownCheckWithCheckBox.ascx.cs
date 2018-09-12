using DevExpress.Web;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{
    public partial class UCUCDropdownCheckWithCheckBox : UC
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator();
            
        }

        public void Translator()
        {
            lblRelationship.Text = Resources.RelationshipLabel ;
        }

        public CheckBox ValueCheckBox
        {
            get
            {
                return cbCheckBoxItem;
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
        public Saplin.Controls.DropDownCheckBoxes ValueDropDawn
        {
            get
            {
                Saplin.Controls.DropDownCheckBoxes txt = null;

                var ListControls = this.Controls;

                foreach (Control ctrl in ListControls)
                {
                    if (ctrl is Saplin.Controls.DropDownCheckBoxes)
                    {
                        txt = ctrl as Saplin.Controls.DropDownCheckBoxes;
                        break;
                    }
                }

                return txt;
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

            ValueDropDawn.Items.Clear();
            foreach (var item in Options.OrderByDescending(a => a.HasAnswer))
            {
               
                ListItem value = new ListItem(item.OptionLabel, item.OptionId.ToString());
                value.Selected = item.HasAnswer;
                ValueDropDawn.Items.Add(value);
            }


        

        }

        public void setCheck(bool res)
        {

            //Panel1.Visible = res;
            cbCheckBoxItem.Checked = res;


        }
        protected void cbCheckBoxItem_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}