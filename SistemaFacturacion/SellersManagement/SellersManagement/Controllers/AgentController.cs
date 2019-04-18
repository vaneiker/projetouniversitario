using SellersManagement.Entities;
using SellersManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellersManagement.CustomCode;

namespace SellersManagement.Controllers
{
    public class AgentController : BaseController
    {
        // GET: Agent
        public ActionResult AddNewAgentInfo(string a = "", string newProspect = "N", string b="")
        {
            if (newProspect == "S")
            {
                a = Utility.generateRandomSellerCode().ToString();
                var exist = validateNoExistProspectCode(a);
                while (exist)
                {
                    a = Utility.generateRandomSellerCode().ToString();
                    exist = validateNoExistProspectCode(a);
                }

                createCookie();
            }


            var list = oDropDownManager.GetManagementType(null);

            var result = from l in list
                         select new
                         {
                             id = l.value,
                             name = l.name
                         };

            var Mlist = oDropDownManager.GetManagementResults(null);

            var resultList = from l in Mlist
                             select new
                             {
                                 id = l.value,
                                 name = l.name
                             };
            if (!string.IsNullOrEmpty(a))
            {
                var FullAgentData = GetAgentData(a);
                if (FullAgentData != null)
                {
                    ViewBag.AgentCode = a;
                    ViewBag.AgentName = FullAgentData.FullName;
                    ViewBag.AgentChannel = FullAgentData.AgentChannel;
                    ViewBag.AgentOffice = FullAgentData.AgentOffices;
                    ViewBag.AgentPhone = FullAgentData.Phones;
                }
            }

            ViewBag.ActivitiTypes = new SelectList(result.ToList().Select(i => new SelectListItem { Text = i.name.ToString(), Value = i.id.ToString() }), "Value", "Text");
            ViewBag.Results = new SelectList(resultList.ToList().Select(i => new SelectListItem { Text = i.name.ToString(), Value = i.id.ToString() }), "Value", "Text");

            ViewBag.showCheckSuper = isExecutivesATLRol();
            ViewBag.showStatistic = (newProspect == "N");
            ViewBag.isAProspect = (newProspect == "S");
            @ViewBag.SupervisorCode = !string.IsNullOrEmpty(b) ? b : "";
            return View();
        }

        public JsonResult setManagement(string agentCode, int AgenTypeManagement, int AgenResultManagement, string CommentManagement, string SuggestedImprovementManagement,
            string supervisorCode,
            bool allowShowGestion,
            string isAProspect = "",
            string AgentName = "",
            string AgentChannel = "",
            string AgentOffice = "",
            string AgentPhone = ""
            )
        {
            bool success = false;
            string message = "";

            var usuario = GetCurrentUsuario();

            if (usuario != null)
            {
                var parame = new ManagementData.parameters();

                int _managementSupervisorCode = !string.IsNullOrEmpty(usuario.AgentCode) ? usuario.AgentCode.TrimStart().TrimEnd().ToInt() : 0;

                if (!isExecutivesATLRol())
                {
                    //parame.ManagedBy = !string.IsNullOrEmpty(supervisorCode)? supervisorCode.ToInt(): (int?)null;
                    parame.ManagedBy = _managementSupervisorCode;
                }
                else
                {
                    parame.ManagedBy = usuario.UserID;
                    _managementSupervisorCode = (supervisorCode.ToInt() <= 0 ? _managementSupervisorCode : supervisorCode.ToInt()) <= 0? usuario.UserID:0 ;
                }

                

                parame.managementId = null;
                parame.managementSupervisorCode = supervisorCode.ToInt() <= 0? _managementSupervisorCode: supervisorCode.ToInt();
                parame.managementSellerCode = Convert.ToInt32(agentCode);
                parame.managementTypeId = AgenTypeManagement;
                parame.managementResultsId = AgenResultManagement;
                parame.comment = CommentManagement;
                parame.suggestedImprovement = SuggestedImprovementManagement;
                parame.createUserId = usuario.UserID;
                parame.ShowToSupervisor = allowShowGestion;
                oManagementManager.SetManagement(parame);
                success = true;

                //Insertando Prospecto si aplica
                if (isAProspect == "true")
                {
                    try
                    {
                        ProspectData.parameters pparame = new ProspectData.parameters();
                        pparame.Id = null;
                        pparame.ProspectCode = agentCode;
                        pparame.ProspectChannel = AgentChannel;
                        pparame.ProspectFullName = AgentName;
                        pparame.ProspectOffices = AgentOffice;
                        pparame.ProspectPhones = AgentPhone;
                        pparame.CreateUserId = usuario.UserID;

                        oManagementManager.SetDataProspect(pparame);
                    }
                    catch (Exception ex)
                    {
                        return Json(new { data = "", success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                //

                message = "Datos guardados correctamente.";
            }

            return Json(new { data = "", success = success, message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListSellerTypeManagement()
        {
            var list = oDropDownManager.GetManagementType(null);

            var result = from l in list
                         select new
                         {
                             id = l.value,
                             name = l.name
                         };

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListSellerResultsManagement()
        {
            var list = oDropDownManager.GetManagementResults(null);

            var result = from l in list
                         select new
                         {
                             id = l.value,
                             name = l.name
                         };

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public AgentInfomation GetAgentData(string agentCode)
        {
            AgentInfomation ainfor = new AgentInfomation();

            var ainfo = oManagementManager.GetDataAgent(new AgentData.parameters() { AgentCode = agentCode, BL = 2 });

            if (ainfo.Count() > 0 && !string.IsNullOrEmpty(ainfo.FirstOrDefault().FullName))
            {
                string phones = ainfo.FirstOrDefault() != null ? ainfo.FirstOrDefault().Phones : "";

                ainfor.FullName = ainfo.FirstOrDefault().FullName;
                ainfor.AgentChannel = ainfo.FirstOrDefault().Channel;
                ainfor.AgentOffices = ainfo.FirstOrDefault().Office;
                ainfor.Phones = phones;
                ainfor.SupervisorAgentCode = ainfo.FirstOrDefault().SupervisorAgentCode;
            }
            else
            {
                //verifico si es un prospecto
                var pros = oManagementManager.GetDataProspect(new ProspectData.parameters() { ProspectCode = agentCode });
                if (pros.Count() > 0)
                {
                    ainfor.FullName = pros.FirstOrDefault().ProspectFullName;
                    ainfor.AgentChannel = pros.FirstOrDefault().ProspectChannel;
                    ainfor.AgentOffices = pros.FirstOrDefault().ProspectOffices;
                    ainfor.Phones = pros.FirstOrDefault().ProspectPhones;
                }
                //
            }
            return ainfor;
        }

        public ActionResult AgentInfoDetail(int smID = 0)
        {
            var managementData = oManagementManager.GetManagement(new ManagementData.parameters() { managementId = smID });
            AgentInfomation model = new AgentInfomation();

            if (managementData.Count() > 0)
            {
                var objData = managementData.FirstOrDefault();

                var adata = GetAgentData(objData.ManagementSellerCode.ToString());

                model.FullName = adata.FullName;
                model.AgentChannel = adata.AgentChannel;
                model.AgentOffices = adata.AgentOffices;
                model.Phones = adata.Phones;

                model.AgentCode = objData.ManagementSellerCode.ToString();
                model.TypeManagement = oDropDownManager.GetManagementType(objData.ManagementTypeIdSelected).FirstOrDefault().name;
                model.ResultManagement = oDropDownManager.GetManagementResults(objData.ManagementResultsIdSelected).FirstOrDefault().name;
                model.Comment = objData.Comment;
                model.SuggestedImprovement = objData.SuggestedImprovement;
            }

            createCookie();

            return View(model);
        }

        private bool validateNoExistProspectCode(string prospectcode)
        {
            var exist = oManagementManager.GetDataProspect(new ProspectData.parameters() { ProspectCode = prospectcode });
            if (exist.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public JsonResult getAgentStatistic(Nullable<int> agentCode)
        {
            try
            {
                var userLogged = GetCurrentUsuario();
                var StatisticData = oManagementManager.GetAgentStatisticData(agentCode, agentCode != null? "": userLogged.AgentNameId);
                
                return Json(new { data = StatisticData, success = true, message = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult getStatisticHeader()
        {
            try
            {
                var StatisticHeader = oManagementManager.GetStatisticHeader();
                var YearsTmp = StatisticHeader.Select(x => new Generic
                {
                    value = x.value
                }).OrderByDescending(d => d.value.ToInt()).ToList();

                var Years = YearsTmp.Select(x => x.value.ToInt()).Distinct().ToList();
                                
                return Json(new { data = StatisticHeader, years= Years, success = true, message = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "", success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}