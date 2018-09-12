using System;
using System.Collections.Generic;

namespace WEB.UnderWriting.Dashboard.UserControls.Common
{
    public partial class Right : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();  
        }

        void FillData()
        {
            var List = new List<String>();
            for (int x = 0; x <= 100; x++)
            {
                List.Add("Example Data");
            }

            //gvResult.DataSource = List;
            //gvResult.DataBind();
        }

       

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.save()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.FillData()
        {
            throw new NotImplementedException();
        }



        public void clearData()
        {
            throw new NotImplementedException();
        }


        void UnderWriting.Common.IUC.clearData()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.ViewStateModeControl(bool Mode)
        {
            throw new NotImplementedException();
        }
    }
}