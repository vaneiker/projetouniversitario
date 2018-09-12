using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{
    public partial class UCUCDropdownCheckBox : UC
    {
        public string SetTitles
        {
            set
            {
                lblDrownDawnTitles.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e){}

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
    }
}