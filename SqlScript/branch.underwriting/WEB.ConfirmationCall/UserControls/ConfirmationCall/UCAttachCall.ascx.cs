using DI.UnderWriting;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.ConfirmationCall;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall.UserControls.ConfirmationCall
{
    public partial class UCAttachCall : UC
    {
        #region metodos

        UnderWritingDIManager diManager = new UnderWritingDIManager();

        public DataTable DataCalls
        {
            get
            {
                var data = Session["UCAttachCall.DataCalls"];
                return data != null ? (DataTable)Session["UCAttachCall.DataCalls"] : null;
            }
            set
            {
                Session["UCAttachCall.DataCalls"] = value;
            }
        }

        public object GetCalls(DataTable data)
        {
            return data;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            Utility.TranslateColumnsAspxGrid(this.gvAttachCalls);

            btnACCancel.Text = Resources.Cancel;
            btnACAttach.Text = Resources.AttachCall;

        }
        
        public void FillData()
        {
            //Usuario por defecto de pruebas cambiar cuando se tenga el identificador por usuario
            var data = diManager.CallRexManager.GetResumedCallDataCRUserId("{3407A220-CA8B-4620-B3C5-F68031ADB07B}", DateTime.Now, ResumedCallData.CallTimePeriod.TwoHoursFromDate, 10).OrderByDescending(r => r.StartTime);
            var dt = new DataTable("Calls");
            if ((data != null) && (data.Count() > 0))
            {
                var props = typeof(ResumedCallData).GetProperties();
                dt.Columns.AddRange(
                  props.Select(p => new DataColumn(p.Name)).ToArray()
                );

                data.ToList().ForEach(
                  i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
                );
                dt.Columns.Add("RecordingFileClean");
                var sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        var fileName = row["RecordingFile"].ToString();
                        var fileArray = fileName.Split('\\');

                        var recDir = _services.recordingsDir + fileArray[0] + "\\";
                        fileName = fileArray[1];

                        if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(fileName))
                        {
                            sb.Clear();
                            sb.Append(@"<audio id='audioCall' controls='controls' src='../../../TempFiles/Mp3/" + fileName.Replace(" ", "").Replace(".wav", ".mp3") + "' class='audioTag' type='audio/mpeg'>Not Supported");
                            row["RecordingFileClean"] = sb.ToString();
                        }

                    }
                }
                DataCalls = dt;
                gvAttachCalls.DataBind();
            }
            else
            {
                dt.Columns.Add("UserName");
                dt.Columns.Add("StartTime");
                dt.Columns.Add("EndTime");
                dt.Columns.Add("Duration");
                dt.Columns.Add("OutgoingNumber");
                dt.Columns.Add("RecordingFile");
                dt.Columns.Add("RecordingFileClean");
                DataCalls = dt;
                gvAttachCalls.DataBind();
            }
        }

        protected void gvAttachCalls_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == DevExpress.Web.GridViewRowType.Data)
            {
                try
                {
                    TableRow row = e.Row;

                    var fileName = gvAttachCalls.GetRowValues(e.VisibleIndex, "RecordingFile").ToString();
                    var fileArray = fileName.Split('\\');

                    var recDir = _services.recordingsDir + fileArray[0] + "\\";
                    fileName = fileArray[1];

                    if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(fileName))
                    {
                        JMAudioTools.ConvertToMp3(recDir, _services.mp3TempDir, fileName, true, Server.MapPath(_services.SoxFilePath));
                    }

                }
                catch (Exception ex)
                {

                    ConfirmationCallLog.Log("gvAttachCalls_HtmlRowPrepared", string.Format("Message {0} InnerException {1}", ex.Message, ex.InnerException), "", UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());
                }

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

        protected void btnACCancel_Click(object sender, EventArgs e)
        {
            var dt = new DataTable("Calls");
            dt.Columns.Add("UserName");
            dt.Columns.Add("StartTime");
            dt.Columns.Add("EndTime");
            dt.Columns.Add("Duration");
            dt.Columns.Add("OutgoingNumber");
            dt.Columns.Add("RecordingFile");
            dt.Columns.Add("RecordingFileClean");
            DataCalls = dt;
            gvAttachCalls.DataBind();
        }

        protected void btnACAttach_Click(object sender, EventArgs e)
        {
            var KeyFieldName = ("UserName\\StartTime\\EndTime\\Duration\\IncomingNumber\\CallerIDName\\CallerIdNumber\\OutgoingNumber\\RecordingFile\\CallLogId").Split('\\');
            var rows = gvAttachCalls.GetFilteredSelectedValues(KeyFieldName);
            string[] fieldvalues = ((System.Collections.IEnumerable)rows[0])
                                                                            .Cast<object>()
                                                                            .Select(x => x.ToString())
                                                                            .ToArray();
            var startDate = fieldvalues[1];
            var endDate = fieldvalues[2];
            var duration = fieldvalues[3];
            var incomingNumber = fieldvalues[4];
            var callerIdName = fieldvalues[5];
            var callerIdNumber = fieldvalues[6];
            var outBoundNumber = fieldvalues[7];
            var recordingFile = fieldvalues[8];
            var callregNotehistoryid = fieldvalues[9];
            var stepTypeId = "1";
            var stepId = "12";
            var stepCaseNo = "1";

            if (!String.IsNullOrEmpty(stepTypeId) && !String.IsNullOrEmpty(stepId) && !String.IsNullOrEmpty(stepCaseNo))
            {
                var currentStep = GetCurrentStep(stepTypeId, stepId, stepCaseNo);

                var callItem = new Entity.UnderWriting.Entities.Policy.Call()
                {
                    CorpId = _services.Corp_Id,
                    RegionId = _services.Region_Id,
                    CountryId = _services.Country_Id,
                    DomesticregId = _services.Domesticreg_Id,
                    StateProvId = _services.State_Prov_Id,
                    CityId = _services.City_Id,
                    OfficeId = _services.Office_Id,
                    CaseSeqNo = _services.Case_Seq_No,
                    HistSeqNo = _services.Hist_Seq_No,

                    ContactId = _services.Current_Contact_Id,
                    ContactRoleTypeId = _services.Current_Contact_Type_Id.ToInt(),

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
                    OriginatedBy = UserDataProvider.UserId,
                    UserId = (int)UserDataProvider.UserId
                };

                //Guardo la llamada
                diManager.PolicyManager.InsertCall(callItem);

                //Oculto el Popup de atachar la llamada
                //((HiddenField)Parent.FindControl("hdnShowPopAttachCall")).Value = "false";

                /* UCAttachment Attachments = new UCAttachment;

                 Attachments.AttachList();*/
                ((UCAttachment)Parent.Parent.Parent).FillAttachedCalls();
            }
        }

        /// <summary>
        /// Función para obtener un objeto tipo "Step" con la información actual
        /// </summary>
        /// <returns>Retorna un objeto tipo "Step"</returns>
        private Entity.UnderWriting.Entities.Step GetCurrentStep(string stepTypeIdVal, string stepIdVal, string stepCaseNoVal)
        {
            var stepId = int.Parse(stepIdVal);
            var stepCaseNo = int.Parse(stepCaseNoVal);
            var stepTypeId = int.Parse(stepTypeIdVal);

            var step = new Entity.UnderWriting.Entities.Step
            {
                StepId = stepId,
                StepTypeId = stepTypeId,
                StepCaseNo = stepCaseNo,
                CorpId = _services.Corp_Id,
                RegionId = _services.Region_Id,
                CountryId = _services.Country_Id,
                DomesticregId = _services.Domesticreg_Id,
                StateProvId = _services.State_Prov_Id,
                CityId = _services.City_Id,
                OfficeId = _services.Office_Id,
                CaseSeqNo = _services.Case_Seq_No,
                HistSeqNo = _services.Hist_Seq_No
            };

            return step;
        }

        #region Events

        protected void dsCalls_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataCalls;
        }

        protected void gvAttachCalls_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvAttachCalls.FocusedRowIndex = -1;
        }

        protected void gvAttachCalls_PageIndexChanged(object sender, EventArgs e)
        {
            gvAttachCalls.FocusedRowIndex = -1;
        }

        protected void gvAttachCalls_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            gvAttachCalls.FocusedRowIndex = -1;
        }
        #endregion
    }
}