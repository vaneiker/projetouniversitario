using DI.UnderWriting;
using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall.UserControls.History
{
    public partial class UCAttachment : UC
    {

        #region metodos

        UnderWritingDIManager diManager = new UnderWritingDIManager();

        public DataTable DataCalls
        {
            get
            {
                var data = Session["UCAttachment.DataCalls"];
                return data != null ? (DataTable)Session["UCAttachment.DataCalls"] : null;
            }
            set
            {
                Session["UCAttachment.DataCalls"] = value;
            }
        }

        public object GetCalls(DataTable data)
        {
            return data;
        }

        public IEnumerable<Entity.UnderWriting.Entities.Policy.CategoryDocument> DataDocuments
        {
            get
            {
                var data = Session["UCAttachment.DataDocuments"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.Policy.CategoryDocument>)Session["UCAttachment.DataDocuments"] : null;
            }
            set
            {
                Session["UCAttachment.DataDocuments"] = value;
            }
        }

        public IEnumerable<Entity.UnderWriting.Entities.Policy.CategoryDocument> GetDocuments(IEnumerable<Entity.UnderWriting.Entities.Policy.CategoryDocument> data)
        {
            return data;
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerPdfPopUp.LicenseKey = ConfigurationManager.AppSettings["PDFViewer"];
            if (!IsPostBack)
            {
                try
                {
                    if (_services.Current_Contact_Id > 0)
                    {
                        //Session["ModificarAddres"] = "0";
                        FillAttachments();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void FillAttachments()
        {
            FillAttchedDocuments();
            FillAttachedCalls();
        }


        public void FillAttchedDocuments()
        {
            try
            {
                DataDocuments = _services.oPolicyManager.GetCategoryDocument(_services.Corp_Id, _services.Region_Id, _services.Country_Id,
                    _services.Domesticreg_Id, _services.State_Prov_Id, _services.City_Id, _services.Office_Id, _services.Case_Seq_No, _services.Hist_Seq_No, null, null,
                    UserDataProvider.LanguageId).Where(d => d.HasDocument == true && !string.IsNullOrEmpty(d.DocCategoryDesc));
                gvDocuments.DataBind();
            }
            catch (Exception ex)
            {
                string parameter = "CorpId:" + _services.Corp_Id + ",Region_Id:" + _services.Region_Id + ",Country_Id:" + _services.Country_Id +
                    ",Domesticreg_Id:" + _services.Domesticreg_Id + ",State_Prov_Id:" + _services.State_Prov_Id + ",City_Id:" + _services.City_Id +
                    ",Office_Id:" + _services.Office_Id + ",Case_Seq_No:" + _services.Case_Seq_No + ",Hist_Seq_No:" + _services.Hist_Seq_No + "";

                ConfirmationCallLog.Log("Historico.FillAttchedDocuments", ex.Message, parameter, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());

            }
        }

        public void FillAttachedCalls()
        {
            //Inserto el Estatus de la Poliza para que cambia el Tab de Warning
            Step Step = new Step();
            Step.CorpId = _services.Corp_Id;
            Step.RegionId = _services.Region_Id;
            Step.CountryId = _services.Country_Id;
            Step.DomesticregId = _services.Domesticreg_Id;
            Step.StateProvId = _services.State_Prov_Id;
            Step.CityId = _services.City_Id;
            Step.OfficeId = _services.Office_Id;
            Step.CaseSeqNo = _services.Case_Seq_No;
            Step.HistSeqNo = _services.Hist_Seq_No;
            Step.StepCaseNo = _services.Step_Case_No;
            Step.StepId = _services.Step_Id;
            Step.StepTypeId = _services.Step_Type_Id;

            var data = diManager.StepManager.GetAllCall(Step).Where(c => c.ContactRoleTypeId == _services.Current_Contact_Type_Id.ToInt());
            var dt = new DataTable("Calls");
            if ((data != null) && (data.Count() > 0))
            {
                var props = typeof(Policy.Call).GetProperties();
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
                            //JMAudioTools.ConvertToMp3(recDir, _services.mp3TempDir, fileName, true, Server.MapPath(_services.SoxFilePath));

                            sb.Clear();
                            sb.Append(@"<audio id='audioCall' controls='controls' src='../../../TempFiles/Mp3/" + fileName.Replace(" ", "").Replace(".wav", ".mp3") + "' class='audioTag' type='audio/mp3'>");
                            row["RecordingFileClean"] = sb.ToString();
                        }

                    }
                }
                DataCalls = dt;
                gvAttachedCalls.DataBind();
            }
            else
            {
                dt.Columns.Add("OriginatedByName");
                dt.Columns.Add("StartDate");
                dt.Columns.Add("EndDate");
                dt.Columns.Add("Duration");
                dt.Columns.Add("OutboundNumber");
                dt.Columns.Add("RecordingFile");
                dt.Columns.Add("RecordingFileClean");
                DataCalls = dt;
                gvAttachedCalls.DataBind();
            }
        }

        protected void gvAttachedCalls_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == DevExpress.Web.GridViewRowType.Data)
            {
                TableRow row = e.Row;

                var fileName = gvAttachedCalls.GetRowValues(e.VisibleIndex, "RecordingFile").ToString();
                var fileArray = fileName.Split('\\');

                var recDir = _services.recordingsDir + fileArray[0] + "\\";
                fileName = fileArray[1];

                if (!String.IsNullOrEmpty(recDir) && !String.IsNullOrEmpty(fileName))
                {
                    JMAudioTools.ConvertToMp3(recDir, _services.mp3TempDir, fileName, true, Server.MapPath(_services.SoxFilePath));
                }
            }
        }

        protected void gvDocuments_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var KeyValues = e.KeyValue.ToString();

            try
            {
                switch (((Button)e.CommandSource).CommandName)
                {
                    case "View":
                        // DocCategoryId;DocTypeId;DocumentId
                        var DocCategoryId = int.Parse(e.KeyValue.ToString().Split('|')[0]);
                        var DocTypeId = int.Parse(e.KeyValue.ToString().Split('|')[1]);
                        var DocumentId = int.Parse(e.KeyValue.ToString().Split('|')[2]);

                        var document = _services.oPaymentManager.GetDocument(_services.Corp_Id, _services.Region_Id, _services.Country_Id,
                        _services.Domesticreg_Id, _services.State_Prov_Id, _services.City_Id, _services.Office_Id,
                        _services.Case_Seq_No, _services.Hist_Seq_No, DocCategoryId, DocTypeId, DocumentId);

                        if (document != null)
                        {
                            if (document.DocumentBinary == null)
                            {
                                string message = RESOURCE.UnderWriting.ConfirmationCall.Resources.MsgDocument;
                                Alertify.Alert(message, this);
                                return;
                            }
                            else
                            {
                                ltMsgTitulo.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.UploadedDocuments.ToUpper();
                                pdfViewerPdfPopUp.PdfSourceBytes = document.DocumentBinary;
                                pdfViewerPdfPopUp.DataBind();
                                ModalPopupPadecimiento.Show();

                            }
                        }

                        break;
                    case "Delete":
                        break;

                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //
            }


        }

        #region Events

        protected void dsCalls_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataCalls;
        }

        protected void gvAttachedCalls_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvAttachedCalls.FocusedRowIndex = -1;
        }

        protected void gvAttachedCalls_PageIndexChanged(object sender, EventArgs e)
        {
            gvAttachedCalls.FocusedRowIndex = -1;
        }

        protected void gvAttachedCalls_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            gvAttachedCalls.FocusedRowIndex = -1;
        }

        protected void dsDocuments_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataDocuments;
        }

        protected void gvDocuments_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvDocuments.FocusedRowIndex = -1;
        }

        protected void gvDocuments_PageIndexChanged(object sender, EventArgs e)
        {
            gvDocuments.FocusedRowIndex = -1;
        }

        protected void gvDocuments_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            gvDocuments.FocusedRowIndex = -1;
        }

        #endregion

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {

            Utility.TranslateColumnsAspxGrid(this.gvAttachedCalls);

            Utility.TranslateColumnsAspxGrid(this.gvDocuments);
            //
            //btnUCAttachCallOrig.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Add;
            //BtnCancelNotes.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Cancel;
        }


    }
}