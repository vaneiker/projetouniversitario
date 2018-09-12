using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Entity.UnderWriting.IllusData;
using RESOURCE.UnderWriting.NewBussiness;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Requirements
{
    public partial class UCRequirement : UC, IUC
    {
        #region Properties
        private UCPlanContainer UCIllustrationPlanContainer
        {
            get
            {
                return (UCPlanContainer)Page.Controls[0].FindControl("bodyContent").FindControl("UCIllustrationContainer").FindControl("UCPlanContainer");
            }
        }

        private List<Requirements> ListRequirements
        {
            get
            {
                var lst = ViewState["ListRequirements"];
                return lst == null ? new List<Requirements>() : (List<Requirements>)lst;
            }
            set
            {
                ViewState["ListRequirements"] = value;
            }
        }

        private long? RequirementId
        {
            get
            {
                var temp = ViewState["RequirementId"];
                return temp == null ? (long?)null : (long?)temp;
            }
            set
            {
                ViewState["RequirementId"] = value;
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
        #endregion
        #region Methods
        #region Private
        private void Save()
        {
            var lstRequirements = ListRequirements;
            foreach (var item in lstRequirements)
                if (item.OperationType == Utility.OperationType.Insert || item.OperationType == Utility.OperationType.Edit)
                {
                    var requirement = new Illustrator.CustomerPlanOtherInsurance
                    {
                        InsuredTypeCode = InsuredTypeCode,
                        AnnuityAmount = item.AnnuityAmount.IsDecimalReturnNull(),
                        AnnuityPeriod = item.AnnuityPeriod,
                        InsuredAmount = item.InsuredAmount.IsDecimalReturnNull(),
                        CustomerPlanNo = ObjIllustrationServices.CustomerPlanNo,
                        ProductCode = item.ProductTypeCode
                    };
                    if (item.OperationType == Utility.OperationType.Insert)
                    {
                        requirement.CustomerPlanOtherInsuranceNo = -1;
                        requirement.DateCreated = DateTime.Now;
                        requirement.CreatedBy = ObjIllustrationServices.IllusUserID;
                    }
                    else
                    {
                        requirement.CustomerPlanOtherInsuranceNo = item.Id;
                        requirement.DateUpdated = DateTime.Now;
                        requirement.UpdatedBy = ObjIllustrationServices.IllusUserID;
                    }
                    item.Id = ObjIllustrationServices.oIllusDataManager.SetCustomerPlanOtherInsurance(requirement).CustomerPlanOtherInsuranceNo;
                    item.OperationType = Utility.OperationType.Edit;
                }
                else if (item.OperationType == Utility.OperationType.Delete)
                    ObjIllustrationServices.oIllusDataManager.DeleteCustomerPlanOtherInsurance(item.Id);
        }

        private void SetRequirement(Requirements requirement)
        {
            requirement.ProductTypeCode = ddlProduct.SelectedValue;
            requirement.ProductType = ddlProduct.SelectedItem.Text;
            requirement.InsuredAmount = txtInsuredAmount.Text;
            requirement.AnnuityAmount = txtAnnuityAmount.Text;
            requirement.AnnuityPeriod = txtAnnuityPeriod.Text.IsIntReturnNull();
        }

        private decimal CalculateTotalInsuredamount()
        {
            var total = ObjIllustrationServices.oIllusDataManager.GetTotalInsuredAmount(ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault(), InsuredTypeCode);//0;//
            return total;
        }
        #endregion
        #region Public
        public void Translator(string Lang)
        {
            btnAdd.Text = Resources.Add;
            gvRequirements.TranslateColumnsAspxGrid();
            gvRequirementDetails.TranslateColumnsAspxGrid();
            if (isChangingLang)
                ddlProduct.Items[0].Text = Resources.Select;
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
        }

        public void save()
        {
            Save();
        }

        public void DeleteExamCondition()
        {
            ObjIllustrationServices.oIllusDataManager.DeleteCustomerPlanExam(ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault(), InsuredTypeCode, ObjServices.UserID.GetValueOrDefault());
        }

        public void RefreshExamCondition()
        {
            string age = "", gender = "", maritalStatus = "";
            if (InsuredTypeCode == "P")//Primary
            {
                var customer = ObjIllustrationServices.oIllusDataManager.GetCustomerDetailById(ObjIllustrationServices.CustomerNo.GetValueOrDefault(), null);
                age = customer.Age;
                gender = customer.GenderCode;
                maritalStatus = customer.MaritalStatusCode;
            }
            else //Other
            {
                var otherCustomer = ObjIllustrationServices.oIllusDataManager.GetCustomerPlanPartnerInsurance(ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault());
                age = otherCustomer.Age.GetValueOrDefault().ToString();
                gender = otherCustomer.GenderCode;
                maritalStatus = otherCustomer.MaritalStatusCode;
            }
            var lstExam = ObjIllustrationServices.oIllusDataManager.GetCustomerExamCondition(UCIllustrationPlanContainer.ProductCode, age.ToInt(), gender, maritalStatus, CalculateTotalInsuredamount());
            foreach (var item in lstExam)
                ObjIllustrationServices.oIllusDataManager.UpdateCustomerPlanExam(new Illustrator.CustomerPlanExam
                {
                    ExamCode = item.ExamCode,
                    CustomerPlanNo = ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault(),
                    InsuredTypeCode = InsuredTypeCode,
                    DateCreated = DateTime.Now,
                    CreatedBy = ObjServices.UserID
                });
            gvRequirementDetails.DataBind();
        }

        public void edit()
        {
            Save();
        }

        public void Initialize()
        {
            Utility.GettingAllDropsToIllus(ref ddlProduct, Utility.DropDownType.ProductType, "Product", "ProductCode", GenerateItemSelect: true, companyId: ObjServices.CompanyId, pLang: ObjServices.Language);
        }


        public void Initialize(string insuredTypeCode)
        {
            InsuredTypeCode = insuredTypeCode;
            Initialize();
        }

        public void ClearData()
        {
        }

        public void FillData()
        {
            if (ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault() > 0)
                ListRequirements = ObjIllustrationServices.oIllusDataManager.GetCustomerPlanOtherInsurance(ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault(), InsuredTypeCode)
                    .Select(o => new Requirements
                    {
                        Id = o.CustomerPlanOtherInsuranceNo,
                        AnnuityAmount = o.AnnuityAmount.GetValueOrDefault().ToString(),
                        AnnuityPeriod = o.AnnuityPeriod.GetValueOrDefault(),
                        InsuredAmount = o.InsuredAmount.GetValueOrDefault().ToString(),
                        ProductTypeCode = o.ProductCode,
                        ProductType = o.Product,
                        OperationType = Utility.OperationType.Edit
                    }).ToList();
            gvRequirements.DataBind();
            gvRequirementDetails.DataBind();
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

        protected void gvRequirements_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            var id = e.CommandArgs.CommandArgument.ToString().ToLong();
            var lstRequirements = ListRequirements;
            var requirement = lstRequirements.Single(o => o.Id == id);
            switch (e.CommandArgs.CommandName)
            {
                case "Edit":
                    RequirementId = id;
                    txtAnnuityAmount.Text = requirement.AnnuityAmount;
                    txtAnnuityPeriod.Text = requirement.AnnuityPeriod.ToString();
                    txtInsuredAmount.Text = requirement.InsuredAmount;
                    ddlProduct.SelectedValue = requirement.ProductTypeCode;
                    btnAdd.Text = Resources.Edit;
                    break;
                case "Delete":
                    if (RequirementId == id)
                    {
                        this.MessageBox("Requirement is editing.");
                        return;
                    }
                    if (requirement.OperationType != Utility.OperationType.Insert)
                        requirement.OperationType = Utility.OperationType.Delete;
                    else
                        lstRequirements.Remove(requirement);
                    ListRequirements = lstRequirements;
                    gvRequirements.DataBind();
                    break;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var lstRequirements = ListRequirements.Clone<List<Requirements>>();
            Requirements requirement;

            if (!RequirementId.HasValue)
            {
                var newId = (lstRequirements.Any() ? lstRequirements.Max(o => o.Id) : 0) + 1;
                requirement = new Requirements
                {
                    Id = newId,
                    OperationType = Utility.OperationType.Insert
                };
                SetRequirement(requirement);
                lstRequirements.Add(requirement);
            }
            else
            {
                requirement = lstRequirements.Single(o => o.Id == RequirementId);
                if (requirement.OperationType != Utility.OperationType.Insert)
                    requirement.OperationType = Utility.OperationType.Edit;
                SetRequirement(requirement);
            }

            ListRequirements = lstRequirements;
            RequirementId = null;
            btnAdd.Text = Resources.Add;
            ddlProduct.SelectedIndex = 0;
            txtAnnuityAmount.Text = txtInsuredAmount.Text = txtAnnuityPeriod.Text = "";
            gvRequirements.DataBind();
        }

        protected void ldsRequirement_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = "Id";
            e.QueryableSource = ListRequirements.Where(o => o.OperationType != Utility.OperationType.Delete).AsQueryable();
        }

        protected void ldsRequirementDetail_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjIllustrationServices.oIllusDataManager.GetCustomerPlanExam(ObjIllustrationServices.CustomerPlanNo.GetValueOrDefault(), InsuredTypeCode).ToList();
            e.KeyExpression = "ExamCode";
            e.QueryableSource = data.AsQueryable();
        }
        #endregion
        [Serializable]
        public class Requirements
        {
            public long Id { get; set; }
            public string ProductTypeCode { get; set; }
            public string ProductType { get; set; }
            public string InsuredAmount { get; set; }
            public string AnnuityAmount { get; set; }
            public int? AnnuityPeriod { get; set; }
            public Utility.OperationType OperationType { get; set; }
        }
    }
}