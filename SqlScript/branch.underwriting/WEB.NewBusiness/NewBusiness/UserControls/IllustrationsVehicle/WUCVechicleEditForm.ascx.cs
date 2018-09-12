using Entity.UnderWriting.Entities;
using Statetrust.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class WUCVechicleEditForm : UC, IUC
    {
        public delegate void BindingGridEventHandler();

        public event BindingGridEventHandler BindGrid;

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

        protected void Page_Load(object sender, EventArgs e)
        {

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

        public void FillDrop()
        {


            ObjServices.GettingAllDrops(ref ddlColor,
                                      Utility.DropDownType.VehicleColor,
                                      "OfficeDesc",
                                      "OfficeId",
                                      GenerateItemSelect: true,
                                      corpId: ObjServices.Corp_Id
                                      );

            ObjServices.GettingAllDrops(ref ddlColorNew,
                          Utility.DropDownType.VehicleColor,
                          "OfficeDesc",
                          "OfficeId",
                          GenerateItemSelect: true,
                          corpId: ObjServices.Corp_Id
                          );
        }

        public void FillData()
        {

        }

        public void FillText(string Plate, string Chassis, int ColorId, bool IsNew)
        {
            ddlColor.SelectedValue = ColorId.ToString();
            ddlCondition.SelectedValue = IsNew.ToString().ToLower();
            txtChassis.Text = Chassis;
            txtPlate.Text = Plate;
            ValidateRequestChange();
        }

        public void Initialize()
        {
            FillDrop();
            udpVehicleEditForm.Update();
        }

        private Entity.UnderWriting.Entities.Policy.VehicleInsured getDataVehicle(long? InsuredVehicleId)
        {
            var result = ObjServices.oPolicyManager.GetVehicleInsured(new Entity.UnderWriting.Entities.Policy.Parameter
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
            }).FirstOrDefault(k => k.InsuredVehicleId == InsuredVehicleId);

            return result;
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChassis.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.VehicleChasis));
                return;
            }

            if (string.IsNullOrEmpty(txtPlate.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Registry));
                return;
            }

            if (ddlColor.SelectedValue == "-1")
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.VehicleColor));
                return;
            }

            if (ObjServices.isVehicleChange)
            {
                if (string.IsNullOrEmpty(txtChassisNew.Text))
                {
                    this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.VehicleChasisNew));
                    return;
                }

                if (string.IsNullOrEmpty(txtPlateNew.Text))
                {
                    this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.RegistryNew));
                    return;
                }

                if (ddlColorNew.SelectedValue == "-1")
                {
                    this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.VehicleColorNew));
                    return;
                }

                //validando que el chasis no exista
                var JSONResult = ObjServices.oSFPolicyServiceClient.CheckChassisOrRegistry(new oSysFlexService.PolicyVehicleKey
                {
                    Chassis = txtChassisNew.Text,
                    Registry = txtPlateNew.Text
                }).JSONResult;


                if (JSONResult != null)
                {

                    var OldValue = "{}";
                    var resultString = JSONResult.Replace(OldValue, "0");

                    //Verificar si el o los vehiculos de esta poliza no esta ya registrado en sysflex
                    var dataResult = Utility.deserializeJSON<IEnumerable<Utility.VehicleIdentification>>(resultString);

                    if (dataResult.Any())
                    {
                        foreach (var item in dataResult)
                        {
                            if (item.Policy != ObjServices.PolicyNoMain)
                            {
                                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.RequestChangePlateChassisValidation, txtChassisNew.Text, txtPlateNew.Text.ToUpper(), item.Policy));
                                return;
                            }
                        }
                    }

                    //if (JSONResult != null)
                    //{
                    //    this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.RequestChangePlateChassisValidation, txtChassisNew.Text, txtPlateNew.Text.ToUpper()));
                    //    return;
                    //}
                }
            }


            var dataVehicle = getDataVehicle(this.InsuredVehicleId);

            if (dataVehicle != null)
            {
                dataVehicle.Registry = !ObjServices.isVehicleChange ? txtPlate.Text : txtPlateNew.Text;
                dataVehicle.Chassis = !ObjServices.isVehicleChange ? txtChassis.Text : txtChassisNew.Text;
                dataVehicle.ColorId = !ObjServices.isVehicleChange ? ddlColor.SelectedValue.ToInt() : ddlColorNew.SelectedValue.ToInt();
                dataVehicle.New = ddlCondition.SelectedValue != "-1" ? ddlCondition.SelectedValue.ToBoolean() : (bool?)null;
                dataVehicle.UserId = ObjServices.UserID.GetValueOrDefault();
                ObjServices.oPolicyManager.SetVehicleInsured(dataVehicle);
                BindGrid();

                #region Si existe inspeccion, cambiar valores
                var vehicleReview = ObjServices.oVehicleManager.GetVehicleReview(new Vehicle
                {
                    CorpId = dataVehicle.CorpId,
                    RegionId = dataVehicle.RegionId,
                    CountryId = dataVehicle.CountryId,
                    DomesticRegId = dataVehicle.DomesticregId,
                    StateProvId = dataVehicle.StateProvId,
                    CityId = dataVehicle.CityId,
                    OfficeId = dataVehicle.OfficeId,
                    CaseSeqNo = dataVehicle.CaseSeqNo,
                    HistSeqNo = dataVehicle.HistSeqNo,
                    InsuredVehicleId = dataVehicle.InsuredVehicleId
                }).FirstOrDefault();

                if (vehicleReview != null)
                {
                    ObjServices.oVehicleManager.SetVehicleReview(new Vehicle.Review
                    {
                        CorpId = dataVehicle.CorpId,
                        RegionId = dataVehicle.RegionId,
                        CountryId = dataVehicle.CountryId,
                        DomesticRegId = dataVehicle.DomesticregId,
                        StateProvId = dataVehicle.StateProvId,
                        CityId = dataVehicle.CityId,
                        OfficeId = dataVehicle.OfficeId,
                        CaseSeqNo = dataVehicle.CaseSeqNo,
                        HistSeqNo = dataVehicle.HistSeqNo,
                        InsuredVehicleId = dataVehicle.InsuredVehicleId,
                        ReviewId = vehicleReview.ReviewId,
                        MakeId = vehicleReview.MakeId,
                        ModelId = vehicleReview.ModelId,
                        VersionId = vehicleReview.VersionId,
                        TransmissionTypeId = vehicleReview.TransmissionTypeId,
                        WheelDriveTypeId = vehicleReview.WheelDriveTypeId,
                        VehicleClassId = vehicleReview.VehicleClassId,
                        ModelYear = vehicleReview.ModelYear,
                        Seats = vehicleReview.Seats,
                        Cylinder = vehicleReview.Cylinder,
                        RegistryPlate = txtPlate.Text,
                        ColorId = ddlColor.SelectedValue.ToInt(),
                        VehicleTypeId = vehicleReview.VehicleTypeId,
                        UsageId = vehicleReview.UsageId,
                        MileageKilometer = vehicleReview.MileageKilometer,
                        Odometer = vehicleReview.Odometer,
                        Hubodometer = vehicleReview.Hubodometer,
                        RegistrationDocument = vehicleReview.RegistrationDocument,
                        FuelInt = vehicleReview.FuelInt,
                        InspectedBy = vehicleReview.InspectedBy,
                        Capacity = vehicleReview.Capacity,
                        ReviewDate = vehicleReview.ReviewDate,
                        ReviewNotes = vehicleReview.ReviewNotes,
                        ReviewAmount = vehicleReview.ReviewAmount,
                        Mark = txtChassis.Text,
                        ReviewFinishDate = vehicleReview.ReviewFinishDate,
                        DocTypeId = vehicleReview.DocTypeId,
                        DocCategoryId = vehicleReview.DocCategoryId,
                        DocumentId = vehicleReview.DocumentId,
                        ReviewStatusId = vehicleReview.ReviewStatusId,
                        ReviewStatus = vehicleReview.ReviewStatus,
                        InspectionNumber = vehicleReview.InspectionNumber,
                        ApplicantInspection = vehicleReview.ApplicantInspection,
                        IdentificationDocument = vehicleReview.IdentificationDocument,
                        InspectorSuggestsAcceptRisk = vehicleReview.InspectorSuggestsAcceptRisk,
                        Email = vehicleReview.Email,
                        Phone = vehicleReview.Phone,
                        CreateDate = vehicleReview.CreateDate,
                        CreateUserId = vehicleReview.CreateUserId ?? ObjServices.UserID.GetValueOrDefault()
                    });
                }
                #endregion

                var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;
                if (IllustrationsVehiclePage != null)
                {
                    var VehiclesInformationUC = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCVehiclesInformation);
                    if (VehiclesInformationUC != null)
                        (VehiclesInformationUC as UCVehiclesInformation).FillData();
                }

                //Update requestChange Table
                if (ObjServices.isVehicleChange)
                {
                    var DataChange = ObjServices.oVehicleManager.GetVehicleRequestChange(ObjServices.PolicyNoMain, null).ToList();
                    int i = 0;
                    bool algoCambio = false;
                    int ChangeId = 0;
                    int vehicleSecuence = 0;
                    if (DataChange.Count() > 0)
                    {
                        for (i = 0; i <= DataChange.Count() - 1; i++)
                        {
                            int condition = DataChange[i].Condition_Id.ToInt();
                            ChangeId = DataChange[i].Change_Id;
                            vehicleSecuence = DataChange[i].Vehicle_Secuence;

                            if (condition == Utility.ChangeConditionCatalog.NoRegistro.ToInt())
                            {
                                if (txtPlateNew.Text != DataChange[i].New_Value)
                                {
                                    algoCambio = true;
                                }
                            }
                            else if (condition == Utility.ChangeConditionCatalog.Chasis.ToInt())
                            {
                                if (txtChassisNew.Text != DataChange[i].New_Value)
                                {
                                    algoCambio = true;
                                }
                            }
                            else if (condition == Utility.ChangeConditionCatalog.Color.ToInt())
                            {
                                if (ddlColorNew.SelectedItem.Text != DataChange[i].New_Value.NTrim())
                                {
                                    algoCambio = true;
                                }

                                /*var listItem = ddlColorNew.Items.FindByText(DataChange[i].New_Value.NTrim());
                                if (listItem != null)
                                {
                                    var indexNew = ddlColorNew.Items.IndexOf(listItem);

                                    if (ddlColorNew.SelectedValue.ToInt() != indexNew)
                                    {
                                        algoCambio = true;
                                    }
                                }*/
                            }
                        }

                        if (ChangeId > 0 && algoCambio)
                        {
                            var actualChangeID = ObjServices.oVehicleManager.SetVehicleRequestChange(new RequestChanges.Parameter()
                            {
                                change_Id = null,
                                condition_Id = Utility.ChangeConditionCatalog.Chasis.ToInt(),
                                vehicle_Secuence = vehicleSecuence,
                                new_Value = txtChassisNew.Text.NTrim(),
                                old_Value = txtChassis.Text.NTrim(),
                                policy_Number = ObjServices.PolicyNoMain,
                                source = "Bandeja Auto",
                                create_User = ObjServices.UserID.GetValueOrDefault()
                            });

                            ObjServices.oVehicleManager.SetVehicleRequestChange(new RequestChanges.Parameter()
                            {
                                change_Id = actualChangeID.Change_Id,
                                condition_Id = Utility.ChangeConditionCatalog.NoRegistro.ToInt(),
                                vehicle_Secuence = vehicleSecuence,
                                new_Value = txtPlateNew.Text.NTrim(),
                                old_Value = txtPlate.Text.NTrim(),
                                policy_Number = ObjServices.PolicyNoMain,
                                source = "Bandeja Auto",
                                create_User = ObjServices.UserID.GetValueOrDefault()
                            });

                            ObjServices.oVehicleManager.SetVehicleRequestChange(new RequestChanges.Parameter()
                            {
                                change_Id = actualChangeID.Change_Id,
                                condition_Id = Utility.ChangeConditionCatalog.Color.ToInt(),
                                vehicle_Secuence = vehicleSecuence,
                                new_Value = ddlColorNew.SelectedItem.Text.NTrim(),
                                old_Value = ddlColor.SelectedItem.Text.NTrim(),
                                policy_Number = ObjServices.PolicyNoMain,
                                source = "Bandeja Auto",
                                create_User = ObjServices.UserID.GetValueOrDefault()
                            });
                        }
                    }
                }
            }
        }

        protected void ddlCondition_PreRender(object sender, EventArgs e)
        {
            pnCondition.Visible = ObjServices.isUserCot;

        }

        public void ValidateRequestChange()
        {
            //var illustration = ObjServices.getillustrationData();
            //var RequestType = (Utility.RequestType)Enum.Parse(typeof(Utility.RequestType), illustration.RequestTypeDesc.MyRemoveInvalidCharactersFilName());
            int i = 0;
            //if (RequestType == Utility.RequestType.Cambios)
            if (ObjServices.isVehicleChange)
            {
                pnPlateNew.Visible = true;
                txtPlateNew.Attributes.Add("validation", "Required");
                txtPlate.Attributes.Remove("validation");

                pnChassisNew.Visible = true;
                txtChassisNew.Attributes.Add("validation", "Required");
                txtChassis.Attributes.Remove("validation");

                pnColorNew.Visible = true;
                ddlColorNew.Attributes.Add("validation", "Required");
                ddlColor.Attributes.Remove("validation");

                var DataChange = ObjServices.oVehicleManager.GetVehicleRequestChange(ObjServices.PolicyNoMain, null).ToList();
                if (DataChange.Count() > 0)
                {
                    for (i = 0; i <= DataChange.Count() - 1; i++)
                    {
                        int condition = DataChange[i].Condition_Id.ToInt();

                        if (condition == Utility.ChangeConditionCatalog.NoRegistro.ToInt())
                        {
                            txtPlate.Text = DataChange[i].Old_Value;
                            txtPlateNew.Text = DataChange[i].New_Value;
                        }
                        else if (condition == Utility.ChangeConditionCatalog.Chasis.ToInt())
                        {
                            txtChassis.Text = DataChange[i].Old_Value;
                            txtChassisNew.Text = DataChange[i].New_Value;
                        }
                        else if (condition == Utility.ChangeConditionCatalog.Color.ToInt())
                        {
                            Utility.SelectIndexByText(ref ddlColor, DataChange[i].Old_Value);
                            Utility.SelectIndexByText(ref ddlColorNew, DataChange[i].New_Value);
                        }

                    }
                }
            }
            else
            {
                pnPlateNew.Visible = false;
                txtPlate.Attributes.Add("validation", "Required");
                txtPlateNew.Attributes.Remove("validation");
                txtPlateNew.Text = string.Empty;

                pnChassisNew.Visible = false;
                txtChassis.Attributes.Add("validation", "Required");
                txtChassisNew.Attributes.Remove("validation");
                txtChassisNew.Text = string.Empty;

                pnColorNew.Visible = false;
                ddlColor.Attributes.Add("validation", "Required");
                ddlColorNew.Attributes.Remove("validation");
                ddlColorNew.SelectedIndex = 0;

                txtChassis.Enabled = true;
                txtPlate.Enabled = true;
                ddlColor.Enabled = true;

            }
        }

    }
}