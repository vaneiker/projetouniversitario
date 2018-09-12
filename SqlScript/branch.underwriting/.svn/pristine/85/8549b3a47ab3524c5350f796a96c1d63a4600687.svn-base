using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
using Entity.UnderWriting.Entities; //Lgonzalez 13-05-2017
using System.Collections.Generic;
using WEB.UnderWriting.Case.UserControls.PersonalData; //Lgonzalez 13-05-2017

namespace WEB.UnderWriting.Case.UserControls.UnderwritingSteps
{
    public partial class UCPopStepComments : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        

        public UCUnderwritingStep UCUnderwritingSteps
        {
            get
            {
                return (UCUnderwritingStep)this.Parent.Parent.Parent;
            }
        }
        // UnderWritingDIManager diManager = new UnderWritingDIManager();
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
            throw new NotImplementedException();
        }

        public void FillData(Entity.UnderWriting.Entities.Step underStep)
        {
            var data = from d in Services.StepManager.GetAllNotes(underStep)
                       select new
                       {
                           d.StepId,
                           d.StepCaseNo,
                           d.StepTypeId,
                           d.OriginatedByName,
                           d.NoteDesc,
                           Date = (d.DateAdded.HasValue ? d.DateAdded.Value.ToString("MM/dd/yyyy") : (d.DateModified.HasValue ? d.DateModified.Value.ToString("MM/dd/yyyy") : "")),
                           Time = (d.DateAdded.HasValue ? d.DateAdded.Value.ToShortTimeString() : (d.DateModified.HasValue ? d.DateModified.Value.ToShortTimeString() : ""))
                       };

            gvUSComments.DataSource = data;
            gvUSComments.DataBind();

            //Save Step Key
            hdnStepId.Value = underStep.StepId.ToString();
            hdnStepCaseNo.Value = underStep.StepCaseNo.ToString();
            hdnStepTypeId.Value = underStep.StepTypeId.ToString();

            //Set buttons Visibility
            pnlBtnAddComment.Visible = underStep.ProcessStatus == 1;
            pnlBtnVoidStep.Visible = underStep.Voidable;
            pnlBtnCloseStep.Visible = underStep.Closable;
        }

        protected void btnUSCSave_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtUSCNewComment.Text.Trim()))
            {
                //Obtengo e inserto una nueva nota
                Services.StepManager.InsertNote(GetNewNote());

                if (hdnSaveCommentSender.Value.ToLower() != "comment")
                {
                    switch (hdnSaveCommentSender.Value.ToLower())
                    {
                        case "void":
                            Services.StepManager.VoidStep(GetCurrentStep());
                            break;

                        case "close":
                            if (GetCurrentStep().StepId == 61) //Lgonzalez 13-05-2017 --> Validando Facultative Status Id en las coberturas -- INICIO
                            {
                                Entity.UnderWriting.Entities.Policy.PlanData datos = Services.PolicyManager.GetPlanData(Service.Corp_Id,
                                                                                                    Service.Region_Id,
                                                                                                    Service.Country_Id,
                                                                                                    Service.Domesticreg_Id,
                                                                                                    Service.State_Prov_Id,
                                                                                                    Service.City_Id,
                                                                                                    Service.Office_Id,
                                                                                                    Service.Case_Seq_No,
                                                                                                    Service.Hist_Seq_No);

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
                                IEnumerable<Reinsurance.FacultativeDetails> facultativeDetails;
                                facultativeDetails = Services.PolicyManager.GetReinsuranceFacultativeDetails(facultativeDets);

                                if (facultativeDetails == null || !facultativeDetails.Any())
                                {
                                    var FacultativeStatus = Service.GetReinsuranceFacultativeStatus().Where(f => f.Facultative_Status_Id == 1).FirstOrDefault();
                                    riders.Add(new Rider
                                    {
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
                                        RyderTypeDesc = "Base Coverage",
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

                                List<Reinsurance.FacultativeDetails> dataFiltrada = facultativeDetails.Where(x => x.Facultative_Status_Id == 3 || x.Facultative_Status_Id == 2).ToList();

                                if (dataFiltrada.Count > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('There are even riders in Required or In Process status for Facultative Insurance', 500, 150, true, '" + RESOURCE.UnderWriting.Underwriting.Resources.Warning + "');", true);
                                    break;
                                }
                            } //Lgonzalez 13-05-2017 --> Validando Facultative Status Id en las coberturas -- FIN

                            if (GetCurrentStep().StepId == 102)
                            {
                                var note = GetNewNote();
                                bool? result = null;

                                if (!String.IsNullOrEmpty(ddlResultBgCheck.SelectedValue))
                                {
                                    result = bool.Parse(ddlResultBgCheck.SelectedValue);
                                }

                                var bgchk = new Policy.BackgroundCheck
                                {
                                    CorpId = note.CorpId,
                                    RegionId = note.RegionId,
                                    CountryId = note.CountryId,
                                    DomesticRegId = note.DomesticregId,
                                    StateProvId = note.StateProvId,
                                    CityId = note.CityId,
                                    OfficeId = note.OfficeId,
                                    CaseSeqNo = note.CaseSeqNo,
                                    HistSeqNo = note.HistSeqNo,
                                    ContactId = Service.Contact_Id,
                                    BackgroundCheckId = note.StepCaseNo,
                                    Reason = "-",
                                    Results = result,
                                    Date = DateTime.Now,
                                    Comments = note.NoteDesc,
                                    UserId = note.UserId

                                };

                                Services.PolicyManager.InsertBackgroundCheck(bgchk);


                                var left = Page.Master.FindControl("Left").FindControl("Left") as Common.Left;
                                left.FillData();
                            }

                            Services.StepManager.CloseStep(GetCurrentStep());
                            break;
                    }

                    if (UCUnderwritingSteps != null)
                        UCUnderwritingSteps.FillData(hdnStepTypeId.Value == "2");

                

                    HidePopUp();
                }
                else
                    //Recargo la información del grid para reflejar la nueva nota
                    FillData(GetCurrentStep());
            }
            else
                this.MessageBox(Message: "The field Comment is required, please try again.", Title: "Required Field");

            var rigth = (Common.Right)Page.Master.FindControl("Right").FindControl("Right");
            rigth.fillPointSteps();


        }

        /// <summary>
        /// Función para obtener un objeto tipo "Step" con la información actual
        /// </summary>
        /// <returns>Retorna un objeto tipo "Step"</returns>
        private Entity.UnderWriting.Entities.Step GetCurrentStep()
        {
            if (!String.IsNullOrEmpty(hdnStepCaseNo.Value) && !String.IsNullOrEmpty(hdnStepId.Value) && !String.IsNullOrEmpty(hdnStepTypeId.Value))
            {
                var stepId = int.Parse(hdnStepId.Value);
                var stepCaseNo = int.Parse(hdnStepCaseNo.Value);
                var stepTypeId = int.Parse(hdnStepTypeId.Value);

                var step = new Entity.UnderWriting.Entities.Step
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
                    LanguageId = Service.LanguageId,
                    UserId = Service.Underwriter_Id
                };

                return step;
            }
            else
                return new Entity.UnderWriting.Entities.Step();
        }

        /// <summary>
        /// Función para obtener una nueva nota
        /// </summary>
        /// <returns>Retorna un objeto tipo "Step.Note" con toda la informacion necesaria para agregar una nueva nota</returns>
        private Entity.UnderWriting.Entities.Step.Note GetNewNote()
        {
            if (!String.IsNullOrEmpty(hdnStepCaseNo.Value) && !String.IsNullOrEmpty(hdnStepId.Value) && !String.IsNullOrEmpty(hdnStepTypeId.Value))
            {
                var stepId = int.Parse(hdnStepId.Value);
                var stepCaseNo = int.Parse(hdnStepCaseNo.Value);
                var stepTypeId = int.Parse(hdnStepTypeId.Value);

                var step = new Entity.UnderWriting.Entities.Step.Note
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
                    NoteDesc = txtUSCNewComment.Text,
                    UserId = Service.Underwriter_Id,
                    OriginatedBy = Service.Underwriter_Id,
                    UnderwriterId = Service.Underwriter_Id
                };

                return step;
            }
            else
                return new Entity.UnderWriting.Entities.Step.Note();
        }

        private void HidePopUp()
        {
            var hdnPopVisible = (HiddenField)UCUnderwritingSteps.FindControl("hdnUSShowPopComments");
            hdnPopVisible.Value = "false";
        }
    }
}