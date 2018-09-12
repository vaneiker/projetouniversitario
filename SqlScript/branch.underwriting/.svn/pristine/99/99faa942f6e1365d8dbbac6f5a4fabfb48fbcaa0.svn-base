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
    public partial class UCDropdown : UC
    {
        public string SetTitles
        {  
            set
            {
                lblDrownDawnTitles.Text = value;
            }
        }

        public DropDownList Value
        {
            get
            {
                return ddlDrownDawnItem;
            }

        }


        protected void Page_Load(object sender, EventArgs e){}

        public void setDiv(bool IsWidht100)
        {
            divDrop.Attributes.Remove("class");

            if (IsWidht100)
                divDrop.Attributes.Add("class", "de_uno fix_height");
            else
                divDrop.Attributes.Add("class", "de_dos fix_height");

        }

        public void fillDrop(List<Questionnaire.Option> Options)
        {
            ListItem select = new ListItem("-------", "-1");
            ddlDrownDawnItem.Items.Add(select);

            foreach (var item in Options)
            {   
                ListItem value = new ListItem(item.OptionLabel, item.OptionId.ToString());
                ddlDrownDawnItem.Items.Add(value);        
            }

            var OptionIdSelect = (from n in Options where n.HasAnswer == true select new { OptionId = n.OptionId }).FirstOrDefault();

            if(OptionIdSelect!= null)
            {
                if (OptionIdSelect.OptionId.HasValue)
                {
                    ddlDrownDawnItem.SelectIndexByValue(OptionIdSelect.OptionId.Value.ToString());
                }
            }

        }        
    }
}