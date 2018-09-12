using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.UnderWriting;
using Entity.UnderWriting.Entities;

namespace ServicesApi.UnderWriting.Common
{
    public class CommonService
    {
        protected static UnderWritingDIManager _uManager = new UnderWritingDIManager();

        public enum DropDownType
        {
            Occupation,
            Profession,
            OccupationType,
            City,
            Country,
            MaritalStatus,
            PolicyStatus,
            ByDate,
            Manager,
            SubManager,
            Office,
            AddressType,
            PhoneType,
            EmailType,
            Smoker,
            Gender,
            Summary,
            StateProvince,
            Relationship,
            IdType,
            Agent,
            AmmendmentType,
            AmmendmentTypeScope,
            RiderStatus,
            LengthatWork,
            Months,
            IssuedBy,
            PrimaryBeneficiary,
            PlanType,
            Product,
            ScaleType,
            Currency,
            Serie,
            ProfileType,
            PaymentFrequency,
            PolicyContactByRole,
            PolicyContactByRoleOnlyInsured,
            ProfileType_NewBusiness,
            ContributionType,
            ContributionPeriod,
            PaymentType,
            PaymentTypeCheck,
            PaymentTypeCC,
            PaymentSource,
            ReceiptType,
            RetirementPeriod,
            DefermentPeriod,
            ProductByFamily,
            BankABANumber,
            ProductType,
            FamilyProduct,
            AnnuityPeriod,
            CalculateType,
            ActivityRiskType,
            HealthRiskType,
            FrequencyType,
            InvestmentProfile,
            IllustrationType,
            IllustrationStatus,
            QuestionDisease,
            Boolean,
            DataReviewNoteType,
            LoteType,
            CountryOfResidence,
            Mortality,
            Commission,
            SurrenderPenal,
            RelationshipFuneral,
            ProfessionType,
            IdentificationType
        }
        public enum BGCExtraInfoType
        {
            Documento = 1,
            URL = 2
        }

        public class BgcDocuments
        {
            public int? DocumentId { get; set; }
            public byte[] DocumentBinary { get; set; }
            public string DocumentName { get; set; }
            public DateTime CreationDate { get; set; }
        }

        public static IEnumerable<Entity.UnderWriting.IllusData.DropDown> GetIllusDropDownByType(DropDownType type, Entity.UnderWriting.IllusData.DropDown.Parameter parameter = null)
        {
            if (parameter == null)
                parameter = new Entity.UnderWriting.IllusData.DropDown.Parameter();
            if (String.IsNullOrEmpty(parameter.DropDownType))
                parameter.DropDownType = Enum.GetName(typeof(DropDownType), type);
            return _uManager.IIllusDataManager
                       .GetDropDownByType(parameter);
        }

        public static IEnumerable<DropDown> GetDropDownByType(DropDownType dropDownType, DropDown.Parameter parameter = null)
        {
            if (parameter == null)
                parameter = new DropDown.Parameter();

            if (!parameter.CorpId.HasValue)
                parameter.CorpId = 1;

            parameter.DropDownType = Enum.GetName(typeof(DropDownType), dropDownType);

            if (!parameter.CompanyId.HasValue)
                parameter.CompanyId = 2;

            if (!parameter.ProjectId.HasValue)
                parameter.ProjectId = 1;

            if (!parameter.LanguageId.HasValue)
                parameter.LanguageId = 1;

            return _uManager.DropDownManager.GetDropDownByType(parameter);
        }
    }
}
