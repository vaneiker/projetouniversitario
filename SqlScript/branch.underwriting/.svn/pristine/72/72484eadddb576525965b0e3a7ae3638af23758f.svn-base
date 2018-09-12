using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WEB.NewBusiness.Common.WebServices
{
    /// <summary>
    /// Summary description for SearchMethods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SearchMethods : System.Web.Services.WebService
    {
        private UnderWritingDIManager idManager = new UnderWritingDIManager();
        public IDropDown oDropDownManager
        {
            get
            {
                return
                    idManager.DropDownManager;
            }
        }

        public class item
        {
            public string BankDesc { get; set; }
            public string AbaNumber { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abaNumber"></param>
        /// <returns>Bank_Desc,ABA_Number</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<item> GetBankABANumber(string abaNumber)
        {
            int? corpId = null;
            int? regionId = null;
            int? countryId = null;
            int? domesticregId = null;
            int? stateProvId = null;
            int? cityId = null;
            int? officeId = null;
            int? caseSeqNo = null;
            int? histSeqNo = null;
            int? contactId = null;
            int? agentId = null;
            bool? isInsured = null;
            int? occupGroupTypeId = null;
            int? requirementCategory = null;
            int? requirementType = null;
            int? BlTypeId = null;
            int? BlId = null;
            int? currencyId = null;
            bool? appliedByFreqOrCountry = null;

            DropDown.Parameter parameter = new DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(WEB.NewBusiness.Common.Utility.DropDownType), WEB.NewBusiness.Common.Utility.DropDownType.BankABANumber),
                CorpId = corpId,
                RegionId = regionId,
                CountryId = countryId,
                DomesticregId = domesticregId,
                StateProvId = stateProvId,
                CityId = cityId,
                OfficeId = officeId,
                CaseSeqNo = caseSeqNo,
                HistSeqNo = histSeqNo,
                ContactId = contactId,
                AgentId = agentId,
                IsInsured = isInsured,
                OccupGroupTypeId = occupGroupTypeId,
                RequirementCatId = requirementCategory,
                //requirementType= requirementType,
                //RiskDetId = null,
                //RiskGroupId = null,
                //TableTypeId = null,
                BlTypeId = BlTypeId,
                BlId = BlId,
                CurrencyId = currencyId,
                AbaNumber = abaNumber,
                AppliedByFreqOrCountry = appliedByFreqOrCountry
            };

            var d = new Services().oDropDownManager.GetDropDownByType(parameter);             

            var result = new List<item>();

            if (d != null && d.Any())
            {
                result = d.Select(x => new item
                {
                    AbaNumber = x.AbaNumber,
                    BankDesc = x.BankDesc
                }).ToList();
            }

            return result;
        }
    }
}
