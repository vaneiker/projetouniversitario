using System;
using System.Linq;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.IllusData;
using Entity.UnderWriting.Entities;
using iTextSharp.text.pdf;
using RESOURCE.UnderWriting.NewBussiness;
using DI.UnderWriting.Implementations;
using WEB.NewBusiness.TransunionServiceReference;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCInsuredInformation : UC, IUC
    {
        string DefaulltPassword = ConfigurationManager.AppSettings["TransunionDefaultPassword"];
        string user = ConfigurationManager.AppSettings["TransunionUserName"];
        string pass = ConfigurationManager.AppSettings["TransunionPass"];

        public int ContactId
        {
            get
            {
                return (int)ViewState["ContactId"];

            }
            set
            {
                ViewState["ContactId"] = value;
            }
        }

        public int? InsuredAge
        {
            get
            {
                var value = ViewState["InsuredAge"];
                return value == null ? null : (int?)value;
            }
            private set
            {
                ViewState["InsuredAge"] = value;
            }
        }

        public string InsuredName
        {
            get
            {
                return txtClientName.Text;
            }
        }

        public string BenefitPlanDesc
        {
            get
            {
                var value = Session["BenefitPlanDesc"];
                return value == null ? null : (string)value;
            }
            private set
            {
                Session["BenefitPlanDesc"] = value;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (hdnShowPopContactEdit.Value == "true")
                mpeContactEditPop.Show();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
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
            try
            {
                var contact = ObjServices.oContactManager.GetContact(
                  ObjServices.Corp_Id,
                  ObjServices.ContactEntityID.GetValueOrDefault(),
                  ObjServices.getCurrentLanguage());

                if (contact == null) return;

                txtInvoiceType.Text = contact.InvoiceTypeDesc;
                ContactId = contact.ContactId;
                ObjServices.Contact_Id = ContactId;

                var dataResult = ObjServices.oPaymentManager.GetPaymentAgreement(new Entity.UnderWriting.Entities.Payment.Agreement
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No
                });

                var hasPaymentAgreement = (dataResult != null);

                if (hasPaymentAgreement)
                {
                    var qtyPay = dataResult.PaymentsAgreementQty;
                    var TextFind = "";

                    /*
                     Pago Único                 0
                     Inicial + 1 Cuota          1
                     Inicial + 2 Cuota          2
                     Inicial + 3 Cuota          3
                     Inicial + 4 Cuota          4
                    */

                    switch (qtyPay)
                    {
                        case 0: TextFind = "Pago Único"; break;
                        case 1: TextFind = "Inicial + 1 Cuota"; break;
                        case 2: TextFind = "Inicial + 2 Cuotas"; break;
                        case 3: TextFind = "Inicial + 3 Cuotas"; break;
                        case 4: TextFind = "Inicial + 4 Cuotas"; break;
                        case 5: TextFind = "Financiado a 5 Cuotas"; break;
                        case 6: TextFind = "Financiado a 6 Cuotas"; break;
                        case 7: TextFind = "Financiado a 7 Cuotas"; break;
                        case 8: TextFind = "Financiado a 8 Cuotas"; break;
                        case 9: TextFind = "Financiado a 9 Cuotas"; break;
                        case 10: TextFind = "Financiado a 10 Cuotas"; break;
                        case 11: TextFind = "Financiado a 11 Cuotas"; break;
                        case 12: TextFind = "Financiado a 12 Cuotas"; break;
                    }

                    txtPaymentFreq.Text = TextFind;
                }

                txtClientName.Text = (
                    contact.FirstName.NTrim() + " " +
                    contact.MiddleName.NTrim() + " " +
                    contact.FirstLastName.NTrim() + " " +
                    contact.SecondLastName.NTrim()).NTrim().IsNullOrEmptyReturnValue(
                    contact.FullName.NTrim().IsNullOrEmptyReturnValue(
                    contact.InstitutionalName.NTrim()
                    ));

                if (contact.Dob.HasValue)
                {
                    txtDateofBirth.Text = contact.Dob.Value.ToString("dd-MMM-yyyy").ToUpper();
                    InsuredAge = Utility.GetAge(contact.Dob.Value);
                }

                var lstIdentification = ObjServices.oContactManager.GetAllIdDocumentInformation(ObjServices.ContactEntityID.GetValueOrDefault(),
                    ObjServices.getCurrentLanguage());

                if (lstIdentification != null && lstIdentification.Any())
                {
                    var dataId = lstIdentification.First();
                    txtIdentification.Text = dataId.Id;
                    txtIdentificationType.Text = dataId.ContactIdTypeDescription;

                    if (dataId.ContactIdType != Utility.IdentificationType.CompanyRegistration.ToInt())
                    {
                        pnExpDate.Visible = true;
                        txtExpDate.Text = dataId.ExpireDate.HasValue ? dataId.ExpireDate.Value.ToString("dd-MMM-yyyy").ToUpper() : "N/A";
                    }
                    else
                        pnExpDate.Visible = false;
                }

                var lstPhones = ObjServices.GetCommunicatonPhone();
                if (lstPhones != null && lstPhones.Any())
                {
                    var phone = lstPhones.FirstOrDefault(o =>
                        o.DirectoryTypeId == Utility.DirectoryType.HomePhone.ToInt() ||
                        o.DirectoryTypeId == Utility.DirectoryType.OtherPhone.ToInt());
                    if (phone != null)
                        txtPhone.Text = (String.IsNullOrEmpty(phone.AreaCode) ? "" : (phone.AreaCode + "-")) + phone.PhoneNumber;

                    phone = lstPhones.FirstOrDefault(o => o.DirectoryTypeId == Utility.DirectoryType.CellPhone.ToInt());
                    if (phone != null)
                        txtCellPhone.Text = (String.IsNullOrEmpty(phone.AreaCode) ? "" : (phone.AreaCode + "-")) + phone.PhoneNumber;
                }

                var lstAddresses = ObjServices.GetCommunicatonAdress();
                if (lstAddresses != null && lstAddresses.Any())
                {
                    var address = lstAddresses.FirstOrDefault();
                    if (address != null)
                    {
                        txtAddress.Text = address.StreetAddress;
                        txtCountry.Text = address.CountryDesc;
                        txtPostalCode.Text = address.ZipCode;  //ADDED ZIP CODE BY ROJAS
                        txtCity.Text = address.CityDesc;      //ADDED CITY BY ROJAS  
                    }
                }

                var lstEmails = ObjServices.GetCommunicationEmail();
                if (lstEmails != null && lstEmails.Any())
                {
                    var email = lstEmails.FirstOrDefault();
                    if (email != null)
                        txtEmail.Text = email.EmailAdress;

                }

                /*ADDED HERE BY ROJAS */
                var gender = contact.Gender;  //GENERO

                if (gender != null && gender.Any())
                {
                    switch (gender)
                    {
                        case "M": TxtGender.Text = "Masculino"; break;
                        case "F": TxtGender.Text = "Femenino"; break;
                        default: TxtGender.Text = "N/A"; break;
                    }
                }

                var maritalid = contact.MaritalStatId;   //ESTADO CIVIL

                var maritalstatus = string.Empty;

                if (maritalid != null)
                {
                    switch (maritalid)
                    {
                        case 1:
                            maritalstatus = "married";
                            break;
                        case 2:
                            maritalstatus = "divorced";
                            break;
                        case 3:
                            maritalstatus = "widowed";
                            break;
                        case 4:
                            maritalstatus = "single";
                            break;
                        default:
                            maritalstatus = "no especifica";
                            break;
                    }
                }

                txtMaritalStatus.Text = maritalstatus;

                var occupation = contact.Occupation_Desc;  //OCUPACION
                if (occupation != null && occupation.Any())
                    txtOccupation.Text = occupation;

                var monthlyincome = contact.AnnualPersonalIncome / 13; //INGRESO MENSUAL
                if (monthlyincome != null)
                    txtMonthlyIncome.Text = monthlyincome.ToString();

                var producto = ObjServices.ProductLine;  //LINEA DE PRODUCTO
                txtProductNameA.Text = producto.ToString();

                var odescripcion = contact.Occupation_Group_Desc; //OCUPACION DESCRIPCION
                if (odescripcion != null && odescripcion.Any())
                    txtOccupationDescription.Text = odescripcion;

                var citizenship = contact.Citizenships; //NACIONALIDAD

                if (citizenship != null && citizenship.Any())
                {
                    var citizen = citizenship.FirstOrDefault();
                    if (citizen != null)
                    {
                        txtCitizenship.Text = citizen.GlobalCountryDesc;
                        ObjServices.Nationality = citizen.GlobalCountryDesc.ToLower();
                        ObjServices.NationalityCountryId = citizen.GlobalCountryId;
                    }
                }

                //DEDUCTIBLE SELECCIONADO???
                var illustrationhealt = ObjServices.oHealthManager.GetBenefitPlan(new Health.BenefitPlan.Key()
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticRegId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No
                }).FirstOrDefault();

                if (illustrationhealt != null)
                {
                    txtSelectedDeductible.Text = illustrationhealt.DeductibleCategoryValue.ToString();
                    txtProductNameA.Text = illustrationhealt.ProductDesc;
                    BenefitPlanDesc = illustrationhealt.BenefitPlanDesc;
                }

                var KRiesgos = new[]
                {                 
                    Utility.TipoRiesgo.RA,
                    Utility.TipoRiesgo.RB,
                    Utility.TipoRiesgo.RM
                };


                //Verificar si ya se hizo la verificacion crediticia                
                var keyRiesgo = contact.TipoRiesgoNameKey == "N/A" || string.IsNullOrEmpty(contact.TipoRiesgoNameKey) ? "NONE" : contact.TipoRiesgoNameKey;

                var isVisible = true;

                if ((keyRiesgo == null))
                    isVisible = false;

                if (!KRiesgos.Contains((Utility.TipoRiesgo)Enum.Parse(typeof(Utility.TipoRiesgo), keyRiesgo)))
                    isVisible = false;

                pnMoreInformation.Visible = isVisible;

                if (isVisible)
                {
                    //Id Doc
                    var dataId = ObjServices.oContactManager.GetAllIdDocumentInformation(ContactId, ObjServices.Language.ToInt());
                    var RecordId = dataId.FirstOrDefault();

                    if (RecordId.ContactIdType == Utility.IdentificationType.ID.ToInt() ||
                        RecordId.ContactIdType == Utility.IdentificationType.DriverLicense.ToInt())
                    {
                        var pCedulaOrDriverLicense = RecordId.Id.Replace("-", "").RemoveInvalidCharacters().RemoveAccentsWithRegEx();

                        var data = new ReportHCIDatosGenerales();

                        try
                        {
                            var TransunionClient = ObjServices.TransunionServiceLogIn(user, pass, DefaulltPassword);

                            var param = new Identification
                            {
                                Cedula = pCedulaOrDriverLicense,
                                UserId = ObjServices.UserName
                            };

                            data = TransunionClient.GetReportHCI(param);

                            if (data == null)
                                return;
                        }
                        catch (Exception)
                        {
                            udpInsuredInformation.Update();
                            return;
                        }

                        //Traer informacion de contacto del servicio de transunion
                        var Telefonos = data.Telefonos;

                        var dCasa = data.Telefonos.FirstOrDefault(g => g.Tipo == "Casa");
                        if (dCasa != null && !string.IsNullOrEmpty(dCasa.Numero))
                            txtCasa.Text = string.Format("{0:(###)-###-####}", Convert.ToInt64(dCasa.Numero));

                        var dTrabajo = data.Telefonos.FirstOrDefault(g => g.Tipo == "Trabajo");
                        if (dTrabajo != null && !string.IsNullOrEmpty(dTrabajo.Numero))
                            txtTrabajo.Text = string.Format("{0:(###)-###-####}", Convert.ToInt64(dTrabajo.Numero));

                        var dCelular = data.Telefonos.FirstOrDefault(g => g.Tipo == "Celular");
                        if (dCelular != null && !string.IsNullOrEmpty(dCelular.Numero))
                            txtCelular.Text = string.Format("{0:(###)-###-####}", Convert.ToInt64(dCelular.Numero));

                        var dDirecciones = data.Direcciones;
                        var Direcciones = new List<string>(0);

                        if (dDirecciones.Any())
                            foreach (var item in dDirecciones)
                                Direcciones.Add(item.Descricion);

                        txtDireccion.Text = Direcciones.Any() ? string.Join("\n\n", Direcciones.ToArray())
                                                              : string.Empty;
                    }
                }

                udpInsuredInformation.Update();
            }
            catch (Exception ex)
            {
                base.DownloadErrorDescripcion(ex);
            }
        }

        public string GetInsuredName()
        {
            return txtClientName.Text;
        }

        public void Initialize()
        {
            ClearData();
            FillData();

            if (ObjServices.isExclusion || ObjServices.isVehicleChange)
            {
                btnEditContact.Visible = false;
                lnkPaymentAgreement.Visible = false;
            }
        }

        public void ClearData()
        {

        }

        protected void btnEditContact_Click(object sender, EventArgs e)
        {
            UCContactEditForm.ContactId = this.ContactId;
            UCContactEditForm.Initialize();
            hdnShowPopContactEdit.Value = "true";
            mpeContactEditPop.Show();
            udpInsuredInformation.Update();
        }

        protected void btnEditContact_PreRender(object sender, EventArgs e)
        {
            var ButtonSender = (sender as LinkButton);
            var isVisible = false;
            var tabSeleccionado = (Utility.Tabs)Enum.Parse(typeof(Utility.Tabs), ObjServices.hdnQuotationTabs);

            switch (tabSeleccionado)
            {
                case Utility.Tabs.lnkIllustrationsToWork:
                case Utility.Tabs.lnkCompleteIllustrations:
                case Utility.Tabs.lnkExpiring:
                case Utility.Tabs.lnkMissingDocuments:
                    isVisible = ObjServices.IsAgentQuotRole || ObjServices.isUserCot;
                    ButtonSender.Visible = isVisible;
                    break;
                case Utility.Tabs.lnkSubscriptions:
                    isVisible = ObjServices.IsSuscripcionQuotRole || ObjServices.IsSucripcionDirectorQuotRole || ObjServices.IsSuscripcionManagerQuotRole || ObjServices.isUserCot;
                    ButtonSender.Visible = isVisible;
                    break;   
                case Utility.Tabs.lnkConfirmationCall:
                    ButtonSender.Visible = true;
                    break;
                case Utility.Tabs.lnkHistoricalIllustrations:
                    ButtonSender.Visible = ObjServices.isUserCot || ObjServices.CanViewContactInformation;
                    break;
                case Utility.Tabs.lnkApprovedBySubscription:
                    ButtonSender.Visible = ObjServices.ViewCreditCardInformation || ObjServices.CanViewContactInformation;
                    break;
                default:
                    ButtonSender.Visible = isVisible;
                    break;
            }
        }

        protected void lnkPaymentAgreement_Click(object sender, EventArgs e)
        {
            UCPaymentAgreement.Initialize();
            hdnShowPopPaymentAgreementPop.Value = "true";
            mpePaymentAgreementPop.Show();
        }

        protected void lnkPaymentAgreement_PreRender(object sender, EventArgs e)
        {
            var ButtonSender = (sender as LinkButton);
            var isVisible = false;
            var tabSeleccionado = (Utility.Tabs)Enum.Parse(typeof(Utility.Tabs), ObjServices.hdnQuotationTabs);

            switch (tabSeleccionado)
            {
                case Utility.Tabs.lnkIllustrationsToWork:
                case Utility.Tabs.lnkCompleteIllustrations:
                case Utility.Tabs.lnkExpiring:
                case Utility.Tabs.lnkMissingDocuments:
                    isVisible = ObjServices.IsAgentQuotRole || ObjServices.IsAngetInspectorQuotRole || ObjServices.isUserCot;
                    ButtonSender.Visible = isVisible;
                    break;
                case Utility.Tabs.lnkSubscriptions:
                    isVisible = ObjServices.IsSuscripcionQuotRole || ObjServices.IsSucripcionDirectorQuotRole || ObjServices.IsSuscripcionManagerQuotRole || ObjServices.isUserCot;
                    ButtonSender.Visible = isVisible;
                    break;
                case Utility.Tabs.lnkDeclinedByClient:
                    ButtonSender.Visible = false;
                    break;
                case Utility.Tabs.lnkDeclinedBySubscription:
                    ButtonSender.Visible = false;
                    break;
                case Utility.Tabs.lnkExpired:
                    ButtonSender.Visible = false;
                    break;
                case Utility.Tabs.lnkMissingInspections:
                    ButtonSender.Visible = false;
                    break;
                case Utility.Tabs.lnkConfirmationCall:
                    ButtonSender.Visible = true;
                    break;
                case Utility.Tabs.lnkHistoricalIllustrations:
                case Utility.Tabs.lnkApprovedBySubscription:
                    ButtonSender.Visible = true;
                    break;
            }
        }

        protected void btnCerrarPOP_Click(object sender, EventArgs e)
        {
            hdnShowPopContactEdit.Value = "false";
            mpeContactEditPop.Hide();
        }
    }
}