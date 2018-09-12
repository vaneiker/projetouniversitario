using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.UnderwritingSteps
{
    public partial class UCUnderwritingStep : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //UnderWritingDIManager diManager = new UnderWritingDIManager();

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

        public void clearData()
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

        }

        public void FillData(Boolean fromChanges)
        {

            hdnFromChange.Value = fromChanges.ToString();

            gvUnderSteps.Columns[1].Visible = !fromChanges;
            var stepTypeId = fromChanges ? 2 : 1;

            var data = Services.StepManager.GetAll(Service.Corp_Id, 
												   Service.Region_Id, 
												   Service.Country_Id, 
												   Service.Domesticreg_Id,
												   Service.State_Prov_Id, 
												   Service.City_Id, 
												   Service.Office_Id, 
												   Service.Case_Seq_No, 
												   Service.Hist_Seq_No, 
												   stepTypeId);  

            //int totalCurrent = data.Sum(r => r.Current.HasValue ? r.Current.Value : 0);
            //int totalStandard = data.Sum(r => r.Standard.HasValue ? r.Standard.Value : 0);
            var totalCurrent = data.Any() ? data.Max(r => r.Current ?? 0) : 0;
            var totalStandard = data.Any() ? data.Max(r => r.Standard ?? 0) : 0;
            txtUSTotalCurrent.Text = totalCurrent.ToString();
            txtUSTotalStandard.Text = totalStandard.ToString();
            //txtUSTotalCurrent.Text = data.Any() ? totalCurrent.ToString() : "0";
            //txtUSTotalStandard.Text = data.Any() ? totalStandard.ToString() : "0";

            txtUSTotalCurrent.CssClass = totalCurrent > totalStandard ? "text_rojo" : "";

            // text_rojo

            gvUnderSteps.DataSource = data;
            gvUnderSteps.DataBind();
        }

        protected void gvUnderSteps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                e.Row.CssClass = "tabla_box";
            }
        }

        protected void lnkReadMore_Click(object sender, EventArgs e)
        {
            var fromChange = Boolean.Parse(String.IsNullOrEmpty(hdnFromChange.Value) ? "false" : hdnFromChange.Value);
            var lnk = (LinkButton)sender;
            var dataRow = (GridViewRow)lnk.NamingContainer;

            var stepId = gvUnderSteps.DataKeys[dataRow.RowIndex]["StepId"].ToString();
            var stepCaseNo = gvUnderSteps.DataKeys[dataRow.RowIndex]["StepCaseNo"].ToString();
            var voideable = gvUnderSteps.DataKeys[dataRow.RowIndex]["Voidable"].ToString();
            var closable = gvUnderSteps.DataKeys[dataRow.RowIndex]["Closable"].ToString();
            var processStatus = gvUnderSteps.DataKeys[dataRow.RowIndex]["ProcessStatus"].ToString();

            if (!String.IsNullOrEmpty(stepId) && !String.IsNullOrEmpty(stepCaseNo) && !String.IsNullOrEmpty(voideable) && !String.IsNullOrEmpty(closable) && !String.IsNullOrEmpty(processStatus))
            {
                var step = new Entity.UnderWriting.Entities.Step
                {
                    StepId = int.Parse(stepId),
                    StepTypeId = fromChange ? 2 : 1,
                    StepCaseNo = int.Parse(stepCaseNo),
                    CorpId = Service.Corp_Id,
                    RegionId = Service.Region_Id,
                    CountryId = Service.Country_Id,
                    DomesticregId = Service.Domesticreg_Id,
                    StateProvId = Service.State_Prov_Id,
                    CityId = Service.City_Id,
                    OfficeId = Service.Office_Id,
                    CaseSeqNo = Service.Case_Seq_No,
                    HistSeqNo = Service.Hist_Seq_No,
                    Voidable = Boolean.Parse(voideable),
                    Closable = Boolean.Parse(closable),
                    ProcessStatus = int.Parse(processStatus)
                };

                hdnUSShowPopComments.Value = "true";
                UCPopStepComments.FillData(step);
            }
        }

        protected void btnPlayCall_Click(object sender, EventArgs e)
        {
            var playBtn = (Button)sender;
            var row = (GridViewRow)playBtn.NamingContainer;

            var playerLiteral = row.FindControl("liAction");
            if (playerLiteral == null)
                return;

            var fileName = gvUnderSteps.DataKeys[row.RowIndex]["RecordingFile"].ToString();
            var fileArray = fileName.Split('\\');

            var recDir = Service.RecordingsDir + fileArray[0] + "\\";
            fileName = fileArray[1];

            if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(fileName))
            {
                JMAudioTools.ConvertToMp3(recDir, Service.Mp3TempDir, fileName, true, Server.MapPath(Service.SoxFilePath));

                var sb = new StringBuilder();

                sb.Append(@"<audio id='audioCall' controls='controls' src='../../../TempFiles/Mp3/" + fileName.Replace(" ", "").Replace(".wav", ".mp3") + "' class='audioTag' type='audio/mp3'>  Your browser does not support the audio tag. </audio>");

                if (playerLiteral != null)
                    ((Literal)playerLiteral).Text = sb.ToString();
            }
            playBtn.Visible = false;
        }
    }
}