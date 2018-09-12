using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.EForm
{
    public partial class UCFormsEvailable : UC, IUC
    {
        public delegate void DisplayFormHaddle(int formID);
        public event DisplayFormHaddle DisplayFormEvent;
        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            Entity.UnderWriting.Entities.DropDown.Parameter paraDrop = new Entity.UnderWriting.Entities.DropDown.Parameter();
            paraDrop.DropDownType = "FormCategory";
            paraDrop.CorpId = ObjServices.Corp_Id;
           
             var datos =  ObjServices.oDropDownManager.GetDropDownByType(paraDrop).ToList();

                datos.Insert(0,new Entity.UnderWriting.Entities.DropDown() { FormCategoryId = -1, FormCatDesc ="All"});

                rtCategory.DataSource = datos;
            rtCategory.DataBind();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

     

        protected void rtCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
                Entity.UnderWriting.Entities.DropDown.Parameter paraDrop = new Entity.UnderWriting.Entities.DropDown.Parameter();
                paraDrop.DropDownType = "Form";
                paraDrop.CorpId = ObjServices.Corp_Id;
                if (int.Parse(((HiddenField)e.Item.FindControl("hfCategoryID")).Value)!= -1)
                    paraDrop.FormCategoryId = int.Parse(((HiddenField)e.Item.FindControl("hfCategoryID")).Value);
                ((Repeater)e.Item.FindControl("rtCategoryForms")).DataSource = ObjServices.oDropDownManager.GetDropDownByType(paraDrop);
                ((Repeater)e.Item.FindControl("rtCategoryForms")).DataBind();
            
        }

        protected void lnkCategory_Click(object sender, EventArgs e)
        {
            DisplayFormEvent(int.Parse(((LinkButton)sender).CommandName));
        }


        public void ReadOnlyControls(bool isReadOnly)
        {
           
        }
    }
}