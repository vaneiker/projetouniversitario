﻿using Newtonsoft.Json;
using Statetrust.Framework.Security.Bll.Item;
using STL.POS.Data;
using STL.POS.Frontend.Security.SecurityProvider;
using STL.POS.Frontend.Web.Areas.Security.Models;
using STL.POS.Frontend.Web.Helpers;
using STL.POS.THProxy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Statetrust.Framework.Core.Base;
using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using STL.POS.Frontend.Web.Controllers;
using STL.POS.AgentWSProxy;
using STL.POS.AgentWSProxy.AgentService;

namespace STL.POS.Frontend.Web.Areas.Security.Controllers
{

    public class AccountController : BaseController
    {
        private IAuthenticationProvider authProvider;
        private ITHProxy thunderHeadProxy;
        private IAgentProxy agentProxy;

        public AccountController(IAuthenticationProvider iauth, PosModel da, ITHProxy thProxy, IAgentProxy aProxy)
            : base(da)
        {
            authProvider = iauth;
            thunderHeadProxy = thProxy;
            agentProxy = aProxy;
        }


        [AllowAnonymous]
        public ActionResult RedirectToOtherApp(string path, string appname, string tab)
        {
            var onlyLoggedUsers = allowOnlyLoggedUsers();
            if (onlyLoggedUsers)
            {
                var addInfo = new AdditionalInfo
                {
                    CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                    Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                    AppName = appname,
                    RedirectUrl = path,
                    RedirectTab = tab
                };

                var data = GenerateToken(Usuario.UserID, addInfo); //Genera un nuevo Token y se le pasa el ID del Usuario, el WebControl que lo llamo para leer los parámetros de aplicación y el Additional info para saber la compañía y el idioma.

                string msjerrr = "";

                if (data.Status)
                {
                    FormsAuthentication.SignOut();
                }
                else
                {
                    msjerrr = data.errormessage.Trim();
                    if (msjerrr == "This user does not have access to this page or App")
                    {
                        msjerrr = Globalization.Home.HomeIndex.userNotAllowed;
                    }
                }
                return Json(new { Status = data.Status, UrlPath = data.UrlPath, errormessage = msjerrr }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false, UrlPath = "", errormessage = "" }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult RedirectToVo(string path, string appname, string tab)
        {
            var addInfo = new AdditionalInfo
            {
                CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                AppName = appname,
                RedirectUrl = path,
                RedirectTab = tab
            };

            var data = GenerateToken(Usuario.UserID, addInfo); //Genera un nuevo Token y se le pasa el ID del Usuario, el WebControl que lo llamo para leer los parámetros de aplicación y el Additional info para saber la compañía y el idioma.

            string msjerrr = "";

            if (data.Status)
            {
                FormsAuthentication.SignOut();
            }
            else
            {
                msjerrr = data.errormessage.Trim();
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Globalization.Home.HomeIndex.userNotAllowed;
                }
            }

            return Json(new { Status = data.Status, UrlPath = data.UrlPath, errormessage = msjerrr }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult LoginFromVOUserPass(string username, string password)
        {
            var userId = 0;

            string token = "NO TOKEN";
            var addInfo = new AdditionalInfo
            {
                CompanyId = 2, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                Language = "es" //Idioma en el que quiere que se vea la aplicación a acceder.
            };
            if (Login(username, password, ref userId))
            {
                SetLoginInformation();
                var obj = GenerateToken(userId, addInfo);
                token = obj.token;
            }
            return Content(token);
        }

        public ActionResult LoginFromVODummy()
        {
            var userId = 0;
            var appId = 0;
            var loginName = "acatellani";
            var email = "agustin.catellani@diveria.com";
            var username = "acatellani";

            var dbUser = (from c in dataAccess.Users
                          where c.Username == loginName
                          && c.UserOrigin == UserOrigins.VO
                          select c).FirstOrDefault();

            var now = DateTime.Now;
            if (dbUser == null)
            {

                dbUser = new Data.User()
                {
                    DateCreated = now,
                    Email = email,
                    LastDateModified = now,
                    //Name = Usuario.FirstName,
                    LastLogin = now,
                    //Surname = Usuario.LastName,
                    Username = loginName,
                    UserOrigin = UserOrigins.VO,
                    UserStatus = UserStatus.Active
                };
                var str = string.Empty;
                dataAccess.Users.Add(dbUser);
            }
            dbUser.LastLogin = now;
            dataAccess.SaveChanges();

            FormsAuthentication.SetAuthCookie(username, true);
            return RedirectToAction("QuotationSearch", new { currentUserName = username, Controller = "Home", Area = string.Empty });
        }

        private void CheckDbUser(string loginName, string email)
        {
            var dbUser = (from c in dataAccess.Users
                          where c.Username == loginName
                          && c.UserOrigin == UserOrigins.VO
                          select c).FirstOrDefault();

            var now = DateTime.Now;
            if (dbUser == null)
            {

                dbUser = new Data.User()
                {
                    DateCreated = now,
                    Email = email,
                    LastDateModified = now,
                    Name = Usuario.FirstName,
                    LastLogin = now,
                    Surname = Usuario.LastName,
                    Username = loginName,
                    UserOrigin = UserOrigins.VO,
                    UserStatus = UserStatus.Active
                };
                switch (Usuario.UserType)
                {
                    case Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant:
                        dbUser.UserType = UserType.Subscriptor;
                        break;
                    case Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent:
                        dbUser.UserType = UserType.Agent;
                        break;
                    default:
                        dbUser.UserType = UserType.WebUser;
                        break;
                }

                var str = string.Empty;
                authProvider.CreateUser(dbUser, out str);
            }
            else
            {
                dbUser.LastLogin = now;
                dataAccess.SaveChanges();
            }
        }

        public ActionResult LoginFromVO(string token)
        {
            var userId = 0;
            var appId = 0;
            var username = string.Empty;
            var loginName = string.Empty;
            var email = string.Empty;
            if (LoginToken(token, ref userId, ref appId, ref username, ref email, ref loginName))
            {
                var dbUser = (from c in dataAccess.Users
                              where c.Username == loginName
                              && c.UserOrigin == UserOrigins.VO
                              select c).FirstOrDefault();

                var now = DateTime.Now;
                if (dbUser == null)
                {

                    dbUser = new Data.User()
                    {
                        DateCreated = now,
                        Email = email,
                        LastDateModified = now,
                        Name = Usuario.FirstName,
                        LastLogin = now,
                        Surname = Usuario.LastName,
                        Username = loginName,
                        UserOrigin = UserOrigins.VO,
                        UserStatus = UserStatus.Active
                    };
                    var str = string.Empty;
                    authProvider.CreateUser(dbUser, out str);
                }
                else
                {
                    dbUser.LastLogin = now;
                    dataAccess.SaveChanges();
                }

                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("QuotationSearch", new { Controller = "Home", Area = string.Empty });
            }
            else
            {
                return RedirectToAction("Login", "Account", new { Area = "Security", unauthorizedAccess = true, showUserCreatedSuccess = false });
            }

        }

        [AllowAnonymous]
        public ActionResult STFLogin()
        {
            var controller = "Home";
            var action = "Index";

            var newController = "Home";
            var newAction = "Index";

            /*
              1 = Solo usuarios Logueados
              0 =  Todo el mundo
            */

            var onlyLoggedUsers = allowOnlyLoggedUsers();

            if (onlyLoggedUsers)
            {
                if (WebConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "false")
                {
                    var userId = 0;
                    //string userLogin = "PTECNOLOGIA";//defaultuser 
                    //string pass = "UjAsEkU/BxUbjoPSX9Zuf/Nu71DbAyxzLv3Jz2naU6E=";
                    string userLogin = "PTECNOLOGIA";//defaultuser 
                    string pass = "outiiz/77lQ=";
                    
                    if (!Login(userLogin, pass, ref userId))
                    {
                        return RedirectToAction(action, controller);
                    }

                    SetLoginInformation();

                    CheckDbUser(Usuario.UserLogin, Usuario.Email);
                    FormsAuthentication.SetAuthCookie(Usuario.UserLogin, true);

                    var UsuarioRoles = Usuario.rolesByUser;
                    Session["IsShowPolicy"] = UsuarioRoles.Any(o => o.Rol_Name.Contains("IsShowPolicy"));
                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        var secToken = Request.QueryString[0];
                        var userId = 0;
                        var applicationId = 0;
                        var username = string.Empty;
                        var loginName = string.Empty;
                        var email = string.Empty;

                        if (!Login(secToken, ref userId, ref applicationId))
                        {
                            return RedirectToAction(action, controller);
                        }

                        SetLoginInformation();

                        CheckDbUser(Usuario.UserLogin, email);

                        FormsAuthentication.SetAuthCookie(Usuario.UserLogin, true);

                        var UsuarioRoles = Usuario.rolesByUser;
                        Session["IsShowPolicy"] = UsuarioRoles.Any(o => o.Rol_Name.Contains("IsShowPolicy"));

                        setOthersValues(ref newController, ref newAction);

                        if (!string.IsNullOrEmpty(newAction) && !string.IsNullOrEmpty(newController))
                        {
                            return RedirectToAction(newAction, new { Controller = newController/*, Area = "Auto"*/ });
                        }
                    }
                    else
                    {
                        return Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
            else
            {
                return RedirectToAction(newAction, new { Controller = newController });
            }

            return RedirectToAction(action, new { currentUserName = Usuario.UserLogin, Controller = controller, Area = string.Empty });
        }

        public ActionResult LogoutPOS()
        {
            FormsAuthentication.SignOut();
            //Session.Abandon();
            //ViewBag.UnauthorizedAccess = false;
            return RedirectToAction("Index", "Home");
        }


        private void setOthersValues(ref string redirectedController, ref string redirectedAction)
        {
            var jsonAdditionalInfo = Request.QueryString["additionalinfo"];
            redirectedController = "";
            redirectedAction = "";

            if (!String.IsNullOrEmpty(jsonAdditionalInfo))
            {
                var additionalInfo = GetAdditionalInfo(jsonAdditionalInfo);
                var urlMVC = additionalInfo.RedirectRoute;

                foreach (var url in urlMVC)
                {
                    if (url.Key.ToString() == "Controller")
                    {
                        redirectedController = url.Value;
                    }

                    if (url.Key.ToString() == "Action")
                    {
                        redirectedAction = url.Value;
                    }
                }
            }
        }
    }

}