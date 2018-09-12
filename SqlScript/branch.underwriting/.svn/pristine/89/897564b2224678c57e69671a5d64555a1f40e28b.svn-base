using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using DI.UnderWriting.IllusData.Interfaces;
using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using RESOURCE.UnderWriting.NewBussiness;
using System.Threading;
using System.Globalization;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.Common.Illustration;
using System.Text;
using Entity.UnderWriting.IllusData;
using WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models;

namespace WEB.NewBusiness
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

        public IPolicy oPolicyManager
        {
            get
            {
                return
                      idManager.PolicyManager;
            }
        }

        public IRequirement oRequirementManager
        {
            get
            {
                return
                      idManager.RequirementManager;
            }
        }

        /// <summary>
        /// Cambia el Idioma del sistema este metodo es ideal para ser invocado desde un web method o un web service
        /// </summary>
        /// <param name="Language"></param>
        public void ChangeLanguage(Utility.Language Language)
        {
            var Idioma = string.Empty;

            if (Language == Utility.Language.en)
                Idioma = "en";
            else Idioma = "es";
            //Configuracion del idioma del sistema
            var culture = new System.Globalization.CultureInfo(Idioma);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abaNumber"></param>
        /// <returns>Bank_Desc,ABA_Number</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Utility.itemABANumber> GetBankABANumber(string abaNumber)
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

            Entity.UnderWriting.Entities.DropDown.Parameter parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(Utility.DropDownType), Utility.DropDownType.BankABANumber),
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
                BlTypeId = BlTypeId,
                BlId = BlId,
                CurrencyId = currencyId,
                AbaNumber = abaNumber,
                AppliedByFreqOrCountry = appliedByFreqOrCountry
            };

            var d = oDropDownManager.GetDropDownByType(parameter);


            var result = new List<Utility.itemABANumber>();

            if (d != null && d.Any())
            {
                result = d.Select(x => new Utility.itemABANumber
                    {
                        AbaNumber = x.AbaNumber,
                        BankDesc = x.BankDesc
                    }).ToList();
            }

            return result;
        }

        /// <summary>
        ///  Motor de Traduccion
        /// </summary>
        /// <param name="key"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetTranslate(string key, string lang)
        {
            var result = string.Empty;
            var msj = string.Empty;
            StringBuilder validationSummary;

            var Lang = lang == "en" ? Utility.Language.en : Utility.Language.es;

            ChangeLanguage(Lang);

            var Message = Utility.deserializeJSON<List<Utility.itemMessage>>(key);

            if (Message.isNullReferenceObject())
                result = Resources.ResourceManager.GetString(key);
            else
            {
                validationSummary = new StringBuilder();
                var BodyMessage = "<strong style='color:red'> * </strong> {0} </br>";
                var Messages = Message.Distinct();

                //Procesar el mensaje de tipo json                
                foreach (var item in Messages)
                {
                    switch (item.ErrorType)
                    {
                        case "Required":
                            msj = string.Format(Resources.ResourceManager.GetString("Required"), item.Field);
                            break;
                        case "InvalidEmail":
                            msj = string.Format(Resources.ResourceManager.GetString("InvalidEmail"), item.Field);
                            break;
                        case "DocExpirationDate":
                            msj = string.Format(Resources.ResourceManager.GetString("DocExpirationDate"), item.Field);
                            break;
                        case "RequiredNumeric":
                            msj = string.Format(Resources.ResourceManager.GetString("RequiredNumeric"), item.Field);
                            break;
                        case "LengthValidation":
                            var dataLenght = item.Length.Split(',');
                            var isRangeLengthValidation = dataLenght.Count() > 0;
                            msj = (isRangeLengthValidation) ? string.Format(Resources.ResourceManager.GetString("validLengthValues"), item.Field, item.Length)
                                                            : string.Format(Resources.ResourceManager.GetString("LengthValidation"), item.Field, item.Length);
                            break;
                        case "InvalidDate":
                            msj = string.Format(Resources.ResourceManager.GetString("InvalidDate"), item.Date, item.Field);
                            break;
                        case "MinimumValidation":
                            msj = string.Format(Resources.ResourceManager.GetString("MinimumValidation"), item.Field, item.MinimumVal);
                            break;
                        case "MaximumValidation":
                            msj = string.Format(Resources.ResourceManager.GetString("MaximumValidation"), item.Field, item.MaximumVal);
                            break;
                        case "FileUploadRequiredMessage":
                            msj = Resources.ResourceManager.GetString("FileUploadRequiredMessage");
                            break;
                        case "validateEqualControlId":
                            msj = string.Format(Resources.ResourceManager.GetString("validateEqualControlId"), item.Field, item.Field2);
                            break;
                        case "QuestionsAnsweredValidation":
                            msj = string.Format(Resources.ResourceManager.GetString("QuestionsAnsweredValidation"), item.Field);
                            break;

                        case "QuestionariesValidation":
                            msj = string.Format(Resources.ResourceManager.GetString("QuestionariesValidation"), item.Field);
                            break;
                        case "VehicleInspectionForm":
                            msj = Resources.ResourceManager.GetString(item.Field);
                            break;
                        case "ComplementaryInformationincomplete":
                            msj = Resources.ResourceManager.GetString("ComplementaryInformationincomplete");
                            break;
                    }

                    validationSummary.Append(string.Format(BodyMessage, msj));
                }

                result = validationSummary.ToString();
            }

            return result;
        }

        /// <summary>
        /// Autocomplete de Occupation Type
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Utility.itemOccupationType> GetOccupationType(string description)
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

            var parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(Utility.DropDownType), Utility.DropDownType.OccupationType),
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
                BlTypeId = BlTypeId,
                BlId = BlId,
                CurrencyId = currencyId,
                AppliedByFreqOrCountry = appliedByFreqOrCountry
            };

            var d = oDropDownManager.GetDropDownByType(parameter).Where(y => y.OccupationGroupDesc.ToUpper().StartsWith(description.ToUpper()));

            var result = new List<Utility.itemOccupationType>();

            if (d != null && d.Any())
            {
                result = d.Select(x => new Utility.itemOccupationType
                {
                    description = x.OccupationGroupDesc,
                    value = x.OccupGroupTypeId.Value
                }).ToList();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Utility.itemOccupation> GetOccupation(string description, string _LanguageId)
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
            int? CompanyId = null;
            int? ProjectId = null;
            int LanguageId = _LanguageId == "en" ? Utility.Language.en.ToInt() : Utility.Language.es.ToInt();
            bool? appliedByFreqOrCountry = null;


            var parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(Utility.DropDownType), Utility.DropDownType.Occupation),
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
                BlTypeId = BlTypeId,
                BlId = BlId,
                CurrencyId = currencyId,
                AppliedByFreqOrCountry = appliedByFreqOrCountry,
                CompanyId = CompanyId,
                ProjectId = ProjectId,
                LanguageId = LanguageId
            };

            var d = oDropDownManager.GetDropDownByType(parameter);

            var result = new List<Utility.itemOccupation>(0);

            if (d != null && d.Any())
            {
                d = d.Where(y => y.OccupationDesc.ToUpper().StartsWith(description.ToUpper()));

                if (d != null && d.Any())
                {
                    result = d.Select(x => new Utility.itemOccupation
                    {
                        description = x.OccupationDesc,
                        value = x.OccupationId.Value,
                        OccupationGroupDesc = x.OccupationGroupDesc,
                        OccupationGroupId = x.OccupGroupTypeId.Value
                    }).ToList();
                }
            }
            return
                result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Utility.TabsCounter> GetCounter(string Parameters)
        {
            var iCounter = Utility.deserializeJSON<Utility.itemCounter>(Parameters);

            var result = oPolicyManager.GetAllCustomerPlanDetailCountQuo(new Policy.QuoGrid.Key
            {
                CorpId = iCounter.CorpId,
                AgentId = iCounter.FilterAgent ? (int?)null : iCounter.AgentId,
                CompanyId = iCounter.CompanyId,
                DateTo = iCounter.DateTo,
                DateFrom = iCounter.DateFrom,
                OfficeId = iCounter.OfficeId,
                BlId = iCounter.BlId,
                Bandeja = iCounter.Bandeja,
                UserId = iCounter.UserId,
                AgentChain = iCounter.FilterAgent ? null : oPolicyManager.GetAgentChain(iCounter.AgentId.HasValue ? iCounter.AgentId.Value : 99999999)
            }).ToList();

            Int64 zero = 0;

            var Counter = new List<Utility.TabsCounter>(0);

            var sIllustrationsToWork = result.FirstOrDefault(c => c.Tab == "IllustrationsToWork");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkIllustrationsToWork.ToString()),
                Count = (sIllustrationsToWork != null) ? sIllustrationsToWork.Count.GetValueOrDefault() : zero
            });

            var sCompleteIllustrations = result.FirstOrDefault(c => c.Tab == "CompleteIllustrations");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkCompleteIllustrations.ToString()),
                Count = (sCompleteIllustrations != null) ? sCompleteIllustrations.Count.GetValueOrDefault() : zero
            });

            var sDeclinedByClient = result.FirstOrDefault(c => c.Tab == "DeclinedByClient");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkDeclinedByClient.ToString()),
                Count = (sDeclinedByClient != null) ? sDeclinedByClient.Count.GetValueOrDefault() : zero
            });

            var sSubscriptions = result.FirstOrDefault(c => c.Tab == "Subscriptions");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkSubscriptions.ToString()),
                Count = (sSubscriptions != null) ? sSubscriptions.Count.GetValueOrDefault() : zero
            });

            var sDiscounts = result.FirstOrDefault(c => c.Tab == "Discounts");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkDiscounts.ToString()),
                Count = (sDiscounts != null) ? sDiscounts.Count.GetValueOrDefault() : zero
            });

            var sDeclinedBySubscription = result.FirstOrDefault(c => c.Tab == "DeclinedBySubscription");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkDeclinedBySubscription.ToString()),
                Count = (sDeclinedBySubscription != null) ? sDeclinedBySubscription.Count.GetValueOrDefault() : zero
            });

            var sMissingInspections = result.FirstOrDefault(c => c.Tab == "MissingInspections");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkMissingInspections.ToString()),
                Count = (sMissingInspections != null) ? sMissingInspections.Count.GetValueOrDefault() : zero
            });

            var sApprovedBySubscription = result.FirstOrDefault(c => c.Tab == "ApprovedBySubscription");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkApprovedBySubscription.ToString()),
                Count = (sApprovedBySubscription != null) ? sApprovedBySubscription.Count.GetValueOrDefault() : zero
            });

            var sHistorical = result.FirstOrDefault(c => c.Tab == "HistoricalIllustrations");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkHistoricalIllustrations.ToString()),
                Count = (sHistorical != null) ? sHistorical.Count.GetValueOrDefault() : zero
            });

            var sIncompleteIllustration = result.FirstOrDefault(c => c.Tab == "IncompleteIllustration");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkIncompleteIllustration.ToString()),
                Count = (sIncompleteIllustration != null) ? sIncompleteIllustration.Count.GetValueOrDefault() : zero
            });

            var sExpired = result.FirstOrDefault(c => c.Tab == "Expired");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkExpired.ToString()),
                Count = (sExpired != null) ? sExpired.Count.GetValueOrDefault() : zero
            });

            var sExpiring = result.FirstOrDefault(c => c.Tab == "Expiring");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkExpiring.ToString()),
                Count = (sExpiring != null) ? sExpiring.Count.GetValueOrDefault() : zero
            });

            var sApprovedByClient = result.FirstOrDefault(c => c.Tab == "ApprovedByClient");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkApprovedByClient.ToString()),
                Count = (sApprovedByClient != null) ? sApprovedByClient.Count.GetValueOrDefault() : zero
            });

            var sMissingDocuments = result.FirstOrDefault(c => c.Tab == "MissingDocuments");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkMissingDocuments.ToString()),
                Count = (sMissingDocuments != null) ? sMissingDocuments.Count.GetValueOrDefault() : zero
            });

            var sPuntoVentaTabCount = result.FirstOrDefault(c => c.Tab == "PointOfSale");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkPuntoVentaTab.ToString()),
                Count = (sPuntoVentaTabCount != null) ? sPuntoVentaTabCount.Count.GetValueOrDefault() : zero
            });

            var sConfirmationCall = result.FirstOrDefault(c => c.Tab == "ConfirmationCall");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkConfirmationCall.ToString()),
                Count = (sConfirmationCall != null) ? sConfirmationCall.Count.GetValueOrDefault() : zero
            });

            var sFacultativo = result.FirstOrDefault(c => c.Tab == "Facultative");
            Counter.Add(new Utility.TabsCounter
            {
                Tab = string.Concat("#", Utility.Tabs.lnkFacultative.ToString()),
                Count = (sFacultativo != null) ? sFacultativo.Count.GetValueOrDefault() : zero
            });

            return
                Counter;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetToolTipMessage(string key, string lang)
        {
            var parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(Utility.DropDownType), Utility.DropDownType.ProjectConfigurationValue),
                CorpId = 1,
                ProjectId = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ProjectIdNewBusiness"])
            };

            var d = oDropDownManager.GetDropDownByType(parameter).FirstOrDefault(y => y.Namekey == key).ConfigurationValue;

            return d;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Utility.itemAgent> GetAgents(string description, string _LanguageId, string pAgentId, int BusinessLineId)
        {
            int? corpId = 1;
            int? regionId = null;
            int? countryId = null;
            int? domesticregId = null;
            int? stateProvId = null;
            int? cityId = null;
            int? officeId = null;
            int? caseSeqNo = null;
            int? histSeqNo = null;
            int? contactId = null;
            int? agentId = int.Parse(pAgentId);
            bool? isInsured = null;
            int? occupGroupTypeId = null;
            int? requirementCategory = null;
            int? requirementType = null;
            int? BlTypeId = null;
            int? BlId = BusinessLineId;
            int? currencyId = null;
            bool? appliedByFreqOrCountry = null;


            var parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(Utility.DropDownType), Utility.DropDownType.AgentCot),
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
                BlTypeId = BlTypeId,
                BlId = BlId,
                CurrencyId = currencyId,
                AppliedByFreqOrCountry = appliedByFreqOrCountry
            };

            var d = oDropDownManager.GetDropDownByType(parameter).Where(y => y.RejectReasonDesc.ToUpper().Contains(description.ToUpper()));

            var result = new List<Utility.itemAgent>();

            if (d != null && d.Any())
            {
                result = d.Select(x => new Utility.itemAgent
                {
                    description = x.RejectReasonDesc,
                    value = x.AgentId.GetValueOrDefault()
                }).ToList();
            }

            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Utility.itemEndorsementBeneficiary> GetEndorsementBenficiary(string description, string _LanguageId)
        {
            int? corpId = 1;
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

            var parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(Utility.DropDownType), Utility.DropDownType.Endorsement),
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
                BlTypeId = BlTypeId,
                BlId = BlId,
                CurrencyId = currencyId,
                AppliedByFreqOrCountry = appliedByFreqOrCountry
            };

            var d = oDropDownManager.GetDropDownByType(parameter).Select(x => new
            {
                Value = Utility.serializeToJSON(new { EndorsementId = x.AgentId, EndorsementNameKey = x.RelationshipDesc, Rnc = x.CityDesc, ContactName = x.GlobalCountryDesc, ContactTel = x.ContactTypeIdDesc, ContactAdress = x.OccupationDesc }),
                Text = x.RoleDesc
            }).
            Where(y => y.Text.ToUpper().Contains(description.ToUpper()));

            var result = new List<Utility.itemEndorsementBeneficiary>();

            if (d != null && d.Any())
            {
                result = d.Select(x => new Utility.itemEndorsementBeneficiary
                {
                    Value = x.Value,
                    Text = x.Text
                }).ToList();
            }

            return
                result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetPercentages(int corpId, string role, string percent)
        {
            List<string> lstDiscount = new List<string>() { };

            var lstDiscountRules = idManager.PolicyManager.GetDiscountRulesAndDetails(new Policy.DParameter
            {
                Active = true,
                CorpId = corpId,
                NameKey = Utility.DiscountRules.SubscriptionDiscountRulesByRoleType.ToString(),
                Role = role
            }).Where(d => d.DetailNameKey.StartsWith(percent) && d.DetailNameKey != "0.00").ToList();

            if (lstDiscountRules != null)
            {
                var ListDiscountRules = lstDiscountRules.Select(o => new DiscountRule
                {
                    DiscountRuleId = o.DiscountRuleId,
                    DiscountRuleDetailId = o.DetailId,
                    DiscountRuleNameKey = o.NameKey,
                    DiscountRuleValue = o.DetailRuleValue,
                    DiscountRuleDetailNameKey = o.DetailNameKey
                }).ToList();

                ListDiscountRules.ForEach(o => lstDiscount.Add(string.Format("{0}|{1}|{2}", o.DiscountRuleDetailNameKey, o.DiscountRuleValue.ToDecimal().ToPercent(false), o.ToJSON())));
            }

            return lstDiscount;
        }

        [WebMethod]
        public void GenerateDocTransunion(string HtmlString, string dataReq)
        {
            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(HtmlString);

            var dataRequirement = Utility.deserializeJSON<Utility.ItemRequirement>(dataReq);

            //Hacer el proceso de insercion del documento en la base de datos
            try
            {
                var pRequirementCatId = dataRequirement.RequirementCatId;
                var pRequirementTypeId = dataRequirement.RequirementTypeId;
                var pRequirementId = dataRequirement.RequirementId;

                if (pRequirementId <= 0)
                {
                    pRequirementId = dataRequirement.SelectedInsuredVehicleId <= 0 ? 1 : dataRequirement.SelectedInsuredVehicleId;

                    var parameter = new Requirement()
                    {
                        CorpId = dataRequirement.CorpId,
                        RegionId = dataRequirement.RegionId,
                        CountryId = dataRequirement.CountryId,
                        DomesticregId = dataRequirement.DomesticregId,
                        StateProvId = dataRequirement.StateProvId,
                        CityId = dataRequirement.CityId,
                        OfficeId = dataRequirement.OfficeId,
                        CaseSeqNo = dataRequirement.CaseSeqNo,
                        HistSeqNo = dataRequirement.HistSeqNo,
                        ContactId = dataRequirement.ContactId,
                        RequirementCatId = pRequirementCatId,
                        RequirementTypeId = pRequirementTypeId,
                        RequirementId = pRequirementId,
                        RequestedBy = 1,
                        ReceivedDate = DateTime.Now,
                        RequestedDate = DateTime.Now,
                        IsManual = false,
                        SendToReinsurance = false,
                        Comment = null,
                        UserId = dataRequirement.userId
                    };

                    oRequirementManager.Update(parameter);
                }


                oRequirementManager.InsertDocument(new Requirement.Document
                {
                    CorpId = dataRequirement.CorpId,
                    RegionId = dataRequirement.RegionId,
                    CountryId = dataRequirement.CountryId,
                    DomesticregId = dataRequirement.DomesticregId,
                    StateProvId = dataRequirement.StateProvId,
                    CityId = dataRequirement.CityId,
                    OfficeId = dataRequirement.OfficeId,
                    CaseSeqNo = dataRequirement.CaseSeqNo,
                    HistSeqNo = dataRequirement.HistSeqNo,
                    ContactId = dataRequirement.ContactId,
                    RequirementCatId = pRequirementCatId,
                    RequirementTypeId = pRequirementTypeId,
                    RequirementId = pRequirementId,
                    DocumentStatusId = 1, //Accepted
                    DocumentBinary = pdfBytes,
                    DocumentName = "Documentodevalidacioncrediticia.pdf",
                    UserId = dataRequirement.userId
                });
            }
            catch (Exception ex)
            {

            }
            //Utility.MyByteArrayToFile(Server.MapPath("~/TempFiles/00114188618.pdf"), pdfBytes);
        }
    }
}
