using System;
using System.Collections.Generic;

namespace WEB.UnderWriting.Case.UserControls.Exceptions
{
    public partial class UCExceptions : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {

        public class Item
        {

            public string exceptionType { get; set; }
            public string exception { get; set; }
            public string Requestor { get; set; }
            public string Approved { get; set; }
            public string DateRequested { get; set; }
            public string DateApproved { get; set; }
            public string TimePeriod { get; set; }
            public string Status { get; set; }
            public string Files { get; set; }

        }

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
            List<Item> items = new List<Item>();
            items.Add(new Item
            {
                exceptionType = "Spouse / Other Insured Rider: Owner/Insured Relationship",
                exception = "Agent &lt; 1 year / Owner-Insured:Family Member / Non-Annual Payment",
                Requestor = "Maria T Perez",
                Approved = "Maria T Perez",
                DateRequested = "06/20/2014",
                DateApproved = "06/20/2014",
                TimePeriod = "1",
                Status = "Pending"
            });

            items.Add(new Item
            {
                exceptionType = "Spouse / Other Insured Rider: Owner/Insured Relationship",
                exception = "Agent &lt; 1 year / Owner-Insured:Family Member / Non-Annual Payment",
                Requestor = "Maria T Perez",
                Approved = "Maria T Perez",
                DateRequested = "06/20/2014",
                DateApproved = "06/20/2014",
                TimePeriod = "1",
                Status = "Pending"
            });

            items.Add(new Item
            {
                exceptionType = "Spouse / Other Insured Rider: Owner/Insured Relationship",
                exception = "Agent &lt; 1 year / Owner-Insured:Family Member / Non-Annual Payment",
                Requestor = "Maria T Perez",
                Approved = "Maria T Perez",
                DateRequested = "06/20/2014",
                DateApproved = "06/20/2014",
                TimePeriod = "1",
                Status = "Pending"
            });

            gvException.DataSource = items;
            gvException.DataBind();

        }




        public void clearData()
        {
            throw new NotImplementedException();
        }
    }
}