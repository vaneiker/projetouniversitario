using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{

    public partial class UCQuestionSelection : UC, IUC
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// aqui por numero de preguntas se deben buscar todas las opciones que tiene la misma para agregar los controles  
        /// dinamicos que tiene la pregunta, luego se tiene que buscar si tiene alguna opcion seleccionada para llenarlo con esta 
        /// informacion. 
        /// </summary>
        public void fillData(Questionnaire.Option option)
        {
            var dt = ObjServices.oHealthDeclarationManager.GetAllQuestionOption(option);

            foreach (var item in dt)
            {
                var id = item.OptionId.Value.ToString() + "_" + item.QuestionId.Value.ToString();
                switch (item.OptionTypeDesc)
                {
                    case "CheckBox":
                        UCCheckBox d = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCCheckBox.ascx") as UCCheckBox;
                        d.Page = this.Page;
                        d.ID = "CheckBox_" + id;
                        d.SetTitles = item.OptionLabel;
                        this.Controls.Add(d);
                        break;

                    case "DropDownList":
                        UCDropdown drop = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCDropdown.ascx") as UCDropdown;
                        drop.Page = this.Page;
                        drop.ID = "DropDownList_" + id;
                        drop.SetTitles = item.OptionLabel;
                        drop.setDiv(item.IsWidth100.HasValue ? item.IsWidth100.Value : false);

                        var Select = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        drop.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(Select).ToList());
                        this.Controls.Add(drop);
                        break;
                    case "DropDownCheckBoxes":
                        UCUCDropdownCheckBox DropDownCheckBoxes = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCUCDropdownCheckBox.ascx") as UCUCDropdownCheckBox;
                        DropDownCheckBoxes.Page = this.Page;
                        DropDownCheckBoxes.ID = "DropDownCheckBoxes_" + id;
                        DropDownCheckBoxes.ValueDropDawn.ID = "ValueDropDawn_" + id;
                        DropDownCheckBoxes.SetTitles = item.OptionLabel;

                        var DropDownCheckBoxesSelect = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        DropDownCheckBoxes.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(DropDownCheckBoxesSelect).ToList());
                        this.Controls.Add(DropDownCheckBoxes);
                        break;
                    case "UCUCDropdownCheckWithCheckBox":
                        UCUCDropdownCheckWithCheckBox DropdownCheckWithCheckBox = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCUCDropdownCheckWithCheckBox.ascx") as UCUCDropdownCheckWithCheckBox;
                        DropdownCheckWithCheckBox.Page = this.Page;
                        DropdownCheckWithCheckBox.ValueCheckBox.Text = item.OptionLabel;
                        DropdownCheckWithCheckBox.ID = "DropdownCheckWithCheckBox__" + id;
                        DropdownCheckWithCheckBox.ValueDropDawn.ID = "DropdownCheckWithCheckBoxValueDropDawn__" + id;
                        DropdownCheckWithCheckBox.ValueCheckBox.Attributes.Add("DropDawnHide", "CheckBoxWithDropdawn_" + item.QuestionId.Value);

                        var SelectDropdownCheckWithCheckBox = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        DropdownCheckWithCheckBox.OptionId = item.OptionId.Value;
                        DropdownCheckWithCheckBox.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(SelectDropdownCheckWithCheckBox).ToList());
                        DropdownCheckWithCheckBox.setCheck(item.HasAnswer);
                        this.Controls.Add(DropdownCheckWithCheckBox);
                        break;
                    case "UCCheckBoxWithText":
                        UCCheckBoxWithText CheckBoxWithText = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCCheckBoxWithText.ascx") as UCCheckBoxWithText;
                        CheckBoxWithText.Page = this.Page;
                        CheckBoxWithText.ValueCheckBox.Text = item.OptionLabel;
                        CheckBoxWithText.ID = "UCCheckBoxWithText_" + id;
                        CheckBoxWithText.ValueCheckBox.Attributes.Add("DropDawnHide", "CheckBoxWithDropdawn_" + item.QuestionId.Value);

                        var CheckBoxWithTextOBJ = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString(),
                        };

                        CheckBoxWithText.OptionId = item.OptionId.Value;
                        CheckBoxWithText.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(CheckBoxWithTextOBJ).ToList());
                        CheckBoxWithText.setCheck(item.HasAnswer);
                        this.Controls.Add(CheckBoxWithText);
                        break;

                    case "UCCheckBoxWithDropdawn":
                        UCCheckBoxWithDropdawn CheckBoxWithDropdawn = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCCheckBoxWithDropdawn.ascx") as UCCheckBoxWithDropdawn;
                        CheckBoxWithDropdawn.Page = this.Page;
                        CheckBoxWithDropdawn.ValueCheckBox.Text = item.OptionLabel;
                        CheckBoxWithDropdawn.ID = "CheckBoxWithDropdawn_" + id;
                        CheckBoxWithDropdawn.ValueCheckBox.Attributes.Add("DropDawnHide", "CheckBoxWithDropdawn_" + item.QuestionId.Value);

                        var SelectCheckBoxWithDropdawn_ = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        CheckBoxWithDropdawn.OptionId = item.OptionId.Value;
                        CheckBoxWithDropdawn.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(SelectCheckBoxWithDropdawn_).ToList());
                        CheckBoxWithDropdawn.setCheck(item.HasAnswer);
                        this.Controls.Add(CheckBoxWithDropdawn);
                        break;
                    case "CheckBoxList":
                        UCCheckBoxList CheckBoxList = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCCheckBoxList.ascx") as UCCheckBoxList;
                        CheckBoxList.Page = this.Page;
                        CheckBoxList.ID = "CheckBoxList_" + id;
                        var Select2 = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        CheckBoxList.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(Select2).ToList());
                        this.Controls.Add(CheckBoxList);
                        break;
                    case "RadioButton":
                        UCRadioButton RadioButton = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCRadioButton.ascx") as UCRadioButton;
                        RadioButton.Page = this.Page;
                        RadioButton.ID = "RadioButton_" + id;

                        RadioButton.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                        this.Controls.Add(RadioButton);
                        break;
                    case "RadioButtonList":
                        UCRadioButtonList RadioButtonList = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCRadioButtonList.ascx") as UCRadioButtonList;
                        RadioButtonList.Page = this.Page;
                        RadioButtonList.ID = "RadioButtonList_" + id;
                        var SelectRadio = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        RadioButtonList.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(SelectRadio).ToList(), item.OptionLabel);

                        this.Controls.Add(RadioButtonList);
                        break;
                    case "CheckBoxListWithQuestion":
                        UCCheckBoxListWithQuestion CheckBoxListWithQuestion = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCCheckBoxListWithQuestion.ascx") as UCCheckBoxListWithQuestion;
                        CheckBoxListWithQuestion.Page = this.Page;
                        CheckBoxListWithQuestion.ID = "CheckBoxListWithQuestion_" + id;

                        var SelectQue = new Questionnaire.Option()
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
                            LanguageId = ObjServices.getCurrentLanguage(),
                            ContactId = option.ContactId,
                            ContactRoleTypeId = option.ContactRoleTypeId,
                            QuestionId = item.QuestionId,
                            QuestionnaireId = item.QuestionnaireId,
                            SubOption = true,
                            ParentOptionId = item.OptionId.ToString()
                        };

                        CheckBoxListWithQuestion.fillDrop(ObjServices.oHealthDeclarationManager.GetAllQuestionOption(SelectQue).ToList(), item.OptionLabel);
                        this.Controls.Add(CheckBoxListWithQuestion);
                        break;
                    case "TextBox":
                        UCTextbox TextBox = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCTextbox.ascx") as UCTextbox;
                        TextBox.Page = this.Page;
                        TextBox.SetTitles = item.OptionLabel;
                        TextBox.OptionId = item.OptionId.Value;
                        TextBox.ID = "TextBox_" + id;
                        if (item.HasAnswer)
                            TextBox.Value.Text = (item.TextualAnswer != null ? item.TextualAnswer : "");
                        this.Controls.Add(TextBox);
                        break;
                    case "TextBoxNumeric":
                        UCTextboxNumeric TextBoxNumeric = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCTextboxNumeric.ascx") as UCTextboxNumeric;
                        TextBoxNumeric.Page = this.Page;
                        TextBoxNumeric.SetTitles = item.OptionLabel;
                        TextBoxNumeric.OptionId = item.OptionId.Value;
                        TextBoxNumeric.ID = "TextBoxNumeric_" + id;
                        if (item.HasAnswer)
                            TextBoxNumeric.Value.Text = (item.TextualAnswer != null ? item.TextualAnswer : "");
                        this.Controls.Add(TextBoxNumeric);
                        break;
                    case "TextBoxDate":
                        UCTextboxDates TextBoxDate = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCTextboxDates.ascx") as UCTextboxDates;
                        TextBoxDate.Page = this.Page;
                        TextBoxDate.SetTitles = item.OptionLabel;
                        TextBoxDate.OptionId = item.OptionId.Value;
                        TextBoxDate.ID = "TextBoxDate_" + id;
                        if (item.HasAnswer)
                            TextBoxDate.Value.Text = (item.DateAnswer != null ? item.DateAnswer.Value.ToString() : "");
                        this.Controls.Add(TextBoxDate);
                        break;
                    case "TextArea":
                        UCTextboxComments TextArea = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCTextboxComments.ascx") as UCTextboxComments;
                        TextArea.Page = this.Page;
                        TextArea.SetTitles = item.OptionLabel;
                        TextArea.OptionId = item.OptionId.Value;
                        TextArea.ID = "TextArea_" + id;
                        TextArea.setDiv(item.IsWidth100.HasValue ? item.IsWidth100.Value : false);
                        if (item.HasAnswer)
                            TextArea.Value.Text = (item.TextualAnswer != null ? item.TextualAnswer : "");
                        this.Controls.Add(TextArea);
                        break; 
                    case "GridView":
                        UCGridView GridViewTemplate = LoadControl("~/NewBusiness/UserControls/AddNewClient/HealthDeclaration/UCGridView.ascx") as UCGridView;
                        GridViewTemplate.Page = this.Page;
                        GridViewTemplate.Value.ID = "HiddenFieldGrid_" + System.Guid.NewGuid().ToString("").Replace("-", "").Substring(0, 12);
                        GridViewTemplate.fillData(item);
                        this.Controls.Add(GridViewTemplate);
                        break;
                    default:
                        break;
                }
            }

        }

        public void Translator(string Lang)
        {

        }

        public void save()
        {

        }

        public void edit()
        {

        }

        public void FillData()
        {

        }

        public void Initialize()
        {

        }

        public void ClearData()
        {

        }


        public void ReadOnlyControls(bool isReadOnly)
        {

        }
    }
}