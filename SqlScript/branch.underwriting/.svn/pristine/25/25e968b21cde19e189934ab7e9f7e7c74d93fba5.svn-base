using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.UnderwritingCall
{
    public partial class UCAttachCall : UC, IUC
    {
        // UnderWritingDIManager diManager = new UnderWritingDIManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetCalls(String userId)
        {
            userId = String.IsNullOrEmpty(userId) ? "{3407A220-CA8B-4620-B3C5-F68031ADB07B}" : userId;

            var callData = Services.CallRexManager.GetResumedCallDataCRUserId(userId, DateTime.Now, ResumedCallData.CallTimePeriod.TwoHoursFromDate, 10).OrderByDescending(r => r.StartTime);

            gvAttachCalls.DataSource = callData;
            gvAttachCalls.DataBind();
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
            GetCalls("");
        }

        protected void gvAttachCalls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    var row = e.Row;

                    var playerLiteral = row.FindControl("liAction");
                    if (playerLiteral == null)
                        return;

                    var fileName = gvAttachCalls.DataKeys[row.RowIndex]["RecordingFile"].ToString();
                    var fileArray = fileName.Split('\\');

                    var recDir = Service.RecordingsDir + fileArray[0] + "\\";
                    fileName = fileArray[1];

                    if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(fileName))
                    {
                        JMAudioTools.ConvertToMp3(recDir, Service.Mp3TempDir, fileName, true, Server.MapPath(Service.SoxFilePath));

                        var sb = new StringBuilder();

                        sb.Append(@"<audio id='audioCall' controls='controls' src='../../../TempFiles/Mp3/" + fileName.Replace(" ", "").Replace(".wav", ".mp3") + "' class='audioTag' type='audio/mp3'> Your browser does not support the audio tag. </audio>");

                        ((Literal)playerLiteral).Text = sb.ToString();
                    }
                    break;
                case DataControlRowType.Header:
                    e.Row.CssClass = "gradient_gris";
                    break;
            }
        }

        protected void btnACAttach_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(hdnUCAttachSelectedRadio.Value)) return;
            //Busco los datos de la llamada
            var selectedIndex = int.Parse(hdnUCAttachSelectedRadio.Value);

            var startDate = gvAttachCalls.DataKeys[selectedIndex]["StartTime"].ToString();
            var endDate = gvAttachCalls.DataKeys[selectedIndex]["EndTime"].ToString();
            var duration = gvAttachCalls.DataKeys[selectedIndex]["Duration"].ToString();
            var callerIdName = gvAttachCalls.DataKeys[selectedIndex]["CallerIDName"].ToString();
            var callerIdNumber = gvAttachCalls.DataKeys[selectedIndex]["CallerIdNumber"].ToString();
            var outBoundNumber = gvAttachCalls.DataKeys[selectedIndex]["OutgoingNumber"].ToString();
            var recordingFile = gvAttachCalls.DataKeys[selectedIndex]["RecordingFile"].ToString();
            var callregNotehistoryid = gvAttachCalls.DataKeys[selectedIndex]["CallLogId"].ToString();

            var step_Type_Id = this.Parent.FindControl("hdnUCStepTypeId");
            var step_Id = this.Parent.FindControl("hdnUCStepId");
            var step_Case_No = this.Parent.FindControl("hdnUCStepCaseNo");

            if (step_Type_Id == null || step_Id == null || step_Case_No == null) return;
            var stepTypeId = ((HiddenField)step_Type_Id).Value;
            var stepId = ((HiddenField)step_Id).Value;
            var stepCaseNo = ((HiddenField)step_Case_No).Value;
            //Cierro el Step "Underwriting Call"
            if (String.IsNullOrEmpty(stepTypeId) || String.IsNullOrEmpty(stepId) || String.IsNullOrEmpty(stepCaseNo))
                return;
            var currentStep = GetCurrentStep(stepTypeId, stepId, stepCaseNo);

            var callItem = new Policy.Call()
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,

                StepTypeId = int.Parse(stepTypeId),
                StepId = int.Parse(stepId),
                StepCaseNo = int.Parse(stepCaseNo),

                CommunicationTypeId = 1,
                DateSent = DateTime.Now,
                CallregNotehistoryid = callregNotehistoryid,
                StartDate = String.IsNullOrWhiteSpace(startDate) ? (DateTime?)null : DateTime.Parse(startDate),
                EndDate = String.IsNullOrWhiteSpace(endDate) ? (DateTime?)null : DateTime.Parse(endDate),
                Duration = duration,
                CallerIdNumber = callerIdNumber,
                CallerIdName = callerIdName,
                OutboundNumber = outBoundNumber,
                RecordingFile = recordingFile,
                DateAdded = DateTime.Now,
                OriginatedBy = Service.Underwriter_Id,
                UserId = Service.Underwriter_Id
            };

            //Guardo la llamada
            Services.PolicyManager.InsertCall(callItem);

            //Para cerrar el Step "Underwriting Call"
            Services.StepManager.CloseStep(currentStep);
            Services.StepManager.InsertStepComment(currentStep);

            //Oculto el Popup de atachar la llamada
            ((HiddenField)Parent.FindControl("hdnShowPopAttachCall")).Value = "false";

            //Lleno los datos del Tab nuevamente
            ((UCUnderwritingCall)Parent.Parent.Parent).FillData();
        }

        /// <summary>
        /// Función para obtener un objeto tipo "Step" con la información actual
        /// </summary>
        /// <returns>Retorna un objeto tipo "Step"</returns>
        private Step GetCurrentStep(string stepTypeIdVal, string stepIdVal, string stepCaseNoVal)
        {
            var stepId = int.Parse(stepIdVal);
            var stepCaseNo = int.Parse(stepCaseNoVal);
            var stepTypeId = int.Parse(stepTypeIdVal);

            var step = new Step
            {
                StepId = stepId,
                StepTypeId = stepTypeId,
                StepCaseNo = stepCaseNo,
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                UserId =  Service.Underwriter_Id
            };

            return step;
        }
    }
}