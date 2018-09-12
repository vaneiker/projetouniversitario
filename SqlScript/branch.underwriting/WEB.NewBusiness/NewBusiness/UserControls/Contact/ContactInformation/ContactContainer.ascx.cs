using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation
{
    public partial class ContactContainer : UC, IUC
    {
        public delegate void FillDataContactHandler();
        public event FillDataContactHandler FillDataContact;


        public void Translator(string Lang) { }
        public void save() {
            WUCContactInformation.save();
        }
        public void edit() { }
        public void ClearData() { }
        public void ReadOnlyControls(bool isReadOnly) { }

        protected void Page_Load(object sender, EventArgs e)
        {
            WUCContactInformation.FillDataContact += FillData;
        }

        public void FillData()
        {
            FillDataContact();
        }

        public void Initialize()
        {
            WUCContactInformation.Initialize();
        }
    }
}