using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    public partial class UCContainerTransfer : UC, WEB.NewBusiness.Common.IUC
    {

        public delegate void SelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId);
        public event SelectPaymemtForm SelectPaymemtFormEvent;

        public delegate void RefreshPaymentDocuments();
        public event RefreshPaymentDocuments RefreshPaymentDocumentsEvent;

        public delegate void SaveDocumentDetail(int PaymentDetId);
        public event SaveDocumentDetail SaveDocumentDetailEvent;

        public void Initialize() { }
        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(this.Controls, isReadOnly);
        }
        public void edit() { }
        public void FillData() { }
        public void Translator(string Lang) { }

        #region CONTROLES
        TextBox txtOriginationDate;
        DropDownList ddlFormofPayment;
        DropDownList ddlCardType;
        TextBox txtAccountHolderName;
        TextBox txtCheckNumber;
        TextBox txtCheckDate;
        TextBox txtBankName;
        DropDownList ddlAccountHolderRelationshipOwnerInsured;
        TextBox txtAmount;
        TextBox txtWireConfirmationNumber;
        TextBox txtWireDueDate;

        UserControl Controles;
        public void setControls()
        {
            switch (hfSelectControls.Value)
            {
                case "VAContainerTransferCheck":
                    Controles = UCContainerTransferCheck;
                    break;

                case "VAContainerTransferWire":
                    Controles = UCContainerTransferWire;
                    break;

                case "VAContainerTransferWirePromise":
                    Controles = UCContainerTransferWirePromise;
                    break;


            }

            /*BUSCO LOS CONTRLES QUE QUIERO GUARDAR*/
            txtOriginationDate = ((TextBox)Controles.FindControl("txtOriginationDate"));
            ddlFormofPayment = ((DropDownList)Controles.FindControl("ddlFormofPayment"));
            ddlCardType = ((DropDownList)Controles.FindControl("ddlCardType"));
            ddlAccountHolderRelationshipOwnerInsured = ((DropDownList)Controles.FindControl("ddlAccountHolderRelationshipOwnerInsured"));
            txtAccountHolderName = ((TextBox)Controles.FindControl("txtAccountHolderName"));
            txtCheckNumber = ((TextBox)Controles.FindControl("txtCheckNumber"));
            txtCheckDate = ((TextBox)Controles.FindControl("txtCheckDate"));
            txtBankName = ((TextBox)Controles.FindControl("txtBankName"));
            txtAmount = ((TextBox)Controles.FindControl("txtAmount"));
            txtWireConfirmationNumber = ((TextBox)Controles.FindControl("txtWireConfirmationNumber"));
            txtWireDueDate = ((TextBox)Controles.FindControl("txtWireDueDate"));


        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            UCContainerTransferCheck._ddlAccountHolderRelationshipOwnerInsured.SelectedIndexChanged += ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged;
            UCContainerTransferCheck._ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
            UCContainerTransferCheck._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
            UCContainerTransferCheck._btnSave.Click += btnSave_Click;
            UCContainerTransferCheck._btnCancel.Click += btnCancel_Click;

            UCContainerTransferWire._ddlAccountHolderRelationshipOwnerInsured.SelectedIndexChanged += ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged;
            UCContainerTransferWire._ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
            UCContainerTransferWire._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
            UCContainerTransferWire._btnSave.Click += btnSave_Click;
            UCContainerTransferWire._btnCancel.Click += btnCancel_Click;

            UCContainerTransferWirePromise._ddlAccountHolderRelationshipOwnerInsured.SelectedIndexChanged += ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged;
            UCContainerTransferWirePromise._ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
            UCContainerTransferWirePromise._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
            UCContainerTransferWirePromise._btnSave.Click += btnSave_Click;
            UCContainerTransferWirePromise._btnCancel.Click += btnCancel_Click;
        }

        #region EVENTOS CONTROLES
        protected void ddlFormofPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = (DropDownList)sender;

            if ((drop).SelectedValue != "-1")
            {
                var InsItem = Utility.deserializeJSON<Utility.PaymentSource>((drop).SelectedValue);
                ObjServices.PaymentDetId = new Nullable<int>();
                SelectPaymemtFormEvent(InsItem.PaymentSourceId, InsItem.PaymentSourceTypeId, InsItem.PaymentControlId);
            }
            else
                SelectPaymemtFormEvent(-1, -1, -1);
        }

        protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region COMMON METHODS

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            
            //Inicializar el formulario 
            var WUCFormOfPayment = (WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCFormOfPayment)this.Page.Master.FindControl("bodyContent")
                             .FindControl("PaymentContainer")
                             .FindControl("WUCFormOfPayment");

            if (!WUCFormOfPayment.isNullReferenceControl())
                WUCFormOfPayment.MethodSelectPaymemtForm(-1, -1, -1);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
            RefreshPaymentDocumentsEvent();
        }

        public void save()
        {
            setControls();
            bool ProcessPayment = false;
            var InsItem = Utility.deserializeJSON<Utility.PaymentSource>(ddlFormofPayment.SelectedValue);
            var amount = Utility.IsDecimal(txtAmount.Text.Replace(",", "")) ?
                          Utility.IsDecimalReturnNull(txtAmount.Text.Replace(",", ""))
                          : 0;

            var Policy = ObjServices.oPolicyManager.GetPlanData(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id, ObjServices.State_Prov_Id
                , ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No, ObjServices.Hist_Seq_No);

            decimal Total = 0;
            Total = ObjServices.oPaymentManager.GetPayment
                 (
                       ObjServices.Corp_Id
                     , ObjServices.Region_Id
                     , ObjServices.Country_Id
                     , ObjServices.Domesticreg_Id
                     , ObjServices.State_Prov_Id
                     , ObjServices.City_Id
                     , ObjServices.Office_Id
                     , ObjServices.Case_Seq_No
                     , ObjServices.Hist_Seq_No
                     , ObjServices.PaymentId.Value
                 ).DueAmount.Value;
            decimal? Pay = 0;
            int? HasdomicilePayment = 0;
            //esta parte investiga si se esta editando un valor en caso de que si 
            //se excluye el pago a total
            if (ObjServices.PaymentDetId.HasValue)
            {
                Pay = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                  (
                        ObjServices.Corp_Id
                      , ObjServices.Region_Id
                      , ObjServices.Country_Id
                      , ObjServices.Domesticreg_Id
                      , ObjServices.State_Prov_Id
                      , ObjServices.City_Id
                      , ObjServices.Office_Id
                      , ObjServices.Case_Seq_No
                      , ObjServices.Hist_Seq_No
                      , ObjServices.PaymentId.Value
                      , ObjServices.Language.ToInt()
                  ).Where(det => det.PaymentDetId != ObjServices.PaymentDetId.Value).Sum(s => s.UsdCreditAmount - s.UsdDebitAmount);

                HasdomicilePayment = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                   (
                         ObjServices.Corp_Id
                       , ObjServices.Region_Id
                       , ObjServices.Country_Id
                       , ObjServices.Domesticreg_Id
                       , ObjServices.State_Prov_Id
                       , ObjServices.City_Id
                       , ObjServices.Office_Id
                       , ObjServices.Case_Seq_No
                       , ObjServices.Hist_Seq_No
                       , ObjServices.PaymentId.Value
                       , ObjServices.Language.ToInt()
                   ).Where(dom => dom.PaymentControlId == 2 && dom.PaymentDetId != ObjServices.PaymentDetId.Value).Count();
            }
            else
            {
                Pay = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                  (
                        ObjServices.Corp_Id
                      , ObjServices.Region_Id
                      , ObjServices.Country_Id
                      , ObjServices.Domesticreg_Id
                      , ObjServices.State_Prov_Id
                      , ObjServices.City_Id
                      , ObjServices.Office_Id
                      , ObjServices.Case_Seq_No
                      , ObjServices.Hist_Seq_No
                      , ObjServices.PaymentId.Value
                      , ObjServices.Language.ToInt()
                  ).Sum(s => s.UsdCreditAmount - s.UsdDebitAmount);

                HasdomicilePayment = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
               (
                     ObjServices.Corp_Id
                   , ObjServices.Region_Id
                   , ObjServices.Country_Id
                   , ObjServices.Domesticreg_Id
                   , ObjServices.State_Prov_Id
                   , ObjServices.City_Id
                   , ObjServices.Office_Id
                   , ObjServices.Case_Seq_No
                   , ObjServices.Hist_Seq_No
                   , ObjServices.PaymentId.Value
                   , ObjServices.Language.ToInt()
               ).Where(dom => dom.PaymentControlId == 2).Count();
            }


            if (InsItem.PaymentControlId == 2) // domicile
            {
                if (HasdomicilePayment == 0)
                {
                    if ((amount >= (Policy.PeriodicPremium) && amount <= (Total - Pay) && amount > 0)) // si el pago  es mayor o igual a la prima y menor que la resta del total pago y lo que debe pagar entonces se puede realizar el pago
                        ProcessPayment = true;
                    else
                        this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.PeriodicPaymentWarning, Title: ObjServices.Language.ToString() == "en" ? "Warning" : "Advertencia");
                }
                else
                {
                    this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.AccountDomiciled, null, null, true, ObjServices.Language.ToString() == "en" ? "Warning" : "Advertencia");
                }
            }
            else
            {
                if (amount <= (Total - Pay) && amount > 0) // si el pago  es mayor o igual a la prima y menor que la resta del total pago y lo que debe pagar entonces se puede realizar el pago  
                    ProcessPayment = true;
                else
                    this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.PeriodicPaymentWarning, Title: ObjServices.Language.ToString() == "en" ? "Warning" : "Advertencia");
            }
            if (ProcessPayment)
            {
                /*primero verifico si existe un pago pendiente en la poliza antes de insertar el detalle*/
                if (ObjServices.PaymentId.HasValue == false)
                {
                    Entity.UnderWriting.Entities.Payment.ApplyPayment item = new Entity.UnderWriting.Entities.Payment.ApplyPayment();
                    item.CorpId = ObjServices.Corp_Id;
                    item.CityId = ObjServices.City_Id;
                    item.CountryId = ObjServices.Country_Id;
                    item.RegionId = ObjServices.Region_Id;
                    item.StateProvId = ObjServices.State_Prov_Id;
                    item.DomesticregId = ObjServices.Domesticreg_Id;
                    item.OfficeId = ObjServices.Office_Id;
                    item.CaseSeqNo = ObjServices.Case_Seq_No;
                    item.HistSeqNo = ObjServices.Hist_Seq_No;

                    item.DueAmount = 0;
                    item.DueDate = DateTime.Now;
                    item.PaidAmount = 0;

                    item.PaymentStatusId = 2;
                    item.UserId = ObjServices.UserID.Value;
                    var payReturn = ObjServices.oPaymentManager.InsertPayment(item);
                    if (payReturn != null)
                    {
                        ObjServices.PaymentId = payReturn.PaymentId;
                    }

                }
                if (ObjServices.PaymentId.HasValue == true)
                {
                    Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail itemDetail = new Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail();

                    itemDetail.CorpId = ObjServices.Corp_Id;
                    itemDetail.CityId = ObjServices.City_Id;
                    itemDetail.CountryId = ObjServices.Country_Id;
                    itemDetail.RegionId = ObjServices.Region_Id;
                    itemDetail.StateProvId = ObjServices.State_Prov_Id;
                    itemDetail.DomesticregId = ObjServices.Domesticreg_Id;
                    itemDetail.OfficeId = ObjServices.Office_Id;
                    itemDetail.CaseSeqNo = ObjServices.Case_Seq_No;
                    itemDetail.HistSeqNo = ObjServices.Hist_Seq_No;
                    itemDetail.PaymentId = ObjServices.PaymentId.Value; 

                    /*campos editables para agregar montos de la transaccion*/
                    itemDetail.Rate = 1; //los pagos son siempre en dolares  

                    itemDetail.OriginCreditAmount = amount;
                    itemDetail.OriginDebitAmount = 0;
                    itemDetail.UsdCreditAmount = amount;
                    itemDetail.UsdDebitAmount = 0;      

                    itemDetail.PaymentSourceId = InsItem.PaymentSourceId;
                    itemDetail.PaymentSourceTypeId = InsItem.PaymentSourceTypeId;
                    itemDetail.PaymentControlId = InsItem.PaymentControlId;
                    itemDetail.PaymentDetailSourceId = System.Guid.NewGuid().ToString();
                    itemDetail.PaymentStatusId = 2;//pendiente

                    switch (hfSelectControls.Value)
                    {
                        case "VAContainerTransferCheck":
                            itemDetail.AccountTypeId = 6; //Check 
                            itemDetail.EFTAccountNumber = txtCheckNumber.Text;
                            break;

                        case "VAContainerTransferWire":
                            itemDetail.AccountTypeId = 7; //transfer 
                            itemDetail.EFTAccountNumber = txtWireConfirmationNumber.Text;
                            break;
                        case "VAContainerTransferWirePromise":
                            itemDetail.AccountTypeId = 7; //transfer 
                            itemDetail.EFTAccountNumber = txtWireConfirmationNumber.Text;
                            break;
                    }

                    itemDetail.CurrencyId = -1; //USD
                    itemDetail.UserId = ObjServices.UserID.Value;

                    itemDetail.DueDate = Utility.IsDateReturnNull(txtOriginationDate.Text);
                    itemDetail.RelationshipToOwnerOrInsured = int.Parse(ddlAccountHolderRelationshipOwnerInsured.SelectedValue);
                    itemDetail.EFTAccountHolder = txtAccountHolderName.Text.Trim();
                    itemDetail.EFTAccountHolderSource = txtBankName.Text.Trim();

                    if (txtCheckDate != null)
                        itemDetail.ReceiptDate = Utility.IsDateReturnNull(txtCheckDate.Text);

                    if (txtWireDueDate != null)
                        itemDetail.ReceiptDate = Utility.IsDateReturnNull(txtWireDueDate.Text);

                    int DetailID = 0;
                    if (ObjServices.PaymentDetId.HasValue)
                    {
                        DetailID = ObjServices.PaymentDetId.Value;
                        itemDetail.PaymentDetId = ObjServices.PaymentDetId.Value;
                        ObjServices.oPaymentManager.UpdatePaymentDetail(itemDetail);
                    }
                    else
                    {
                        itemDetail.PaymentDetailSourceId = System.Guid.NewGuid().ToString();
                        DetailID = ObjServices.oPaymentManager.InsertPaymentDetail(itemDetail).PaymentDetId;
                    }
                    
                    SaveDocumentDetailEvent(DetailID);

                    //Inicializar el formulario 
                    var WUCFormOfPayment = (WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCFormOfPayment)this.Page.Master.FindControl("bodyContent")
                                     .FindControl("PaymentContainer")
                                     .FindControl("WUCFormOfPayment");

                    if (!WUCFormOfPayment.isNullReferenceControl())
                        WUCFormOfPayment.MethodSelectPaymemtForm(-1, -1, -1);

                }
                ClearData();
            }
        }
        /// <summary>
        /// aqui es donde veo que control debo de llenar  por defecto estare UCACHDOMICILE
        /// </summary>
        public void FillDataSelectControl(String SelectControles, int PaymentSourceId, int PaymentSourceTypeId
            , int PaymentControlId, Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail Payment = null)
        {
            /*AQUI BUSCO QUE CONTROL DEBO PRESENTAR PRIMERO*/
            switch (SelectControles)
            {
                case "VAContainerTransferCheck":
                    MVTransfer.SetActiveView(VAContainerTransferCheck);
                    hfSelectControls.Value = "VAContainerTransferCheck";
                    break;

                case "VAContainerTransferWire":
                    MVTransfer.SetActiveView(VAContainerTransferWire);
                    hfSelectControls.Value = "VAContainerTransferWire";
                    break;
                case "VAContainerTransferWirePromise":
                    MVTransfer.SetActiveView(VAContainerTransferWirePromise);
                    hfSelectControls.Value = "VAContainerTransferWirePromise";
                    break;
                default:
                    MVTransfer.SetActiveView(VAContainerTransferCheck);
                    hfSelectControls.Value = "VAContainerTransferCheck";
                    break;
            }
            /*BUSCO LOS OBJECTOS QUE NECESITO LLENAR DEL CONTROL SELECCIONADO*/
            setControls();
            ObjServices.GettingAllDropsJSON(ref ddlFormofPayment, WEB.NewBusiness.Common.Utility.DropDownType.PaymentSource, "PaymentSourceDesc"
                              , corpId: ObjServices.Corp_Id
                , regionId: ObjServices.Region_Id
                , countryId: ObjServices.Country_Id
                , domesticregId: ObjServices.Domesticreg_Id
                , stateProvId: ObjServices.State_Prov_Id
                , cityId: ObjServices.City_Id
                , officeId: ObjServices.Office_Id
                , caseSeqNo: ObjServices.Case_Seq_No
                , histSeqNo: ObjServices.Hist_Seq_No
                , appliedByFreqOrCountry: true                      
                );

            string x2 = "{\"PaymentSourceId\":{1},\"PaymentSourceTypeId\":{2},\"PaymentControlId\":{3}}"
                 .Replace("{1}", PaymentSourceId.ToString())
                 .Replace("{2}", PaymentSourceTypeId.ToString())
                 .Replace("{3}", PaymentControlId.ToString())
                 ;
            ddlFormofPayment.SelectIndexByValueJSON(x2);

            if (ddlAccountHolderRelationshipOwnerInsured != null)
            {
                ObjServices.GettingAllDrops(ref ddlAccountHolderRelationshipOwnerInsured,
                                    Utility.DropDownType.RelationshipPayment,
                                   "RelationshipDesc",
                                   "RelationshipId",
                                    GenerateItemSelect: true
                                   );
            }
            if (ddlCardType != null)
            {
                ObjServices.GettingAllDrops(ref ddlCardType,
                                Utility.DropDownType.PaymentType,
                                "AccountDesc",
                                "AccountTypeId",
                                GenerateItemSelect: true,
                                PaymentSourceId: PaymentSourceId,
                                PaymentSourceTypeId: PaymentSourceTypeId,
                                corpId: ObjServices.Corp_Id
                           );
            }

            if (!ObjServices.IsDataReviewMode)
            {
                if (txtOriginationDate != null)
                    txtOriginationDate.Text = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            }

            /*esto quiere decir el pago esta en modo de editar*/
            if (Payment != null)
            {

                ObjServices.PaymentDetId = Payment.PaymentDetId;
                ddlCardType.SelectIndexByValue(Payment.AccountTypeId.ToString());


                if (Payment.OriginCreditAmount.HasValue)
                    txtAmount.Text = Payment.OriginCreditAmount.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);

                txtOriginationDate.Text = Payment.PaidDate.HasValue ? Payment.PaidDate.Value.ToString() : txtOriginationDate.Text;

                if (txtAccountHolderName != null)
                    if (string.IsNullOrEmpty(Payment.EFTAccountHolder) == false)
                        txtAccountHolderName.Text = Payment.EFTAccountHolder;


                if (txtBankName != null)
                    if (string.IsNullOrEmpty(Payment.EFTAccountHolderSource) == false)
                        txtBankName.Text = Payment.EFTAccountHolderSource;

                if (txtCheckDate != null)
                    if (Payment.ReceiptDate.HasValue)
                        txtCheckDate.Text = Payment.ReceiptDate.ToString();

                if (txtWireDueDate != null)
                    if (Payment.ReceiptDate.HasValue)
                        txtWireDueDate.Text = Payment.ReceiptDate.ToString();


                if (txtCheckNumber != null)
                    if (string.IsNullOrEmpty(Payment.EFTAccountNumber) == false)
                        txtCheckNumber.Text = Payment.EFTAccountNumber.ToString();

                if (txtWireConfirmationNumber != null)
                    if (string.IsNullOrEmpty(Payment.EFTAccountNumber) == false)
                        txtWireConfirmationNumber.Text = Payment.EFTAccountNumber.ToString();


                if (Payment.RelationshipToOwnerOrInsured != null)
                    ddlAccountHolderRelationshipOwnerInsured.SelectIndexByValue(Payment.RelationshipToOwnerOrInsured.ToString());

                if (Payment.PaymentStatusId == 1)
                    readOnly(false);
                else
                    readOnly(true);

            }
            else
            {
                var paymentHeader = ObjServices.oPaymentManager.GetPayment
                    (
                          ObjServices.Corp_Id
                        , ObjServices.Region_Id
                        , ObjServices.Country_Id
                        , ObjServices.Domesticreg_Id
                        , ObjServices.State_Prov_Id
                        , ObjServices.City_Id
                        , ObjServices.Office_Id
                        , ObjServices.Case_Seq_No
                        , ObjServices.Hist_Seq_No
                        , ObjServices.PaymentId.Value
                    );

                if (paymentHeader != null)
                {
                    if (paymentHeader.PaymentStatusId == 1)
                        readOnly(false);
                    else
                        readOnly(true);
                }
                else
                    readOnly(true);
            }

        }
        public void readOnly(bool Enabled = true)
        {
            setControls();

            UCContainerTransferCheck.activeSaveButton(Enabled);
            UCContainerTransferWire.activeSaveButton(Enabled);
            UCContainerTransferWirePromise.activeSaveButton(Enabled);


            txtOriginationDate.Enabled = Enabled;
            if (txtAccountHolderName != null)
                txtAccountHolderName.Enabled = Enabled;


            if (txtCheckNumber != null)
                txtCheckNumber.Enabled = Enabled;

            if (txtBankName != null)
                txtBankName.Enabled = Enabled;

            if (txtAmount != null)
                txtAmount.Enabled = Enabled;


            if (txtWireConfirmationNumber != null)
                txtWireConfirmationNumber.Enabled = Enabled;

            if (txtWireDueDate != null)
                txtWireDueDate.Enabled = Enabled;


            if (ddlFormofPayment != null)
                ddlFormofPayment.Enabled = Enabled;


            if (ddlCardType != null)
                ddlCardType.Enabled = Enabled;


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlAccountHolderRelationshipOwnerInsured.Enabled = Enabled;

        }

        public void ClearData()
        {
            setControls();
            txtOriginationDate.Text = string.Empty;

            if (txtAccountHolderName != null)
                txtAccountHolderName.Text = string.Empty;


            if (txtCheckNumber != null)
                txtCheckNumber.Text = string.Empty;

            if (txtBankName != null)
                txtBankName.Text = string.Empty;

            if (txtAmount != null)
                txtAmount.Text = string.Empty;


            if (txtWireConfirmationNumber != null)
                txtWireConfirmationNumber.Text = string.Empty;

            if (txtWireDueDate != null)
                txtWireDueDate.Text = string.Empty;


            if (ddlFormofPayment != null)
                ddlFormofPayment.SelectIndexByValue("-1");


            if (ddlCardType != null)
                ddlCardType.SelectIndexByValue("-1");


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlAccountHolderRelationshipOwnerInsured.SelectIndexByValue("-1");          

        }

        #endregion
    }
}