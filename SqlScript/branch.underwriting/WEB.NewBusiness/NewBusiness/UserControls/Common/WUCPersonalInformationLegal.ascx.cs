using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using System.Globalization;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCPersonalInformationLegal : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool validateData()
        {
            bool isValid = true;
            String message = "";

            if (String.IsNullOrWhiteSpace(tb_WUC_PI_FirstName_Legal.Text))
            {
                isValid = false;
                message = RESOURCE.UnderWriting.NewBussiness.Resources.FirstNameRequired + "\n";
            }

            if (String.IsNullOrWhiteSpace(tb_WUC_PI_FirstLastName_Legal.Text))
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.LastNameRequired + "\n";
            }

            if (ddl_WUC_PI_Gender_Legal.SelectedValue == "-1")
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.GenderRequired + "\n";
            }

            if (ddl_WUC_PI_Smoker_Legal.SelectedValue == "-1")
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.SmokerRequired + "\n";
            }

            if (ddl_WUC_PI_CountryBirth_Legal.SelectedValue == "-1")
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.CountryOfBirthRequired + "\n";
            }

            if (ddl_WUC_PI_CountryCitizenship_Legal.SelectedValue == "-1")
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.CountryOfCitizenshipRequired + "\n";
            }

            if (String.IsNullOrWhiteSpace(tb_WUC_PI_DateBirth_Legal.Text))
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.DateOfBirthRequired + "\n";
            }

            if (String.IsNullOrWhiteSpace(tb_WUC_PI_YearLyFamilyIncome_Legal.Text))
            {
                isValid = false;
                message += RESOURCE.UnderWriting.NewBussiness.Resources.YearlyFamilyIncomeRequired + "\n";
            }

            if (!isValid)
                this.MessageBox(message, null, null, true, "Warning");

            return isValid;
        }

        /// <summary>
        ///   DataBinding de los DropDownList
        /// </summary>
        public void FillDrops()
        {
            //Llenar el dropDpown de Generos
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_Gender_Legal,
                                    Utility.DropDownType.Gender,
                                    "GenderDesc",
                                    "GenderId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Smoker
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_Smoker_Legal,
                                    Utility.DropDownType.Smoker,
                                    "SmokerDesc",
                                    "SmokerId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Country Birth
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_CountryBirth_Legal,
                                    Utility.DropDownType.Country,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Country Citizenship
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_CountryCitizenship_Legal,
                                    Utility.DropDownType.Country,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de  Marital status
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_MaritalStatus_Legal,
                                    Utility.DropDownType.MaritalStatus,
                                    "MaritalStatusDesc", "MaritalStatId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de LengOfWork
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_LengthWorkFrom_Legal,
                                    Utility.DropDownType.LengthatWork,
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Months 
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_LengthWorkTo_Legal,
                                    Utility.DropDownType.Months,
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Country Of Residence
            ObjServices.GettingAllDrops(ref ddlCountryOfResidence_Legal,
                                    Utility.DropDownType.CountryOfResidence,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                   );

            //Llenar dropDown Customer BL 1
            ObjServices.GettingAllDrops(ref ddl_BusinessLine2_Legal,
                                      Utility.DropDownType.CustomerBusinessLine2,
                                      "GlobalCountryDesc",
                                      "CountryId",
                                    GenerateItemSelect: true
                                   );

            /*if (ddl_BusinessLine1.SelectedIndex == 0)
                ddl_BusinessLine2.Items.Clear();*/
            //Llenar dropDown Customer BL 2
            /*
            ObjServices.GettingAllDrops(ref ddl_BusinessLine2,
                                      Utility.DropDownType.CustomerBusinessLine,
                                      "GlobalCountryDesc",
                                      "CountryId",
                                    GenerateItemSelect: true
                                   );
            */
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            FirstName.InnerHtml = Resources.FirstNameLabel;
            MiddleName.InnerHtml = Resources.MiddleNameLabel;
            LastName.InnerHtml = Resources.LastNameLabel;
            SecondLastName.InnerHtml = Resources.SecondLastNameLabel;
            Gender.InnerHtml = Resources.GenderLabel;
            Smoker.InnerHtml = Resources.SmokerLabel;
            CountryOfBirth.InnerHtml = Resources.CountryofBirthLabel;
            CountryOfCitizenship.InnerHtml = Resources.CountryofCitizenshipLabel;
            CountryofResidence.InnerHtml = Resources.CountryOfResidenceLabel;
            DateOfBirth.InnerHtml = Resources.DateofBirthLabel;
            Age.InnerHtml = Resources.AgeLabel;
            MaritalStatus.InnerHtml = Resources.MaritalStatusLabel;
            YearlyFamilyIncome.InnerHtml = Resources.YearlyFamilyIncomeLabel;
            YearlyPersonalIncome.InnerHtml = Resources.YearlyPersonalIncomeLabel;
            OccupationType.InnerHtml = Resources.OccupationTypeLabel;
            Occupation.InnerHtml = Resources.OccupationLabel;
            CompanyName.InnerHtml = Resources.CompanyNameLabel;
            LineOfBusiness1.InnerHtml = Resources.LineofBusinessLabel + " 1";
            LineOfBusiness2.InnerHtml = Resources.LineofBusinessLabel + " 2";
            TaskPerformed.InnerHtml = Resources.TasksPerformedLabel;
            YearsatWork.InnerHtml = Resources.YearsatWorkLabel;
            Months.InnerHtml = Resources.MonthsLabel;
            ltPersonalInformation.Text = Resources.PersonalInformationLabel;

            //if (isChangingLang)
            //    FillDrops();

            //if (!hdnOccupationGroupId_Legal.Value.SIsNullOrEmpty() && !hdnOccupationId_Legal.Value.SIsNullOrEmpty())
            //{
            //    var data = ObjServices.GettingDropData(Utility.DropDownType.Occupation);

            //    if (data != null)
            //    {
            //        var dataOccup = data.FirstOrDefault(y => y.OccupGroupTypeId == hdnOccupationGroupId_Legal.ToInt() && y.OccupationId == hdnOccupationId_Legal.ToInt());

            //        if (dataOccup != null)
            //        {
            //            txtOccupation_Legal.Text = dataOccup.OccupationDesc;
            //            txtProfession_Legal.Text = dataOccup.OccupationGroupDesc;
            //        }
            //    }
            //}
            if (isChangingLang)
                FillDrops();

            if (!hdnOccupationGroupId_Legal.Value.SIsNullOrEmpty() && !hdnOccupationId_Legal.Value.SIsNullOrEmpty())
            {
                var data = ObjServices.GettingDropData(Utility.DropDownType.Occupation);

                if (data != null)
                {
                    var dataOccup = data.FirstOrDefault(y => y.OccupGroupTypeId == hdnOccupationGroupId_Legal.ToInt() && y.OccupationId == hdnOccupationId_Legal.ToInt());

                    if (dataOccup != null)
                    {
                        txtOccupation_Legal.Text = dataOccup.OccupationDesc;
                        txtProfession_Legal.Text = dataOccup.OccupationGroupDesc;
                    }
                }
            }
        }

        public void save()
        {
           // throw new NotImplementedException();
        }

        public void edit()
        {
        }

        public void FillData()
        {
            var nContact = ObjServices.GetContact(ObjServices.Agent_Legal.Value);

            if (nContact != null)
            {
                tb_WUC_PI_FirstName_Legal.Text = nContact.FirstName;
                tb_WUC_PI_MiddleName_Legal.Text = nContact.MiddleName;
                tb_WUC_PI_FirstLastName_Legal.Text = nContact.FirstLastName;
                tb_WUC_PI_SecondLastName_Legal.Text = nContact.SecondLastName;
                ddl_WUC_PI_Gender_Legal.SelectIndexByValue((string.IsNullOrEmpty(nContact.Gender)) ? "-1" : nContact.Gender);
                ddl_WUC_PI_Smoker_Legal.SelectIndexByValue(!nContact.Smoker.HasValue ? "-1" : (nContact.Smoker.Value ? "1" : "0"));
                tb_WUC_PI_Age_Legal.Text = nContact.Age.ToString();

                ddl_WUC_PI_CountryBirth_Legal.SelectIndexByValue(nContact.CountryOfBirthId.ToString(), true);
                ddlCountryOfResidence_Legal.SelectIndexByValue(nContact.CountryOfResidenceId.ToString(), true);

                tb_WUC_PI_DateBirth_Legal.Text = !nContact.Dob.HasValue ? "" :
                                           nContact.Dob.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                hdnAge_Legal.Value = !nContact.Age.HasValue ? "" : nContact.Age.Value.ToString();

                if (nContact.MaritalStatId.HasValue)
                    ddl_WUC_PI_MaritalStatus_Legal.SelectIndexByValue(nContact.MaritalStatId.ToString(), true);

                tb_WUC_PI_PersonalIncome_Legal.Text = !nContact.AnnualPersonalIncome.HasValue ? ""
                                                                                        : nContact.AnnualPersonalIncome.Value.ToString(NumberFormatInfo.InvariantInfo);

                tb_WUC_PI_YearLyFamilyIncome_Legal.Text = !nContact.AnnualFamilyIncome.HasValue ? ""
                                                                                          : nContact.AnnualFamilyIncome.Value.ToString(NumberFormatInfo.InvariantInfo);

                if (nContact.OccupGroupTypeId.HasValue)
                {
                    txtOccupation_Legal.Text = nContact.Occupation_Desc;
                    hdnOccupationGroupId_Legal.Value = nContact.OccupGroupTypeId.Value.ToString();
                }

                if (nContact.OccupationId.HasValue)
                {
                    txtProfession_Legal.Text = nContact.Occupation_Group_Desc;
                    hdnOccupationId_Legal.Value = nContact.OccupationId.Value.ToString();
                }

                tb_WUC_PI_CompanyName_Legal.Text = nContact.CompanyName;

                if (nContact.LineOfBusiness2 != null)
                {

                    if (nContact.LineOfBusiness2.Length > 0)
                    {
                        Utility.SelectIndexByText(ref ddl_BusinessLine2_Legal, nContact.LineOfBusiness2);
                    }
                    if (ddl_BusinessLine1_Legal.Items.Count > 0)
                        ddl_BusinessLine1_Legal.Items.Clear();
                    ListItem lstBL1 = new ListItem(nContact.LineOfBusiness, "-1");
                    ddl_BusinessLine1_Legal.Items.Add(lstBL1);

                }
                if (nContact.LineOfBusiness != null && ddl_BusinessLine2_Legal != null && ddl_BusinessLine2_Legal.SelectedIndex > 0)
                {
                    var countryId = ddl_BusinessLine2_Legal != null && ddl_BusinessLine2_Legal.Items != null && ddl_BusinessLine2_Legal.Items.Count > 0 ? ddl_BusinessLine2_Legal.SelectedValue.ToInt() : 0;
                    if (countryId > 0)
                    {
                        ObjServices.GettingAllDrops(ref ddl_BusinessLine1_Legal,
                                  Utility.DropDownType.CustomerBusinessLine,
                                  "GlobalCountryDesc",
                                  "CountryId",
                                  countryId: countryId,
                                GenerateItemSelect: true
                               );
                        if (nContact.LineOfBusiness.Length > 0)
                        {
                            Utility.SelectIndexByText(ref ddl_BusinessLine1_Legal, nContact.LineOfBusiness);
                        }
                    }
                }

                tb_WUC_PI_TaskPerformed_Legal.Text = nContact.LaborTasks;

                if (nContact.LengthWorkYear.HasValue)
                    ddl_WUC_PI_LengthWorkFrom_Legal.SelectIndexByValue(nContact.LengthWorkYear.Value.ToString(), true);

                if (nContact.LengthWorkMonth.HasValue)
                    ddl_WUC_PI_LengthWorkTo_Legal.SelectIndexByValue(nContact.LengthWorkMonth.Value.ToString(), true);
                 
                // var ContactCitizenship = ObjServices.GetContactCitizenship();
                var ContactCitizenship = ObjServices.GetContactCitizenship(nContact.ContactId); 

                if (ContactCitizenship != null)
                    ddl_WUC_PI_CountryCitizenship_Legal.SelectIndexByValue(ContactCitizenship.GlobalCountryId.ToString());
            }
            udpPersonalInformationLegal.Update();
        }

        public void Initialize()
        {
            ClearData();
            FillDrops();
            FillData();
           // if (ObjServices.IsDataReviewMode)
               // EnabledControls(!(currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id));
        }

        public void ClearData()
        {
            hdnOccupationGroupId_Legal.Value = string.Empty;
            hdnOccupationId_Legal.Value = string.Empty;
            ClearControls(this);
            if (ddl_BusinessLine2_Legal.Items.Count > 0)
                ddl_BusinessLine2_Legal.Items.Clear();
            if (ddl_BusinessLine1_Legal.Items.Count > 0)
            {
                ddl_BusinessLine1_Legal.Items.Clear();
            }
            ClearControls();
        }

        public void LoadSameDataFromInsured(Entity.UnderWriting.Entities.Contact nContact)
        {
            FillDrops();

            if (nContact != null)
            {
                tb_WUC_PI_FirstName_Legal.Text = nContact.FirstName;
                tb_WUC_PI_MiddleName_Legal.Text = nContact.MiddleName;
                tb_WUC_PI_FirstLastName_Legal.Text = nContact.FirstLastName;
                tb_WUC_PI_SecondLastName_Legal.Text = nContact.SecondLastName;
                ddl_WUC_PI_Gender_Legal.SelectIndexByValue((string.IsNullOrEmpty(nContact.Gender)) ? "-1" : nContact.Gender);
                ddl_WUC_PI_Smoker_Legal.SelectIndexByValue(!nContact.Smoker.HasValue ? "-1" : (nContact.Smoker.Value ? "1" : "0"));
                ddl_WUC_PI_CountryBirth_Legal.SelectIndexByValue(nContact.CountryOfBirthId.ToString());
                tb_WUC_PI_DateBirth_Legal.Text = !nContact.Dob.HasValue ? "" : nContact.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                tb_WUC_PI_Age_Legal.Text = !nContact.Age.HasValue ? "" : nContact.Age.Value.ToString();
                hdnAge_Legal.Value = !nContact.Age.HasValue ? "" : nContact.Age.Value.ToString();
                ddlCountryOfResidence_Legal.SelectIndexByValue(nContact.CountryOfResidenceId.ToString(), true);

                ddl_WUC_PI_MaritalStatus_Legal.SelectIndexByValue(nContact.MaritalStatId.ToString());
                tb_WUC_PI_PersonalIncome_Legal.Text = !nContact.AnnualPersonalIncome.HasValue ? ""
                    : nContact.AnnualPersonalIncome.Value.ToString(NumberFormatInfo.InvariantInfo);
                tb_WUC_PI_YearLyFamilyIncome_Legal.Text = !nContact.AnnualFamilyIncome.HasValue ? ""
                    : nContact.AnnualFamilyIncome.Value.ToString(NumberFormatInfo.InvariantInfo);

                if (nContact.OccupGroupTypeId.HasValue)
                {
                    txtOccupation_Legal.Text = nContact.Occupation_Desc;
                    hdnOccupationGroupId_Legal.Value = nContact.OccupGroupTypeId.Value.ToString();
                }

                if (nContact.OccupationId.HasValue)
                {
                    txtProfession_Legal.Text = nContact.Occupation_Group_Desc;
                    hdnOccupationId_Legal.Value = nContact.OccupationId.Value.ToString();
                }

                tb_WUC_PI_CompanyName_Legal.Text = nContact.CompanyName;

                if (nContact.LineOfBusiness2 != null && nContact.LineOfBusiness2.Length > 0)
                {
                    Utility.SelectIndexByText(ref ddl_BusinessLine2_Legal, nContact.LineOfBusiness2);
                    if (ddl_BusinessLine1_Legal.Items.Count > 0)
                        ddl_BusinessLine1_Legal.Items.Clear();

                    ListItem lstBL2 = new ListItem(nContact.LineOfBusiness, "-1");
                    ddl_BusinessLine1_Legal.Items.Add(lstBL2);
                }

                //Bmarroquin 05-03-2017 Correccion para que no se pierda la Linea o Giro de Negocio 1 
                if (nContact.LineOfBusiness != null && ddl_BusinessLine2_Legal != null && ddl_BusinessLine2_Legal.SelectedIndex > 0)
                {
                    var countryId = ddl_BusinessLine2_Legal != null && ddl_BusinessLine2_Legal.Items != null && ddl_BusinessLine2_Legal.Items.Count > 0 ? ddl_BusinessLine2_Legal.SelectedValue.ToInt() : 0;
                    if (countryId > 0)
                    {
                        ObjServices.GettingAllDrops(ref ddl_BusinessLine1_Legal,
                                  Utility.DropDownType.CustomerBusinessLine,
                                  "GlobalCountryDesc",
                                  "CountryId",
                                  countryId: countryId,
                                GenerateItemSelect: true
                               );
                        if (nContact.LineOfBusiness.Length > 0)
                        {
                            Utility.SelectIndexByText(ref ddl_BusinessLine1_Legal, nContact.LineOfBusiness);
                        }
                    }
                }

                tb_WUC_PI_TaskPerformed_Legal.Text = nContact.LaborTasks;
                ddl_WUC_PI_LengthWorkFrom_Legal.SelectIndexByValue(!nContact.LengthWorkYear.HasValue ? "-1"
                    : nContact.LengthWorkYear.Value.ToString());
                ddl_WUC_PI_LengthWorkTo_Legal.SelectIndexByValue(!nContact.LengthWorkMonth.HasValue ? "-1"
                    : nContact.LengthWorkMonth.Value.ToString());
                var GlobalCountryId = ObjServices.oContactManager.GetContactCitizenshipByContact(nContact.ContactId).FirstOrDefault().GlobalCountryId.ToString();
                ddl_WUC_PI_CountryCitizenship_Legal.SelectIndexByValue(GlobalCountryId);
            }
            else
                ClearControls();

            udpPersonalInformationLegal.Update();

        } 

        public void EnabledControls(bool x)
        {
            EnabledControls(frmPersonalInformationLegal.Controls, x);
            udpPersonalInformationLegal.Update();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(frmPersonalInformationLegal.Controls, isReadOnly);
            udpPersonalInformationLegal.Update();
        }

        protected void ddl_BusinessLine2_SelectedIndexChanged_Legal(object sender, EventArgs e)
        {
            ObjServices.GettingAllDrops(ref ddl_BusinessLine1_Legal,
                                      Utility.DropDownType.CustomerBusinessLine,
                                      "GlobalCountryDesc",
                                      "CountryId",
                                      countryId: int.Parse(ddl_BusinessLine2_Legal.SelectedValue),
                                    GenerateItemSelect: false
                                   );
            if (ddl_BusinessLine1_Legal.Items.Count > 0)
            {
                ddl_BusinessLine1_Legal.SelectedIndex = 0;
            }
        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession_Legal.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }
    }
}