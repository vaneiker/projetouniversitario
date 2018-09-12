using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
//wcastro 27-04-2017
using System.Text;
using System.Web.UI;
//fin wcastro 27-04-2017
//wcastro 16-05-2017
using System.Net.Mail;
//fin wcastro 16-05-2017

namespace WEB.UnderWriting.Case.UserControls.Common
{
    public partial class UCPopSentToReinsurance : UC
    {
        public int? _StepCaseNo
        {
            get { return String.IsNullOrWhiteSpace(hdnSRStepCaseNo.Value) ? (int?)null : int.Parse(hdnSRStepCaseNo.Value); }
            set { hdnSRStepCaseNo.Value = value.HasValue ? value.Value.ToString() : ""; }
        }
        public int? _StepId
        {
            get { return String.IsNullOrWhiteSpace(hdnSRStepId.Value) ? (int?)null : int.Parse(hdnSRStepId.Value); }
            set { hdnSRStepId.Value = value.HasValue ? value.Value.ToString() : ""; }
        }
        public int? _StepTypeId
        {
            get { return String.IsNullOrWhiteSpace(hdnSRStepTypeId.Value) ? (int?)null : int.Parse(hdnSRStepTypeId.Value); }
            set { hdnSRStepTypeId.Value = value.HasValue ? value.Value.ToString() : ""; }
        }
        public String _StepSeqReference
        {
            get { return hdnSRStepSeqReference.Value; }
            set { hdnSRStepSeqReference.Value = value; }
        }
        public int? _ReinsurerId
        {
            get { return String.IsNullOrWhiteSpace(hdnSRReinsurerId.Value) ? (int?)null : int.Parse(hdnSRReinsurerId.Value); }
            set { hdnSRReinsurerId.Value = value.HasValue ? value.Value.ToString() : ""; }
        }
        public int? _CommTypeId
        {
            get { return String.IsNullOrWhiteSpace(hdnSRCommunicationTypeId.Value) ? (int?)null : int.Parse(hdnSRCommunicationTypeId.Value); }
            set { hdnSRCommunicationTypeId.Value = value.HasValue ? value.Value.ToString() : ""; }
        }
        public String _EmailRecipient
        {
            get { return hdnSREmailRecipient.Value; }
            set { hdnSREmailRecipient.Value = value; }
        }

        List<Tools.EmailAttachmentItem> EmailAttachmentList
        {
            get { return Session["EmailAttachmentList"] == null ? new List<Tools.EmailAttachmentItem>() : (List<Tools.EmailAttachmentItem>)Session["EmailAttachmentList"]; }
            set { Session["EmailAttachmentList"] = value; }
        }

        //wcastro 15-05-2017
        public IEnumerable<Reinsurance.Communication> commData
        {
            get { return Session["commData"] == null ? null : (IEnumerable<Reinsurance.Communication>)Session["commData"]; }
            set { Session["commData"] = value; }
        }
        //fin wcastro 15-05-2017

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSRView_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var stepTypeId = int.Parse(gvInbox.DataKeys[gridRow.RowIndex]["StepTypeId"].ToString());
            var stepId = int.Parse(gvInbox.DataKeys[gridRow.RowIndex]["StepId"].ToString());
            var stepCaseNo = int.Parse(gvInbox.DataKeys[gridRow.RowIndex]["StepCaseNo"].ToString());
            var communicationId = int.Parse(gvInbox.DataKeys[gridRow.RowIndex]["CommunicationId"].ToString());
            var hasAttachment = Boolean.Parse(gvInbox.DataKeys[gridRow.RowIndex]["CommAttachment"].ToString());

            var commItem = new Reinsurance.Communication()
              {
                  CorpId = Service.Corp_Id,
                  RegionId = Service.Region_Id,
                  CountryId = Service.Country_Id,
                  DomesticRegId = Service.Domesticreg_Id,
                  StateProvId = Service.State_Prov_Id,
                  CityId = Service.City_Id,
                  OfficeId = Service.Office_Id,
                  CaseSeqNo = Service.Case_Seq_No,
                  HistSeqNo = Service.Hist_Seq_No,
                  StepTypeId = stepTypeId,
                  StepId = stepId,
                  StepCaseNo = stepCaseNo,
                  CommunicationId = communicationId
              };

            //Get email and Attachments
            //wcastro 16-05-2017
            commData = Service.GetRCHtmlAndAttach(commItem);
            //fin wcastro 16-05-2017

            //Get email Text
            ltCorreo.Text = commData.First().CommText;
            lblSRSubject.Text = commData.First().CommSubject;

            //Fill attachments
            gvEmailAttachments.Visible = hasAttachment;// false; //hasAttachment;
            gvEmailAttachments.DataSource = hasAttachment ? commData : null;
            gvEmailAttachments.DataBind();
        }

        public void FillData(IEnumerable<Reinsurance.Communication> data, Reinsurance.StepAvailable stepInfo)
        {
            EmailAttachmentList = new List<Tools.EmailAttachmentItem>();

            ClearFields();

            gvInbox.DataSource = data;
            gvInbox.DataBind();

            GetRequirementDocs();

            FillDrops();
            FillAttachmentsGrid();
            FillDocumentsFromDrops();

            FillStepInfo(stepInfo);
            FillData();
        }

        private void FillDocumentsData(Tools.PolicyKeyItem policyKey = null, int? docCategoryId = null, int? documentTypeid = null)
        {
            var policyDocuments = Service.GetCategoryDocuments(policyKey, docCategoryId, documentTypeid);

            //Bmarroquin 16-05-2017 Primer Filtro, "elimino" los REgistros con DocCategoryId = 172 son los que se adjuntan en cada envio de correo
            policyDocuments = policyDocuments.Where(r => r.DocCategoryId != 172);

            policyDocuments = policyDocuments.Where(r => !EmailAttachmentList.Any(a => a.DocumentId == r.DocumentId && a.DocCategoryId == r.DocCategoryId && a.DocTypeId == r.DocTypeId));

            gvSRPolicyDocument.DataSource = policyDocuments.ToList();
            gvSRPolicyDocument.DataBind();

            if (gvSRPolicyDocument.BottomPagerRow != null)
            {
                var totalItems = (Literal)gvSRPolicyDocument.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = policyDocuments.ToList().Count + "";
            }

            setPagerIndex(gvSRPolicyDocument);
        }

        private void FillAttachmentsGrid()
        {
            gvSREmailSendAttachments.DataSource = EmailAttachmentList;
            gvSREmailSendAttachments.DataBind();
        }

        private void ClearFields()
        {
            ltCorreo.Text = "";
            lblSRSubject.Text = "";
            gvEmailAttachments.Visible = false;
            gvEmailAttachments.DataSource = null;
            gvEmailAttachments.DataBind();
        }

        protected void btnSRPreviewAttach_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var grid = (GridView)gridRow.NamingContainer;

            var docCategoryId = int.Parse(grid.DataKeys[gridRow.RowIndex]["DocCategoryId"].ToString());
            var docTypeId = int.Parse(grid.DataKeys[gridRow.RowIndex]["DocTypeId"].ToString());
            var documentId = int.Parse(grid.DataKeys[gridRow.RowIndex]["DocumentId"].ToString());

            var doc = Service.GetCommDocBinary(docCategoryId, docTypeId, documentId);

            if (doc != null)
                PreviewDoc(doc);
            else
                this.MessageBox("This document is Empty, please try with another one.", 500, 150, true, "Empty Document");
        }

        protected void btnSRDownloadAttach_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

            var docCategoryId = int.Parse(gvEmailAttachments.DataKeys[gridRow.RowIndex]["DocCategoryId"].ToString());
            var docTypeId = int.Parse(gvEmailAttachments.DataKeys[gridRow.RowIndex]["DocTypeId"].ToString());
            var documentId = int.Parse(gvEmailAttachments.DataKeys[gridRow.RowIndex]["DocumentId"].ToString());
            var documentName = gvEmailAttachments.DataKeys[gridRow.RowIndex]["DocumentName"].ToString();


            var commDoc = Service.GetCommDocument(docCategoryId, docTypeId, documentId);

            var docFullName = documentName + commDoc.Extension;
            var doc = commDoc.DocumentBinary;

            Tools.StreamFileToBrowser(docFullName, doc);
        }

        protected void btnSRCloseEmail_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void ddlSRDocumentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDocumentsFromDrops();
        }

        protected void ddlSRPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var policyArray = ddlSRPolicy.SelectedValue.Split('|');

            var policyKey = new Tools.PolicyKeyItem()
            {
                CorpId = int.Parse(policyArray[0]),
                RegionId = int.Parse(policyArray[1]),
                CountryId = int.Parse(policyArray[2]),
                DomesticregId = int.Parse(policyArray[3]),
                StateProvId = int.Parse(policyArray[4]),
                CityId = int.Parse(policyArray[5]),
                OfficeId = int.Parse(policyArray[6]),
                CaseSeqNo = int.Parse(policyArray[7]),
                HistSeqNo = int.Parse(policyArray[8])
            };

            FillDocumentsFromDrops();
            FillDrops(policyKey, false);
        }

        protected void ddlFacultativeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var facultativeStatus = ddlFacultativeStatus.SelectedValue;

            switch (facultativeStatus)
            {
                default:
                    break;
            }

            //SetFieldsStatusReinsurance();
        }

        protected void gvSRPolicyDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSRPolicyDocument.PageIndex = e.NewPageIndex;
            gvSRPolicyDocument.DataBind();
            FillDocumentsFromDrops();
            setPagerIndex(gvSRPolicyDocument);
        }

        protected void gvSREmailSendAttachments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnSRCancelEmail_Click(object sender, EventArgs e)
        {
            ClearEmailInfo();
        }

        private Step.Note GetNewNote()
        {


            var step = new Entity.UnderWriting.Entities.Step.Note
            {
                StepId = (int)_StepId,
                StepTypeId = (int)_StepTypeId,
                StepCaseNo = (int)_StepCaseNo,
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                NoteDesc = txtSRSendEmail.Text,
                UserId =  Service.Underwriter_Id,
                OriginatedBy =  Service.Underwriter_Id
            };

            return step;

        }

        protected void btnSRSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //wcastro 14-05-2017
                //if (!_StepCaseNo.HasValue || _StepCaseNo.Value < 1)
                //{
                //    var newStep = new Step.NewStep
                //    {
                //        StepCaseNo = -1,

                //        //Send To Reinsurance Step Key
                //        StepTypeId = 1,
                //        StepId = 61,
                //        Note = txtSRSendEmail.Text
                //    };

                //    _StepCaseNo = Service.InsertNewStep(newStep);

                //    var stepInfo = Service.StepAvailable();

                //    FillStepInfo(stepInfo);
                //}
                //else
                //{
                //fin wcastro 14-05-2017

                //wcastro 18-05-2017
                if (!(!_StepCaseNo.HasValue || _StepCaseNo.Value < 1))
                {
                    //fin wcastro 18-05-2017

                    Services.StepManager.InsertNote(GetNewNote());

                    //wcastro 14-05-2017
                    //}
                    //fin wcastro 14-05-2017

                    //Bmarroquin 15-05-17 comento codigo 
                    /*
                    const string subjectFormat = "{0} - [Step#{1}]";
                    var subject = string.Format(subjectFormat, txtSRSendSubject.Text.Trim(), _StepSeqReference);
                    */
                    var subject = txtSRSendSubject.Text.Trim(); //Que el asunto del Email no se genere con el correlativo Aeroespacial 
                                                                //Fin Bmarroquin 15-05-17

                    var reinsuranceComm = new Reinsurance.Communication()
                    {
                        //Key
                        CommunicationId = -1,
                        StepCaseNo = _StepCaseNo.Value,
                        StepId = _StepId.Value,
                        StepTypeId = _StepTypeId.Value,
                        ReinsurerId = _ReinsurerId.Value,
                        CommTypeId = _CommTypeId.Value,

                        //Communication Info
                        CommDate = DateTime.Now,
                        CommFrom = Service.FromEmail,
                        CommSubject = subject,
                        CommText = txtSRSendEmail.Text,
                        CommAttachment = EmailAttachmentList.Any(),

                        //UserInfo
                        UserId = Service.Underwriter_Id,
                    };

                    //Insert Communication
                    var insertedComm = Service.InsertReinsuranceCommunication(reinsuranceComm);

                    //Insert Communication Attachments
                    if (EmailAttachmentList.Any())
                    {
                        var commAttachmentsList = new List<Reinsurance.Communication>();

                        foreach (var item in EmailAttachmentList)
                        {

                            var docId = Services.PolicyManager.SetDocument(
                                item.FileTypeId.Value,
                                172, //ReinsuranceEmailAttachment,
                                -1,
                                Tools.ReadBinaryFile(item.FilePath),
                                item.DocName,
                                DateTime.Now,
                                null,
                                Service.Underwriter_Id
                                );

                            var commAttachItem = new Reinsurance.Communication()
                            {
                                //Key
                                CommunicationId = insertedComm.CommunicationId,
                                StepCaseNo = insertedComm.StepCaseNo,
                                StepId = insertedComm.StepId,
                                StepTypeId = insertedComm.StepTypeId,

                                //Document Info
                                DocumentId = docId,
                                DocCategoryId = 172, //ReinsuranceEmailAttachment
                                DocTypeId = item.FileTypeId.Value,

                                //UserInfo
                                UserId = Service.Underwriter_Id
                            };

                            commAttachmentsList.Add(commAttachItem);
                        }

                        if (commAttachmentsList.Any())
                            Service.SetReinsuranceCommunicationAttachment(commAttachmentsList);
                    }

                    //Fin Bmarroquin 15-05-17

                    //Bmarroquin 17-05-17 Mejora para controlar excepcion cuando se da un error en el envio de correo 
                    try
                    {
                        //Send Email
                        MailManager.SendMessage(_EmailRecipient,
                                     "",
                                     "",
                                     txtSRSendEmail.Text,
                                     "",
                                     Service.FromEmail,
                                     subject,
                                     EmailAttachmentList,
                                     false,
                                     Service.SmtpServer);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('" + ex.InnerException.Message.ToString() + "', 500, 150, true, 'Error');", true);
                        return;
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('E-mail sent successfully!', 500, 150, true, 'Alert');", true);
                    //Fin Bmarroquin 17-05-17

                    //Clear Email
                    ClearEmailInfo();

                    //Bmarroquin 16-05-17 Vuelvo a poner en funcionamiento este codigo, descomentar para que el Inbox se Refresque
                    ///Reload Data
                    //Get Step Info
                    var stepsInfo = Service.StepAvailable();

                    //Get Communications Data
                    var commItem = new Reinsurance.Communication()
                    {
                        CorpId = Service.Corp_Id,
                        RegionId = Service.Region_Id,
                        CountryId = Service.Country_Id,
                        DomesticRegId = Service.Domesticreg_Id,
                        StateProvId = Service.State_Prov_Id,
                        CityId = Service.City_Id,
                        OfficeId = Service.Office_Id,
                        CaseSeqNo = Service.Case_Seq_No,
                        HistSeqNo = Service.Hist_Seq_No,
                        StepId = stepsInfo.StepId,
                        StepCaseNo = stepsInfo.StepCaseNo,
                        StepTypeId = stepsInfo.StepTypeId
                    };

                    var data = Service.FillResinsuranceComm(commItem);
                    FillData(data, stepsInfo);
                    var right = (Right)this.Parent.Parent.Parent;
                    right.fillPointSteps();
                    //Fin Bmarroquin 16-05-17 

                    //wcastro 18-05-2017
                    if (data == null || data.Count == 1)//Solo debe de haber 1 correo que es el que se acaba de enviar arriba, ya que solo se deben de actualizar una vez la(s) cobertura(s)
                    {
                    //fin wcastro 18-05-2017

                        for (int i = 0; i < gvRiders.Rows.Count; i++)
                        {

                            Policy.ReinsuranceFacultative objReinsure2 = new Policy.ReinsuranceFacultative();
                            objReinsure2.CorpId = Service.Corp_Id;
                            objReinsure2.RegionId = Service.Region_Id;
                            objReinsure2.CountryId = Service.Country_Id;
                            objReinsure2.DomesticregId = Service.Domesticreg_Id;
                            objReinsure2.StateProvId = Service.State_Prov_Id;
                            objReinsure2.CityId = Service.City_Id;
                            objReinsure2.OfficeId = Service.Office_Id;
                            objReinsure2.CaseSeqNo = Service.Case_Seq_No;
                            objReinsure2.HistSeqNo = Service.Hist_Seq_No;

                            objReinsure2.CoverageTypeDesc = Convert.ToString(gvRiders.DataKeys[i]["Coverage_Type_Desc"]);
                            objReinsure2.BeneficiaryAmount = Convert.ToDecimal((gvRiders.DataKeys[i]["Beneficiary_Amount"]));
                            //objReinsure.CompanyRiskAmount = Convert.ToDecimal(txtCompanyRiskAmountDet.Text.Replace(",", ""));
                            //objReinsure.ReinsuranceRiskAmount = Convert.ToDecimal(txtReinRiskAmountDet.Text.Replace(",", ""));
                            //objReinsure.AuthorizedAmount = Convert.ToDecimal(txtTotalAmountAuthDet.Text.Replace(",", ""));
                            objReinsure2.RiskRatingTable = Convert.ToString(gvRiders.DataKeys[i]["Risk_Rating"]);
                            objReinsure2.PerThousendRiskAmount = Convert.ToDecimal(gvRiders.DataKeys[i]["Per_Thousend_Risk_Amount"]);
                            objReinsure2.FacultativeStatusId = 2;//Es el de requested

                            objReinsure2.FacultativeReinsuranceId = Convert.ToString(gvRiders.DataKeys[i]["Facultative_Reinsurance_Id"]);

                            objReinsure2.ReinsuranceFacultativeStatus = Convert.ToBoolean(gvRiders.DataKeys[i]["Reinsurance_Facultative_Status"]);
                            objReinsure2.UserId = Service.Underwriter_Id;

                            objReinsure2.RequestedDate = DateTime.Now;

                            if (!string.IsNullOrEmpty(Convert.ToString(gvRiders.DataKeys[i]["Processed_Date"])))
                            {
                                objReinsure2.ProcessedDate = Convert.ToDateTime(gvRiders.DataKeys[i]["Processed_Date"]);
                            }

                            Services.PolicyManager.SetReninsuranceFacultative(objReinsure2);

                        }
                    //wcastro 18-05-2017
                    }
                    //fin wcastro 18-05-2017

                    FillData();
                    //fin wcastro 14-05-2017

                //wcastro 18-05-2017
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('Failed to send email because it does not apply reinsurance.', 500, 150, true, 'Invalid process!!!');", true);
                    return;
                }
                //fin wcastro 18-05-2017
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //wcastro 02-05-2017
        /// <summary>
        /// Metodo que manda el caso a un nuevo caso que es el de reaseguro
        /// </summary>
        public void createNewStepReInsurance()
        {
            try
            {
                //wcastro 14-05-2017
                var checkStep = Services.StepManager.GetAll_byStepId(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
                                Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, 1, 61);

                if (checkStep != null)
                {
                    _StepCaseNo = Convert.ToInt32(checkStep.Select(x => x.StepCaseNo).FirstOrDefault());
                }
                //fin wcastro 14-05-2017

                if (!_StepCaseNo.HasValue || _StepCaseNo.Value < 1)
                {
                    var newStep = new Step.NewStep
                    {
                        StepCaseNo = -1,

                        //Send To Reinsurance Step Key
                        StepTypeId = 1,
                        StepId = 61,
                        Note = txtSRSendEmail.Text
                    };

                    _StepCaseNo = Service.InsertNewStep(newStep);

                    var stepInfo = Service.StepAvailable();

                    FillStepInfo(stepInfo);
                }

                ///Reload Data
                //Get Step Info
                var stepsInfo = Service.StepAvailable();

                //Get Communications Data
                var commItem = new Reinsurance.Communication()
                {
                    CorpId = Service.Corp_Id,
                    RegionId = Service.Region_Id,
                    CountryId = Service.Country_Id,
                    DomesticRegId = Service.Domesticreg_Id,
                    StateProvId = Service.State_Prov_Id,
                    CityId = Service.City_Id,
                    OfficeId = Service.Office_Id,
                    CaseSeqNo = Service.Case_Seq_No,
                    HistSeqNo = Service.Hist_Seq_No,
                    StepId = stepsInfo.StepId,
                    StepCaseNo = stepsInfo.StepCaseNo,
                    StepTypeId = stepsInfo.StepTypeId
                };

                var data = Service.FillResinsuranceComm(commItem);
                FillData(data, stepsInfo);
                var right = (Right)this.Parent.Parent.Parent;
                right.fillPointSteps();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //fin wcastro 02-05-2017

        public void FillData()
        {
            var Corp_Id = Service.Corp_Id;
            var Region_Id = Service.Region_Id;
            var Country_Id = Service.Country_Id;
            var Domesticreg_Id = Service.Domesticreg_Id;
            var State_Prov_Id = Service.State_Prov_Id;
            var City_Id = Service.City_Id;
            var Office_Id = Service.Office_Id;
            var Case_Seq_No = Service.Case_Seq_No;
            var Hist_Seq_No = Service.Hist_Seq_No;

            Entity.UnderWriting.Entities.Policy.PlanData datos = Services.PolicyManager.GetPlanData(Corp_Id,
                                                                                                    Region_Id,
                                                                                                    Country_Id,
                                                                                                    Domesticreg_Id,
                                                                                                    State_Prov_Id,
                                                                                                    City_Id,
                                                                                                    Office_Id,
                                                                                                    Case_Seq_No,
                                                                                                    Hist_Seq_No);
            //wcastro 28-04-2017
            hdPolicyStatusId.Value = Convert.ToString(datos.PolicyStatusId);//Estado de la poliza
            hdBenefitAmount.Value = Convert.ToString(datos.BenefitAmount);//Monto de la poliza
            //fin wcastro 28-04-2017

            List<Rider> riders = Services.RiderManager.GetAllRider(new Policy.Parameter
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
                LanguageId = Service.LanguageId
            }).ToList();

            var facultativeDets = new Reinsurance.FacultativeDetails
            {
                Corp_Id = Service.Corp_Id,
                Region_Id = Service.Region_Id,
                Country_Id = Service.Country_Id,
                Domesticreg_Id = Service.Domesticreg_Id,
                State_Prov_Id = Service.State_Prov_Id,
                City_Id = Service.City_Id,
                Office_Id = Service.Office_Id,
                Case_seq_No = Service.Case_Seq_No,
                Hist_Seq_No = Service.Hist_Seq_No
            };
            //riders.Join()
            IEnumerable<Reinsurance.FacultativeDetails> facultativeDetails;
            facultativeDetails = Services.PolicyManager.GetReinsuranceFacultativeDetails(facultativeDets);
            if (facultativeDetails == null || !facultativeDetails.Any())
            {
                var FacultativeStatus = Service.GetReinsuranceFacultativeStatus().Where(f => f.Facultative_Status_Id == 1).FirstOrDefault();
                riders.Add(new Rider {
                    CorpId = datos.CorpId,
                    CaseSeqNo = datos.CaseSeqNo,
                    CityId = datos.CityId,
                    BeneficiaryAmount = datos.InsuredAmount,
                    CountryId = datos.CountryId,
                    DomesticregId = datos.DomesticregId,
                    HistSeqNo = datos.HistSeqNo,
                    OfficeId = datos.OfficeId,
                    RegionId = datos.RegionId,
                    StateProvId = datos.StateProvId,
                    RyderTypeDesc = "Cobertura Básica",
                    RiderId = 0
                });
                facultativeDetails = riders.Select(r => new Reinsurance.FacultativeDetails
                {
                    Corp_Id = r.CorpId,
                    Case_seq_No = r.CaseSeqNo,
                    City_Id = r.CityId,
                    Beneficiary_Amount = r.BeneficiaryAmount,
                    Country_Id = r.CountryId,
                    Domesticreg_Id = r.DomesticregId,
                    Hist_Seq_No = r.HistSeqNo,
                    Office_Id = r.OfficeId,
                    Region_Id = r.RegionId,
                    State_Prov_Id = r.StateProvId,
                    Coverage_Type_Desc = r.RyderTypeDesc,
                    Rider_Id = r.RiderId,
                    Rider_Type_Id = r.RiderTypeId,
                    Facultative_Status_Id = FacultativeStatus.Facultative_Status_Id,
                    Facultative_Status_Desc = FacultativeStatus.Facultative_Status_Desc,
                    Total_Amount_Insured = riders.Sum(b => b.BeneficiaryAmount).GetValueOrDefault(),
                    Per_Thousend_Risk_Amount = 0,
                    Risk_Rating = "Standard 100%",
                    Authorized_Amount = 0
                }).ToArray();
            }
            else
                facultativeDetails.ToList();
                    //.ForEach(v=>v.Risk_Rating = Services.PolicyManager.GetRatingRisk(null).Where(r=>r.TableRating_Id == v.Risk_Rating).FirstOrDefault().Long_Description);
            gvRiders.DataSource = facultativeDetails;
            gvRiders.DataBind();
        }

        protected void gvRiders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton lnkEdit = e.Row.FindControl("lnkEdit") as LinkButton;
                //this.upRiderInformation2.Triggers.Add(new AsyncPostBackTrigger
                //{
                //    ControlID = lnkEdit.UniqueID,
                //    EventName = "Click"
                //});

                //Button btnRemove = e.Row.FindControl("btnRemove") as Button;
                //this.upRiderInformation2.Triggers.Add(new AsyncPostBackTrigger
                //{
                //    ControlID = btnRemove.UniqueID,
                //    EventName = "Click"
                //});
            }
        }

        protected void gvRiders_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle = this.style.backgroundColor; this.style.backgroundColor = '#8CC65E'; this.style.cursor = 'pointer'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor = this.originalstyle;");
                e.Row.Cells[0].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
                e.Row.Cells[1].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
                e.Row.Cells[2].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
                e.Row.Cells[3].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
                e.Row.Cells[4].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
                e.Row.Cells[5].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
                e.Row.Cells[7].Attributes.Add("OnClick", Page.ClientScript.GetPostBackClientHyperlink(gvRiders, "Select$" + e.Row.RowIndex));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //wcastro 26-04-2017
            try
            {
                var msgError = new StringBuilder();
                bool isValid = false;

                isValid = controlValidate(out msgError);

                //if(isValid)
                //    isValid = bussinesValidate(out msgError);

                if (isValid)
                {
                    Policy.ReinsuranceFacultative objReinsure = new Policy.ReinsuranceFacultative();
                    objReinsure.CorpId = Service.Corp_Id;
                    objReinsure.RegionId = Service.Region_Id;
                    objReinsure.CountryId = Service.Country_Id;
                    objReinsure.DomesticregId = Service.Domesticreg_Id;
                    objReinsure.StateProvId = Service.State_Prov_Id;
                    objReinsure.CityId = Service.City_Id;
                    objReinsure.OfficeId = Service.Office_Id;
                    objReinsure.CaseSeqNo = Service.Case_Seq_No;
                    objReinsure.HistSeqNo = Service.Hist_Seq_No;

                    objReinsure.CoverageTypeDesc = Convert.ToString(txtCoverageName.Text);
                    objReinsure.BeneficiaryAmount = Convert.ToDecimal(txtCoverageAmount.Text.Replace(",", ""));
                    //objReinsure.CompanyRiskAmount = Convert.ToDecimal(txtCompanyRiskAmountDet.Text.Replace(",", ""));
                    //objReinsure.ReinsuranceRiskAmount = Convert.ToDecimal(txtReinRiskAmountDet.Text.Replace(",", ""));
                    //objReinsure.AuthorizedAmount = Convert.ToDecimal(txtTotalAmountAuthDet.Text.Replace(",", ""));
                    objReinsure.RiskRatingTable = Convert.ToString(ddlRiskRatingPercents.SelectedItem.Text);
                    objReinsure.PerThousendRiskAmount = Convert.ToDecimal(txtRiskPerThousand.Text.Replace(",", ""));
                    objReinsure.FacultativeStatusId = Convert.ToInt32(ddlFacultativeStatus.SelectedValue);

                    objReinsure.FacultativeReinsuranceId = Convert.ToString(txtFacultativeReinsuranceId.Text);
                    objReinsure.ReinsuranceFacultativeStatus = true;
                    objReinsure.UserId = Service.Underwriter_Id;

                    if (!String.IsNullOrEmpty(hdDateRequested.Value))
                        objReinsure.RequestedDate = Convert.ToDateTime(hdDateRequested.Value);

                    if (ddlFacultativeStatus.SelectedItem.Text.ToLower().Equals("requested"))
                        objReinsure.RequestedDate = DateTime.Now;

                    if (!String.IsNullOrEmpty(hdDateApproved.Value))
                        objReinsure.ProcessedDate = Convert.ToDateTime(hdDateApproved.Value);

                    if (ddlFacultativeStatus.SelectedItem.Text.ToLower().Equals("approved"))
                        objReinsure.ProcessedDate = DateTime.Now;

                    Services.PolicyManager.SetReninsuranceFacultative(objReinsure);

                    for (int i = 0; i < gvRiders.Rows.Count; i++)
                    {
                        if (!Convert.ToString(gvRiders.DataKeys[i]["Coverage_Type_Desc"]).Equals(txtCoverageName.Text))
                        {
                            Policy.ReinsuranceFacultative objReinsure2 = new Policy.ReinsuranceFacultative();
                            objReinsure2.CorpId = Service.Corp_Id;
                            objReinsure2.RegionId = Service.Region_Id;
                            objReinsure2.CountryId = Service.Country_Id;
                            objReinsure2.DomesticregId = Service.Domesticreg_Id;
                            objReinsure2.StateProvId = Service.State_Prov_Id;
                            objReinsure2.CityId = Service.City_Id;
                            objReinsure2.OfficeId = Service.Office_Id;
                            objReinsure2.CaseSeqNo = Service.Case_Seq_No;
                            objReinsure2.HistSeqNo = Service.Hist_Seq_No;

                            objReinsure2.CoverageTypeDesc = Convert.ToString(gvRiders.DataKeys[i]["Coverage_Type_Desc"]);
                            objReinsure2.BeneficiaryAmount = Convert.ToDecimal((gvRiders.DataKeys[i]["Beneficiary_Amount"]));
                            //objReinsure.CompanyRiskAmount = Convert.ToDecimal(txtCompanyRiskAmountDet.Text.Replace(",", ""));
                            //objReinsure.ReinsuranceRiskAmount = Convert.ToDecimal(txtReinRiskAmountDet.Text.Replace(",", ""));
                            //objReinsure.AuthorizedAmount = Convert.ToDecimal(txtTotalAmountAuthDet.Text.Replace(",", ""));
                            objReinsure2.RiskRatingTable = Convert.ToString(gvRiders.DataKeys[i]["Risk_Rating"]);
                            objReinsure2.PerThousendRiskAmount = Convert.ToDecimal(gvRiders.DataKeys[i]["Per_Thousend_Risk_Amount"]);
                            objReinsure2.FacultativeStatusId = Convert.ToInt32(gvRiders.DataKeys[i]["Facultative_Status_Id"]);

                            if (string.IsNullOrEmpty(Convert.ToString(gvRiders.DataKeys[i]["Facultative_Reinsurance_Id"])))
                            {
                                string IdTemp = Convert.ToString((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "/" + objReinsure2.CaseSeqNo + "/29,06.89/" + Guid.NewGuid().ToString()));
                                //Bmarroquin 13-05-17
                                objReinsure2.FacultativeReinsuranceId = txtFacultativeReinsuranceId.Text;//IdTemp;  
                            }
                            else
                            {
                                objReinsure2.FacultativeReinsuranceId = Convert.ToString(gvRiders.DataKeys[i]["Facultative_Reinsurance_Id"]);
                            }

                            objReinsure2.ReinsuranceFacultativeStatus = true;
                            objReinsure2.UserId = Service.Underwriter_Id;

                            if(!string.IsNullOrEmpty(Convert.ToString(gvRiders.DataKeys[i]["Requested_Date"])))
                            {
                                objReinsure2.RequestedDate = Convert.ToDateTime(gvRiders.DataKeys[i]["Requested_Date"]);
                            }
                            if (!string.IsNullOrEmpty(Convert.ToString(gvRiders.DataKeys[i]["Processed_Date"])))
                            {
                                objReinsure2.ProcessedDate = Convert.ToDateTime(gvRiders.DataKeys[i]["Processed_Date"]);
                            }

                            Services.PolicyManager.SetReninsuranceFacultative(objReinsure2);
                        }
                    }

                    FillData();

                    ControlDisabled();
                }
                else
                {
                    var Msgarray = msgError.ToString().Split('\n');
                    var msg = string.Empty;

                    foreach (var item in Msgarray)
                        if (!string.IsNullOrEmpty(item))
                            msg += item.Replace("\r", "") + "<br/>" + "<br/>";

                    this.MessageBox(msg.ToString(), Title: RESOURCE.UnderWriting.Underwriting.Resources.Warning);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("UK_FACULTATIVE_REINSURANCE_ID_BY_COMPANY"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('FACULTATIVE ID already exists', 500, 150, true, 'Error');", true);
                    return;
                }
            }
            //fin wcastro 26-04-2017
        }

        //wcastro 26-04-2017
        private bool controlValidate(out StringBuilder error)
        {
            bool isValid = true;
            StringBuilder stringError = new StringBuilder();

            #region Validacion que esten habilitados los botones

            //------------------------------------Process
            if (ddlFacultativeStatus.Enabled == false)
            { 
                isValid = false;
                stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.FacultativeStatusRequired);
            }
            //------------------------------------Amount Distribution
            //if (txtCompanyRiskAmountDet.Enabled == false)
            //{
            //    isValid = false;
            //    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.CompanyRiskRequired);
            //}
            //if (txtReinRiskAmountDet.Enabled == false)
            //{
            //    isValid = false;
            //    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.ReinsuranceRiskRequired);
            //}
            #endregion

            #region Validacion que no esten vacios los controles
            if (isValid)
            {
                //------------------------------------Process
                if (ddlFacultativeStatus.SelectedIndex <= -1)
                {
                    isValid = false;
                    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.FacultativeStatusRequired);
                }
                //------------------------------------Coverage Informacion
                if (string.IsNullOrEmpty(txtCoverageName.Text))
                {
                    isValid = false;
                    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.CoverageNameRequired);
                }
                if (string.IsNullOrEmpty(txtCoverageAmount.Text))
                {
                    isValid = false;
                    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.CoverageAmountRequired);
                }
                //------------------------------------Risk Rating
                if (ddlRiskRatingPercents.SelectedIndex <= -1)
                {
                    isValid = false;
                    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.RiskRequired);
                }
                //if (string.IsNullOrEmpty(txtRiskPerThousand.Text))
                //{
                //    isValid = false;
                //    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.PerThousandRequired);
                //}
                if (string.IsNullOrEmpty(txtFacultativeReinsuranceId.Text))
                {
                    isValid = false;
                    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.FacultativeIdRequired);
                }
            }
            #endregion

            //Bmarroquin 13-05-2017, Validar que el Id Facultativo no se repita en otras cotizaciones, se quito la UniqueConstraint
            #region Otras Validaciones Necesarias
            if (string.IsNullOrEmpty(txtFacultativeReinsuranceId.Text) == false)
            {
                string lStr_Result = Service.getIsValidFacultativeID(Service.Case_Seq_No, txtFacultativeReinsuranceId.Text);
                if (string.IsNullOrWhiteSpace(lStr_Result))
                {
                    isValid = false;
                    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.msjGeneralError);                    
                }
                else
                {
                    if (lStr_Result == "0")
                    {
                        isValid = false;
                        stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.msjFacultativeIdNoValid);
                    }
                }
               
            }
            #endregion
            //Fin Bmarroquin 13-05-2017

            error = stringError;

            return isValid;
        }
        
        private bool bussinesValidate(out StringBuilder error)
        {
            bool isValid = true;
            StringBuilder stringError = new StringBuilder();

            //decimal valueCompanyRisk = String.IsNullOrEmpty(Convert.ToString(txtCompanyRiskAmountDet)) ? 0 : Convert.ToDecimal(txtCompanyRiskAmountDet.Text.Replace(",", ""));
            //decimal valueReinRiskAmountDet = String.IsNullOrEmpty(Convert.ToString(txtReinRiskAmountDet)) ? 0 : Convert.ToDecimal(txtReinRiskAmountDet.Text.Replace(",", ""));

            //decimal sumValues = valueCompanyRisk + valueReinRiskAmountDet;

            //decimal valueTotalAmountAuthDet = String.IsNullOrEmpty(Convert.ToString(txtTotalAmountAuthDet)) ? 0 : Convert.ToDecimal(txtTotalAmountAuthDet.Text.Replace(",", ""));

            //if(sumValues > valueTotalAmountAuthDet)
            //{
            //    isValid = false;
            //    stringError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.SumAmountToAuthorizeDontMatch);
            //}

            error = stringError;
            return isValid;
        }

        private bool validateToEdit(int pFacultativeStatusId)
        {
            var msgError = new StringBuilder();
            bool isValid = true;

            //wcastro 14-05-2017
            //if ((pFacultativeStatusId == 4) || (Convert.ToInt32(hdPolicyStatusId.Value) != 5))//Si ya se proceso el reaseguro o si la poliza ya no esta en pendiente se va a denegar
            if (Convert.ToInt32(hdPolicyStatusId.Value) != 5)//Si la poliza ya no esta en pendiente se va a denegar
            //fin wcastro 14-05-2017
            {
                msgError.AppendLine(RESOURCE.UnderWriting.Underwriting.Resources.ReinsuranceDontApplies);
                isValid = false;
            }

            if (!isValid)
            {
                var Msgarray = msgError.ToString().Split('\n');
                var msg = string.Empty;

                foreach (var item in Msgarray)
                    if (!string.IsNullOrEmpty(item))
                        msg += item.Replace("\r", "") + "<br/>" + "<br/>";

                this.MessageBox(msg.ToString(), Title: RESOURCE.UnderWriting.Underwriting.Resources.Warning);
            }

            return isValid;
        }

        //fin wcastro 26-04-2017

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //editMode();
            //clearFields();
            FillData();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ViewState["SelectedIndex"] = index;

            //wcastro 28-04-2017
            int mFacultativeStatusId = Convert.ToInt32(Convert.ToString(gvRiders.DataKeys[index]["Facultative_Status_Id"]));
            //ddlFacultativeStatus.SelectedValue = (gvRiders.DataKeys[index]["Facultative_Status_Id"]).ToString();

            bool isValid = false;

            isValid = validateToEdit(mFacultativeStatusId);

            if (isValid)
            {
                ddlFacultativeStatus.SelectedValue = mFacultativeStatusId.ToString();
                //fin wcastro 28-04-2017
                txtCoverageName.Text = (gvRiders.DataKeys[index]["Coverage_Type_Desc"]).ToString();
                txtCoverageAmount.Text = Decimal.Parse((gvRiders.DataKeys[index]["Beneficiary_Amount"]).ToString()).ToString("N");
                txtTotalAmtInsured.Text = Decimal.Parse((gvRiders.DataKeys[index]["Total_Amount_Insured"]).ToString()).ToString("N2");
                //wcastro 26-04-2017
                //txtCompanyRiskAmountDet.Text = (gvRiders.DataKeys[index]["Company_Risk_Amount"]).ToString();
                //txtCompanyRiskAmountDet.Text = Convert.ToDecimal((gvRiders.DataKeys[index]["Company_Risk_Amount"]).ToString()).ToString("N");
                //txtReinRiskAmountDet.Text = (gvRiders.DataKeys[index]["Reinsurance_Risk_Amount"]).ToString();
                //txtReinRiskAmountDet.Text = Convert.ToDecimal((gvRiders.DataKeys[index]["Reinsurance_Risk_Amount"]).ToString()).ToString("N");
                //txtTotalAmountAuthDet.Text = ((gvRiders.DataKeys[index]["Authorized_Amount"])??"0").ToString();
                //txtTotalAmountAuthDet.Text = Convert.ToDecimal(((gvRiders.DataKeys[index]["Authorized_Amount"]) ?? "0").ToString()).ToString("N");
                //wcastro 18-05-2017
                //ddlRiskRatingPercents.SelectedItem.Text = (gvRiders.DataKeys[index]["Risk_Rating"]).ToString();
                ddlRiskRatingPercents.SelectedValue = ddlRiskRatingPercents.Items.FindByText((Convert.ToString(gvRiders.DataKeys[index]["Risk_Rating"]))).Value;
                //fin wcastro 18-05-2017
                //txtRiskPerThousand.Text = (gvRiders.DataKeys[index]["Per_Thousend_Risk_Amount"]).ToString();
                txtRiskPerThousand.Text = Convert.ToDecimal((gvRiders.DataKeys[index]["Per_Thousend_Risk_Amount"]).ToString()).ToString("N");

                if(!Convert.ToString(gvRiders.DataKeys[index]["Facultative_Reinsurance_Id"]).Contains("29,06.89"))
                    txtFacultativeReinsuranceId.Text = Convert.ToString(gvRiders.DataKeys[index]["Facultative_Reinsurance_Id"]);

                hdDateRequested.Value = Convert.ToString(gvRiders.DataKeys[index]["Requested_Date"]);
                hdDateApproved.Value = Convert.ToString(gvRiders.DataKeys[index]["Processed_Date"]);

                ControlEnabled();

                //txtTotalAmountAuthDet.Text = (Convert.ToDecimal(hdFacultativeAmount.Value) - Convert.ToDecimal(hdBenefitAmount.Value)).ToString("N"); 
            }
            //fin wcastro 26-04-2017


            //btnCancel.Enabled = true;
            //pnBtnCancel.Attributes.Add("class", "boton_wrapper gradient_RJ bdrRJ fr");

            //fillDdl(true, null);

            //ddlRiderType.SelectedValue = (gvRiders.DataKeys[index]["RiderTypeId"]).ToString();

            //txtBeneficiaryAmount.Text = (gvRiders.DataKeys[index]["BeneficiaryAmount"] == null ? 0 : gvRiders.DataKeys[index]["BeneficiaryAmount"]).ToString();
            //txtNumberOfYear.Text = (gvRiders.DataKeys[index]["NumberOfYear"] == null ? 0 : gvRiders.DataKeys[index]["NumberOfYear"]).ToString();

            //txtExtraPremiumComment.Text = gvRiders.DataKeys[index]["ExtraPremiumCommentCompleted"] == null ? "" : gvRiders.DataKeys[index]["ExtraPremiumCommentCompleted"].ToString();

            //ddlStatus.SelectedValue = (gvRiders.DataKeys[index]["RiderStatusId"]).ToString();

            //txtEffectiveDate.Text = gvRiders.DataKeys[index]["EffectiveDate"] == null ? "" : Convert.ToDateTime((gvRiders.DataKeys[index]["EffectiveDate"]).ToString()).ToString("MM/dd/yyyy");

            //saveEditMode();
            //readOnlyMode(false);
            //ValidateRyderType();
        }

        //wcastro 26-04-2017
        private void ControlEnabled()
        {
            //Process
            ddlFacultativeStatus.Enabled = true;

            //Coverage Informacion
            txtFacultativeReinsuranceId.Enabled = true;

            //Amount Distribution
            //txtCompanyRiskAmountDet.Enabled = true;
            //txtReinRiskAmountDet.Enabled = true;

            //Risk Rating
            ddlRiskRatingPercents.Enabled = true;
            txtRiskPerThousand.Enabled = true;
        }

        private void ControlDisabled()
        {
            //Process
            ddlFacultativeStatus.Enabled = false;
            ddlFacultativeStatus.SelectedIndex = -1;

            //Coverage Informacion
            //wcastro 18-05-2017
            txtCoverageName.Text = string.Empty;
            txtCoverageAmount.Text = "0.00";
            txtTotalAmtInsured.Text = "0.00";
            //fin wcastro 18-05-2017
            txtFacultativeReinsuranceId.Enabled = false;
            txtFacultativeReinsuranceId.Text = string.Empty;

            //Amount Distribution
            //txtCompanyRiskAmountDet.Enabled = false;
            //txtReinRiskAmountDet.Enabled = false;
            //txtTotalAmountAuthDet.Enabled = false;

            //txtCompanyRiskAmountDet.Text = string.Empty;
            //txtReinRiskAmountDet.Text = string.Empty;
            //txtTotalAmountAuthDet.Text = string.Empty;

            //Risk Rating
            ddlRiskRatingPercents.Enabled = false;
            txtRiskPerThousand.Enabled = false;

            ddlRiskRatingPercents.SelectedIndex = -1;
            //wcastro 18-05-2017
            //txtRiskPerThousand.Text = string.Empty;
            txtRiskPerThousand.Text = "0.00";
            //fin wcastro 18-05-2017
        }

        //fin wcastro 26-04-2017

        protected void btnSRAttachDoc_Click(object sender, EventArgs e)
        {
            var reloadGrid = false;

            foreach (GridViewRow gvRow in gvSRPolicyDocument.Rows)
            {
                var chkAttach = (CheckBox)gvRow.FindControl("chkAttach");

                if (!chkAttach.Checked) continue;
                var docCategoryId = int.Parse(gvSRPolicyDocument.DataKeys[gvRow.RowIndex]["DocCategoryId"].ToString());
                var docTypeId = int.Parse(gvSRPolicyDocument.DataKeys[gvRow.RowIndex]["DocTypeId"].ToString());
                var documentId = int.Parse(gvSRPolicyDocument.DataKeys[gvRow.RowIndex]["DocumentId"].ToString());

                reloadGrid = AttachPolicyDocs(docCategoryId, docTypeId, documentId, true);
            }

            if (!reloadGrid) return;
            FillAttachmentsGrid();
            FillDocumentsFromDrops();
        }

        protected void btnSRRemoveAttachment_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var docId = int.Parse(gvSREmailSendAttachments.DataKeys[gridRow.RowIndex]["DocCountId"].ToString());

            var tempList = new List<Tools.EmailAttachmentItem>(EmailAttachmentList);
            tempList.Remove(tempList.First(r => r.DocCountId == docId));
            EmailAttachmentList = tempList;

            FillAttachmentsGrid();
            FillDocumentsFromDrops();
            lblSRTotalSize.Text = "Total Size: " + EmailAttachmentList.Sum(r => r.DocSize).ToString("N2") + "MB";
        }

        private void FillDrops(Tools.PolicyKeyItem policyItem = null, Boolean FillPolicies = true)
        {
            if (policyItem == null)
            {
                policyItem = new Tools.PolicyKeyItem()
                {
                    CorpId = Service.Corp_Id,
                    RegionId = Service.Region_Id,
                    CountryId = Service.Country_Id,
                    DomesticregId = Service.Domesticreg_Id,
                    StateProvId = Service.State_Prov_Id,
                    CityId = Service.City_Id,
                    OfficeId = Service.Office_Id,
                    CaseSeqNo = Service.Case_Seq_No,
                    HistSeqNo = Service.Hist_Seq_No

                };
            }

            ddlRiskRatingPercents.DataSource = Service.GetRatingRisk(null).Select(l => new ListItem { Text = l.Long_Description, Value = l.Rating_Value.GetValueOrDefault().ToString() });
            ddlRiskRatingPercents.DataBind();

            ddlFacultativeStatus.DataSource = Service.GetReinsuranceFacultativeStatus().Select(l=> new ListItem { Text = l.Name_Key, Value = l.Facultative_Status_Id.ToString() });
            ddlFacultativeStatus.DataBind();
            if (FillPolicies)
            {
                //Contact Policies
                ddlSRPolicy.DataSource = Service.DropDowns.GetDropDown(
                    DropDownType.OwnerPolicy, 
                    contactId: Service.Contact_Id, 
                    corpId: Service.Corp_Id,
                    regionId: Service.Region_Id,
                    countryId: Service.Country_Id,
                    domesticregId: Service.Domesticreg_Id,
                    stateProvId: Service.State_Prov_Id,
                    cityId:Service.City_Id,
                    officeId:Service.Office_Id,
                    caseSeqNo:Service.Case_Seq_No,
                    histSeqNo:Service.Hist_Seq_No,
                    projectId: Service.ProjectId,
                    companyId: Service.CompanyId);
                ddlSRPolicy.DataBind();

                if (ddlSRPolicy != null)
                    ddlSRPolicy.SelectedValue = ddlSRPolicy.Items.FindByText(Service.Policy_Id).Value;
            }

            //Document Categories
            Service.DropDowns.GetDropDown(ref ddlSRDocumentTypes, Language.English, DropDownType.PolicyDocument,
                policyItem.CorpId,
                policyItem.RegionId,
                policyItem.CountryId,
                policyItem.DomesticregId,
                policyItem.StateProvId,
                policyItem.CityId,
                policyItem.OfficeId,
                policyItem.CaseSeqNo,
                policyItem.HistSeqNo, projectId: Service.ProjectId, companyId: Service.CompanyId);
        }

        void setPagerIndex(GridView gv)
        {
            if (gv.BottomPagerRow != null)
            {
                var lnkPrev = (Button)gv.BottomPagerRow.FindControl("prevButton");
                var lnkFirst = (Button)gv.BottomPagerRow.FindControl("firstButton");
                var lnkNext = (Button)gv.BottomPagerRow.FindControl("nextButton");
                var lnkLast = (Button)gv.BottomPagerRow.FindControl("lastButton");
                var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
                var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


                var count = gv.PageCount;
                var index = gv.PageIndex + 1;

                indexText.Text = index.ToString();
                totalText.Text = count.ToString();

                if (index == 1)
                {
                    DisableLinkButton(lnkPrev, "prev_dis");
                    DisableLinkButton(lnkFirst, "rewd_dis");
                }
                else if (index == count)
                {
                    DisableLinkButton(lnkNext, "next_dis");
                    DisableLinkButton(lnkLast, "fwrd_dis");
                }
            }
        }

        public void DisableLinkButton(Button linkButton, string disable_class)
        {
            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }

        protected void btnSRViewEmailAttach_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var docId = int.Parse(gvSREmailSendAttachments.DataKeys[gridRow.RowIndex]["DocCountId"].ToString());
            var doc = EmailAttachmentList.First(r => r.DocCountId == docId);

            PreviewDoc(Tools.ReadBinaryFile(doc.FilePath));
        }

        protected void fuSRUploadFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            var message = "";
            try
            {
                var file = e.UploadedFile;
                if (file.IsValid)
                {
                    var fileName = Tools.GetSerialId() + "~~" + file.FileName.Trim();
                    var savePath = Service.TempFilePath + "\\" + fileName;
                    file.SaveAs(savePath);

                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", fileName, "");
                }
                else
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
            }
            catch (Exception ex)
            {
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }
            e.CallbackData = message;
        }

        private void FillDocumentsFromDrops()
        {
            var policyArray = ddlSRPolicy.SelectedValue.Split('|');

            var policyKey = new Tools.PolicyKeyItem()
            {
                CorpId = int.Parse(policyArray[0]),
                RegionId = int.Parse(policyArray[1]),
                CountryId = int.Parse(policyArray[2]),
                DomesticregId = int.Parse(policyArray[3]),
                StateProvId = int.Parse(policyArray[4]),
                CityId = int.Parse(policyArray[5]),
                OfficeId = int.Parse(policyArray[6]),
                CaseSeqNo = int.Parse(policyArray[7]),
                HistSeqNo = int.Parse(policyArray[8])
            };

            var docHasValue = ddlSRDocumentTypes.SelectedIndex > 0;
            var docArray = ddlSRDocumentTypes.SelectedValue.Split('|');

            var docTypeId = docHasValue ? int.Parse(docArray[0]) : (int?)null;
            var docCategoryId = docHasValue ? int.Parse(docArray[1]) : (int?)null;

            FillDocumentsData(policyKey, docCategoryId, docTypeId);
        }

        private void PreviewDoc(Byte[] documentBinary)
        {
            UCPdfViewer1.LoadPdf(documentBinary, new Unit(1185, UnitType.Pixel), new Unit(709, UnitType.Pixel));
            hdnNSShowPDFPop.Value = "true";
        }

        protected void btnSRSaveUploadedAttach_Click(object sender, EventArgs e)
        {
            var savePath = Service.TempFilePath + "\\" + hdnSRUploadedFile.Value;
            if (String.IsNullOrWhiteSpace(hdnSRUploadedFile.Value))
            {
                this.MessageBox("There is not document to save", 500, 150, true, "Empty Document");
                return;
            }
            var fileInfo = new FileInfo(savePath);

            var origFileName = fileInfo.Name.Split(new string[] { "~~" }, StringSplitOptions.None)[1];

            var fileSize = fileInfo.Length;
            var fileName = Tools.GetFileNameWithoutExt(origFileName);
            var fileExt = fileInfo.Extension;

            var emailAttachItem = new Tools.EmailAttachmentItem()
            {
                DocCountId = EmailAttachmentList.Count + 1,
                DocName = fileName,
                DocExtension = fileExt,
                DocSize = (Decimal.Parse(fileSize.ToString()) / Decimal.Parse("1048576")),
                FilePath = savePath,
                FileTypeId = Tools.GetFileTypeFromExt(fileExt)
            };

            var tempList = new List<Tools.EmailAttachmentItem>(EmailAttachmentList);
            tempList.Add(emailAttachItem);
            EmailAttachmentList = tempList;

            //Reload Grids
            FillAttachmentsGrid();
            lblSRTotalSize.Text = "Total Size: " + EmailAttachmentList.Sum(r => r.DocSize).ToString("N2") + "MB";
            hdnSRUploadedFile.Value = "";
        }

        private void ClearEmailInfo()
        {
            EmailAttachmentList = new List<Tools.EmailAttachmentItem>();
            txtSRSendEmail.Text = "";
            //wcastro 13-05-2017
            //txtSRSendRecipients.Text = "";
            //fin wcastro 13-05-2017
            txtSRSendSubject.Text = "";

            FillAttachmentsGrid();
            FillDocumentsFromDrops();
            lblSRTotalSize.Text = "Total Size: 0.00MB";
        }

        private void FillStepInfo(Reinsurance.StepAvailable stepInfo)
        {
            _StepCaseNo = stepInfo.StepCaseNo;
            _StepId = stepInfo.StepId;
            _StepTypeId = stepInfo.StepTypeId;
            _StepSeqReference = stepInfo.StepSeqReference;
            _ReinsurerId = stepInfo.ReinsurerId;
            _CommTypeId = stepInfo.CommTypeId;
            _EmailRecipient = stepInfo.ReinsurerEmail;
            txtSRSendRecipients.Text = stepInfo.ReinsurerEmail;
        }

        private bool AttachPolicyDocs(int docCategoryId, int docTypeId, int documentId, bool showMessage = false)
        {
            var doc = Service.GetCommDocument(docCategoryId, docTypeId, documentId);

            if (doc.DocumentBinary == null)
            {
                if (showMessage)
                    this.MessageBox("This document is Empty, please try with another one.", 500, 150, true, "Empty Document");
                return false;
            }

            var fileName = Tools.GetFileNameWithoutExt(doc.DocumentName);
            var savePath = Service.TempFilePath + "\\" + Tools.GetSerialId() + "~~" + fileName + doc.Extension;
            var fileSize = doc.DocumentBinary.SaveByteToFile(savePath);

            var emailAttachItem = new Tools.EmailAttachmentItem()
            {
                DocCountId = EmailAttachmentList.Count + 1,
                DocumentId = documentId,
                DocCategoryId = docCategoryId,
                DocTypeId = docTypeId,
                DocName = fileName,
                DocExtension = doc.Extension,
                DocSize = (Decimal.Parse(fileSize.ToString()) / Decimal.Parse("1048576")),
                FilePath = savePath,
                FileTypeId = Tools.GetFileTypeFromExt(doc.Extension),
            };

            var tempList = new List<Tools.EmailAttachmentItem>(EmailAttachmentList) { emailAttachItem };
            EmailAttachmentList = tempList;

            lblSRTotalSize.Text = "Total Size: " + EmailAttachmentList.Sum(r => r.DocSize).ToString("N2") + "MB";
            return true;
        }

        private void GetRequirementDocs()
        {
            var requirementData = Services.RequirementManager.GetAll(
                 Service.Corp_Id
               , Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id
               , Service.Case_Seq_No, Service.Hist_Seq_No, Service.LanguageId
               ).Where(r => r.SendToReinsurance).ToList();

            foreach (var recDoc in from recDoc in requirementData where recDoc.DocCategoryId != null where recDoc.DocTypeId != null where recDoc.DocumentId != null select recDoc)
                AttachPolicyDocs(recDoc.DocCategoryId.Value, recDoc.DocTypeId.Value, recDoc.DocumentId.Value);
        }

        //Bmarroquin 13-05-2017
        protected void btnGuardarDocReaseguro_Click(object sender, EventArgs e)
        {
            if (gvSREmailSendAttachments != null)
            {
                if (gvSREmailSendAttachments.Rows.Count > 0)
                {
                    var commAttachmentsList = new List<Reinsurance.Communication>();

                    foreach (GridViewRow gvRow in gvSREmailSendAttachments.Rows)
                    {
                        var TempDocId = int.Parse(gvSREmailSendAttachments.DataKeys[gvRow.RowIndex]["DocCountId"].ToString());
                        var doc = EmailAttachmentList.First(r => r.DocCountId == TempDocId);
                        

                        var docId = Services.PolicyManager.SetDocument( doc.FileTypeId.Value,
                                                                        270 /*Reinsurance Document*/,
                                                                        -1,
                                                                        Tools.ReadBinaryFile(doc.FilePath),
                                                                        doc.DocName,
                                                                        DateTime.Now,
                                                                        null,
                                                                        Service.Underwriter_Id
                                                                        );

                        var commAttachItem = new Reinsurance.Communication()
                        {
                            //Key
                            CommunicationId = -1, //ComunicationID -1 esto permite guardar Files en la tabla asociativa sin que hagan Ruido en otros procesos 
                            StepCaseNo = 1,
                            StepId = 61,
                            StepTypeId = 1,

                            //Document Info
                            DocumentId = docId,
                            DocCategoryId = 270 /*Reinsurance Document*/,
                            DocTypeId = doc.FileTypeId.Value,

                            //UserInfo
                            UserId = Service.Underwriter_Id
                        };

                        commAttachmentsList.Add(commAttachItem);


                        //Remover de la variable de session, EmailAttachmentList el item Documento para que ya no aparezca en el grid de temporales
                        var tempList = new List<Tools.EmailAttachmentItem>(EmailAttachmentList);
                        tempList.Remove(tempList.First(r => r.DocCountId == TempDocId));
                        EmailAttachmentList = tempList;

                    }

                    lblSRTotalSize.Text = "Total Size: " + EmailAttachmentList.Sum(r => r.DocSize).ToString("N2") + "MB";

                    //Bmarroquin 15-05-2017 Hasta que se ejecuta esto se guarda el Documento en la BD 
                    if (commAttachmentsList.Any())
                        Service.SetReinsuranceCommunicationAttachment(commAttachmentsList);


                    //Refrescar los grid para que en el de arriba aparezca el nuevo documento y en el de abajo ya no aparezca !!
                    FillAttachmentsGrid();
                    FillDocumentsFromDrops();

                }
            }
        }

        //wcastro 16-05-2017
        protected void replaySend_Click(object sender, EventArgs e)
        {
            if (commData != null && !string.IsNullOrEmpty(Convert.ToString(commData.Select(x => x.CommText).FirstOrDefault())))
            {
                List<Attachment> lstAtt = new List<Attachment>();
                if (gvEmailAttachments.Rows.Count > 0)
                {
                    for (int i = 0; i < gvEmailAttachments.Rows.Count; i++)
                    {
                        var docCategoryIdd = Convert.ToInt32(gvEmailAttachments.DataKeys[i]["DocCategoryId"]);
                        var docTypeIdd = Convert.ToInt32(gvEmailAttachments.DataKeys[i]["DocTypeId"]);
                        var documentIdd = Convert.ToInt32(gvEmailAttachments.DataKeys[i]["DocumentId"]);
                        var docName = Convert.ToString(gvEmailAttachments.DataKeys[i]["DocumentName"]);
                        var docExtension = Convert.ToString(gvEmailAttachments.DataKeys[i]["Extension"]);

                        var docc = Service.GetCommDocBinary(docCategoryIdd, docTypeIdd, documentIdd);

                        Attachment attt = new Attachment(new MemoryStream(docc), docName + docExtension);

                        lstAtt.Add(attt);

                    }
                }

                try
                {
                    MailManager.SendMessage(_EmailRecipient,
                                     "",
                                     "",
                                     Convert.ToString(commData.Select(x => x.CommText).FirstOrDefault()),
                                     "",
                                     Convert.ToString(commData.Select(x => x.CommFrom).FirstOrDefault()),
                                     Convert.ToString(commData.Select(x => x.CommSubject).FirstOrDefault()),
                                     false,
                                     Service.SmtpServer, "", "", "", lstAtt);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('" + ex.InnerException.Message.ToString() + "', 500, 150, true, 'Error');", true);
                    return;
                }

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('E-mail sent successfully!', 500, 150, true, 'Alert');", true);
                return;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('Email Body cant be empty, please try again.', 500, 150, true, 'Required Field');", true);
                return;
            }
        }
        //fin wcastro 15-05-2017
    }
}