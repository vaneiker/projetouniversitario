using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    public partial class UCPagoConTarjetas : UC,IUC
    {

        public DropDownList _ddlFormofPayment { get { return ddlFormofPayment; } }

        public DropDownList _ddlCardType { get { return ddlCardType; } }

        public DropDownList _ddlAccountHolderRelationshipOwnerInsured { get { return ddlAccountHolderRelationshipOwnerInsured; } }

        public Button _btnSave { get { return btnSave; } }

        public Button _btnCancel { get { return btnCancel; } }

        public DropDownList _ddlNombresBancos { get { return ddlNombresBancos; } }

        public CheckBox _chkTarAlternativa { get { return chkTarAlternativa; } }

        public System.Web.UI.HtmlControls.HtmlGenericControl _lblTarjetaAlternativa { get { return lblTarjetaAlternativa; } }
        //public Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail itemDetail_TarAlter { get { return itemDetail_TarAlter; } set { this.itemDetail_TarAlter = value; } }
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDataTar();
            }            
        }

        private void FillDataTar()
        {

            if (ddlAccountHolderRelationshipOwnerInsured2 != null)
            {
                ObjServices.GettingAllDrops(ref ddlAccountHolderRelationshipOwnerInsured2,
                                    Utility.DropDownType.RelationshipPayment,
                                   "RelationshipDesc",
                                   "RelationshipId",
                                    GenerateItemSelect: true
                                   );
            }

            if (ddlCardType2 != null)
            {
                ObjServices.GettingAllDrops(ref ddlCardType2,
                                        Utility.DropDownType.PaymentType,
                                        "CardTypeDesc",
                                        "CardTypeId",
                                        GenerateItemSelect: true,
                                        PaymentSourceId: 3,
                                        PaymentSourceTypeId: 3,
                                        corpId: ObjServices.Corp_Id
                                   );
            }

            if (ddlNombresBancos2 != null)
            {
                ObjServices.GettingAllDrops(ref ddlNombresBancos2,
                        Utility.DropDownType.BankList,
                        "BankDesc",
                        "BankId",
                        GenerateItemSelect: true,
                        countryId: ObjServices.Country_Id
                   );
            }
        }

        protected void ddlFormofPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        public void activeSaveButton(bool IsActive = true)
        {
            if (IsActive)
                MultiView1.SetActiveView(vActive);
            else
                MultiView1.SetActiveView(vInactive);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            OriginationDate.InnerHtml = Resources.OriginationDate;
            FormofPayment.InnerHtml = Resources.FormOfPayment;
            PaymentType.InnerHtml = Resources.PaymentType;
            AccountHolderName.InnerHtml = Resources.AccountHolderName;
            BankName.InnerHtml = Resources.BankName;
            //AccountNumber.InnerHtml = Resources.AccountNumber;
            RepeatAccountNumber.InnerHtml = Resources.RepeatAccountNumber;
            ABANumber.InnerHtml = Resources.ABANumber;
            AccountHolderRelationshipOwnerInsured.InnerHtml = Resources.AccountHolderRelationshipOwnerInsured;
            Amount.InnerHtml = Resources.AmountLabel;
            btnSave.Text = Resources.Save;
            btnProcessPayment2.Text = Resources.Save;
            btnCancel.Text = Resources.Cancel.Capitalize();

            //Para el Pop UP
            PaymentType2.InnerHtml = Resources.PaymentType;
            AccountHolderName2.InnerHtml = Resources.AccountHolderName;
            BankName2.InnerHtml = Resources.BankName;
            AccountHolderRelationshipOwnerInsured2.InnerHtml = Resources.AccountHolderRelationshipOwnerInsured;
            btnSaveTarAlter.Text = Resources.Save;
            btnCancelTarAlter.Text = Resources.Cancel.Capitalize();

        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
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

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        protected void chkTarAlternativa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTarAlternativa.Checked)
                mpePopUpTarjeAlter.Show();
        }

        protected void btnSaveTarAlter_Click(object sender, EventArgs e)
        {
            //Bmarroquin 17-03-2017 Validar el tamanio en el numero de las tarjetas en payments 
            if (ddlCardType2.SelectedValue == "1")
            {
                if (txtAccountNumber2.Text.Length != 15)
                {
                    this.MessageBox("Por favor ingrese un numero de tarjeta con 15 digitos", Title: "Advertencia");
                    return;
                }
            }

            if (ddlCardType2.SelectedValue == "4" || ddlCardType2.SelectedValue == "5")
            {
                if (txtAccountNumber2.Text.Length != 16)
                {
                    this.MessageBox("Por favor ingrese un numero de tarjeta con 16 digitos", Title: "Advertencia");
                    return;
                }
            }
            //Fin cambio Bmarroquin 17-03-2017

            Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail itemDetail_TarAlter = new Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail();           
            itemDetail_TarAlter.RelationshipToOwnerOrInsured = int.Parse(ddlAccountHolderRelationshipOwnerInsured2.SelectedValue);
            itemDetail_TarAlter.EFTAccountHolder = txtAccountHolderName2.Text.Trim();
            itemDetail_TarAlter.EFTAccountHolderSource = ddlNombresBancos2.SelectedValue;
            itemDetail_TarAlter.EFTAccountNumber = txtAccountNumber2.Text;
            //Estos datos se guardan en la tabla [Policy].[PL_PCY_CARDS]
            //itemDetail_TarAlter.ExpireDate = Utility.IsDateReturnNull(txtFecVenTarjeta2.Text);
            //Bmarroquin 27-02-2017 ahora la fecha se guarda en formato mes-anio
            itemDetail_TarAlter.TransactionDescription = txtFecVenTarjeta2.Text;
            itemDetail_TarAlter.Status = true;
            itemDetail_TarAlter.Name = txtAccountHolderName2.Text.Trim();
            itemDetail_TarAlter.Number = txtAccountNumber2.Text;
            //Bmarroquin 10-03-2017 se guarde el tipo de tarjeta que seleccionen...
            itemDetail_TarAlter.AccountTypeId = int.Parse(ddlCardType2.SelectedValue);
            itemDetail_TarAlter.OrderId = "-99";
            Session["objTarjeAlter"] = itemDetail_TarAlter;

            LimpiarControls();

            //Cerrar el modal
            mpePopUpTarjeAlter.Hide();
        }

        public void LimpiarControls()
        {
            //Limpiar Controles
            ddlCardType2.SelectedValue = "-1";
            ddlNombresBancos2.SelectedValue = "-1";
            ddlAccountHolderRelationshipOwnerInsured2.SelectedValue = "-1";
            txtAccountNumber2.Text = "";
            txtAccountHolderName2.Text = "";
            txtFecVenTarjeta2.Text = "";
        }

        protected void btnCancelTarAlter_Click(object sender, EventArgs e)
        {
            LimpiarControls();
            //Cerrar el modal
            mpePopUpTarjeAlter.Hide();
        }
    }
}