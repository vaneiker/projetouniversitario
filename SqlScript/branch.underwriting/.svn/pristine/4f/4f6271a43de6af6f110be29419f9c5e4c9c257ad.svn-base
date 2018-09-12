using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.UnderWriting.IllusData;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.Entities;
using iTextSharp.text.pdf;
using RESOURCE.UnderWriting.NewBussiness;



namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCHealthView : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
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
        }

        public void btndependientes_Click(object sender, EventArgs e){
            ucHdependientes.Visible = true;
            ucHdependientes.FillData();
            ucHsuplementos.Visible = false;
            ucHdependientes.ExcecuteJScript("setTimeout(\"changeTabSelected1()\", 10);");
        }

        public void btnsuplementos_Click(object sender, EventArgs e){
            ucHsuplementos.Visible = true;
            ucHdependientes.Visible = false;
            ucHsuplementos.FillData();
            ucHsuplementos.ExcecuteJScript("setTimeout(\"changeTabSelected2()\", 10);");
        }

        private void BindGrid()
        {

        }
        
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}