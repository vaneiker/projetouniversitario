using Newtonsoft.Json;
using Statetrust.Framework.Security.Bll.Item;
using Statetrust.Framework.Security.Core;
using Statetrust.Framework.Web.WebParts.Controllers;
using STL.POS.Data;
using STL.POS.Frontend.Security.SecurityProvider;
using STL.POS.Frontend.Web.Areas.Security.Models;
using STL.POS.Frontend.Web.Helpers;
using STL.POS.THProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace STL.POS.Frontend.Web.Areas.Security.Controllers
{
    public class AccountController : STFMainController
    {

        private IAuthenticationProvider authProvider;
        private PosModel dataAccess;
        private ITHProxy thunderHeadProxy;

        public AccountController(IAuthenticationProvider iauth, PosModel da, ITHProxy thProxy)
        {
            authProvider = iauth;
            dataAccess = da;
            thunderHeadProxy = thProxy;
        }


        public ActionResult RedirectToVo(string path, string appname, string tab)
        {
            var addInfo = new AdditionalInfo
            {
                CompanyId = Usuario.CurrentCompanyId, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                Language = Usuario.CurrentLanguageKey, //Idioma en el que quiere que se vea la aplicación a acceder.
                AppName = appname,
                RedirectUrl = path,
                RedirectTab = tab
            };

            var data = GenerateToken(Usuario.UserID, addInfo); //Genera un nuevo Token y se le pasa el ID del Usuario, el WebControl que lo llamo para leer los parámetros de aplicación y el Additional info para saber la compañía y el idioma.

            if (data.Status) //Devuelve True en caso de que el logueo haya sido exitoso.
                return Redirect(data.UrlPath);
            else
                return RedirectToAction("Login", "Account", new { Area = "Security", unauthorizedAccess = true, showUserCreatedSuccess = false });
        }

        //public ActionResult Login(bool? unauthorizedAccess, bool? showUserCreatedSuccess)
        //{
        //    ViewBag.UnauthorizedAccess = unauthorizedAccess.GetValueOrDefault(false);
        //    ViewBag.ShowUserCreatedSuccess = showUserCreatedSuccess.GetValueOrDefault(false);
        //    return View("Login");
        //}

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
                //return RedirectToAction("Login", "Account", new { Area = "Security", unauthorizedAccess = true, showUserCreatedSuccess = false });
            }

        }

        // GET: Security/Account
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginRegisterModel model, string returnUrl)
        {

            var auth = authProvider.AuthenticateUser(model.Username, model.Password);

            if (auth)
            {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                if (string.IsNullOrEmpty(returnUrl))
                    returnUrl = "/";
                return Redirect(returnUrl);

            }
            else
            {
                var errors = new List<string>() { "El usuario no existe, o contraseña incorrecta." };
                model.Errors = JsonConvert.SerializeObject(errors);
                return View(model);
            }
        }

        public ActionResult RegistrationSuccess(LoginRegisterModel model)
        {
            return View(model);
        }

        private string GetChangePasswordLink(string token)
        {
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                                Request.ApplicationPath.TrimEnd('/');
            return baseUrl + Url.Action("ChangePassword", "Account", new { Area = "Security", token = token });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(LoginRegisterModel model)
        {

            List<string> errorMessages;
            if (model.IsValid(out errorMessages))
            {
                var error = string.Empty;
                var user = model.GetUser();
                if (!authProvider.CreateUser(user, out error))
                {
                    errorMessages.Add(error);
                    model.Errors = JsonConvert.SerializeObject(errorMessages);
                    return View("Login", model);
                }
                else
                {
                    //User created, force password change
                    var authToken = authProvider.ChangePasswordRequest(user.Username, false);

                    try
                    {
                        thunderHeadProxy.SendNewUserCreated(user.Username, user.GetFullName(), user.Email, GetChangePasswordLink(authToken));
                        return Login(false, true);
                    }
                    catch (Exception ex)
                    {
                        //Make mail
                        var subject = dataAccess.GetParameter(Parameter.PARAMETER_KEY_EMAIL_WEBSERVICE_ERROR).Value;
                        var sender = dataAccess.GetParameter(Parameter.PARAMETER_KEY_EMAIL_SENDER).Value;
                        var body = string.Format("Se produjo un error al enviar el e-mail de cambio de contraseña para el usuario {0}. Nombre: {1} - Url: {2}",
                            user.Username,
                            user.GetFullName(),
                            GetChangePasswordLink(authToken));

                        SendEmailHelper.SendMail(sender, subject.Split(',').ToList(), "Error en Thunderhead", body, null);
                    }
                }
            }
            model.Errors = JsonConvert.SerializeObject(errorMessages);
            return View("Login", model);
        }

        public ActionResult AskForPasswordChange(string username)
        {
            var errorMessages = new List<string>();

            var authToken = authProvider.ChangePasswordRequest(username, true);

            if (!string.IsNullOrEmpty(authToken))
            {
                var user = (from u in dataAccess.Users
                            where u.Username == username
                            select u).FirstOrDefault();

                try
                {
                    thunderHeadProxy.SendForgetPassword(user.Username, user.GetFullName(), user.Email, GetChangePasswordLink(authToken));
                    return Json(new List<string>(), JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    //Make mail
                    var subject = dataAccess.GetParameter(Parameter.PARAMETER_KEY_EMAIL_WEBSERVICE_ERROR).Value;
                    var sender = dataAccess.GetParameter(Parameter.PARAMETER_KEY_EMAIL_SENDER).Value;
                    var body = string.Format("Se produjo un error al enviar el e-mail de cambio de contraseña para el usuario {0}. Nombre: {1} - Url: {2}",
                        user.Username,
                        user.GetFullName(),
                        GetChangePasswordLink(authToken));

                    SendEmailHelper.SendMail(sender, subject.Split(',').ToList(), "Error en Thunderhead", body, null);
                }
            }
            else
                errorMessages.Add("El usuario es incorrecto.");

            return Json(errorMessages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangePassword(string token)
        {
            var model = new ChangePasswordModel();
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(token))
                errorList.Add("No se ha proporcionado un token de cambio de contraseña válido.");
            else
            {
                var user = (from u in dataAccess.Users
                            where u.ChangePasswordToken == token
                            select u).FirstOrDefault();

                if (user == null)
                {
                    errorList.Add("No se ha proporcionado un token de cambio de contraseña válido.");
                }
                else
                {
                    model.Username = user.Username;
                    model.IsNewUser = user.UserStatus == UserStatus.Created;
                    model.IsLostPass = authProvider.IsTokenForPasswordLost(user);
                    model.ChangePasswordToken = token;
                }
            }

            model.Errors = JsonConvert.SerializeObject(errorList);
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var errMessage = string.Empty;
            var errors = new List<string>();
            if (model.NewPassword != model.ConfirmNewPassword)
            {
                errors.Add("La Contraseña ingresada y su confirmación no coinciden.");
            }
            else
            {
                string userName = string.Empty;
                var setOk = authProvider.SetPasswordForUser(model.ChangePasswordToken, model.Password, model.NewPassword, out userName, out errMessage);

                if (setOk)
                {
                    FormsAuthentication.SetAuthCookie(userName, true);
                    model.RedirectUrl = Url.Action("Index", "Home", new { Area = string.Empty });
                }
                else
                {
                    errors.Add(errMessage);
                    model.RedirectUrl = null;
                }
            }
            model.Errors = JsonConvert.SerializeObject(errors);
            return View(model);
        }

        public ActionResult LogoutPOS()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            ViewBag.UnauthorizedAccess = false;
            return RedirectToAction("Login", "Account", new { Area = "Security" });
        }


    }
}