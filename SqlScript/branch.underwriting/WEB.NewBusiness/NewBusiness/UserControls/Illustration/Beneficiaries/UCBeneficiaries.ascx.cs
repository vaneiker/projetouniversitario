using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Entity.UnderWriting.IllusData;
using RESOURCE.UnderWriting.NewBussiness;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Beneficiaries
{
    public partial class UCBeneficiaries : UC, IUC
    {
        #region Properties
        private List<Beneficiaries> ListBeneficiaries
        {
            get
            {
                var lst = ViewState["ListBeneficiaries"];
                return lst == null ? null : (List<Beneficiaries>)lst;
            }
            set
            {
                ViewState["ListBeneficiaries"] = value;
            }
        }

        private long? BeneficiaryId
        {
            get
            {
                var temp = ViewState["BeneficiaryId"];
                return temp == null ? (long?)null : (long?)temp;
            }
            set
            {
                ViewState["BeneficiaryId"] = value;
            }
        }

        private string InsuredTypeCode
        {
            get
            {
                var temp = ViewState["InsuredTypeCode"];
                return temp == null ? null : temp.ToString();
            }
            set
            {
                ViewState["InsuredTypeCode"] = value;
            }
        }

        private string BeneficiaryTypeCode
        {
            get
            {
                var temp = ViewState["BeneficiaryTypeCode"];
                return temp == null ? null : temp.ToString();
            }
            set
            {
                ViewState["BeneficiaryTypeCode"] = value;
            }
        }
        #endregion
        #region Methods
        #region Private
        private void Save()
        {
            var lstBeneficiaries = ListBeneficiaries;
            foreach (var item in lstBeneficiaries)
                if (item.OperationType == Utility.OperationType.Insert || item.OperationType == Utility.OperationType.Edit)
                {
                    var beneficiary = new Illustrator.CustomerPlanBeneficiary
                       {
                           InsuredTypeCode = InsuredTypeCode,
                           BeneficiaryTypeCode = BeneficiaryTypeCode,
                           FirstName = item.FirstName,
                           MiddleName = item.MiddleName,
                           LastName = item.LastName,
                           Dob = item.DateOfBirth,
                           RelationshipTypeCode = item.RelationshipCode,
                           PercentValue = item.Percentage,
                           CustomerPlanNo = ObjIllustrationServices.CustomerPlanNo,
                           SecondLastName = item.SecondLastName //Lgonzalez 11-02-17
                       };
                    if (item.OperationType == Utility.OperationType.Insert)
                    {
                        beneficiary.CustomerPlanbeneficiaryNo = -1;
                        beneficiary.DateCreated = DateTime.Now;
                        beneficiary.CreatedBy = ObjIllustrationServices.IllusUserID;
                    }
                    else
                    {
                        beneficiary.CustomerPlanbeneficiaryNo = item.Id;
                        beneficiary.DateUpdated = DateTime.Now;
                        beneficiary.UpdatedBy = ObjIllustrationServices.IllusUserID;
                    }
                    item.Id = ObjIllustrationServices.oIllusDataManager.SetCustomerPlanBeneficiary(beneficiary).CustomerPlanbeneficiaryNo;
                    item.OperationType = Utility.OperationType.Edit;
                }
                else if (item.OperationType == Utility.OperationType.Delete)
                    ObjIllustrationServices.oIllusDataManager.DeleteCustomerPlanBeneficiary(item.Id);
        }
        #endregion
        #region Public
        public void FillData()
        {

        }

        public void FillData(string insuredTypeCode, string beneficiaryType)
        {
            InsuredTypeCode = insuredTypeCode;
            BeneficiaryTypeCode = beneficiaryType;
            if (ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault() > 0)
            {
                ListBeneficiaries = ObjIllustrationServices.oIllusDataManager.GetCustomerPlanBeneficiary(ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault(), insuredTypeCode, beneficiaryType)
                    .Select(o => new Beneficiaries
                    {
                        Id = o.CustomerPlanbeneficiaryNo,
                        FirstName = o.FirstName,
                        MiddleName = o.MiddleName,
                        LastName = o.LastName,
                        DateOfBirth = o.Dob,
                        RelationshipCode = o.RelationshipTypeCode,
                        Relationship = o.RelationshipType,
                        Percentage = o.PercentValue,
                        OperationType = Utility.OperationType.Edit,
                        SecondLastName = o.SecondLastName
                    }).ToList();
            }
            gvBeneficiaries.DataBind();
        }

        public void Translator(string Lang)
        {
            btnAdd.Text = RESOURCE.UnderWriting.NewBussiness.Resources.Add;
            gvBeneficiaries.TranslateColumnsAspxGrid();
            if (isChangingLang)
                FillDropDown();
        }

        public void save()
        {
            Save();
        }

        public void edit()
        {
            Save();
        }

        public void Initialize()
        {
            FillDropDown();
            ListBeneficiaries = new List<Beneficiaries>();
        }

        public void FillDropDown()
        {
            Utility.GettingAllDropsToIllus(ref ddlRelationship, Utility.DropDownType.Relationship, "RelationshipType", "RelationshipTypeCode", GenerateItemSelect: true, pLang: ObjServices.Language);
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        public void SetBeneficiary(Beneficiaries beneficiary)
        {
            beneficiary.FirstName = txtFirstName.Text;
            beneficiary.MiddleName = txtMiddleName.Text;
            beneficiary.LastName = txtLastName.Text;
            beneficiary.SecondLastName = txtSecondLastName.Text;
            beneficiary.DateOfBirth = txtDateOfBirth.Text.IsDateReturnNull();
            beneficiary.RelationshipCode = ddlRelationship.SelectedValue;
            beneficiary.Relationship = ddlRelationship.SelectedItem.Text;
            beneficiary.Percentage = txtPercentage.Text.ToDecimal();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {

        }

        public void ChangeVisibilityPercentage(bool visible)
        {
            txtPercentage.Visible = lblPercentage.Visible = gvBeneficiaries.Columns["PercentageLabel"].Visible = visible;

            if (visible)
                txtPercentage.Attributes.Add("validation", "Required");
            else
                txtPercentage.Attributes.Remove("validation");
        }
        #endregion
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translator(null);
        }

        public List<Beneficiaries> GetBeneficiaries(List<Beneficiaries> data)
        {
            return data.Where(o => o.OperationType != Utility.OperationType.Delete).ToList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var lstBeneficiaries = ListBeneficiaries.Clone<List<Beneficiaries>>();
            var beneficiary = new Beneficiaries();
            if (txtPercentage.Text.ToLong() < 0 || txtPercentage.Text.ToLong() > 100)
            {
                this.MessageBox("Percentage cant be less than 0 or more than 100.");
                return;
            }

            if (!BeneficiaryId.HasValue)
            {
                var newId = (lstBeneficiaries.Any() ? lstBeneficiaries.Max(o => o.Id) : 0) + 1;
                beneficiary = new Beneficiaries
                {
                    Id = newId,
                    OperationType = Utility.OperationType.Insert
                };
                SetBeneficiary(beneficiary);
                lstBeneficiaries.Add(beneficiary);
            }
            else
            {
                beneficiary = lstBeneficiaries.Single(o => o.Id == BeneficiaryId);
                if (beneficiary.OperationType != Utility.OperationType.Insert)
                    beneficiary.OperationType = Utility.OperationType.Edit;
                SetBeneficiary(beneficiary);
            }

            var total = lstBeneficiaries.Sum(o => o.Percentage);

            if (total > 100)
            {
                this.MessageBox("Total Percentage cant be more than 100.");
                return;
            }
            ListBeneficiaries = lstBeneficiaries;
            BeneficiaryId = null;
            btnAdd.Text = Resources.Add;
            this.ClearControls();
            gvBeneficiaries.DataBind();
        }

        protected void dsBeneficiaries_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = ListBeneficiaries;
        }

        protected void gvBeneficiaries_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            var id = e.CommandArgs.CommandArgument.ToString().ToLong();
            var lstBeneficiaries = ListBeneficiaries;
            var beneficiary = lstBeneficiaries.Single(o => o.Id == id);
            switch (e.CommandArgs.CommandName)
            {
                case "Edit":
                    BeneficiaryId = id;
                    txtFirstName.Text = beneficiary.FirstName;
                    txtMiddleName.Text = beneficiary.MiddleName;
                    txtLastName.Text = beneficiary.LastName;
                    txtDateOfBirth.Text = beneficiary.DateOfBirth.GetValueOrDefault().ToShortDateString();
                    ddlRelationship.SelectedValue = beneficiary.RelationshipCode;
                    txtPercentage.Text = beneficiary.Percentage.GetValueOrDefault().ToString();
                    txtSecondLastName.Text = beneficiary.SecondLastName; //lgonzalez 11-02-17
                    btnAdd.Text = Resources.Edit;
                    break;
                case "Delete":
                    if (BeneficiaryId == id)
                    {
                        this.MessageBox("Beneficiary is editing.");
                        return;
                    }
                    if (beneficiary.OperationType != Utility.OperationType.Insert)
                        beneficiary.OperationType = Utility.OperationType.Delete;
                    else
                        lstBeneficiaries.Remove(beneficiary);
                    ListBeneficiaries = lstBeneficiaries;
                    break;
            }
            gvBeneficiaries.DataBind();
        }
        #endregion
        [Serializable]
        public class Beneficiaries
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string RelationshipCode { get; set; }
            public string Relationship { get; set; }
            public decimal? Percentage { get; set; }
            public string SecondLastName { get; set; }
            public WEB.NewBusiness.Common.Utility.OperationType OperationType { get; set; }
        }
    }
}