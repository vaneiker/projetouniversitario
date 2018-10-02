using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellersManagement.Models;
using SellersManagement.Entities;

namespace SellersManagement.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var usuario = GetCurrentUsuario();

            int bl = 2;

            List<AgentInfomation> ainfoModel = GetSupervisorAgentChain(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl, usuario.AgentCode);

            Session["AgentInfoSession"] = ainfoModel;

            ViewBag.SupervisorName = "N/A";
            ViewBag.SupervisorCode = "N/A";
            ViewBag.SupervisorOffices = "N/A";
            ViewBag.SupervisorChannel = "N/A";

            ViewBag.SellerCodes = new SelectList(ainfoModel.Select(x => x.AgentCode).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerNames = new SelectList(ainfoModel.Select(x => x.FullName).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.SellerChannels = new SelectList(ainfoModel.Select(x => x.AgentChannel).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerOffices = new SelectList(ainfoModel.Select(x => x.AgentOffices).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            //var t = oDropDownManager.GetManagementType(null);
            //ViewBag.SellerTypeManagement = new SelectList(t.Select(i => new SelectListItem { Text = i.name, Value = i.value }), "Value", "Text");

            //var r = oDropDownManager.GetManagementResults(null);
            //ViewBag.SellerResultManagement = new SelectList(r.Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.SellerTypeManagement = new SelectList(ainfoModel.Select(x => x.TypeManagement).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerResultManagement = new SelectList(ainfoModel.Select(x => x.ResultManagement).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");

            ViewBag.SellerComment = new SelectList(ainfoModel.Select(x => x.Comment).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerSuggestedImprovement = new SelectList(ainfoModel.Select(x => x.SuggestedImprovement).ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.SellerDate = new SelectList(ainfoModel.Select(x => x.ManagementDate).ToList().Select(i => new SelectListItem { Text = i, Value = i}), "Value", "Text");


            if (usuario != null)
            {
                ViewBag.SupervisorName = usuario.FullName;
                ViewBag.SupervisorCode = usuario.AgentCode.TrimStart().TrimEnd();
                ViewBag.SupervisorOffices = usuario.AgentOffices.FirstOrDefault().OfficeDesc;
                ViewBag.SupervisorChannel = usuario.AgentsChannel.Channel_Desc;
            }



            return View(ainfoModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<AgentInfomation> GetSupervisorAgentChain(int? CorpId, int? AgentId, string NameId, int BlId, string AgentCode = "")
        {
            List<AgentInfomation> ainfo = new List<AgentInfomation>();

            var agentChain = oAgentServices.GetAgentTreeNewInfo(CorpId, AgentId, NameId, BlId).ToList();
            int chainAgentCode = 0;

            foreach (var ag in agentChain)
            {
                var agentinfo = getAgenteUserInfo(ag.NameId);

                if (ag.NameId != NameId)
                {
                    chainAgentCode = !string.IsNullOrEmpty(ag.AgentCode.TrimStart().TrimEnd()) ? Convert.ToInt32(ag.AgentCode.TrimStart().TrimEnd()) : 0;
                    var allManagement = oManagementManager.GetManagement(new ManagementData.parameters()
                    {
                        managementSupervisorCode = Convert.ToInt32(AgentCode),
                        managementSellerCode = Convert.ToInt32(chainAgentCode)
                    });

                    if (allManagement.Count() > 0)
                    {
                        foreach (var am in allManagement)
                        {
                            var ResultManagement = oDropDownManager.GetManagementResults(am.ManagementResultsIdSelected);
                            var TypeManagement = oDropDownManager.GetManagementType(am.ManagementTypeIdSelected);

                            ainfo.Add(new AgentInfomation()
                            {
                                AgentCode = chainAgentCode.ToString(),
                                FullName = agentinfo.FullName,
                                AgentChannel = agentinfo.AgentsChannel.Channel_Desc,
                                AgentOffices = agentinfo.AgentOffices.FirstOrDefault().OfficeDesc,
                                Comment = am.Comment,
                                ResultManagement = ResultManagement.FirstOrDefault().name,
                                SuggestedImprovement = am.SuggestedImprovement,
                                TypeManagement = TypeManagement.FirstOrDefault().name,
                                ManagementDate = am.ManagementDate.ToString("dd-MMM-yyyy")
                            });
                        }
                    }
                    else
                    {
                        ainfo.Add(new AgentInfomation()
                        {
                            AgentCode = chainAgentCode.ToString(),
                            FullName = agentinfo.FullName,
                            AgentChannel = agentinfo.AgentsChannel.Channel_Desc,
                            AgentOffices = agentinfo.AgentOffices.FirstOrDefault().OfficeDesc,
                            Comment = "",
                            ResultManagement = "N/A",
                            SuggestedImprovement = "",
                            TypeManagement = "N/A",
                            ManagementDate = ""
                        });
                    }
                }
            }

            return ainfo.OrderByDescending(x => x.ManagementDate).ToList();
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

        public JsonResult getAgentInfo(string agentCode)
        {
            AgentInfomation ainfor = new AgentInfomation();
            bool success = false;
            string message = "";

            var a = oAgentServices.GetAgent(new AgentServiceReference.Agent.Key() { CorpId = 1, AgentCode = agentCode });

            if (a.Count() > 0)
            {
                //Valido que el agente introducido este en mi cadena
                var usuario = GetCurrentUsuario();

                List<AgentInfomation> ainfoModel = (List<AgentInfomation>)Session["AgentInfoSession"];

                if (ainfoModel.FirstOrDefault(x => x.AgentCode == agentCode.Trim()) == null)
                {
                    return Json(new { data = ainfor, success = false, message = "El Código introducido no pertenece a su cadena." }, JsonRequestBehavior.AllowGet);
                }
                //

                var Allphones = oAgentServices.GetAgentPhone(new AgentServiceReference.Agent.CommDetailKey()
                {
                    DirectoryId = a.FirstOrDefault().DirectoryId,
                    CommTypeId = 1,
                    CorpId = 1
                });

                string phones = "";

                if (Allphones.Count() > 0)
                {
                    phones = string.Join(", ", Allphones.Select(x => x.PhoneNumber).ToArray());
                }

                var ainfo = getAgenteUserInfo(a.FirstOrDefault().NameId);

                ainfor.FullName = ainfo.FullName;
                ainfor.AgentChannel = ainfo.AgentsChannel.Channel_Desc;
                ainfor.AgentOffices = ainfo.AgentOffices.FirstOrDefault().OfficeDesc;
                ainfor.Phones = phones;

                success = true;
            }

            return Json(new { data = ainfor, success = success, message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult setManagement(string agentCode, int AgenTypeManagement, int AgenResultManagement, string CommentManagement, string SuggestedImprovementManagement)
        {
            bool success = false;
            string message = "";

            var usuario = GetCurrentUsuario();

            if (usuario != null)
            {
                var parame = new ManagementData.parameters();

                parame.managementId = null;
                parame.managementSupervisorCode = Convert.ToInt32(usuario.AgentCode.TrimStart().TrimEnd());
                parame.managementSellerCode = Convert.ToInt32(agentCode);
                parame.managementTypeId = AgenTypeManagement;
                parame.managementResultsId = AgenResultManagement;
                parame.comment = CommentManagement;
                parame.suggestedImprovement = SuggestedImprovementManagement;
                parame.createUserId = usuario.UserID;

                oManagementManager.SetManagement(parame);
                success = true;
                message = "Datos guardados correctamente.";
            }

            return Json(new { data = "", success = success, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}