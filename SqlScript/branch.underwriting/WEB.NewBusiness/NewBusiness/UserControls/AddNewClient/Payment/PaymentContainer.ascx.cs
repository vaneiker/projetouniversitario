using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Payment
{
    public partial class PaymentContainer : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WUCFormOfPayment.SelectPaymemtFormOfPaymentEvent += new WUCFormOfPayment.SelectPaymemtFormOfPayment(MethodSelectPaymemtForm);
            WUCFormOfPayment.RefreshPaymentInformationsEvent += new WUCFormOfPayment.RefreshPaymentInformations(refreshPayment);
            WUCPayment.PaymentProcessEvent += new WUCPayment.PaymentProcess(PaymentProcess);
        }

        public void ClearData() { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);


        }

        public void Translator(string Lang)
        {
            btnSubmitSTL.Text = Resources.SubmitToDataReview.ToUpper();

            if (isChangingLang)
                FillData();
        }

        public void save() { }
        public void edit() { }
        public void PaymentProcess()
        {
            WUCFormOfPayment.FillData();
        }

        public void refreshPayment()
        {
            WUCPayment.FillData();
        }

        public void FillData()
        {
            WUCFormOfPayment.FillData();
            WUCPayment.FillData();
        }

        public void Initialize()
        {
            WUCFormOfPayment.SelectPaymemtFormOfPaymentEvent += new WUCFormOfPayment.SelectPaymemtFormOfPayment(MethodSelectPaymemtForm);
            WUCFormOfPayment.RefreshPaymentInformationsEvent += new WUCFormOfPayment.RefreshPaymentInformations(refreshPayment);
            WUCPayment.PaymentProcessEvent += new WUCPayment.PaymentProcess(PaymentProcess);
            FillData();
            if (ObjServices.IsDataReviewMode && getisView)
                ReadOnlyControls(ObjServices.IsReadOnly);

        }

        /// <summary>
        /// AQUI CAMBIA LA PARTE DECHA DEPENDIENDO EL LA FORMA DE PAGO 
        /// Payment_Source_Id	Payment_Source_Desc
        /// 0	                Other
        /// 1	                ACH Domicile
        /// 2	                Credit Card Domicile
        /// 3	                Check
        /// 4	                Deposit
        /// 5	                Wire
        /// 6	                ACH One Time
        /// 7	                ACH Statetrust Bank Domicile
        /// 8	                ACH  Statetrust Bank One Time
        /// 9	                Credit Card One Time
        /// 10	                Wire Promise
        /// </summary>
        /// <param name="PaymentSourceId"></param>
        public void MethodSelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId)
        {
            WUCPaymentInformation.MethodSelectPaymemtForm(PaymentSourceId, PaymentSourceTypeId, PaymentControlId);
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            WUCFormOfPayment.ReadOnlyControls(isReadOnly);
            WUCPayment.ReadOnlyControls(isReadOnly);
        }

        protected void btnSubmitSTL_Click(object sender, EventArgs e)
        {
            var ListError = new List<Utility.Errors>();
            var ListMessage = new List<Utility.ListTabError>();
            var Message = new StringBuilder();

            var CountCasesError = 0;

            var Result = ObjServices.oCaseManager.SendToStl(new Case()
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                UserId = ObjIllustrationServices.IllusUserID.Value
            });

            if (!Result.Result)
            {
                CountCasesError++;

                var item = new Utility.Errors();
                var vErrors = Result.ResultMessage.Split(',');
                /*
                 1-Owner Info Tab no se ha completado
                 2-Plan/Policy Tab no se ha completado
                 3-Beneficiaries Tab no se ha completado
                 4-Requirements Tab no se ha completado
                 5-Health Declaration Tab no se ha completado
               */

                for (int x = 0; x < vErrors.Length; x++)
                {
                    switch (vErrors[x])
                    {
                        case "Client Info":
                            vErrors[x] = Resources.ClientInfoLabel;
                            break;
                        case "Owner Info":
                            vErrors[x] = Resources.OwnerInfoLabel;
                            break;
                        case "Plan/Policy":
                            vErrors[x] = Resources.PlanPolicyLabel;
                            break;
                        case "Beneficiaries":
                            vErrors[x] = Resources.BeneficiariesLabel;
                            break;
                        case "Requirements":
                            vErrors[x] = Resources.RequirementsLabel;
                            break;
                        case "Health Declaration":
                            vErrors[x] = Resources.HealthDeclarationLabel;
                            break;
                        case "Payment":
                            vErrors[x] = Resources.PaymentsLabel.Capitalize();
                            break;
                    }

                    item.MessageErrorList.Add((ObjServices.Language == Utility.Language.en) ? string.Concat((x + 1).ToString(), "-", vErrors[x], " ", RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted)
                                                                                            : string.Concat((x + 1).ToString(), "-", "El Tab de ", vErrors[x], " ", RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted2));

                }

                ListError.Add(item);

                foreach (var item2 in ListError)
                {
                    var temp = new Utility.ListTabError();
                    //temp.Policy = RESOURCE.UnderWriting.NewBussiness.Resources.ErrorPolicyNumber + " \"" + item2.Policy + ":\"" + "<br/>";
                    temp.Errors = string.Join("<br/>", item2.MessageErrorList.ToArray());
                    ListMessage.Add(temp);
                }

                Message.Append(CountCasesError.ToString("#,0") + " " + RESOURCE.UnderWriting.NewBussiness.Resources.CasesError);
                Message.Append("<br/>");

                foreach (var item2 in ListMessage)
                {
                    Message.Append(item2.Errors);
                    Message.Append("<br/>");
                }
                this.MessageBox(Message.ToString(), Width: 500, Height: 350, Title: RESOURCE.UnderWriting.NewBussiness.Resources.ErrorInCase);

            }
            else
            {
                //this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.CaseSentDataReview, Title: ObjServices.Language == Utility.Language.en ? "Information" : "Información");
                Response.Redirect("ReadyToReview.aspx");
            }
        }
    }
}