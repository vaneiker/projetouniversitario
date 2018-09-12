using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration
{
    public partial class UCPopupChangeStatusSaveNotes : UC, IUC
    {
        public delegate void DChangeStatusSaveNotes(Utility.IllustrationStatus illustrationStatus,
                                                    string note,
                                                    List<Policy.VehiclesCoverage> lst = null,
                                                    string Comment = null);

        public DChangeStatusSaveNotes ChangeStatusSaveNotes;

        public void ReadOnlyControls(bool isReadOnly) { }

        public void save() { }

        public void edit() { }

        private static string StatusChangedSuccessfully = string.Empty,
                              Success = string.Empty,
                              AnErrorOccuredChangingStatus = string.Empty;

        public string SelectedPolicy
        {
            get
            {
                var selectedPolicy = ViewState["SelectedPolicy"];
                return selectedPolicy == null ? null : selectedPolicy.ToString();
            }
            set
            {
                ViewState["SelectedPolicy"] = value;
            }
        }

        public List<Policy.VehicleInsured> ListVehicles
        {
            get
            {
                var k = ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ListVehiclesPoPuP;
                return k == null ? null : k;
            }
            set
            {
                ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ListVehiclesPoPuP = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);

            if (Session["MissingInspection"] == null)
                return;

            if (Session["MissingInspection"].ToString() == "true")
            {
                drpStatusQuotation.SelectedValue = "MissingInspection";
                Session["MissingInspection"] = "false";
            }
        }

        private List<Policy> getPolicies()
        {
            var result = new List<Policy>(0);

            //Actualizar el resumen   
            var oWUCIllustrationsList = Utility.GetAllChildren(this.Page).FirstOrDefault(uc => uc is WUCIllustrationsList);

            if (oWUCIllustrationsList != null)
            {
                var ogvIllustration = (oWUCIllustrationsList as WUCIllustrationsList).FindControl("gvIllustration");

                if (ogvIllustration != null)
                {
                    var gvIllustration = ogvIllustration as DevExpress.Web.ASPxGridView;

                    for (int i = gvIllustration.VisibleStartIndex; i < gvIllustration.VisibleRowCount; i++)
                    {
                        var chk = gvIllustration.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                        if (chk != null && chk.Checked)
                        {
                            var itemPol = new Utility.itemPolicy
                            {
                                CorpId = gvIllustration.GetKeyFromAspxGridView("CorpId", i).ToInt(),
                                RegionId = gvIllustration.GetKeyFromAspxGridView("RegionId", i).ToInt(),
                                CountryId = gvIllustration.GetKeyFromAspxGridView("CountryId", i).ToInt(),
                                DomesticregId = gvIllustration.GetKeyFromAspxGridView("DomesticregId", i).ToInt(),
                                StateProvId = gvIllustration.GetKeyFromAspxGridView("StateProvId", i).ToInt(),
                                CityId = gvIllustration.GetKeyFromAspxGridView("CityId", i).ToInt(),
                                OfficeId = gvIllustration.GetKeyFromAspxGridView("OfficeId", i).ToInt(),
                                CaseSeqNo = gvIllustration.GetKeyFromAspxGridView("CaseSeqNo", i).ToInt(),
                                HistSeqNo = gvIllustration.GetKeyFromAspxGridView("HistSeqNo", i).ToInt()
                            };

                            var dataPolicy = ObjServices.oPolicyManager.GetPolicy(itemPol.CorpId,
                                                                                  itemPol.RegionId,
                                                                                  itemPol.CountryId,
                                                                                  itemPol.DomesticregId,
                                                                                  itemPol.StateProvId,
                                                                                  itemPol.CityId,
                                                                                  itemPol.OfficeId,
                                                                                  itemPol.CaseSeqNo,
                                                                                  itemPol.HistSeqNo);

                            result.Add(dataPolicy);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Cambio de estatus para mas de una cotizacion a la vez
        /// </summary>
        private void ChangeStatus()
        {
            var SummaryErrors = new List<Tuple<string, string>>(0);

            var tab = getTab(ObjServices.hdnQuotationTabs != null ? ObjServices.hdnQuotationTabs : "");
            hdnIllustrationStatus.Value = drpStatusQuotation.SelectedValue;

            var illustrationStatus = Utility.IllustrationStatus.Submitted;
            var statusIsParse = Enum.TryParse<Utility.IllustrationStatus>(hdnIllustrationStatus.Value, true, out illustrationStatus);

            var dataPolicies = getPolicies();

            var hasValidation = tab != "QoutationsDeclinedBySubscription";

            if (hasValidation)
            {
                foreach (var item in dataPolicies)
                {
                    #region Validar Documentos
                    if (illustrationStatus == Utility.IllustrationStatus.Subscription && ObjServices.hdnQuotationTabs != "lnkMissingInspections")
                    {
                        //Validar los documentos requeridos para el agente antes de enviar a suscripcion
                        var dValdoc = ObjServices.ValidateDocRequiredListFromPolicy(item.PolicyNo, Utility.AgentRoleType.Agent.ToString());

                        if (dValdoc.Any())
                            SummaryErrors.AddRange(dValdoc);
                    }
                    #endregion

                    if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                    {
                        #region Validar el carfax
                        if (illustrationStatus == Utility.IllustrationStatus.MissingInspection)
                        {
                            var DataRequirement = ObjServices.GetDataDocument(item.CorpId, item.RegionId, item.CountryId, item.DomesticregId, item.StateProvId, item.CityId
                                                          , item.OfficeId, item.CaseSeqNo, item.HistSeqNo);

                            var carfaxRequirement = DataRequirement.FirstOrDefault(x => x.RequimentOnBaseNameKey == "SUS-Verificacion historial Vehiculo (Carfax,Autocheck,Salvagedb)");
                            if (carfaxRequirement.IsMandatory.GetValueOrDefault())
                            {
                                //Validar documento CarFax requerido antes de enviar a Inspeccion
                                var dValCarFax = ObjServices.ValidateCarFaxRequiredList(Utility.AgentRoleType.Subscritor.ToString());
                                if (!string.IsNullOrEmpty(dValCarFax))
                                    SummaryErrors.Add(new Tuple<string, string>(item.PolicyNo, dValCarFax));
                            }

                        }
                        #endregion

                        #region Verificar si fue colocada la direccion de inspeccion antes de enviarla a inspeccion
                        if ((ObjServices.IsSuscripcionQuotRole || ObjServices.isUserCot) &&
                            illustrationStatus == Utility.IllustrationStatus.MissingInspection ||
                            illustrationStatus == Utility.IllustrationStatus.Subscription
                            )
                        {
                            var UsedCar = ObjServices.oPolicyManager.GetVehicleInsured(new Policy.Parameter
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
                            }).Where(x => !x.New.GetValueOrDefault() &&
                                          (!x.ProductTypeDesc.Trim().RemoveCR().ToLower().Contains("ley") &&
                                           !x.ProductTypeDesc.Trim().RemoveCR().ToLower().Contains("ultra"))).ToList();

                            if (UsedCar.Count > 0)
                            {
                                var emptyaddress = UsedCar.Any(x => string.IsNullOrWhiteSpace(x.InspectionAddress));
                                if (emptyaddress)
                                {
                                    this.ExcecuteJScript("$('#divReason').hide();");
                                    this.MessageBox(Resources.YouMustIndicateInspectionAddress, Width: 500, Title: Resources.Warning);
                                    return;
                                }
                            }
                        }
                        #endregion
                    }


                    #region Verificar que la inspeccion este completa antes de enviarla a suscripcion
                    //if (ObjServices.ProductLine == Utility.ProductLine.Auto ||
                    //    ObjServices.AlliedLinesProductBehavior == Utility.AlliedLinesType.Vehicle ||
                    //    ObjServices.AlliedLinesProductBehavior == Utility.AlliedLinesType.Property)
                    //{
                    //    if (tab == "QoutationsMissingInspections")//&& (ObjServices.IsInspectorQuotRole || ObjServices.IsAngetInspectorQuotRole || ObjServices.isUserCot))
                    //    {
                    //        Utility.itemPolicy policy = new Utility.itemPolicy()
                    //        {
                    //            CorpId = item.CorpId,
                    //            RegionId = item.RegionId,
                    //            CountryId = item.CountryId,
                    //            DomesticregId = item.DomesticregId,
                    //            StateProvId = item.StateProvId,
                    //            CityId = item.CityId,
                    //            OfficeId = item.OfficeId,
                    //            CaseSeqNo = item.CaseSeqNo,
                    //            HistSeqNo = item.HistSeqNo
                    //        };

                    //        string result = ObjServices.InspectionCompleted(policy, ObjServices.ProductLine);
                    //        SummaryErrors.Add(new Tuple<string, string>(item.PolicyNo, result + "<br/>"));
                    //    }
                    //}

                    if (ObjServices.ProductLine == Utility.ProductLine.Auto ||
                        ObjServices.AlliedLinesProductBehavior == Utility.AlliedLinesType.Vehicle ||
                        ObjServices.AlliedLinesProductBehavior == Utility.AlliedLinesType.Property)
                    {
                        Utility.itemPolicy policy = new Utility.itemPolicy()
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

                        string result = ObjServices.InspectionCompleted(policy, ObjServices.ProductLine);
                        if (!string.IsNullOrWhiteSpace(result))
                            if (tab == "QoutationsMissingInspections")//&& (ObjServices.IsInspectorQuotRole || ObjServices.IsAngetInspectorQuotRole || ObjServices.isUserCot))
                            {
                                //this.ExcecuteJScript("$('#divReason').hide();");
                                //this.MessageBox(result, Width: 500, Title: Resources.Warning);
                                //return;

                                this.ExcecuteJScript("$('#divReason').hide();");
                                SummaryErrors.Add(new Tuple<string, string>(item.PolicyNo, result + "<br/>"));
                            }
                    }
                    #endregion

                    ppcChangeStatusIllustrations.ShowOnPageLoad = false;
                    hdnButtonSelected.Value = hdnIllustrationStatus.Value = "";
                }
            }

            if (SummaryErrors.Count > 0)
            {
                var policies = SummaryErrors.Select(x => x.Item1).Distinct();
                var ErrorListMessage = new StringBuilder();

                foreach (var it in policies)
                {
                    var dErrorsPol = SummaryErrors.Where(k => k.Item1 == it).Select(x => x.Item2).ToArray();
                    var msg = string.Join("<br/><br/>", dErrorsPol);
                    ErrorListMessage.AppendLine("Errores en Cotización:" + it + "<br/><br/>" + msg + "<br/><br/>");
                }

                this.MessageBox(ErrorListMessage.ToString().Replace("\r", "").Replace("\n", ""), Title: "Error", Width: 500, Height: 350);
                return;
            }

            var note = "";

            if (illustrationStatus == Utility.IllustrationStatus.PendingByClient)
                note = Resources.PendingByClientText + " " + txtReasonPending.Text;
            else if (illustrationStatus == Utility.IllustrationStatus.DeclinedByClient)
                note = Resources.DeclinedByClientText + " " + drpReasonDeclined.SelectedItem.Text + " - " + txtReasonPending.Text;
            else if (illustrationStatus == Utility.IllustrationStatus.DeclinedBySubscription)
                note = Resources.DeclinedBySubscriptionText + " " + drpReasonDeclined.SelectedItem.Text + " - " + txtReasonPending.Text;
            else if (illustrationStatus == Utility.IllustrationStatus.Subscription || illustrationStatus == Utility.IllustrationStatus.Submitted)
                note = Resources.SubscriptionText + " " + txtReasonPending.Text;
            else if (illustrationStatus == Utility.IllustrationStatus.MissingDocuments)
                note = Resources.MissingDocumentsText + " " + drpDocumentos.SelectedItem.Text + " - " + txtReasonPending.Text;
            else if (illustrationStatus == Utility.IllustrationStatus.MissingInspection)
                note = Resources.MissingInspectionText + " " + drpInspectors.SelectedItem.Text + " - " + txtReasonPending.Text;

            foreach (var i in dataPolicies)
            {
                #region Asignar la cotizacion al inspector seleccionado
                if (tab == "QoutationsSubscription" && illustrationStatus == Utility.IllustrationStatus.MissingInspection)
                {
                    ObjServices.oPolicyManager.SetAssingQuotation(new Policy.Parameter
                    {
                        CorpId = i.CorpId,
                        RegionId = i.RegionId,
                        CountryId = i.CountryId,
                        DomesticregId = i.DomesticregId,
                        StateProvId = i.StateProvId,
                        CityId = i.CityId,
                        OfficeId = i.OfficeId,
                        CaseSeqNo = i.CaseSeqNo,
                        HistSeqNo = i.HistSeqNo,
                        AgentId = drpInspectors.ToInt(),
                        UserId = ObjServices.UserID,
                    });
                }
                #endregion

                var isDeclinedByClientOrDeclinedBySubscription = (illustrationStatus == Utility.IllustrationStatus.DeclinedByClient || illustrationStatus == Utility.IllustrationStatus.DeclinedBySubscription);
                var isMissingDocument = illustrationStatus == Utility.IllustrationStatus.MissingDocuments;

                var Comment = string.Empty;

                try
                {
                    Comment = drpReasonDeclined.SelectedValue.Split('|')[1];
                }
                catch (Exception) { }

                string SetComment = null;

                if (isDeclinedByClientOrDeclinedBySubscription && !string.IsNullOrEmpty(Comment))
                    SetComment = Comment;
                else
                    if (isMissingDocument)
                    SetComment = "Contact Information";


                ChangeStatusSaveNotes(illustrationStatus, note, null, SetComment);

                //Llevar los archivos a onbase
                if (illustrationStatus == Utility.IllustrationStatus.DeclinedByClient ||
                    illustrationStatus == Utility.IllustrationStatus.DeclinedBySubscription)
                {
                    ObjServices.GenerateOnBaseFiles(
                                                    i.CorpId,
                                                    i.RegionId,
                                                    i.CountryId,
                                                    i.DomesticregId,
                                                    i.StateProvId,
                                                    i.CityId,
                                                    i.OfficeId,
                                                    i.CaseSeqNo,
                                                    i.HistSeqNo,
                                                    true,
                                                    Server.MapPath("~/NewBusiness/XML/")
                                                   );
                }
            }

            txtReasonPending.Text = "";
        }

        public void Translator(string Lang)
        {
            var reasonLabel = Resources.ReasonLabel.Capitalize();
            lblReason.Text = reasonLabel;
            txtReasonPending.Attributes.Add("label", Resources.Notes);
            drpReasonDeclined.Attributes.Add("label", reasonLabel);
            btnChangeStatus.Text = Resources.Accept;
            ppcChangeStatusIllustrations.HeaderText = Resources.ChangeStatus;
            lblNoteReason.Text =
            ppcNotes.HeaderText =
            lblNote.InnerText = Resources.Notes;
            lblInspector.Text = Resources.Inspector;
            btnSaveNotes.Text = Resources.Save;
            string lblstatus = Resources.SelStatus;
            lblStatus.Text = lblstatus;
            drpStatusQuotation.Attributes.Add("label", lblstatus);
            drpInspectors.Attributes.Add("label", lblInspector.Text);

            StatusChangedSuccessfully = Resources.StatusChangedSuccessfully;
            Success = Resources.Success;
            AnErrorOccuredChangingStatus = Resources.AErrorOccuredChangingStatus;

            if (!string.IsNullOrEmpty(hdnTab.Value))
                txtReasonPending.Attributes.Add("label", Resources.Notes);
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                var tab = getTab(ObjServices.hdnQuotationTabs != null ? ObjServices.hdnQuotationTabs : "");
                hdnIllustrationStatus.Value = drpStatusQuotation.SelectedValue;

                var illustrationStatus = Utility.IllustrationStatus.Submitted;
                var statusIsParse = Enum.TryParse<Utility.IllustrationStatus>(hdnIllustrationStatus.Value, true, out illustrationStatus);

                var CurrentPage = this.GetCurrentPageName();

                bool? IsDetail = null;

                if (CurrentPage == "Illustrations.aspx")
                    IsDetail = false;
                else
                    if (CurrentPage == "IllustrationsVehicle.aspx")
                    IsDetail = true;

                if (!IsDetail.GetValueOrDefault())
                {
                    ChangeStatus();
                    return;
                }

                var hasValidation = tab != "QoutationsDeclinedBySubscription";

                if (hasValidation)
                {
                    #region Validaciones

                    #region Validar los documentos requeridos
                    if (illustrationStatus == Utility.IllustrationStatus.Subscription && ObjServices.hdnQuotationTabs != "lnkMissingInspections")
                    {
                        if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                        {
                            //Validar los documentos requeridos para el agente antes de enviar a suscripcion
                            //ObjServices.ValidateDocRequired(ObjServices.Policy_Id, Utility.AgentRoleType.Agent.ToString());//Original
                            ObjServices.ValidateDocRequiredVehicles(ObjServices.Policy_Id, Utility.AgentRoleType.Agent.ToString());
                        }
                        else
                        {
                            if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                                ObjServices.ValidateDocRequiredByAlliedLines(ObjServices.Policy_Id, Utility.AgentRoleType.Agent.ToString());
                        }
                    }
                    #endregion

                    #region Validar documento CarFax
                    if (illustrationStatus == Utility.IllustrationStatus.MissingInspection)
                    {
                        var DataRequirement = ObjServices.GetDataDocument();

                        var carfaxRequirement = DataRequirement.FirstOrDefault(x => x.RequimentOnBaseNameKey == "SUS-Verificacion historial Vehiculo (Carfax,Autocheck,Salvagedb)");
                        if (carfaxRequirement.IsMandatory.GetValueOrDefault())
                            //Validar documento CarFax requerido antes de enviar a Inspeccion
                            ObjServices.ValidateCarFaxRequired(Utility.AgentRoleType.Subscritor.ToString());
                    }
                    #endregion

                    if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                    {
                        #region Verificar si fue colocada la direccion de inspeccion antes de enviarla a inspeccion
                        if ((ObjServices.IsSuscripcionQuotRole || ObjServices.isUserCot) &&
                            illustrationStatus == Utility.IllustrationStatus.MissingInspection ||
                            illustrationStatus == Utility.IllustrationStatus.Subscription
                            )
                        {
                            var UsedCar = ObjServices.oPolicyManager.GetVehicleInsured(new Policy.Parameter
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
                            }).Where(x => !x.New.GetValueOrDefault() &&
                                          (!x.ProductTypeDesc.Trim().RemoveCR().ToLower().Contains("ley") &&
                                           !x.ProductTypeDesc.Trim().RemoveCR().ToLower().Contains("ultra"))).ToList();

                            if (UsedCar.Count > 0)
                            {
                                var emptyaddress = UsedCar.Any(x => string.IsNullOrWhiteSpace(x.InspectionAddress));
                                if (emptyaddress)
                                {
                                    this.ExcecuteJScript("$('#divReason').hide();");
                                    this.MessageBox(Resources.YouMustIndicateInspectionAddress, Width: 500, Title: Resources.Warning);
                                    return;
                                }
                            }
                        }
                        #endregion
                    }

                    #region Verificar que la inspeccion este completa
                    if (drpStatusQuotation.SelectedValue != Utility.IllustrationStatus.DeclinedByClient.ToString() &&
                        drpStatusQuotation.SelectedValue != Utility.IllustrationStatus.DeclinedBySubscription.ToString())
                    {
                        if (ObjServices.ProductLine == Utility.ProductLine.Auto ||
                            ObjServices.AlliedLinesProductBehavior == Utility.AlliedLinesType.Property ||
                            ObjServices.AlliedLinesProductBehavior == Utility.AlliedLinesType.Vehicle
                        )
                        {
                            Utility.itemPolicy policy = new Utility.itemPolicy()
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

                            string result = ObjServices.InspectionCompleted(policy, ObjServices.ProductLine);
                            if (!string.IsNullOrWhiteSpace(result))
                                if (tab == "QoutationsMissingInspections")// && (ObjServices.IsInspectorQuotRole || ObjServices.IsAngetInspectorQuotRole || ObjServices.isUserCot) && illustrationStatus == Utility.IllustrationStatus.Subscription)
                                {
                                    this.ExcecuteJScript("$('#divReason').hide();");
                                    this.MessageBox(result, Width: 500, Title: Resources.Warning);
                                    return;
                                }
                        }
                    }
                    #endregion

                    #endregion
                }

                var note = "";

                if (illustrationStatus == Utility.IllustrationStatus.PendingByClient)
                    note = Resources.PendingByClientText + " " + txtReasonPending.Text;
                else if (illustrationStatus == Utility.IllustrationStatus.DeclinedByClient)
                    note = Resources.DeclinedByClientText + " " + drpReasonDeclined.SelectedItem.Text + " - " + txtReasonPending.Text;
                else if (illustrationStatus == Utility.IllustrationStatus.DeclinedBySubscription)
                    note = Resources.DeclinedBySubscriptionText + " " + drpReasonDeclined.SelectedItem.Text + " - " + txtReasonPending.Text;
                else if (illustrationStatus == Utility.IllustrationStatus.Subscription || illustrationStatus == Utility.IllustrationStatus.Submitted)
                    note = Resources.SubscriptionText + " " + txtReasonPending.Text;
                else if (illustrationStatus == Utility.IllustrationStatus.MissingDocuments)
                    note = Resources.MissingDocumentsText + " " + drpDocumentos.SelectedItem.Text + " - " + txtReasonPending.Text;
                else if (illustrationStatus == Utility.IllustrationStatus.MissingInspection)
                    note = Resources.MissingInspectionText + " " + drpInspectors.SelectedItem.Text + " - " + txtReasonPending.Text;


                if (!statusIsParse ||
                    ((illustrationStatus == Utility.IllustrationStatus.PendingByClient ||
                      illustrationStatus == Utility.IllustrationStatus.DeclinedByClient ||
                      illustrationStatus == Utility.IllustrationStatus.DeclinedBySubscription ||
                      illustrationStatus == Utility.IllustrationStatus.Subscription ||
                      illustrationStatus == Utility.IllustrationStatus.Submitted) &&
                      note.SIsNullOrEmpty()))
                {
                    this.MessageBox(AnErrorOccuredChangingStatus, Width: 500, Title: "Error");
                    return;
                }


                //
                #region Validando el chasis y placa antes de cambiar el status a Subscription
                string vEnabledChassisOrPlateValidationKey = System.Configuration.ConfigurationManager.AppSettings["EnabledChassisOrPlateValidation"];
                bool vEnabledChassisOrPlateValidation = false;
                bool.TryParse(vEnabledChassisOrPlateValidationKey, out vEnabledChassisOrPlateValidation);

                if (vEnabledChassisOrPlateValidation)
                {
                    if (illustrationStatus == Utility.IllustrationStatus.Subscription && ObjServices.hdnQuotationTabs == "lnkIllustrationsToWork")
                    {
                        //Data de los Vehiculos
                        var dataVehicle = ObjServices.oPolicyManager.GetVehicleInsured(new Policy.Parameter
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
                            UnderwriterId = ObjServices.Agent_LoginId,
                            LanguageId = ObjServices.Language.ToInt(),
                            UserId = ObjServices.UserID
                        });


                        var MessageError = string.Empty;
                        var ListError = new StringBuilder();


                        foreach (var itemVehicle in dataVehicle)
                        {
                            var JSONResult = ObjServices.oSFPolicyServiceClient.CheckChassisOrRegistry(new oSysFlexService.PolicyVehicleKey
                            {
                                Chassis = itemVehicle.Chassis,
                                Registry = itemVehicle.Registry
                            }).JSONResult;

                            if (JSONResult == null)
                                JSONResult = "[]";

                            var OldValue = "{}";
                            var resultString = JSONResult.Replace(OldValue, "0");

                            //Verificar si el o los vehiculos de esta poliza no esta ya registrado en sysflex
                            var dataResult = Utility.deserializeJSON<IEnumerable<Utility.VehicleIdentification>>(resultString);
                            bool entro = false;

                            if (dataResult.Any())
                            {
                                foreach (var item in dataResult)
                                {
                                    if (item.Policy.Trim() != ObjServices.PolicyNoMain.Trim())
                                    {
                                        MessageError = (item.Type == "Placa") ? string.Format(Resources.PlateValidation, item.Value.ToUpper(), item.Policy)
                                                                              : string.Format(Resources.ChassisValidation, item.Value.ToUpper(), item.Policy);

                                        ListError.Append(MessageError);
                                        entro = true;
                                    }
                                }

                                if (entro)
                                {
                                    ListError.Insert(0, Resources.ChassisOrPlateValidationMessage2);
                                }
                            }

                            MessageError = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(ListError.ToString()))
                        {
                            this.MessageBox(ListError.ToString().Replace('\'', '\"'), Width: 500, Title: "Error");
                            return;
                        }
                    }
                }
                #endregion



                ppcChangeStatusIllustrations.ShowOnPageLoad = false;
                hdnButtonSelected.Value = hdnIllustrationStatus.Value = "";

                if (tab == "QoutationsSubscription" && illustrationStatus == Utility.IllustrationStatus.MissingInspection)
                {
                    //Asignar la cotizacion al inspector seleccionado
                    /*ObjServices.oPolicyManager.SetAssingQuotation(new Policy.Parameter
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
                        AgentId = drpInspectors.ToInt(),
                        UserId = ObjServices.UserID,
                    });*/
                    ObjServices.AssignIllustrationToSubscriber(ObjServices.Corp_Id,
                        ObjServices.Region_Id,
                        ObjServices.Country_Id,
                        ObjServices.Domesticreg_Id,
                        ObjServices.State_Prov_Id,
                        ObjServices.City_Id,
                        ObjServices.Office_Id,
                        ObjServices.Case_Seq_No,
                        ObjServices.Hist_Seq_No,
                        drpInspectors.ToInt(),
                        "Inspector"
                        );

                }

                var isDeclinedByClientOrDeclinedBySubscription = (illustrationStatus == Utility.IllustrationStatus.DeclinedByClient || illustrationStatus == Utility.IllustrationStatus.DeclinedBySubscription);
                var isMissingDocument = illustrationStatus == Utility.IllustrationStatus.MissingDocuments;

                var Comment = string.Empty;

                try
                {
                    Comment = drpReasonDeclined.SelectedValue.Split('|')[1];
                }
                catch (Exception) { }

                string SetComment = null;

                if (isDeclinedByClientOrDeclinedBySubscription && !string.IsNullOrEmpty(Comment))
                    SetComment = Comment;
                else
                    if (isMissingDocument)
                    SetComment = "Contact Information";


                ChangeStatusSaveNotes(illustrationStatus, note, null, SetComment);

                //Llevar los archivos a onbase
                if (isDeclinedByClientOrDeclinedBySubscription)
                {
                    ObjServices.GenerateOnBaseFiles(
                            ObjServices.Corp_Id,
                            ObjServices.Region_Id,
                            ObjServices.Country_Id,
                            ObjServices.Domesticreg_Id,
                            ObjServices.State_Prov_Id,
                            ObjServices.City_Id,
                            ObjServices.Office_Id,
                            ObjServices.Case_Seq_No,
                            ObjServices.Hist_Seq_No,
                            true,
                            Server.MapPath("~/NewBusiness/XML/")
                           );
                }

                txtReasonPending.Text = "";

                if (Session["areInspected"] != null && Session["areInspected"].ToString().Trim().ToLower() == "true")
                {
                    string script = string.Format("BackToIllustrationList('{0}', '{1}');", StatusChangedSuccessfully, Success);
                    this.ExcecuteJScript(script);
                }
            }
            catch (Exception ex)
            {
                drpStatusQuotation.SelectedIndex = 0;
                var msg = ex.GetLastInnerException().Message;
                this.MessageBox(msg.RemoveInvalidCharacters().Replace('\'', '\"'), Title: "Error", Width: 800);
            }
        }

        private void BindGrid(List<Policy.VehicleInsured> lst)
        {
            rptVehicles.DataSource = lst.OrderBy(o => o.InsuredVehicleId).Select(o => new
            {
                o.VehicleUniqueId,
                Vehicle = o.MakeDesc + " " + o.ModelDesc + " " + o.Year,
                o.MakeDesc,
                o.ModelDesc,
                o.Year,
                Inspection = o.Inspection.GetValueOrDefault()
            });

            rptVehicles.DataBind();
        }

        public void FillData()
        {
            BindGrid(ListVehicles);
        }

        public void Initialize()
        {
            ClearData();

            this.ExcecuteJScript("ddlInspectors(false)");
            this.ExcecuteJScript("ddlDocumentos(false)");
            this.ExcecuteJScript("ddlReasonDeclined(false)");
            StatusQuotation(hdnTab.Value);
        }

        public void ClearData()
        {
            txtNotes.Clear();
            txtReasonPending.Clear();
        }

        protected void btnSaveNotes_Click(object sender, EventArgs e)
        {
            var policy = Utility.deserializeJSON<Policy.Parameter>(SelectedPolicy);

            ObjServices.SaveNotes(policy.CorpId,
                                  policy.RegionId,
                                  policy.CountryId,
                                  policy.DomesticregId,
                                  policy.StateProvId,
                                  policy.CityId,
                                  policy.OfficeId,
                                  policy.CaseSeqNo,
                                  policy.HistSeqNo,
                                  ObjServices.UserID.GetValueOrDefault(),
                                  txtNotes.Text);


            //Enviar correo de la nota generada
            ObjServices.SendMailFromStatusChangeOrNotes(string.Empty, true, txtNotes.Text);

            FillNotes(policy.CorpId,
                      policy.RegionId,
                      policy.CountryId,
                      policy.DomesticregId,
                      policy.StateProvId,
                      policy.CityId,
                      policy.OfficeId,
                      policy.CaseSeqNo,
                      policy.HistSeqNo);
        }

        public void FillNotes(int corpId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            txtNotes.Text = "";

            var policy = new Policy.Parameter();
            policy.CorpId = corpId;
            policy.RegionId = regionId;
            policy.CountryId = countryId;
            policy.DomesticregId = domesticRegId;
            policy.StateProvId = stateProvId;
            policy.CityId = cityId;
            policy.OfficeId = officeId;
            policy.CaseSeqNo = caseSeqNo;
            policy.HistSeqNo = histSeqNo;

            SelectedPolicy = Utility.serializeToJSON(policy);

            var lstNotes = ObjServices.oNote.GetAll(corpId,
                                                    regionId,
                                                    countryId,
                                                    domesticRegId,
                                                    stateProvId,
                                                    cityId,
                                                    officeId,
                                                    caseSeqNo,
                                                    histSeqNo).Where(o => o.ReferenceTypeId == Utility.PolicyNotesReferenceType.IllustrationNotes.ToInt()).OrderBy(o => o.DateAdded);

            rpNotes.DataSource = lstNotes.Select(o => new
            {
                Note = (o.DateAdded.ToString("MM/dd/yyyy hh:mm:ss tt") + " - Usuario: "
                                                                       + o.OriginatedByName
                                                                       + " - "
                                                                       + o.NoteBody.Replace("[Pending By Client]", "[{0}]".SFormat(Resources.PendingByClient))
                                                                                   .Replace("[Declined By Client]", "[{0}]".SFormat(Resources.DeclinedByClient)))
            }).ToList();

            rpNotes.DataBind();
        }

        public void FillReasonDenied(string familyProduct, Utility.ReasonPredefinieds reasonPredefinied)
        {
            ObjServices.FillReason(drpReasonDeclined, familyProduct, reasonPredefinied);
        }

        public void StatusQuotation(string tab = "")
        {
            try
            {
                if (string.IsNullOrEmpty(tab))
                    tab = getTab(!string.IsNullOrEmpty(ObjServices.hdnQuotationTabs) ? ObjServices.hdnQuotationTabs : "");

                drpStatusQuotation.ClearSelection();
                drpStatusQuotation.Items.Clear();
                drpStatusQuotation.Items.Add(new ListItem() { Text = "Seleccionar", Value = "-1" });

                //-----------------------
                #region Auto
                bool mostrarEnviarInspeccion = false;

                if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                {
                    int notInspected = ListVehicles.Count(v => v.InspectionRequired.GetValueOrDefault());

                    //Verificar si existe inspeccion previa
                    var vehiclesReview = ObjServices.oVehicleManager.GetVehicleReview(new Vehicle
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
                    }).Where(v => v.Inspection.GetValueOrDefault()).ToList();


                    if (ObjServices.IsInspectorQuotRole)
                    {
                        if (notInspected > 0)
                            mostrarEnviarInspeccion = true;
                        else
                        {
                            var inspeccionPrevia = vehiclesReview.Any(v => v.ReviewId > 0);
                            mostrarEnviarInspeccion = inspeccionPrevia;
                        }
                    }
                    else
                    {
                        if (vehiclesReview.Count > 0)
                            mostrarEnviarInspeccion = true;
                        else
                            mostrarEnviarInspeccion = (notInspected > 0);
                    }
                }
                #endregion

                #region Lineas Aliadas
                else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                {
                    var alliedLinesType = ObjServices.GettingDropData(Utility.DropDownType.AlliedLinesType);
                    if (alliedLinesType != null)
                    {
                        var alt = alliedLinesType.Select(r => r.Namekey);
                        mostrarEnviarInspeccion = alt.Contains(ObjServices.AlliedLinesProductBehavior.ToString());
                    }
                }
                #endregion
                //-----------------------

                #region (tab == "QoutationsToWork" || tab == "QoutationsCompleted")
                if (tab == "QoutationsToWork" || tab == "QoutationsCompleted")
                {
                    if (ObjServices.IsAgentQuotRole || ObjServices.isUserCot)
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });

                    drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                }
                #endregion

                #region (tab == "QoutationsConfirmationCall")
                else if (tab == "QoutationsConfirmationCall")
                    drpStatusQuotation.Items.Add(new ListItem() { Text = "Documentos Faltantes", Value = Utility.IllustrationStatus.MissingDocuments.ToString() });
                #endregion

                #region (tab == "QoutationsDeclinedBySubscription")
                else if (tab == "QoutationsDeclinedBySubscription")
                    drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });
                #endregion

                #region (tab == "QoutationsSubscription")
                else if (tab == "QoutationsSubscription")
                {
                    if (ObjServices.IsSuscripcionQuotRole || ObjServices.isUserCot)
                    {
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por Suscripción", Value = Utility.IllustrationStatus.DeclinedBySubscription.ToString() });

                        if (mostrarEnviarInspeccion)
                            drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Inspección", Value = Utility.IllustrationStatus.MissingInspection.ToString() });

                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Documentos Faltantes", Value = Utility.IllustrationStatus.MissingDocuments.ToString() });
                    }
                    //else if (ObjServices.IsAgentQuotRole || ObjServices.isUserCot)
                    //{
                    //    drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });

                    //    if (mostrarEnviarInspeccion)
                    //        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Inspección", Value = Utility.IllustrationStatus.MissingInspection.ToString() });
                    //}
                }
                #endregion

                #region (tab == "QoutationsMissingDocuments")
                else if (tab == "QoutationsMissingDocuments")
                {
                    if (ObjServices.IsAgentQuotRole || ObjServices.isUserCot)
                    {
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                    }
                    else
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                }
                #endregion

                #region (tab == "QoutationsMissingInspections")
                else if (tab == "QoutationsMissingInspections")
                {
                    if (ObjServices.IsAgentQuotRole && !ObjServices.IsInspectorQuotRole)
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });

                    else if (ObjServices.IsInspectorQuotRole && !ObjServices.IsAgentQuotRole)
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });

                    else if (ObjServices.IsInspectorQuotRole && ObjServices.IsAgentQuotRole)
                    {
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                    }
                    else if (ObjServices.isUserCot)
                    {
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                    }
                }
                #endregion

                #region (tab == "QoutationsExpiring")
                else if (tab == "QoutationsExpiring")
                {
                    if (ObjServices.IsAgentQuotRole || ObjServices.isUserCot)
                    {
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });
                    }
                }
                #endregion

                #region (tab == Utility.Tabs.lnkDeclinedByClient.ToString())
                else if (tab == Utility.Tabs.lnkDeclinedByClient.ToString())
                {
                    if (ObjServices.IsAgentQuotRole || ObjServices.isUserCot)
                    {
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Declinada por el Cliente", Value = Utility.IllustrationStatus.DeclinedByClient.ToString() });
                        drpStatusQuotation.Items.Add(new ListItem() { Text = "Enviar a Suscripción", Value = Utility.IllustrationStatus.Subscription.ToString() });
                    }
                }
                #endregion
            }
            catch (Exception)
            {
            }
        }

        public string getTab(string tab)
        {
            string tb = "";

            if (!string.IsNullOrEmpty(tab))
            {
                switch (tab)
                {
                    case "lnkIllustrationsToWork":
                        tb = Utility.tabsQoutationsPopUp.QoutationsToWork.ToString();
                        break;
                    case "lnkCompleteIllustrations":
                        tb = Utility.tabsQoutationsPopUp.QoutationsCompleted.ToString();
                        break;
                    case "lnkSubscriptions":
                        tb = Utility.tabsQoutationsPopUp.QoutationsSubscription.ToString();
                        break;
                    case "lnkMissingDocuments":
                        tb = Utility.tabsQoutationsPopUp.QoutationsMissingDocuments.ToString();
                        break;
                    case "lnkMissingInspections":
                        tb = Utility.tabsQoutationsPopUp.QoutationsMissingInspections.ToString();
                        break;
                    case "lnkExpiring":
                        tb = Utility.tabsQoutationsPopUp.QoutationsExpiring.ToString();
                        break;
                    case "lnkConfirmationCall":
                        tb = Utility.tabsQoutationsPopUp.QoutationsConfirmationCall.ToString();
                        break;
                    case "lnkDeclinedBySubscription":
                        tb = Utility.tabsQoutationsPopUp.QoutationsDeclinedBySubscription.ToString();
                        break;
                }
            }

            return tb;
        }

        protected void UpdatePanel_Unload(object sender, EventArgs e)
        {
            MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                             .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();

            methodInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { sender as UpdatePanel });
        }

        protected void drpStatusQuotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            divReason.Attributes.Remove("Style");
            divReason.Attributes.Add("Style=", "margin-left: -5px; width: 600px; display: none");

            if (drpStatusQuotation.SelectedItem.Value.Equals(Utility.IllustrationStatus.MissingInspection.ToString()))
            {
                var dataAgent = ObjServices.GettingDropData(Utility.DropDownType.InspectorCot,
                                                            corpId: ObjServices.Corp_Id,
                                                            regionId: ObjServices.Region_Id,
                                                            countryId: ObjServices.Country_Id,
                                                            domesticregId: ObjServices.Domesticreg_Id,
                                                            stateProvId: ObjServices.State_Prov_Id,
                                                            cityId: ObjServices.City_Id,
                                                            officeId: ObjServices.Office_Id,
                                                            caseSeqNo: ObjServices.Case_Seq_No,
                                                            histSeqNo: ObjServices.Hist_Seq_No
                                                            );

                drpInspectors.DataSource = dataAgent;
                drpInspectors.DataTextField = "AgentName";
                drpInspectors.DataValueField = "AgentId";
                drpInspectors.DataBind();
                drpInspectors.Items.Insert(0, new ListItem { Text = Resources.Select, Value = "-1" });
                drpInspectors.SelectedIndex = -1;
                Session["MissingInspection"] = "true";
                this.ExcecuteJScript("ddlInspectors(true)");
            }
            else if (drpStatusQuotation.SelectedItem.Value.Equals(Utility.IllustrationStatus.MissingDocuments.ToString()))
            {
                dynamic dataResult = null;

                if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                {
                    //dataResult = ObjServices.GetDataDocument();
                    dataResult = ObjServices.GetDataDocumentVehicle();
                }
                else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                {
                    dataResult = ObjServices.GetDataDocumentAlliedLines();
                }

                drpDocumentos.DataSource = dataResult;
                drpDocumentos.DataTextField = "RequirementTypeDesc";
                drpDocumentos.DataValueField = "RequirementTypeDesc";
                drpDocumentos.DataBind();
                drpDocumentos.Items.Insert(0, new ListItem { Text = Resources.Select, Value = "-1" });
                drpDocumentos.SelectedIndex = -1;

                this.ExcecuteJScript("ddlDocumentos(true)");
            }
            else if (drpStatusQuotation.SelectedItem.Value.Equals(Utility.IllustrationStatus.DeclinedByClient.ToString()))
            {
                drpReasonDeclined.SelectedIndex = -1;
                this.ExcecuteJScript("ddlReasonDeclined(true)");
            }
            else if (drpStatusQuotation.SelectedItem.Value.Equals(Utility.IllustrationStatus.DeclinedBySubscription.ToString()))
            {
                divReason.Attributes.Remove("Style");
                divReason.Attributes.Add("Style=", "margin-left: -5px; width: 600px; display: block");
            }

            this.ExcecuteJScript("ddlOtherStatus()");
            hdnIllustrationStatus.Value = drpStatusQuotation.SelectedItem.Value;
        }
    }
}