using Statetrust.Framework.Security.Dal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle;
using WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Products;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines
{
    public partial class UCEndosoCesionAlliedLines : UC, IUC
    {
        public delegate void ExportToPDFHandler(byte[] pdfFile, string FileName);

        public event ExportToPDFHandler ExportToPdf;
        public delegate void BindingGridEventHandler();
        public event BindingGridEventHandler BindGrid;

        public int SeqId
        {
            get { return ViewState["SeqId"].ToInt(); }
            set { ViewState["SeqId"] = value; }
        }

        public int UniqueId
        {
            get { return ViewState["UniqueId"].ToInt(); }
            set { ViewState["UniqueId"] = value; }
        }

        public int InsuredAmount
        {
            get { return ViewState["InsuredAmount"].ToInt(); }
            set { ViewState["InsuredAmount"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(string Lang)
        {

        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            txtSelectBenficiary.Enabled = !isReadOnly;
            txtBeneficiario.ReadOnly = isReadOnly;
            txtMonto.ReadOnly = isReadOnly;
            txtRNC.ReadOnly = isReadOnly;
            txtContactName.ReadOnly = isReadOnly;
            txtPhoneNumber.ReadOnly = isReadOnly;
            txtEmailAddress.ReadOnly = isReadOnly;
            btnEndosoCesionGuardar.Visible = !isReadOnly;
            pnAnularEndoso.Visible = !isReadOnly;
        }

        public void FillDrop()
        {
            
        }

        /// <summary>
        /// Salvar la data
        /// </summary>
        public void save()
        {
            try
            {
                var EndorsementAmount = decimal.Parse(txtMonto.Text.Replace(",", ""), CultureInfo.InvariantCulture);
                var PhoneNumber = txtPhoneNumber.Text.Replace("(", "").Replace(")", "").Replace("-", ""); 
                var PriceOfVehicle = InsuredAmount;                                                       

                if (EndorsementAmount > PriceOfVehicle)
                {
                    this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.EndonsoNotBigger, Title: "Error");
                    return;
                }

                switch (ObjServices.AlliedLinesProductBehavior)
                {
                    #region Airplane
                    case Utility.AlliedLinesType.Airplane:
                        var dataAirPlane = ObjServices.oAirPlaneManager.GetAirplaneInsured(new Entity.UnderWriting.Entities.Airplane.Insured.Key
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
                        }).FirstOrDefault((h => h.UniqueAirplaneId == UniqueId));

                        if (dataAirPlane != null)
                        {
                            dataAirPlane.Endorsement = true;
                            dataAirPlane.EndorsementAmount = EndorsementAmount;
                            dataAirPlane.EndorsementBeneficiary = txtBeneficiario.Text;
                            dataAirPlane.EndorsementBeneficiaryRnc = txtRNC.Text;
                            dataAirPlane.EndorsementContactName = txtContactName.Text;
                            dataAirPlane.EndorsementContactPhone = PhoneNumber;
                            dataAirPlane.EndorsementContactEmail = txtEmailAddress.Text;
                            ObjServices.oAirPlaneManager.SetAirplaneInsured(dataAirPlane);
                        }
                        break;
                    #endregion
                    #region Bail
                    case Utility.AlliedLinesType.Bail:
                        var dataBail = ObjServices.oBailManager.GetBailInsured(new Entity.UnderWriting.Entities.Bail.Insured.Key
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
                       }).FirstOrDefault((h => h.UniqueBailId == UniqueId));

                        if (dataBail != null)
                        {
                            dataBail.Endorsement = true;
                            dataBail.EndorsementAmount = EndorsementAmount;
                            dataBail.EndorsementBeneficiaryRnc = txtRNC.Text;
                            dataBail.EndorsementBeneficiary = txtBeneficiario.Text;
                            dataBail.EndorsementContactName = txtContactName.Text;
                            dataBail.EndorsementContactPhone = PhoneNumber;
                            dataBail.EndorsementContactEmail = txtEmailAddress.Text;
                            dataBail.UsrId = ObjServices.UserID.GetValueOrDefault();
                            ObjServices.oBailManager.SetBailInsured(dataBail);
                        }
                        break;
                    #endregion
                    #region Navy
                    case Utility.AlliedLinesType.Navy:
                        var dataNavy = ObjServices.oNavyManager.GetNavyInsured(new Entity.UnderWriting.Entities.Navy.Insured.Key
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
                       }).FirstOrDefault((h => h.UniqueNavyId == UniqueId));

                        if (dataNavy != null)
                        {
                            dataNavy.Endorsement = true;
                            dataNavy.EndorsementAmount = EndorsementAmount;
                            dataNavy.EndorsementBeneficiaryRnc = txtRNC.Text;
                            dataNavy.EndorsementBeneficiary = txtBeneficiario.Text;
                            dataNavy.EndorsementContactName = txtContactName.Text;
                            dataNavy.EndorsementContactPhone = PhoneNumber;
                            dataNavy.EndorsementContactEmail = txtEmailAddress.Text;
                            dataNavy.UserId = ObjServices.UserID.GetValueOrDefault();
                            ObjServices.oNavyManager.SetNavyInsured(dataNavy);
                        }
                        break;
                    #endregion
                    #region Property
                    case Utility.AlliedLinesType.Property:

                        var dataProperty = ObjServices.oPropertyManager.GetPropertyInsuredDet(new Entity.UnderWriting.Entities.Property.Insured.Detail
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
                            SeqId = SeqId,
                            uniquePropertyId = UniqueId
                        });

                        if (dataProperty != null)
                        {
                            dataProperty.Endorsement = true;
                            dataProperty.EndorsementAmount = EndorsementAmount;
                            dataProperty.EndorsementBeneficiaryRnc = txtRNC.Text;
                            dataProperty.EndorsementBeneficiary = txtBeneficiario.Text;
                            dataProperty.EndorsementContactName = txtContactName.Text;
                            dataProperty.EndorsementContactPhone = PhoneNumber;
                            dataProperty.EndorsementContactEmail = txtEmailAddress.Text;
                            ObjServices.oPropertyManager.SetPropertyInsuredDetail(dataProperty);
                        }
                        break;
                    #endregion
                    #region Transport
                    case Utility.AlliedLinesType.Transport:
                        var dataTransport = ObjServices.oTransportManager.GetTransportInsured(new Entity.UnderWriting.Entities.Transport.Insured.Key
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
                       }).FirstOrDefault((h => h.UniqueTransportId == UniqueId));

                        if (dataTransport != null)
                        {
                            dataTransport.Endorsement = true;
                            dataTransport.EndorsementAmount = EndorsementAmount;
                            dataTransport.EndorsementBeneficiaryRnc = txtRNC.Text;
                            dataTransport.EndorsementBeneficiary = txtBeneficiario.Text;
                            dataTransport.EndorsementContactName = txtContactName.Text;
                            dataTransport.EndorsementContactPhone = PhoneNumber;
                            dataTransport.EndorsementContactEmail = txtEmailAddress.Text;
                            dataTransport.UserId = ObjServices.UserID.GetValueOrDefault();
                            ObjServices.oTransportManager.SetTransportInsured(dataTransport);
                        }
                        break;
                    #endregion
                }

                BindGrid();
                lnkAnularEndoso.Visible =
                lnkDescargarHojaEndoso.Visible = true;
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully);
            }
            catch (Exception ex)
            {
                var msg = string.Format("ExceptionMessage {0} InnerException {1} TraceStack {2}", ex.Message.MyRemoveInvalidCharacters(), ex.InnerException, ex.StackTrace.MyRemoveInvalidCharacters());
                this.MessageBox(msg);
            }
        }

        public void edit()
        {

        }

        public void FillData()
        {
            switch (ObjServices.AlliedLinesProductBehavior)
            {
                case Utility.AlliedLinesType.Airplane:
                    var dataAirPlane = ObjServices.GetDataAirPlane(UniqueId).FirstOrDefault();

                    if (dataAirPlane != null)
                    {
                        txtBeneficiario.Text = dataAirPlane.EndorsementBeneficiary;
                        txtMonto.Text = dataAirPlane.EndorsementAmount.HasValue ? dataAirPlane.EndorsementAmount.Value.ToString("#0.00", NumberFormatInfo.InvariantInfo) : "0.00";
                        txtRNC.Text = dataAirPlane.EndorsementBeneficiaryRnc;
                        txtContactName.Text = dataAirPlane.EndorsementContactName;
                        txtPhoneNumber.Text = dataAirPlane.EndorsementContactPhone;
                        txtEmailAddress.Text = dataAirPlane.EndorsementContactEmail;
                    }
                    break;
                case Utility.AlliedLinesType.Bail:
                    var dataBail = ObjServices.GetDataBail(UniqueId).FirstOrDefault();

                    if (dataBail != null)
                    {
                        txtBeneficiario.Text = dataBail.EndorsementBeneficiary;
                        txtMonto.Text = dataBail.EndorsementAmount.HasValue ? dataBail.EndorsementAmount.Value.ToString("#0.00", NumberFormatInfo.InvariantInfo) : "0.00";
                        txtRNC.Text = dataBail.EndorsementBeneficiaryRnc;
                        txtContactName.Text = dataBail.EndorsementContactName;
                        txtPhoneNumber.Text = dataBail.EndorsementContactPhone;
                        txtEmailAddress.Text = dataBail.EndorsementContactEmail;
                    }
                    break;
                case Utility.AlliedLinesType.Navy:
                    var dataNavy = ObjServices.GetDataNavy(UniqueId).FirstOrDefault();

                    if (dataNavy != null)
                    {
                        txtBeneficiario.Text = dataNavy.EndorsementBeneficiary;
                        txtMonto.Text = dataNavy.EndorsementAmount.HasValue ? dataNavy.EndorsementAmount.Value.ToString("#0.00", NumberFormatInfo.InvariantInfo) : "0.00";
                        txtRNC.Text = dataNavy.EndorsementBeneficiaryRnc;
                        txtContactName.Text = dataNavy.EndorsementContactName;
                        txtPhoneNumber.Text = dataNavy.EndorsementContactPhone;
                        txtEmailAddress.Text = dataNavy.EndorsementContactEmail;
                    }
                    break;
                case Utility.AlliedLinesType.Property:
                    var dataProperty = ObjServices.GetDataProperty(UniqueId).FirstOrDefault();

                    if (dataProperty != null)
                    {
                        txtBeneficiario.Text = dataProperty.EndorsementBeneficiary;
                        txtMonto.Text = dataProperty.EndorsementAmount.HasValue ? dataProperty.EndorsementAmount.Value.ToString("#0.00", NumberFormatInfo.InvariantInfo) : "0.00";
                        txtRNC.Text = dataProperty.EndorsementBeneficiaryRnc;
                        txtContactName.Text = dataProperty.EndorsementContactName;
                        txtPhoneNumber.Text = dataProperty.EndorsementContactPhone;
                        txtEmailAddress.Text = dataProperty.EndorsementContactEmail;
                    }
                    break;
                case Utility.AlliedLinesType.Transport:
                    var dataTransport = ObjServices.GetDataTransport(UniqueId).FirstOrDefault();

                    if (dataTransport != null)
                    {
                        txtBeneficiario.Text = dataTransport.EndorsementBeneficiary;
                        txtMonto.Text = dataTransport.EndorsementAmount.HasValue ? dataTransport.EndorsementAmount.Value.ToString("#0.00", NumberFormatInfo.InvariantInfo) : "0.00";
                        txtRNC.Text = dataTransport.EndorsementBeneficiaryRnc;
                        txtContactName.Text = dataTransport.EndorsementContactName;
                        txtPhoneNumber.Text = dataTransport.EndorsementContactPhone;
                        txtEmailAddress.Text = dataTransport.EndorsementContactEmail;
                    }
                    break;
                case Utility.AlliedLinesType.Vehicle:
                    break;
                default:
                    break;
            }

            var HojaEndosoVisible = !string.IsNullOrEmpty(txtRNC.Text) && !string.IsNullOrEmpty(txtBeneficiario.Text) && txtMonto.ToDecimal() > 0;
            lnkDescargarHojaEndoso.Visible = HojaEndosoVisible;
            lnkAnularEndoso.Visible = lnkDescargarHojaEndoso.Visible;
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
        }

        private byte[] UploadPDfHojaEndoso()
        {
            byte[] result = null;

            try
            {
                if (ObjServices.ProductLine == Utility.ProductLine.Auto)
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
                                                                                     vehicleUniqueID: UniqueId,
                                                                                     templateType: ThunderheadWrap.Service.TemplateType.Endoso
                                                                                     );

                    result = ObjServices.SendToThunderHead(XMLByteArray, ThunderheadWrap.Service.TemplateType.Endoso);

                }
                else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                {
                    var param = new Entity.UnderWriting.Entities.Property.Key
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
                    };

                    var XMLArrayByte = ObjServices.GenerateEndosoPropertyXMLByThunderhead(param, templateType: ThunderheadWrap.Service.TemplateType.EndosoCesionDerecho);

                    result = ObjServices.SendToThunderHead(XMLArrayByte,
                                                           ThunderheadWrap.Service.TemplateType.EndosoCesionDerecho,
                                                           ThunderheadWrap.Service.BusinessLine.IncendioLineasAliadas,
                                                           ThunderheadWrap.Service.ContactCountry.ElSalvador
                                                           );
                }
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
            switch (ObjServices.AlliedLinesProductBehavior)
            {
                #region Airplane
                case Utility.AlliedLinesType.Airplane:
                    var dataAirPlane = ObjServices.oAirPlaneManager.GetAirplaneInsured(new Entity.UnderWriting.Entities.Airplane.Insured.Key
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
                       }).FirstOrDefault((h => h.UniqueAirplaneId == UniqueId));

                    if (dataAirPlane != null)
                    {
                        dataAirPlane.Endorsement = false;
                        dataAirPlane.EndorsementAmount = null;
                        dataAirPlane.EndorsementBeneficiaryRnc = null;
                        dataAirPlane.EndorsementBeneficiary = null;

                        dataAirPlane.EndorsementContactName = null;
                        dataAirPlane.EndorsementContactPhone = null;
                        dataAirPlane.EndorsementContactEmail = null;

                        txtContactName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtEmailAddress.Text = "";

                        ObjServices.oAirPlaneManager.SetAirplaneInsured(dataAirPlane);
                    }
                    break;
                #endregion
                #region Bail
                case Utility.AlliedLinesType.Bail:
                    var dataBail = ObjServices.oBailManager.GetBailInsured(new Entity.UnderWriting.Entities.Bail.Insured.Key
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
                       }).FirstOrDefault((h => h.UniqueBailId == UniqueId));

                    if (dataBail != null)
                    {
                        dataBail.Endorsement = false;
                        dataBail.EndorsementAmount = null;
                        dataBail.EndorsementBeneficiaryRnc = null;
                        dataBail.EndorsementBeneficiary = null;
                        dataBail.UsrId = ObjServices.UserID.GetValueOrDefault();

                        dataBail.EndorsementContactName = null;
                        dataBail.EndorsementContactPhone = null;
                        dataBail.EndorsementContactEmail = null;

                        txtContactName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtEmailAddress.Text = "";

                        ObjServices.oBailManager.SetBailInsured(dataBail);
                    }
                    break;
                #endregion
                #region Navy
                case Utility.AlliedLinesType.Navy:
                    var dataNavy = ObjServices.oNavyManager.GetNavyInsured(new Entity.UnderWriting.Entities.Navy.Insured.Key
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
                        }).FirstOrDefault((h => h.UniqueNavyId == UniqueId));

                    if (dataNavy != null)
                    {
                        dataNavy.Endorsement = false;
                        dataNavy.EndorsementAmount = null;
                        dataNavy.EndorsementBeneficiaryRnc = null;
                        dataNavy.EndorsementBeneficiary = null;
                        dataNavy.UserId = ObjServices.UserID.GetValueOrDefault();

                        dataNavy.EndorsementContactName = null;
                        dataNavy.EndorsementContactPhone = null;
                        dataNavy.EndorsementContactEmail = null;

                        txtContactName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtEmailAddress.Text = "";

                        ObjServices.oNavyManager.SetNavyInsured(dataNavy);
                    }
                    break;
                #endregion
                #region Property
                case Utility.AlliedLinesType.Property:
                    var dataProperty = ObjServices.oPropertyManager.GetProperty(new Entity.UnderWriting.Entities.Property.Key
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
                        }).FirstOrDefault((h => h.UniquePropertyId == UniqueId));

                    if (dataProperty != null)
                    {
                        dataProperty.EndorsementAmount = null;
                        dataProperty.EndorsementBeneficiaryRnc = null;
                        dataProperty.EndorsementBeneficiary = null;
                        dataProperty.UserId = ObjServices.UserID.GetValueOrDefault();

                        dataProperty.EndorsementContactName = null;
                        dataProperty.EndorsementContactPhone = null;
                        dataProperty.EndorsementContactEmail = null;

                        txtContactName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtEmailAddress.Text = "";

                        ObjServices.oPropertyManager.SetProperty(dataProperty);
                    }
                    break;
                #endregion
                #region Transport
                case Utility.AlliedLinesType.Transport:
                    var dataTransport = ObjServices.oTransportManager.GetTransportInsured(new Entity.UnderWriting.Entities.Transport.Insured.Key
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
                      }).FirstOrDefault((h => h.UniqueTransportId == UniqueId));

                    if (dataTransport != null)
                    {
                        dataTransport.Endorsement = false;
                        dataTransport.EndorsementAmount = null;
                        dataTransport.EndorsementBeneficiaryRnc = null;
                        dataTransport.EndorsementBeneficiary = null;
                        dataTransport.UserId = ObjServices.UserID.GetValueOrDefault();

                        dataTransport.EndorsementContactName = null;
                        dataTransport.EndorsementContactPhone = null;
                        dataTransport.EndorsementContactEmail = null;

                        txtContactName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtEmailAddress.Text = "";

                        ObjServices.oTransportManager.SetTransportInsured(dataTransport);
                    }
                    break;
                #endregion
            }

            Initialize();

            BindGrid();

            lnkAnularEndoso.Visible =
            lnkDescargarHojaEndoso.Visible = false;
        }

        protected void lnkAnularEndoso_Click(object sender, EventArgs e)
        {
            AnularEndoso();
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