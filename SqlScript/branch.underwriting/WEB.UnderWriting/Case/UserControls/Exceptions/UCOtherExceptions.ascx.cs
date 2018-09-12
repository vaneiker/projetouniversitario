using System;
using System.Collections.Generic;

namespace WEB.UnderWriting.Case.UserControls.Exceptions
{
    public partial class UCOtherExceptions : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {

        public class Item {

            public string policy { get; set; }
            public string name { get; set; }
            public string role { get; set; }
            public string exceptionType { get; set; }
            public string exception { get; set; }
            public string date { get; set; }
            public string time { get; set; }
            public string status { get; set; }
        
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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

        public void FillData() { 
        
            List<Item> items=new List<Item>();
            items.Add(new Item { policy = "S451245", name = "Maria T Perez", role = "Owner/Additional Insured",
                                 exceptionType = "Spouse / Other Insured Rider: Owner/Insured Relationship",
                                 exception = "Agent 1 year / Owner-Insured:Family Member / Non-Annual Payment",
                                 date = "06/20/2012",
                                 time = "1",
                                 status = "Pending"
            });

            items.Add(new Item
            {
                policy = "S451245",
                name = "Maria T Perez",
                role = "Owner/Additional Insured",
                exceptionType = "Spouse / Other Insured Rider: Owner/Insured Relationship",
                exception = "Agent 1 year / Owner-Insured:Family Member / Non-Annual Payment",
                date = "06/20/2012",
                time = "1",
                status = "Pending"
            });

            items.Add(new Item
            {
                policy = "S451245",
                name = "Maria T Perez",
                role = "Owner/Additional Insured",
                exceptionType = "Spouse / Other Insured Rider: Owner/Insured Relationship",
                exception = "Agent 1 year / Owner-Insured:Family Member / Non-Annual Payment",
                date = "06/20/2012",
                time = "1",
                status = "Pending"
            });

            gvOtherException.DataSource = items;
            gvOtherException.DataBind();
        }


        public void clearData()
        {
            throw new NotImplementedException();
        }
    }
}