using Statetrust.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCEndosoCesion : UC, IUC
    {
        public delegate void ExportToPDFHandler(byte[] pdfFile, string FileName);

        public event ExportToPDFHandler ExportToPdf;

        public UCVehiclesInformation UCVehiclesInformation
        {
            get
            {
                return ((UCVehiclesInformation)this.Parent.Parent);
            }
        }

        public long? InsuredVehicleId
        {
            get
            {
                return !string.IsNullOrEmpty(hdnInsuredVehicleId.Value) ? hdnInsuredVehicleId.Value.ToLong()
                                                                        : 0;
            }
            set
            {
                hdnInsuredVehicleId.Value = value != null ? value.ToString()
                                                          : string.Empty;
            }
        }

        public long? VehicleUniqueId
        {
            get
            {
                return ViewState["VehicleUniqueId"] != null ? ViewState["VehicleUniqueId"].ToLong() : 0;
            }
            set
            {
                ViewState["VehicleUniqueId"] = value != null ? value.ToString()
                                                             : string.Empty;
            }
        }

        public int? VehicleValue
        {
            get
            {
                return ViewState["VehicleValue"] == null ? 0
                                                         : ViewState["VehicleValue"].ToInt();
            }

            set
            {
                ViewState["VehicleValue"] = value != null ? value
                                                          : 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(string Lang)
        {

        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            txtBeneficiario.ReadOnly = isReadOnly;
            txtMonto.ReadOnly = isReadOnly;
            txtRNC.ReadOnly = isReadOnly;
            txtContactName.ReadOnly = isReadOnly;
            txtPhoneNumber.ReadOnly = isReadOnly;
            txtEmailAddress.ReadOnly = isReadOnly;
            btnEndosoCesionGuardar.Visible = !isReadOnly;
            pnAnularEndoso.Visible = !isReadOnly;
            txtSelectBenficiary.Enabled = !isReadOnly;
        }

        /// <summary>
        /// Salvar la data
        /// </summary>
        public void save()
        {
            try
            {
                var EndorsementAmount = decimal.Parse(txtMonto.Text.Replace(",", ""), CultureInfo.InvariantCulture);

                if (EndorsementAmount > VehicleValue)
                {
                    this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.EndonsoNotBigger, Title: "Error");
                    return;
                }

                var dataVehicle = ObjServices.oPolicyManager.GetVehicleInsured(new Entity.UnderWriting.Entities.Policy.Parameter
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
                }).FirstOrDefault(h => h.InsuredVehicleId == InsuredVehicleId.ToInt());

                dataVehicle.EndorsementAmount = EndorsementAmount;
                dataVehicle.EndorsementBbeneficiaryRnc = txtRNC.Text;
                dataVehicle.EndorsementBeneficiary = txtBeneficiario.Text;
                dataVehicle.EndorsementContactName = txtContactName.Text;
                dataVehicle.EndorsementContactPhone = txtPhoneNumber.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                dataVehicle.EndorsementContactEmail = txtEmailAddress.Text;
                dataVehicle.UserId = ObjServices.UserID.GetValueOrDefault();

                ObjServices.oPolicyManager.SetVehicleInsured(dataVehicle);

                UCVehiclesInformation.FillData("", UCVehiclesInformation.EnableTag, UCVehiclesInformation.CanEnableInspection);

                lnkAnularEndoso.Visible =
                    lnkDescargarHojaEndoso.Visible = true;

                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully);
            }
            catch (Exception ex)
            {
                var msg = string.Format("ExceptionMessage {0} InnerException {1} TraceStack {2}", ex.Message.MyRemoveInvalidCharacters(), ex.InnerException, ex.StackTrace.MyRemoveInvalidCharacters());
                this.MessageBox(ex.Message);
            }
        }

        public void edit()
        {

        }

        public void FillData(Utility.EndorstmentData endorstmentdata)
        {
            txtBeneficiario.Text = endorstmentdata.EndorsementBeneficiary;
            txtMonto.Text = endorstmentdata.EndorsementAmount.HasValue ? endorstmentdata.EndorsementAmount.Value.ToString("#0.00", NumberFormatInfo.InvariantInfo) : "0.00";
            txtRNC.Text = endorstmentdata.EndorsementBbeneficiaryRnc;
            txtContactName.Text = endorstmentdata.EndorsementContactName;
            txtPhoneNumber.Text = endorstmentdata.EndorsementContactPhone;
            txtEmailAddress.Text = endorstmentdata.EndorsementContactEmail;
            var HojaEndosoVisible = !string.IsNullOrEmpty(txtRNC.Text) && !string.IsNullOrEmpty(txtBeneficiario.Text) && txtMonto.ToDecimal() > 0;
            lnkDescargarHojaEndoso.Visible = HojaEndosoVisible;
            lnkAnularEndoso.Visible = lnkDescargarHojaEndoso.Visible;
        }               

        public void FillDrop()
        {
            
        }

        public void Initialize()
        {
            var tabSelected = (Utility.Tabs)Enum.Parse(typeof(Utility.Tabs), ObjServices.hdnQuotationTabs);

            Utility.Tabs[] tabs = new[]
            {
                Utility.Tabs.lnkIllustrationsToWork,
                Utility.Tabs.lnkCompleteIllustrations,
                Utility.Tabs.lnkExpiring,
                Utility.Tabs.lnkMissingDocuments
            };

            ReadOnlyControls(!tabs.Contains(tabSelected));
            ClearData();
            FillDrop();
        }

        public void ClearData()
        {
            txtMonto.Clear("0.00");
            txtBeneficiario.Clear();
            txtRNC.Clear();
            txtContactName.Clear();
            txtPhoneNumber.Clear();
            txtEmailAddress.Clear();
            txtSelectBenficiary.Clear();
        }

        private byte[] UploadPDfHojaEndoso()
        {
            byte[] result = null;

            try
            {
                var ServerMaptPath = Server.MapPath("~/NewBusiness/XML/");
                //Mostrar la cotizacion generada via thunderhead
                //Generar el Documento XML con la data de la cotizazion 
                var XMLByteArray = ObjServices.GenerateXMLQuotationToThunderhead(ObjServices.Corp_Id,
                                                                                 ObjServices.Region_Id,
                                                                                 ObjServices.Country_Id,
                                                                                 ObjServices.Domesticreg_Id,
                                                                                 ObjServices.State_Prov_Id,
                                                                                 ObjServices.City_Id,
                                                                                 ObjServices.Office_Id,
                                                                                 ObjServices.Case_Seq_No,
                                                                                 ObjServices.Hist_Seq_No,
                                                                                 ServerMaptPath,
                                                                                 vehicleUniqueID: VehicleUniqueId,
                                                                                 templateType: ThunderheadWrap.Service.TemplateType.Endoso
                                                                                 );

                var PDFByteArray = ObjServices.SendToThunderHead(XMLByteArray, ThunderheadWrap.Service.TemplateType.Endoso);
                result = PDFByteArray;
            }
            catch (Exception ex)
            {
                var msg = ex.GetLastInnerException().Message;
                this.MessageBox(msg.RemoveInvalidCharacters().Replace('\'', '\"'), Title: "Error", Width: 800);
            }

            return result;
        }

        protected void lnkDescargarHojaEndoso_Click(object sender, EventArgs e)
        {
            ExportToPdf(UploadPDfHojaEndoso(), "Endoso");

        }

        protected void btnEndosoCesionGuardar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void AnularEndoso()
        {
            //Verificar si para este endoso ya se le subio el documento en documentos requeridos.
            var dataDoc = ObjServices.GetDataDocument();

            if (dataDoc != null)
            {
                var DataEndoso = dataDoc.FirstOrDefault(x => x.RequimentOnBaseNameKey == "SRV-Hoja de Emision de Seguro");

                if (DataEndoso != null)
                {
                    var hasEndoso = DataEndoso.DocumentId.HasValue;

                    if (hasEndoso)
                    {
                        this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DontDeleteEndoso);
                        return;
                    }
                }
            }

            ObjServices.oPolicyManager.SetVehicleInsured(new Entity.UnderWriting.Entities.Policy.VehicleInsured
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
                InsuredVehicleId = InsuredVehicleId.ToInt(),
                EndorsementAmount = null,
                EndorsementBbeneficiaryRnc = null,
                EndorsementBeneficiary = null,
                EndorsementContactEmail = null,
                EndorsementContactName = null,
                EndorsementContactPhone = null,
                UserId = ObjServices.UserID.GetValueOrDefault()
            });

            Initialize();

            UCVehiclesInformation.FillData("", UCVehiclesInformation.EnableTag, UCVehiclesInformation.CanEnableInspection);

            lnkAnularEndoso.Visible =
            lnkDescargarHojaEndoso.Visible = false;
        }

        protected void lnkAnularEndoso_Click(object sender, EventArgs e)
        {
            AnularEndoso();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }

        protected void ddlBeneficiario_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            if (drop.SelectedValue != "-1")
            {
                var dataItem = Utility.deserializeJSON<Utility.ItemEndorsement>(drop.SelectedValue);
                txtBeneficiario.Text = drop.SelectedItem.Text;
                txtRNC.Text = dataItem.Rnc;
                txtContactName.Text = dataItem.ContactName;
                txtPhoneNumber.Text = dataItem.ContactTel;
                txtEmailAddress.Text = dataItem.ContactAdress;
            }
            else
            {
                txtBeneficiario.Clear();
                txtRNC.Clear();
                txtContactName.Clear();
                txtPhoneNumber.Clear();
                txtEmailAddress.Clear();
            }
        }
    }
}