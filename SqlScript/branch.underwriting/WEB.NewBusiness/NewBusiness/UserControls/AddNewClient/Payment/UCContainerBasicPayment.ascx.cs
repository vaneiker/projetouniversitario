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
    public partial class UCContainerBasicPayment : UC, IUC
    {
        public void edit() { }
        public void FillData() { }
        public void Translator(string Lang) { }
        public void Initialize() { }
        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(this.Controls, isReadOnly);
        }
        public delegate void SelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId);
        public event SelectPaymemtForm SelectPaymemtFormEvent;

        public delegate void RefreshPaymentDocuments();
        public event RefreshPaymentDocuments RefreshPaymentDocumentsEvent;
        public delegate void SaveDocumentDetail(int PaymentDetId);
        public event SaveDocumentDetail SaveDocumentDetailEvent;

        #region CONTROLES
        TextBox txtOriginationDate;
        DropDownList ddlFormofPayment;
        UserControl Controles;

        public void setControls()
        {
            switch (hfSelectControls.Value)
            {
                case "VBasicPayment":
                    Controles = UCBasicPayment;
                    break;
            }
            /*BUSCO LOS CONTRLES QUE QUIERO GUARDAR*/
            txtOriginationDate = ((TextBox)Controles.FindControl("txtOriginationDate"));
            ddlFormofPayment = ((DropDownList)Controles.FindControl("ddlFormofPayment"));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            UCBasicPayment._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
        }

        #region EVENTOS CONTROLES
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
            RefreshPaymentDocumentsEvent();
        }

        protected void ddlFormofPayment_SelectedIndexChanged(object sender, EventArgs e)
        {   
            var drop = (DropDownList)sender;

            if ((drop).SelectedValue != "-1")
            {
                var InsItem = Utility.deserializeJSON<Utility.PaymentSource>((drop).SelectedValue);
                ObjServices.PaymentDetId = new Nullable<int>();
                SelectPaymemtFormEvent(InsItem.PaymentSourceId, InsItem.PaymentSourceTypeId, InsItem.PaymentControlId);
            } else 
                SelectPaymemtFormEvent(-1, -1, -1);
        }

        #endregion

        #region COMMON METHODS
        public void save() { }

        /// <summary>
        /// aqui es donde veo que control debo de llenar  por defecto estare UCACHDOMICILE
        /// </summary>
        public void FillDataSelectControl(String SelectControles, int PaymentSourceId, int PaymentSourceTypeId
            , int PaymentControlId, Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail Payment = null)
        {
            /*AQUI BUSCO QUE CONTROL DEBO PRESENTAR PRIMERO*/
            ClearData();
            switch (SelectControles)
            {
                case "VBasicPayment":
                    hfSelectControls.Value = "VBasicPayment";
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

            ddlFormofPayment.SelectIndexByValue("-1");


            if (!ObjServices.IsDataReviewMode)
            {
                if (txtOriginationDate != null)
                    txtOriginationDate.Text = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            }

            /*esto quiere decir el pago esta en modo de editar*/
            if (Payment == null)
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
                       , ObjServices.PaymentId.HasValue ? ObjServices.PaymentId.Value : -1
                   );


                if (paymentHeader != null)
                {                 
                    readOnly(!(paymentHeader.PaymentStatusId == 1));              
                }
                else
                    readOnly(true);
            }
        }

        public void readOnly(bool Enabled = true)
        {
            setControls();
            UCBasicPayment.activeSaveButton(Enabled);

            txtOriginationDate.Enabled = Enabled;

            if (ddlFormofPayment != null)
                ddlFormofPayment.Enabled = Enabled;
        }

        public void ClearData()
        {
            setControls();
            txtOriginationDate.Text = string.Empty;

            if (ddlFormofPayment != null)
                ddlFormofPayment.SelectIndexByValue("-1");

        }

        #endregion
    }
}