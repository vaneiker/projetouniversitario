using System;
using System.Collections.Generic;

namespace WEB.UnderWriting.Dashboard.UserControls.AlertRerport
{
    

    public partial class WUCGroupedView : WEB.UnderWriting.Common.UC,WEB.UnderWriting.Common.IUC
    {
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

        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            var ListGrouped = new List<String>();
            for (int x = 0; x <= 500; x++)
            {
                ListGrouped.Add("Example Data");
            }

            gvGroupedView.DataSource = ListGrouped;
            gvGroupedView.DataBind();
        }



        public void clearData()
        {
            throw new NotImplementedException();
        }
    }
}