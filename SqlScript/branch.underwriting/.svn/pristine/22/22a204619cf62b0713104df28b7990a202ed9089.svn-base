using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Workflow
{
    public partial class UCWorkFlow : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {


        //public enum Tools.WorkFlowTypes
        //{
        //    ReadyForUnderWriting = 41,
        //    PaymentReview = 57,
        //    BackgroundCheck = 20,
        //    ConfirmationCall = 12,
        //    WaitingForMedicalInfo = 61,
        //    Evaluation = 39,
        //    WaitingForClientInfo = 88,
        //    Reinsurance = 60,
        //    FinalReview = 71,
        //    Issuance=2,
        //    NeverIssued=1
        //};



        //IStep StepManager
        //{
        //    get { return diManager.StepManager; }
        //}

        //UnderWritingDIManager diManager = new UnderWritingDIManager();

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

        public void FillData()
        {
            var Workflow = Services.StepManager.GetWorkflow(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id,
              Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No);

            ltrReadyForUnderWriting.Text = "Approval";
            var DataApproval = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Approval);
            var statusApproval = DataApproval.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueApproval = statusApproval.ProcessStatus > 0 ? statusApproval.ProcessStatus : (int?)null;
            gvReadyForUnderWriting.DataSource = DataApproval;
            gvReadyForUnderWriting.DataBind();
            SetColorState(pnReadyForUnderWriting, lnkReadyForUnderWriting, statusValueApproval);
       

            ltrPaymentReview.Text = "Payment Review";
            var DataPaymentReview = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.PaymentReview);
            var statusPaymentReview = DataPaymentReview.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValuePaymentReview = statusPaymentReview.ProcessStatus > 0 ? statusPaymentReview.ProcessStatus : (int?)null;
            gvPaymentReview.DataSource = DataPaymentReview;
            gvPaymentReview.DataBind();
            SetColorState(pnPaymentReview, lnkPaymentReview, statusValuePaymentReview);

            ltrBackGroundCheck.Text = "BackgroundCheck";
            var DataBackgroundCheck = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.BackgroundCheck);
            var statusBackgroundCheck = DataBackgroundCheck.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueBackgroundCheck = statusBackgroundCheck.ProcessStatus > 0 ? statusBackgroundCheck.ProcessStatus : (int?)null;
            gvBackgroundCheck.DataSource = DataBackgroundCheck;
            gvBackgroundCheck.DataBind();
            SetColorState(pnBackgrounCheck, lnkBackgroundCheck, statusValueBackgroundCheck);

            ltrConfirmationCall.Text = "Confirmation Call";
            var DataConfirmationCall = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.ConfirmationCall);
            var statusConfirmationCall = DataConfirmationCall.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueConfirmationCall = statusConfirmationCall.ProcessStatus > 0 ? statusConfirmationCall.ProcessStatus : (int?)null;
            gvConfirmationCall.DataSource = DataConfirmationCall;
            gvConfirmationCall.DataBind();
            SetColorState(pnConfirmationCall, lnkConfirmationCall, statusValueConfirmationCall);


            ltrWaitingForMedicalInfo.Text = "Waiting for medical info";
            var DataWaitingformedicalinfo = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Waitingformedicalinfo);
            var statusWaitingformedicalinfo = DataWaitingformedicalinfo.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueWaitingformedicalinfo = statusWaitingformedicalinfo.ProcessStatus > 0 ? statusWaitingformedicalinfo.ProcessStatus : (int?)null;
            gvWaitingForMedicalInfo.DataSource = DataWaitingformedicalinfo;
            gvWaitingForMedicalInfo.DataBind();
            SetColorState(pnWaitingForMedicalInfo, lnkWaitingForMedicalInfo, statusValueWaitingformedicalinfo);

            ltrEvaluation.Text = "Evaluation";
            var DataEvaluation = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Evaluation);
            var statusEvaluation = DataEvaluation.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueEvaluation = statusEvaluation.ProcessStatus > 0 ? statusEvaluation.ProcessStatus : (int?)null;
            gvEvaluation.DataSource = DataEvaluation;
            gvEvaluation.DataBind();
            SetColorState(pnEvaluation, lnkEvaluation, statusValueEvaluation);


            ltrWaitingForClientInfo.Text = "Waiting for Client information";
            var DataWaitingfoClientinformation = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.WaitingfoClientinformation);
            var statusWaitingfoClientinformation = DataWaitingfoClientinformation.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueWaitingfoClientinformation = statusWaitingfoClientinformation.ProcessStatus > 0 ? statusWaitingfoClientinformation.ProcessStatus : (int?)null;
            gvWaitingForClientInfo.DataSource = DataWaitingfoClientinformation;
            gvWaitingForClientInfo.DataBind();
            SetColorState(pnWaitingForClientInfo, lnkWaitingForClientInfo, statusValueWaitingfoClientinformation);

            ltrReinsurance.Text = "Reinsurance";
            var DataReinsurance = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Reinsurance);
            var statusReinsurance = DataReinsurance.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueReinsurance = statusReinsurance.ProcessStatus > 0 ? statusReinsurance.ProcessStatus : (int?)null;
            gvReinsurance.DataSource = DataReinsurance;
            gvReinsurance.DataBind();
            SetColorState(pnReinsurance, lnkReinsurance, statusValueReinsurance);

            ltrFinalReview.Text = "Final Review";
            var DataFinalReview = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.FinalReview);
            var statusFinalReview = DataFinalReview.OrderBy(w => w.Order).FirstOrDefault();
            int? statusValueFinalReview = statusFinalReview.ProcessStatus > 0 ? statusFinalReview.ProcessStatus : (int?)null;
            gvFinalReview.DataSource = DataFinalReview;
            gvFinalReview.DataBind();
            SetColorState(pnFinalReview, lnkFinalReview, statusValueFinalReview);


            //  ltrFinalReview.Text = "Never Issued";
            gvNeverIssued.DataSource = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.NeverIssued);
            gvNeverIssued.DataBind();
            //   SetColorState(pnFinalReview, lnkFinalReview, element.ProcessStatus);


            //.Text = "Issuance";
            gvIssuance.DataSource = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Issuance);
            gvIssuance.DataBind();
            //     SetColorState(pnFinalReview, lnkFinalReview, element.ProcessStatus);


        }


        /*      public void FillData()
              {
                  var Workflow = Services.StepManager.GetWorkflow(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id,
                    Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No);

                  List<Entity.UnderWriting.Entities.Step.WorkflowAction> actions = new List<Entity.UnderWriting.Entities.Step.WorkflowAction>();

                  var StepIdWorkFlow = Enum.GetValues(typeof(Tools.WorkFlowTypes)).Cast<Tools.WorkFlowTypes>();

                  foreach (int StepIdWF in StepIdWorkFlow)
                  {
                      var element = Workflow.Where(r => r.StepId == StepIdWF).FirstOrDefault();

                      switch (StepIdWF)
                      {
                          case (int)Tools.WorkFlowTypes.Approval:
                              ltrReadyForUnderWriting.Text = "Approval";
                              gvReadyForUnderWriting.DataSource = element.Actions;
                              gvReadyForUnderWriting.DataBind();

                              SetColorState(pnReadyForUnderWriting, lnkReadyForUnderWriting, element.ProcessStatus);

                              break;

                          case (int)Tools.WorkFlowTypes.PaymentReview:
                              ltrPaymentReview.Text = "Payment Review";
                              gvPaymentReview.DataSource = element.Actions;
                              gvPaymentReview.DataBind();

                              SetColorState(pnPaymentReview, lnkPaymentReview, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.BackgroundCheck:
                              ltrBackGroundCheck.Text = "BackgroundCheck";
                              gvBackgroundCheck.DataSource = element.Actions;
                              gvBackgroundCheck.DataBind();

                              SetColorState(pnBackgrounCheck, lnkBackgroundCheck, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.ConfirmationCall:
                              ltrConfirmationCall.Text = "Confirmation Call";
                              gvConfirmationCall.DataSource = element.Actions;
                              gvConfirmationCall.DataBind();

                              SetColorState(pnConfirmationCall, lnkConfirmationCall, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.Waitingformedicalinfo:
                              ltrWaitingForMedicalInfo.Text = "Waiting for medical info";
                              gvWaitingForMedicalInfo.DataSource = element.Actions;
                              gvWaitingForMedicalInfo.DataBind();

                              SetColorState(pnWaitingForMedicalInfo, lnkWaitingForMedicalInfo, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.Evaluation:
                              ltrEvaluation.Text = "Evaluation";
                              gvEvaluation.DataSource = element.Actions;
                              gvEvaluation.DataBind();

                              SetColorState(pnEvaluation, lnkEvaluation, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.WaitingfoClientinformation:
                              ltrWaitingForClientInfo.Text = "Waiting for Client information";
                              gvWaitingForClientInfo.DataSource = element.Actions;
                              gvWaitingForClientInfo.DataBind();

                              SetColorState(pnWaitingForClientInfo, lnkWaitingForClientInfo, element.ProcessStatus);
                              break;


                          case (int)Tools.WorkFlowTypes.Reinsurance:
                              ltrReinsurance.Text = "Reinsurance";
                              gvReinsurance.DataSource = element.Actions;
                              gvReinsurance.DataBind();

                              SetColorState(pnReinsurance, lnkReinsurance, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.FinalReview:
                              ltrFinalReview.Text = "Final Review";
                              gvFinalReview.DataSource = element.Actions;
                              gvFinalReview.DataBind();

                              SetColorState(pnFinalReview, lnkFinalReview, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.NeverIssued:
                              //  ltrFinalReview.Text = "Never Issued";
                              gvNeverIssued.DataSource = element.Actions;
                              gvNeverIssued.DataBind();

                              SetColorState(pnFinalReview, lnkFinalReview, element.ProcessStatus);
                              break;

                          case (int)Tools.WorkFlowTypes.Issuance:
                              //.Text = "Issuance";
                              gvIssuance.DataSource = element.Actions;
                              gvIssuance.DataBind();

                              SetColorState(pnFinalReview, lnkFinalReview, element.ProcessStatus);
                              break;

                          //case (int)Tools.WorkFlowTypes.NeverIssued:

                          //    if (element.Actions != null)
                          //        gvNeverIssued.DataSource = element.Actions;
                          //    else
                          //        gvNeverIssued.DataSource = actions;

                          //    gvNeverIssued.DataBind();
                          //    break;

                          //case (int)Tools.WorkFlowTypes.Issuance:

                          //    if (element.Actions != null)
                          //        gvIssuance.DataSource = element.Actions;
                          //    else
                          //        gvIssuance.DataSource = actions;

                          //    gvIssuance.DataBind();
                          //    break;



                      }


                  }



              }*/



        private void SetColorState(Panel panel, HyperLink hiperLink, int? state)
        {

            string LinkCssClass = "step_in rds10 tooltip3 ";
            string PanelCssClass = "step_name rds10 ";
            string PendingColor = "naranjaGR|naranjaGR_in";
            string CompleteColor = "verdeGR|verdeGR_in";
            string UnstateColor = "cremaGR|cremaGR_in";

            if (state == null)
            {

                panel.CssClass = PanelCssClass + UnstateColor.Split('|')[1];
                hiperLink.CssClass = LinkCssClass + UnstateColor.Split('|')[0];

            }
            else if (state == 1 || state == 3)
            {

                panel.CssClass = PanelCssClass + PendingColor.Split('|')[1];
                hiperLink.CssClass = LinkCssClass + PendingColor.Split('|')[0];


            }
            else
            {

                panel.CssClass = PanelCssClass + CompleteColor.Split('|')[1];
                hiperLink.CssClass = LinkCssClass + CompleteColor.Split('|')[0];


            }


        }

        public void clearData()
        {
            throw new NotImplementedException();
        }
    }
}