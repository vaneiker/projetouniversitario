using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.ChangeSteps
{
    public partial class UCChangeSteps : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
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
            var data = Services.StepManager.GetAll(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
           Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, 1);

            txtUSCTotalCurrent.Text = data.Min(r => r.Current.Value).ToString();
            txtUSCTotalStandard.Text = data.Max(r => r.Standard.Value).ToString();

            gvStepChanges.DataSource = data;
            gvStepChanges.DataBind();
        }

        protected void gvStepChanges_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                e.Row.CssClass = "tabla_box";

                var hasFile = Boolean.Parse(gvStepChanges.DataKeys[row.RowIndex]["HasCall"].ToString());

                if (hasFile)
                {
                    var playerLiteral = row.FindControl("liAction");
                    if (playerLiteral == null)
                        return;

                    var recordingFile = gvStepChanges.DataKeys[row.RowIndex]["RecordingFile"].ToString();
                    var fileArray = recordingFile.Split('\\');

                    var recDir = Service.RecordingsDir + fileArray[0] + "\\";
                    recordingFile = fileArray[1];

                    if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(recordingFile))
                    {
                        JMAudioTools.ConvertToMp3(recDir, Service.Mp3TempDir, recordingFile, true, Service.SoxFilePath);

                        var sb = new StringBuilder();

                        sb.Append(@"<audio id='audioCall' controls='controls' src='../../../TempFiles/Mp3/" + recordingFile.Replace(" ", "").Replace(".wav", ".mp3") + "' class='audioTag' type='audio/mp3'>");

                        if (playerLiteral != null)
                            ((Literal)playerLiteral).Text = sb.ToString();
                    }
                }
            }
        }

        protected void lnkReadMore_Click(object sender, EventArgs e)
        {
            var lnk = (LinkButton)sender;
            var dataRow = (GridViewRow)lnk.NamingContainer;

            var stepId = gvStepChanges.DataKeys[dataRow.RowIndex]["StepId"].ToString();
            var stepCaseNo = gvStepChanges.DataKeys[dataRow.RowIndex]["StepCaseNo"].ToString();
            var voideable = gvStepChanges.DataKeys[dataRow.RowIndex]["Voidable"].ToString();
            var closable = gvStepChanges.DataKeys[dataRow.RowIndex]["Closable"].ToString();
            var processStatus = gvStepChanges.DataKeys[dataRow.RowIndex]["ProcessStatus"].ToString();

            if (!String.IsNullOrEmpty(stepId) && !String.IsNullOrEmpty(stepCaseNo) && !String.IsNullOrEmpty(voideable) && !String.IsNullOrEmpty(closable) && !String.IsNullOrEmpty(processStatus))
            {
                var step = new Entity.UnderWriting.Entities.Step
                {
                    StepId = int.Parse(stepId),
                    StepTypeId = 1,
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

                hdnUSCShowPopComments.Value = "true";
                UCPopStepComments1.FillData(step);
            }
        }
    }
}