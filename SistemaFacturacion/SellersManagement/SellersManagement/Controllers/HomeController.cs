using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellersManagement.Models;
using SellersManagement.Entities;
using Newtonsoft.Json;
using SellersManagement.CustomCode;
using SellersManagement.Models.ViewModels;
using System.Globalization;

namespace SellersManagement.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var usuario = GetCurrentUsuario();

            ViewBag.SupervisorName = "N/A";
            ViewBag.SupervisorCode = "N/A";
            ViewBag.SupervisorOffices = "N/A";
            ViewBag.SupervisorChannel = "N/A";

            if (usuario != null && (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant || usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent))
            {
                ViewBag.SupervisorName = usuario.FullName;
                ViewBag.SupervisorCode = usuario.AgentCode.TrimStart().TrimEnd();
                ViewBag.SupervisorOffices = usuario.AgentOffices.FirstOrDefault().OfficeDesc;
                ViewBag.SupervisorChannel = usuario.AgentsChannel.Channel_Desc;
            }
            else if (usuario != null)
            {
                ViewBag.SupervisorName = usuario.FullName;
            }

            return View();
        }

        public ActionResult _SellerManagementTable(string allData = "")
        {
            var usuario = GetCurrentUsuario();

            int bl = 2;

            List<AgentInfomation> ainfoModel = GetSupervisorAgentChain(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl, usuario.AgentCode, allData);

            Session["AgentInfoSession"] = ainfoModel;

            ViewBag.SellerCodes = new SelectList(ainfoModel.Select(x => x.AgentCode).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerNames = new SelectList(ainfoModel.Select(x => x.FullName).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.SellerChannels = new SelectList(ainfoModel.Select(x => x.AgentChannel).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerOffices = new SelectList(ainfoModel.Select(x => x.AgentOffices).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.SellerTypeManagement = new SelectList(ainfoModel.Select(x => x.TypeManagement).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerResultManagement = new SelectList(ainfoModel.Select(x => x.ResultManagement).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.SellerComment = new SelectList(ainfoModel.Select(x => x.Comment).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerSuggestedImprovement = new SelectList(ainfoModel.Select(x => x.SuggestedImprovement).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerDate = new SelectList(ainfoModel.Select(x => x.ManagementDate).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.Phones = new SelectList(ainfoModel.Select(x => x.Phones).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.Supervisors = new SelectList(ainfoModel.Select(x => x.Supervisor).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            return PartialView(ainfoModel);
        }

        public ActionResult _PartialManagementGrid(string allData = "", string paramFiltersJson = "", int page = 1)
        {
            var usuario = GetCurrentUsuario();
            int bl = 2;
            var model = GetManagementGridData(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl, usuario.AgentCode, allData, paramFiltersJson, page);

            return PartialView(model);
        }

        private List<AgentInfomation> GetSupervisorAgentChain(int? CorpId, int? AgentId, string NameId, int BlId, string AgentCode = "", string allData = "")
        {
            List<AgentInfomation> ainfo = new List<AgentInfomation>();
            List<string> agentsCodes = new List<string>();



            var _isExecutivesATLRol = isExecutivesATLRol();
            var Allagentinfo = oManagementManager.GetDataAgentAndManagement(new AgentData.parameters() { NameId = NameId, BL = BlId, isExecutiveRol = _isExecutivesATLRol });

            //var Allagentinfo = oManagementManager.GetDataAgent(new AgentData.parameters() { NameId = NameId, BL = BlId, isExecutiveRol = _isExecutivesATLRol });

            var MANAGEMENT_TYPES = oDropDownManager.GetDropDown("MANAGEMENT_TYPES").ToList();
            var MANAGEMENT_RESULTS = oDropDownManager.GetDropDown("MANAGEMENT_RESULTS").ToList();

            if (!_isExecutivesATLRol && !string.IsNullOrEmpty(NameId))
            {
                Allagentinfo = Allagentinfo.Where(x => x.ShowToSupervisor.GetValueOrDefault()).ToList();
            }


            if (allData == "")
            {
                ainfo = (from agentinfo in Allagentinfo
                         select new AgentInfomation
                         {
                             SellerManagementId = agentinfo.Management_Id.GetValueOrDefault(),
                             AgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToString() : "0",
                             FullName = agentinfo.FullName,
                             AgentChannel = agentinfo.Channel,
                             AgentOffices = agentinfo.Office,
                             Phones = agentinfo.Phones,
                             Comment = agentinfo.Comment.shrinkText(),
                             ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name : "N/A",// oDropDownManager.GetManagementResults(agentinfo.ManagementResultsIdSelected),
                             SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                             TypeManagement = agentinfo.ManagementTypeIdSelected.HasValue ? MANAGEMENT_TYPES.Where(a => a.value == agentinfo.ManagementTypeIdSelected.Value.ToString()).FirstOrDefault().name : "N/A",//oDropDownManager.GetManagementType(agentinfo.ManagementTypeIdSelected);
                             ManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value.ToString("dd-MMM-yyyy") : "",
                             GroupByManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value : (DateTime?)null,
                             SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                             Supervisor = string.Concat(agentinfo.SupervisorName, "(", agentinfo.SupervisorAgentCode, ")"),
                             DataJson = JsonConvert.SerializeObject(agentinfo),
                             showDetailManagement = agentinfo.Management_Id.HasValue
                         }
                    ).ToList();

            }
            else if (allData == "SI")
            {
                ainfo = (from agentinfo in Allagentinfo
                         select new AgentInfomation
                         {
                             SellerManagementId = agentinfo.Management_Id,
                             AgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToString() : "0",
                             FullName = agentinfo.FullName,
                             AgentChannel = agentinfo.Channel,
                             AgentOffices = agentinfo.Office,
                             Phones = agentinfo.Phones,
                             Comment = agentinfo.Comment.shrinkText(),
                             ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name : "N/A",// oDropDownManager.GetManagementResults(agentinfo.ManagementResultsIdSelected),
                             SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                             TypeManagement = agentinfo.ManagementTypeIdSelected.HasValue ? MANAGEMENT_TYPES.Where(a => a.value == agentinfo.ManagementTypeIdSelected.Value.ToString()).FirstOrDefault().name : "N/A",//oDropDownManager.GetManagementType(agentinfo.ManagementTypeIdSelected);
                             ManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value.ToString("dd-MMM-yyyy") : "",
                             GroupByManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value : (DateTime?)null,
                             SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                             Supervisor = string.Concat(agentinfo.SupervisorName, "(", agentinfo.SupervisorAgentCode, ")"),
                             DataJson = JsonConvert.SerializeObject(agentinfo),
                             showDetailManagement = agentinfo.Management_Id.HasValue
                         }
                   ).Where(a => a.SellerManagementId.HasValue).ToList();
            }
            else
            {
                ainfo = (from agentinfo in Allagentinfo
                         select new AgentInfomation
                         {
                             SellerManagementId = agentinfo.Management_Id,
                             AgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToString() : "0",
                             FullName = agentinfo.FullName,
                             AgentChannel = agentinfo.Channel,
                             AgentOffices = agentinfo.Office,
                             Phones = agentinfo.Phones,
                             Comment = agentinfo.Comment.shrinkText(),
                             ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name : "N/A",// oDropDownManager.GetManagementResults(agentinfo.ManagementResultsIdSelected),
                             SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                             TypeManagement = "N/A",
                             ManagementDate = "",
                             GroupByManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value : (DateTime?)null,
                             SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                             Supervisor = string.Concat(agentinfo.SupervisorName, "(", agentinfo.SupervisorAgentCode, ")"),
                             DataJson = JsonConvert.SerializeObject(agentinfo),
                             showDetailManagement = false
                         }
                ).Where(a => a.SellerManagementId.HasValue == false).ToList();
            }
            /*
            if (Allagentinfo.Count() > 0)
            {
                foreach (var agentinfo in Allagentinfo)
                {
                    fullName = agentinfo.FullName;

                    chainAgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToInt() : 0;

                    //var allManagement = oManagementManager.GetManagement(new ManagementData.parameters()
                    //{
                    //    managementSupervisorCode = AgentCode.ToIntNullable(),
                    //    managementSellerCode = chainAgentCode
                    //}).ToList();

                    //if (!_isExecutivesATLRol && !string.IsNullOrEmpty(NameId))
                    //{
                    //    allManagement= allManagement.Where(x => x.ShowToSupervisor.GetValueOrDefault()).ToList();
                    //}

                    // if (allManagement.Count() > 0 && (allData == "SI" || allData == ""))
                    if (agentinfo.Management_Id.HasValue && (allData == "SI" || allData == ""))
                    {
                        //foreach (var am in allManagement)
                        //{
                        var ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name :"N/A";// oDropDownManager.GetManagementResults(agentinfo.ManagementResultsIdSelected);
                        var TypeManagement = agentinfo.ManagementTypeIdSelected.HasValue ? MANAGEMENT_TYPES.Where(a => a.value == agentinfo.ManagementTypeIdSelected.Value.ToString()).FirstOrDefault().name : "N/A"; ;//oDropDownManager.GetManagementType(agentinfo.ManagementTypeIdSelected);
                        var newRow = new AgentInfomation()
                        {
                            SellerManagementId = agentinfo.Management_Id.Value,
                            AgentCode = chainAgentCode.ToString(),
                            FullName = fullName,
                            AgentChannel = agentinfo.Channel,
                            AgentOffices = agentinfo.Office,
                            Phones = agentinfo.Phones,
                            Comment = agentinfo.Comment.shrinkText(),
                            ResultManagement = ResultManagement,
                            SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                            TypeManagement = TypeManagement,
                            ManagementDate = agentinfo.Management_Date.Value.ToString("dd-MMM-yyyy"),
                            GroupByManagementDate =  agentinfo.Management_Date.Value,
                            SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                            Supervisor = string.Concat(agentinfo.SupervisorName, "(", agentinfo.SupervisorAgentCode, ")"),
                            //DataJson = JsonConvert.SerializeObject(agentinfo)
                            showDetailManagement = true
                        };
                        newRow.DataJson = JsonConvert.SerializeObject(newRow);
                        ainfo.Add(newRow);

                        agentsCodes.Add(chainAgentCode.ToString());
                        //}
                    }
                    else if (allData != "SI" && agentinfo.Management_Id.HasValue)
                    {
                        continue;
                    }
                    else if (allData != "SI")
                    {
                        var newRow = new AgentInfomation()
                        {
                            AgentCode = chainAgentCode.ToString(),
                            FullName = fullName,
                            AgentChannel = agentinfo.Channel,
                            AgentOffices = agentinfo.Office,
                            Phones = agentinfo.Phones,
                            Comment = "",
                            ResultManagement = "N/A",
                            TypeManagement = "N/A",
                            ManagementDate = "",
                            Supervisor = string.Concat(agentinfo.SupervisorName, "(", agentinfo.SupervisorAgentCode, ")"),
                            SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                            showDetailManagement = false
                        };
                        newRow.DataJson = JsonConvert.SerializeObject(newRow);
                        ainfo.Add(newRow);
                        agentsCodes.Add(chainAgentCode.ToString());
                    }
                }
            }*/

            //Proceso para los Prospectos regitrados         
            #region prospecto
            /*if ((allData == "SI" || allData == ""))
            {
                var allManagement_Prospects = oManagementManager.GetManagement(new ManagementData.parameters()
                {
                    managementSupervisorCode = AgentCode.ToIntNullable()

                }).Where(x => !agentsCodes.Contains(x.ManagementSellerCode.ToString())).ToList();


                if (allManagement_Prospects.Count() > 0)
                {
                    foreach (var am in allManagement_Prospects)
                    {
                        var prospectInfo = oManagementManager.GetDataProspect(new ProspectData.parameters() { ProspectCode = am.ManagementSellerCode.ToString() });

                        if (prospectInfo.Count() > 0)
                        {
                            var ResultManagement = oDropDownManager.GetManagementResults(am.ManagementResultsIdSelected);
                            var TypeManagement = oDropDownManager.GetManagementType(am.ManagementTypeIdSelected);
                            bool entro = false;
                            string supervisorData = "";

                            if (isExecutivesATLRol())
                            {
                                var SupervisorInfo = oManagementManager.GetDataAgent(new AgentData.parameters() { AgentCode = am.ManagementSupervisorCode.ToString(), BL = 2 });
                                if (SupervisorInfo.Count() > 0)
                                {

                                    supervisorData = string.Concat(SupervisorInfo.FirstOrDefault().FullName, " (", SupervisorInfo.FirstOrDefault().AgentCode, ")");
                                    entro = true;
                                }
                            }

                            if (!entro)
                            {
                                if (!string.IsNullOrEmpty(NameId))
                                {
                                    var userinfo = getAgenteUserInfo(NameId);

                                    if (userinfo != null)
                                    {
                                        supervisorData = string.Concat(userinfo.FullName, " (", userinfo.AgentCode, ")");
                                    }
                                }
                                else
                                {
                                    var CurrentUser = GetCurrentUsuario();
                                    supervisorData = CurrentUser != null ? CurrentUser.FullName : "N/A";
                                }
                            }
                            var newRow = new AgentInfomation()
                            {
                                SellerManagementId = am.ManagementId,
                                AgentCode = am.ManagementSellerCode.ToString(),
                                FullName = prospectInfo.FirstOrDefault().ProspectFullName,
                                AgentChannel = !string.IsNullOrEmpty(prospectInfo.FirstOrDefault().ProspectChannel) ? prospectInfo.FirstOrDefault().ProspectChannel : "N/A",
                                AgentOffices = !string.IsNullOrEmpty(prospectInfo.FirstOrDefault().ProspectOffices) ? prospectInfo.FirstOrDefault().ProspectOffices : "N/A",
                                Phones = !string.IsNullOrEmpty(prospectInfo.FirstOrDefault().ProspectPhones) ? prospectInfo.FirstOrDefault().ProspectPhones : "N/A",
                                Comment = am.Comment.shrinkText(),
                                ResultManagement = ResultManagement.FirstOrDefault().name,
                                SuggestedImprovement = am.SuggestedImprovement.shrinkText(),
                                TypeManagement = TypeManagement.FirstOrDefault().name,
                                ManagementDate = am.ManagementDate.ToString("dd-MMM-yyyy"),
                                GroupByManagementDate = am.ManagementDate,
                                Supervisor = supervisorData,
                                showDetailManagement = true,
                                SupervisorAgentCode = am.ManagementSupervisorCode.ToString()
                            };
                            newRow.DataJson = JsonConvert.SerializeObject(newRow);
                            ainfo.Add(newRow);
                        }
                    }
                }
            }*/
            //
            #endregion


            //for (var i = 0; i <= ainfo.Count - 1; i++)
            //{
            //    ainfo[i].DataJson = JsonConvert.SerializeObject(ainfo[i]);
            //}
            return ainfo.OrderByDescending(x => x.GroupByManagementDate).ToList();
        }

        public JsonResult getAgentInfo2(string agentCode)
        {
            AgentInfomation ainfor = new AgentInfomation();
            bool success = false;
            string message = "";

            var ainfo = oManagementManager.GetDataAgent(new AgentData.parameters() { AgentCode = agentCode, BL = 2 });

            if (ainfo != null)
            {
                //Valido que el agente introducido este en mi cadena
                var usuario = GetCurrentUsuario();

                List<AgentInfomation> ainfoModel = (List<AgentInfomation>)Session["AgentInfoSession"];

                if (ainfoModel.FirstOrDefault(x => x.AgentCode == agentCode.Trim()) == null)
                {
                    return Json(new { data = ainfor, success = false, message = "El Código introducido no pertenece a su cadena." }, JsonRequestBehavior.AllowGet);
                }
                //           

                string phones = ainfo.FirstOrDefault() != null ? ainfo.FirstOrDefault().Phones : "";

                ainfor.FullName = ainfo.FirstOrDefault().FullName;
                ainfor.AgentChannel = ainfo.FirstOrDefault().Channel;
                ainfor.AgentOffices = ainfo.FirstOrDefault().Office;
                ainfor.Phones = phones;

                success = true;
            }

            return Json(new { data = ainfor, success = success, message = message }, JsonRequestBehavior.AllowGet);
        }

        private ManagementGridViewModel GetManagementGridData(int? CorpId, int? AgentId, string NameId, int BlId, string AgentCode = "", string allData = "", string paramFiltersJson = "", int page = 1)
        {
            var result = new ManagementGridViewModel();
            IEnumerable<AgentInfomation> ainfo;
            List<string> agentsCodes = new List<string>();



            var _isExecutivesATLRol = isExecutivesATLRol();
            var Allagentinfo = oManagementManager.GetDataAgentAndManagement(new AgentData.parameters() { NameId = NameId, BL = BlId, isExecutiveRol = _isExecutivesATLRol });

            //var Allagentinfo = oManagementManager.GetDataAgent(new AgentData.parameters() { NameId = NameId, BL = BlId, isExecutiveRol = _isExecutivesATLRol });

            var MANAGEMENT_TYPES = oDropDownManager.GetDropDown("MANAGEMENT_TYPES").ToList();
            var MANAGEMENT_RESULTS = oDropDownManager.GetDropDown("MANAGEMENT_RESULTS").ToList();

            if (!_isExecutivesATLRol && !string.IsNullOrEmpty(NameId))
            {
                Allagentinfo = Allagentinfo.Where(x => x.ShowToSupervisor.GetValueOrDefault()).ToList();
            }


            if (string.IsNullOrEmpty(allData))
            {
                ainfo = Allagentinfo.Select(agentinfo => new AgentInfomation
                {
                    SellerManagementId = agentinfo.Management_Id.GetValueOrDefault(),
                    AgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToString() : "0",
                    FullName = ConvertValueToUpper(agentinfo.FullName),
                    AgentChannel = ConvertValueToUpper(agentinfo.Channel),
                    AgentOffices = ConvertValueToUpper(agentinfo.Office),
                    Phones = ConvertValueToUpper(agentinfo.Phones),
                    Comment = agentinfo.Comment.shrinkText(),
                    ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? ConvertValueToUpper(MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name) : "N/A",
                    SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                    TypeManagement = agentinfo.ManagementTypeIdSelected.HasValue ? ConvertValueToUpper(MANAGEMENT_TYPES.Where(a => a.value == agentinfo.ManagementTypeIdSelected.Value.ToString()).FirstOrDefault().name) : "N/A",
                    ManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value.ToString("dd-MMM-yyyy") : "",
                    GroupByManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value : (DateTime?)null,
                    SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                    Supervisor = GetFullNameAndCode(agentinfo.SupervisorName,agentinfo.SupervisorAgentCode),
                    DataJson = JsonConvert.SerializeObject(agentinfo),
                    showDetailManagement = agentinfo.Management_Id.HasValue
                }).ToList();

            }
            else if (allData == "SI")
            {
                ainfo = Allagentinfo.Select(agentinfo => new AgentInfomation
                {
                    SellerManagementId = agentinfo.Management_Id,
                    AgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToString() : "0",
                    FullName = ConvertValueToUpper(agentinfo.FullName),
                    AgentChannel = ConvertValueToUpper(agentinfo.Channel),
                    AgentOffices = ConvertValueToUpper(agentinfo.Office),
                    Phones = ConvertValueToUpper(agentinfo.Phones),
                    Comment = agentinfo.Comment.shrinkText(),
                    ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? ConvertValueToUpper(MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name) : "N/A",
                    SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                    TypeManagement = agentinfo.ManagementTypeIdSelected.HasValue ? ConvertValueToUpper(MANAGEMENT_TYPES.Where(a => a.value == agentinfo.ManagementTypeIdSelected.Value.ToString()).FirstOrDefault().name) : "N/A",
                    ManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value.ToString("dd-MMM-yyyy") : "",
                    GroupByManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value : (DateTime?)null,
                    SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                    Supervisor = GetFullNameAndCode(agentinfo.SupervisorName, agentinfo.SupervisorAgentCode),
                    DataJson = JsonConvert.SerializeObject(agentinfo),
                    showDetailManagement = agentinfo.Management_Id.HasValue
                }).Where(a => a.SellerManagementId.HasValue).ToList();
            }
            else
            {
                ainfo = Allagentinfo.Select(agentinfo => new AgentInfomation
                {
                    SellerManagementId = agentinfo.Management_Id,
                    AgentCode = !string.IsNullOrEmpty(agentinfo.AgentCode.TrimStart().TrimEnd()) ? agentinfo.AgentCode.TrimStart().TrimEnd().ToString() : "0",
                    FullName = ConvertValueToUpper(agentinfo.FullName),
                    AgentChannel = ConvertValueToUpper(agentinfo.Channel),
                    AgentOffices = ConvertValueToUpper(agentinfo.Office),
                    Phones = ConvertValueToUpper(agentinfo.Phones),
                    Comment = ConvertValueToUpper(agentinfo.Comment.shrinkText()),
                    ResultManagement = agentinfo.ManagementResultsIdSelected.HasValue ? ConvertValueToUpper(MANAGEMENT_RESULTS.Where(a => a.value == agentinfo.ManagementResultsIdSelected.Value.ToString()).FirstOrDefault().name) : "N/A",
                    SuggestedImprovement = agentinfo.Suggested_Improvement.shrinkText(),
                    TypeManagement = "N/A",
                    ManagementDate = "",
                    GroupByManagementDate = agentinfo.Management_Date.HasValue ? agentinfo.Management_Date.Value : (DateTime?)null,
                    SupervisorAgentCode = agentinfo.SupervisorAgentCode,
                    Supervisor = GetFullNameAndCode(agentinfo.SupervisorName,agentinfo.SupervisorAgentCode),
                    DataJson = JsonConvert.SerializeObject(agentinfo),
                    showDetailManagement = false
                }).Where(a => a.SellerManagementId.HasValue == false).ToList();
            }

            
            if (!string.IsNullOrEmpty(paramFiltersJson))
                ainfo = FilterData(ainfo, paramFiltersJson);
            
           
            result.Managements = ainfo.OrderByDescending(x => x.GroupByManagementDate).ToList();

            #region Configurando las columnas de los filtros
            var Columns = new List<dynamic>
                    {
                        new {
                            FieldDescription = "Código",
                            FieldTableName = "AgentCode",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Vendedor",
                            FieldTableName = "FullName",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Canal",
                            FieldTableName = "AgentChannel",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Oficina",
                            FieldTableName = "AgentOffices",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Teléfono(s)",
                            FieldTableName = "Phones",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Supervisor",
                            FieldTableName = "Supervisor",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Fecha",
                            FieldTableName = "ManagementDate",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Tipo",
                            FieldTableName = "TypeManagement",
                            IsNumber = false
                        },
                        new {
                            FieldDescription = "Resultado",
                            FieldTableName = "ResultManagement",
                            IsNumber = false
                        }
                    };

            result.ColumnsNameJson = JsonConvert.SerializeObject(Columns);
            #endregion

            result.CurrentPage = page;
            result.LastPage = base.GetLastPage(result.Managements.Count(), 10);
            return result;
        }

        public string GetFullNameAndCode(string name, string code)
        {
            var result = "";
            if (!string.IsNullOrEmpty(name))
                result = ConvertValueToUpper(string.Concat(name, "(", code, ")"));

                return result;
        }

        public string ConvertValueToUpper(string value)
        {
            var result = "";
            if (!string.IsNullOrEmpty(value))
                result = value.ToUpper();

            return result;
        }

        /// <summary>
        /// Proceso de filtado para los grids
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Data"></param>
        /// <param name="paramFiltersJson"></param>
        /// <returns></returns>
        protected IEnumerable<T> FilterData<T>(IEnumerable<T> Data, string paramFiltersJson) where T : class
        {
            var result = Data;

            var strFilter = string.Empty;
            var filterList = new List<string>(0);
            var paramValues = new List<object>(0);
            var cCount = 0;

            if (!string.IsNullOrEmpty(paramFiltersJson))
            {
                var FiltersParamsConfig = Utility.deserializeJSON<IEnumerable<BaseViewModel.ItemAdditionalFilters>>(paramFiltersJson);
                if (FiltersParamsConfig.Any())
                {
                    FiltersParamsConfig = FiltersParamsConfig.Where(x => !string.IsNullOrEmpty(x.Value)).ToList();

                    if (FiltersParamsConfig.Any())
                    {
                        FiltersParamsConfig.ToList().ForEach(g =>
                        {
                            g.Value = g.Value.ToUpper(CultureInfo.InvariantCulture);
                        });

                        foreach (var item in FiltersParamsConfig)
                        {
                            var filter = item.IsNumber ? string.Format("{0} = @{1}", item.Key, cCount) : string.Format("{0}", item.Key + ".Contains(@" + cCount + ")");
                            paramValues.Add((item.IsNumber ? (object)decimal.Parse(item.Value) : item.Value.ToUpper()));
                            filterList.Add(filter);
                            cCount++;
                        }
                    }
                }
            }

            if (filterList.Any())
            {
                strFilter = string.Join(" AND ", filterList.ToArray());
                result = Data.AsQueryable().Where(strFilter, paramValues.ToArray()).ToList();
            }

            return
                result;
        }
    }
}