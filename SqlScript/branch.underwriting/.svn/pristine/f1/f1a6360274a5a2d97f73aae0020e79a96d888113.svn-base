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
    public partial class UCRadioButtonList : UC
    {
        public RadioButtonList Value
        {
            get
            {
                return rblRadioButtonList;
            }

        }
        public void fillDrop(List<Questionnaire.Option> Options, string optionLabel)
        {
            foreach (var item in Options.Where(a => a.SubOption == true))
            {

                ListItem value = new ListItem(item.OptionLabel, item.OptionId.ToString());
                value.Selected = item.HasAnswer;
                rblRadioButtonList.Items.Add(value);
            }




        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}