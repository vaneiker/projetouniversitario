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
    public partial class UCCheckBoxList : UC
    {


        public CheckBoxList Value 
        { 
               get
            {
                return cbCheckBoxItem;
            }
            
        }
        public void fillDrop(List<Questionnaire.Option> Options)
        {
            foreach (var item in Options)
            {

                ListItem value = new ListItem(item.OptionLabel, item.OptionId.ToString());
                value.Selected = item.HasAnswer;

                

                //value.Attributes.Render(HtmlTextWriterTag.Div);
                cbCheckBoxItem.Items.Add(value);

                

                //t.RenderBeginTag(HtmlTextWriterTag.Div);
                //cbCheckBoxItem.RenderBeginTag(t);
                //cbCheckBoxItem.RenderEndTag(HtmlTextWriterTag.Div);
            }



        }

         protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void cbCheckBoxItem_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       protected void cbCheckBoxItem_PreRender(object sender, EventArgs e)
       {
           
       }
    }
}