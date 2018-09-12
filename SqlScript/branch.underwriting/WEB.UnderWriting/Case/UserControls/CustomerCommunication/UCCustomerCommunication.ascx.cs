using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.CustomerCommunication
{
    public partial class UCCustomerCommunication : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        


        public class Item
        {
            public string CommunicationName { set; get; }
            public string DateSent { set; get; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {}

        public void FillData()
        {
            var Data = Services.PolicyManager.GetPolicyCommunication(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id,
                Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, null);

            gvClientComunication.DataSource = Data;
            gvClientComunication.DataBind();
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        protected void lnkDocumentIcon_Click(object sender, EventArgs e)
        {
            var lnk = (LinkButton)sender;
            var lnkClass = lnk.CssClass.ToLower();
            var dataRow = (GridViewRow)lnk.NamingContainer;

            hdnCCShowNotePop.Value = (lnkClass == "sobre_ico").ToString().ToLower();
            hdnCCShowCallPop.Value = (lnkClass == "audio_ico").ToString().ToLower();

            var callNoteId = gvClientComunication.DataKeys[dataRow.RowIndex]["CallNoteId"] == null ? -1 : int.Parse(gvClientComunication.DataKeys[dataRow.RowIndex]["CallNoteId"].ToString());

            if (callNoteId > -1)
            {
                var Data = Services.PolicyManager.GetPolicyCommunication(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
                    Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, callNoteId);

                if (!Data.Any()) return;
                if (hdnCCShowNotePop.Value == "true")
                {
                    var note = String.IsNullOrEmpty(Data.First().LargeText) ? "" : Data.First().LargeText;
                    var subject = String.IsNullOrEmpty(Data.First().Subject) ? "" : Data.First().Subject;
                    UCCommNotes.FillData(subject, note);
                }
                else
                {
                    var recFile = String.IsNullOrEmpty(Data.First().RecordingFile) ? "" : Data.First().RecordingFile;
                    var dateAdded = Data.First().StartDate.HasValue ? Data.First().StartDate.Value.ToString("MM/dd/yyyy") : "";
                    var contactedBy = String.IsNullOrEmpty(Data.First().ProcessedBy) ? "" : Data.First().ProcessedBy;

                    UCCommCalls.FillData(recFile, contactedBy, dateAdded);
                }
            }
            else
            {
                hdnCCShowNotePop.Value = "false";
                hdnCCShowCallPop.Value = "false";
            }
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
    }
}