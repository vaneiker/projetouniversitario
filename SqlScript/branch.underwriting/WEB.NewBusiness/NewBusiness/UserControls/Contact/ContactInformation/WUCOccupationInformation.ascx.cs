using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation
{
    public partial class WUCOccupationInformation : UC, IUC
    {
        public void edit() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            YearlyFamilyIncome.InnerHtml = Resources.YearlyFamilyIncomeLabel;
            YearlyPersonalIncome.InnerHtml = Resources.YearlyPersonalIncomeLabel;
            OccupationType.InnerHtml = Resources.OccupationTypeLabel;
            Occupation.InnerHtml = Resources.OccupationLabel;
            CompanyName.InnerHtml = Resources.CompanyNameLabel;
            LineofBusiness1.InnerHtml = Resources.LineofBusinessLabel + " 1";
            LineofBusiness2.InnerHtml = Resources.LineofBusinessLabel + " 2";
            TaskPerformed.InnerHtml = Resources.TasksPerformedLabel;
            Years.InnerHtml = Resources.YearsatWorkLabel;
            Months.InnerHtml = Resources.MonthsLabel;
            OccupationInformation.InnerHtml = Resources.OCCUPATIONINFORMATIONLabel;
            LengthatWork.InnerHtml = Resources.LengthAtWorkLabel;

            if (!hdnOccupationGroupId.Value.SIsNullOrEmpty() && !hdnOccupationId.Value.SIsNullOrEmpty())
            {
                var data = ObjServices.GettingDropData(Utility.DropDownType.Occupation);

                if (data != null)
                {
                    var dataOccup = data.FirstOrDefault(y => y.OccupGroupTypeId == hdnOccupationGroupId.ToInt() && y.OccupationId == hdnOccupationId.ToInt());
                    
                    if (dataOccup != null)
                    {
                        txtOccupation.Text = dataOccup.OccupationDesc;
                        txtProfession.Text = dataOccup.OccupationGroupDesc;
                    }
                }
            }
        }

        public void save()
        {
            if (ObjServices.ContactEntityID.HasValue && ObjServices.ContactEntityID.Value > 0)
            {
                var oContact = ObjServices.GetContact(ObjServices.ContactEntityID.Value);
                SetDataAndUpdate(oContact);
            }
        }

        public void SetDataAndUpdate(Entity.UnderWriting.Entities.Contact oContact)
        {
            if (oContact != null)
            {
                oContact.AnnualPersonalIncome = !string.IsNullOrEmpty(txtPersonalIncome.Text) ? txtPersonalIncome.ToDecimal() :
                    (decimal?)null;
                oContact.AnnualFamilyIncome = !string.IsNullOrEmpty(txtYearlyFamilyIncome.Text) ? txtYearlyFamilyIncome.ToDecimal() :
                    (decimal?)null;

                oContact.OccupGroupTypeId = !string.IsNullOrEmpty(hdnOccupationGroupId.Value) ? hdnOccupationGroupId.ToInt() : (int?)null;
                oContact.OccupationId = !string.IsNullOrEmpty(hdnOccupationId.Value) ? hdnOccupationId.ToInt() : (int?)null;

                oContact.CompanyName = txtCompanyName.Text;
                if (ddl_BusinessLine1.SelectedValue.ToString() != "-1" && ddl_BusinessLine1.SelectedValue.ToString() != string.Empty && ddl_BusinessLine1.SelectedItem.Text.Length > 0)
                {
                    oContact.LineOfBusiness = ddl_BusinessLine1.SelectedItem.Text;
                }
                else
                {
                    oContact.LineOfBusiness = "";
                }
                //oContact.LineOfBusiness = (ddl_BusinessLine1.SelectedValue.ToString() == "-1" ? "" : ddl_BusinessLine1.SelectedItem.Text); //txtFirstLineOfBussines.Text;
                if (ddl_BusinessLine2.Items.Count > 0)
                {
                    oContact.LineOfBusiness2 = ddl_BusinessLine2.SelectedItem.Text; // (ddl_BusinessLine2.SelectedValue.ToString() == "-1" ? "" : ddl_BusinessLine2.SelectedItem.Text);  //txt2ndLineOfBussines.Text;
                }
                else
                {
                    oContact.LineOfBusiness2 = "";
                }

                oContact.LaborTasks = txtTaskPerformed.Text;
                oContact.LengthWorkYear = ddlYears.SelectedValue != "-1" ? ddlYears.ToInt() : (int?)null;
                oContact.LengthWorkMonth = ddlMonths.SelectedValue != "-1" ? ddlMonths.ToInt() : (int?)null;
                //Actualizar el contacto
                ObjServices.oContactManager.UpdateContact(oContact);
            }
        }

        public void FillDrop()
        {
            //Llenar el dropDpown de LengOfWork
            ObjServices.GettingAllDrops(ref ddlYears,
                                    Utility.DropDownType.LengthatWork,
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Months 
            ObjServices.GettingAllDrops(ref ddlMonths,
                                      Utility.DropDownType.Months,
                                    GenerateItemSelect: true
                                   );

            //Llenar dropDown Customer BL 1
            //ObjServices.GettingAllDrops(ref ddl_BusinessLine1,
            //                          Utility.DropDownType.CustomerBusinessLine,
            //                          "GlobalCountryDesc",
            //                          "CountryId",
            //                        GenerateItemSelect: true
            //                       );


            ObjServices.GettingAllDrops(ref ddl_BusinessLine2,
                                      Utility.DropDownType.CustomerBusinessLine2,
                                      "GlobalCountryDesc",
                                      "CountryId",
                                    GenerateItemSelect: true
                                   );

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

        public void FillData()
        {
            Entity.UnderWriting.Entities.Contact oContact = null;

            oContact = ObjServices.GetContact(ObjServices.ContactEntityID.Value);

            if (oContact != null)
            {
                txtPersonalIncome.Text = !oContact.AnnualPersonalIncome.HasValue ? "" : oContact.AnnualPersonalIncome.Value.ToString(NumberFormatInfo.InvariantInfo);
                txtYearlyFamilyIncome.Text = !oContact.AnnualFamilyIncome.HasValue ? "" : oContact.AnnualFamilyIncome.Value.ToString(NumberFormatInfo.InvariantInfo);

                if (oContact.OccupGroupTypeId.HasValue)
                {
                    txtOccupation.Text = oContact.Occupation_Desc;
                    hdnOccupationGroupId.Value = oContact.OccupGroupTypeId.Value.ToString();
                }

                if (oContact.OccupationId.HasValue)
                {
                    txtProfession.Text = oContact.Occupation_Group_Desc;
                    hdnOccupationId.Value = oContact.OccupationId.Value.ToString();
                }

                txtCompanyName.Text = oContact.CompanyName;
                //txtFirstLineOfBussines.Text = oContact.LineOfBusiness;
                if (oContact.LineOfBusiness2 != null)
                {
                    
                    if (oContact.LineOfBusiness2.Length > 0)
                    {
                        Utility.SelectIndexByText(ref ddl_BusinessLine2, oContact.LineOfBusiness2);
                    }
                    if (ddl_BusinessLine1.Items.Count > 0)
                        ddl_BusinessLine1.Items.Clear();
                    ListItem lstBL1 = new ListItem(oContact.LineOfBusiness, "-1");
                    ddl_BusinessLine1.Items.Add(lstBL1);
                }

                //txt2ndLineOfBussines.Text = oContact.LineOfBusiness2;
                if (oContact.LineOfBusiness != null && ddl_BusinessLine2 != null && ddl_BusinessLine2.SelectedIndex > 0)
                {
                    var countryId = ddl_BusinessLine2 != null  && ddl_BusinessLine2.Items != null && ddl_BusinessLine2.Items.Count > 0 ? ddl_BusinessLine2.SelectedValue.ToInt() : 0;
                    if (countryId > 0)
                    {
                        ObjServices.GettingAllDrops(ref ddl_BusinessLine1,
                                  Utility.DropDownType.CustomerBusinessLine,
                                  "GlobalCountryDesc",
                                  "CountryId",
                                  countryId: countryId,
                                GenerateItemSelect: true
                               );
                        if (oContact.LineOfBusiness.Length > 0)
                        {
                            Utility.SelectIndexByText(ref ddl_BusinessLine1, oContact.LineOfBusiness);
                        }
                    }

                }


                txtTaskPerformed.Text = oContact.LaborTasks;
                ddlYears.SelectIndexByValue(!oContact.LengthWorkYear.HasValue ? "-1" : oContact.LengthWorkYear.Value.ToString());
                ddlMonths.SelectIndexByValue(!oContact.LengthWorkMonth.HasValue ? "-1" : oContact.LengthWorkMonth.Value.ToString());
            }

        }

        public void Initialize()
        {
            FillDrop();
            FillData();
        }

        public void ClearData()
        {
            hdnOccupationGroupId.Value = string.Empty;
            hdnOccupationId.Value = string.Empty;
            Utility.ClearAll(this.Controls);
        }

        protected void ddl_BusinessLine2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjServices.GettingAllDrops(ref ddl_BusinessLine1,
                                      Utility.DropDownType.CustomerBusinessLine,
                                      "GlobalCountryDesc",
                                      "CountryId",
                                      countryId: int.Parse(ddl_BusinessLine2.SelectedValue),
                                    GenerateItemSelect: false
                                   );
            if (ddl_BusinessLine1.Items.Count > 0)
            {
                ddl_BusinessLine1.SelectedIndex = 0;
            }

        }
    }
}