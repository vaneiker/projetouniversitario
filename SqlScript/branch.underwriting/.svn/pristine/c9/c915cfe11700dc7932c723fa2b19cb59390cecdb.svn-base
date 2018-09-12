using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    public partial class UCContainerCC : UC, IUC
    {


        public delegate void SelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId);
        public event SelectPaymemtForm SelectPaymemtFormEvent;


        public delegate void RefreshPaymentDocuments();
        public event RefreshPaymentDocuments RefreshPaymentDocumentsEvent;

        public delegate void SaveDocumentDetail(int PaymentDetId);
        public event SaveDocumentDetail SaveDocumentDetailEvent;

        #region CONTROLES
        TextBox txtOriginationDate;
        DropDownList ddlFormofPayment;
        DropDownList ddlCardType;

        DropDownList ddlExpirationDateMonth;
        DropDownList ddlExpirationDateYear;


        TextBox txtCardholderName;
        TextBox txtCardNumber;
        TextBox txtRepeatCardNumber;
        TextBox txtCIDCVV;
        TextBox txtRepeatCIDCVV;
        TextBox txtAmount;

        DropDownList ddlAccountHolderRelationshipOwnerInsured;


        UserControl Controles;
        public void setControls()
        {
            switch (hfSelectControls.Value)
            {
                case "VAContainerCCOneTime":
                    Controles = UCContainerCCOneTime;
                    break;

                case "VAContainerCCDomicile":
                    Controles = UCContainerCCDomicile;
                    break;
            }

            /*BUSCO LOS CONTRLES QUE QUIERO GUARDAR*/
            txtOriginationDate = ((TextBox)Controles.FindControl("txtOriginationDate"));
            ddlFormofPayment = ((DropDownList)Controles.FindControl("ddlFormofPayment"));
            ddlCardType = ((DropDownList)Controles.FindControl("ddlCardType"));

            ddlExpirationDateMonth = ((DropDownList)Controles.FindControl("ddlExpirationDateMonth"));
            ddlExpirationDateYear = ((DropDownList)Controles.FindControl("ddlExpirationDateYear"));

            txtCardholderName = ((TextBox)Controles.FindControl("txtCardholderName"));
            txtCardNumber = ((TextBox)Controles.FindControl("txtCardNumber"));
            txtRepeatCardNumber = ((TextBox)Controles.FindControl("txtRepeatCardNumber"));
            txtCIDCVV = ((TextBox)Controles.FindControl("txtCIDCVV"));
            txtRepeatCIDCVV = ((TextBox)Controles.FindControl("txtRepeatCIDCVV"));
            txtAmount = ((TextBox)Controles.FindControl("txtAmount"));

            ddlAccountHolderRelationshipOwnerInsured = ((DropDownList)Controles.FindControl("ddlAccountHolderRelationshipOwnerInsured"));




        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            UCContainerCCOneTime._ddlAccountHolderRelationshipOwnerInsured.SelectedIndexChanged += ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged;
            UCContainerCCOneTime._ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
            UCContainerCCOneTime._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
            UCContainerCCOneTime._btnSave.Click += btnSave_Click;
            UCContainerCCOneTime._btnCancel.Click += btnCancel_Click;

            UCContainerCCDomicile._ddlAccountHolderRelationshipOwnerInsured.SelectedIndexChanged += ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged;
            UCContainerCCDomicile._ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
            UCContainerCCDomicile._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
            UCContainerCCDomicile._btnSave.Click += btnSave_Click;
            UCContainerCCDomicile._btnCancel.Click += btnCancel_Click;
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
        /// <summary>
        /// este control salva los datos y refresca el grid de documentos via un evento que se dispara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


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
        #endregion
        #region COMMON METHODS


        public void Translator(string Lang)
        {
            throw new NotImplementedException();
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
            var contact = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id, ObjServices.State_Prov_Id, ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No, ObjServices.Hist_Seq_No, null, 1, ObjServices.Language.ToInt());
            if (contact != null)
            {
                this.SetContactInfo(contact);
            }
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
                    this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.AccountDomiciled, null, null, true, Title: ObjServices.Language.ToString() == "en" ? "Warning" : "Advertencia");
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
                        ObjServices.PaymentId = payReturn.PaymentId;
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
                    itemDetail.AccountTypeId = 4;
                    //itemDetail.PaymentTypeId = int.Parse(ddlCardType.SelectedValue);
                    itemDetail.CurrencyId = -1; //USD
                    itemDetail.PaymentStatusId = 2;//pendiente

                    itemDetail.UserId = ObjServices.UserID.Value;


                    itemDetail.DueDate = Utility.IsDateReturnNull(txtOriginationDate.Text);
                    itemDetail.Name = txtCardholderName.Text;
                    itemDetail.Number = txtCardNumber.Text.Replace("-", "");
                    itemDetail.ExpireDate = new DateTime(int.Parse(ddlExpirationDateYear.SelectedValue), int.Parse(ddlExpirationDateMonth.SelectedValue), 1);
                    itemDetail.ControlDigit = txtCIDCVV.Text;
                    itemDetail.TypeId = int.Parse(ddlCardType.SelectedValue);//creditcard 
                    itemDetail.RelationshipToOwnerOrInsured = int.Parse(ddlAccountHolderRelationshipOwnerInsured.SelectedValue);
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

        public void edit()
        {

        }

        public void FillData()
        {
        }
        /// <summary>
        /// aqui es donde veo que control debo de llenar  por defecto estare UCACHDOMICILE
        /// </summary>
        public void FillDataSelectControl(String SelectControles, int PaymentSourceId, int PaymentSourceTypeId
            , int PaymentControlId, Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail Payment = null)
        {
            ClearData();
            /*AQUI BUSCO QUE CONTROL DEBO PRESENTAR PRIMERO*/
            switch (SelectControles)
            {
                case "VAContainerCCOneTime":
                    MVCC.SetActiveView(VAContainerCCOneTime);
                    hfSelectControls.Value = "VAContainerCCOneTime";
                    break;

                case "VAContainerCCDomicile":
                    MVCC.SetActiveView(VAContainerCCDomicile);
                    hfSelectControls.Value = "VAContainerCCDomicile";
                    break;
                default:
                    MVCC.SetActiveView(VAContainerCCOneTime);
                    hfSelectControls.Value = "VAContainerCCOneTime";
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
                 .Replace("{3}", PaymentControlId.ToString());

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
                                        "CardTypeDesc",
                                        "CardTypeId",
                                        GenerateItemSelect: true,
                                        PaymentSourceId: PaymentSourceId,
                                        PaymentSourceTypeId: PaymentSourceTypeId,
                                        corpId: ObjServices.Corp_Id
                                   );
            }


            if (ddlExpirationDateMonth != null)
            {
                ddlExpirationDateMonth.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    ddlExpirationDateMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                ddlExpirationDateMonth.Items.Insert(0, new ListItem() { Value = "-1", Text = "-----" });
            }
            if (ddlExpirationDateYear != null)
            {
                ddlExpirationDateYear.Items.Clear();
                for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 5; i++)
                {
                    ddlExpirationDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                ddlExpirationDateYear.Items.Insert(0, new ListItem() { Value = "-1", Text = "-----" });
            }

            if (!ObjServices.IsDataReviewMode)
            {
                if (txtOriginationDate != null)
                    txtOriginationDate.Text = DateTime.Now.ToString();
            }

            /*esto quiere decir el pago esta en modo de editar*/
            if (Payment != null)
            {

                ObjServices.PaymentDetId = Payment.PaymentDetId;
                ddlCardType.SelectIndexByValue(Payment.TypeId.ToString());


                if (Payment.OriginCreditAmount.HasValue)
                    txtAmount.Text = Payment.OriginCreditAmount.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);

                txtOriginationDate.Text = Payment.PaidDate.HasValue ? Payment.PaidDate.Value.ToString() : txtOriginationDate.Text;

                txtCardholderName.Text = string.IsNullOrEmpty(Payment.Name) ? "" : Payment.Name;
                txtCardNumber.Text = string.IsNullOrEmpty(Payment.Number) ? "" : Payment.Number;
                txtRepeatCardNumber.Text = string.IsNullOrEmpty(Payment.Number) ? "" : Payment.Number;
                txtCIDCVV.Text = string.IsNullOrEmpty(Payment.ControlDigit) ? "" : Payment.ControlDigit;
                txtRepeatCIDCVV.Text = string.IsNullOrEmpty(Payment.ControlDigit) ? "" : Payment.ControlDigit;

                if (Payment.ExpireDate.HasValue)
                {
                    ddlExpirationDateYear.SelectIndexByValue(Payment.ExpireDate.Value.Year.ToString());
                    ddlExpirationDateMonth.SelectIndexByValue(Payment.ExpireDate.Value.Month.ToString());
                }


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
            UCContainerCCOneTime.activeSaveButton(Enabled);
            UCContainerCCDomicile.activeSaveButton(Enabled);




            txtOriginationDate.Enabled = Enabled;
            txtAmount.Enabled = Enabled;
            txtCardholderName.Enabled = Enabled;
            txtCardNumber.Enabled = Enabled;
            txtCIDCVV.Enabled = Enabled;
            txtOriginationDate.Enabled = Enabled;
            txtRepeatCardNumber.Enabled = Enabled;
            txtRepeatCIDCVV.Enabled = Enabled;
            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlAccountHolderRelationshipOwnerInsured.Enabled = Enabled;


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlCardType.Enabled = Enabled;


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlExpirationDateMonth.Enabled = Enabled;


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlExpirationDateYear.Enabled = Enabled;


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlFormofPayment.Enabled = Enabled;
        }
        public void Initialize()
        {

        }

        public void ClearData()
        {
            setControls();
            txtOriginationDate.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtCardholderName.Text = string.Empty;
            txtCardNumber.Text = string.Empty;
            txtCIDCVV.Text = string.Empty;
            txtOriginationDate.Text = string.Empty;
            txtRepeatCardNumber.Text = string.Empty;
            txtRepeatCIDCVV.Text = string.Empty;
            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlAccountHolderRelationshipOwnerInsured.SelectIndexByValue("-1");


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlCardType.SelectIndexByValue("-1");


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlExpirationDateMonth.SelectIndexByValue("-1");


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlExpirationDateYear.SelectIndexByValue("-1");


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlFormofPayment.SelectIndexByValue("-1");


        }

        #endregion  
        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(this.Controls, isReadOnly);
        }
        private bool SetContactInfo(Entity.UnderWriting.Entities.Contact contact)
        {
            var result = false;
            var relationShipToOwner = !string.IsNullOrEmpty(ddlAccountHolderRelationshipOwnerInsured.SelectedValue) ? ddlAccountHolderRelationshipOwnerInsured.SelectedValue.ToInt() : 0;
            contact.RelationshiptoOwner = relationShipToOwner;
            ObjServices.oContactManager.UpdateContact(contact);
            return result;
        }
    }
}