using System.Collections.Generic;

namespace WEB.ConfirmationCall.Infrastructure.Providers
{
    public static class UserDataProvider
    {
        public static int CorpId
        {
            get
            {
                return SessionProvider.Get("CorpId") == null ? 0 : int.Parse(SessionProvider.Get("CorpId").ToString());
            }
            set { SessionProvider.Set("CorpId", value); }
        }

        public static int CompanyId
        {
            get
            {
                return SessionProvider.Get("CompanyId") == null ? 0 : int.Parse(SessionProvider.Get("CompanyId").ToString());
            }
            set { SessionProvider.Set("CompanyId", value); }
        }

        //Este es el ID del proyecto, que para ConfirmationCall es 4
        public static int ProjectId
        {
            get { return 4; }
        }

        public static int AgentId
        {
            get
            {
                return SessionProvider.Get("AgentId") == null ? 0 : int.Parse(SessionProvider.Get("AgentId").ToString());
            }
            set { SessionProvider.Set("AgentId", value); }
        }

        public static int UserId
        {
            get
            {
                return SessionProvider.Get("UserId") == null ? 0 : int.Parse(SessionProvider.Get("UserId").ToString());
            }
            set { SessionProvider.Set("UserId", value); }
        }

        public static string NameId
        {
            get
            {
                return SessionProvider.Get("ViewNameId") == null ? SessionProvider.Get("NameId") == null ? "" : SessionProvider.Get("NameId").ToString()
                                                                 : SessionProvider.Get("ViewNameId") == null ? "" : SessionProvider.Get("ViewNameId").ToString();
            }
            set
            {
                SessionProvider.Set("NameId", value);
                SessionProvider.Set("ViewNameId", null);
            }
        }

        public static string RealNameId
        {
            get
            {
                return SessionProvider.Get("NameId") == null ? "" : SessionProvider.Get("NameId").ToString();
            }
            set { SessionProvider.Set("NameId", value); }
        }

        public static string ViewNameId
        {
            get
            {
                return SessionProvider.Get("ViewNameId") == null ? "" : SessionProvider.Get("ViewNameId").ToString();
            }
            set { SessionProvider.Set("ViewNameId", value); }
        }

        public static string Language
        {
            get
            {
                var lang = SessionProvider.Get("Language");
                return lang == null ? "es" : lang.ToString();
            }
            set { SessionProvider.Set("Language", value); }
        }

        public static int LanguageId
        {
            get
            {
                return Language == "en" ? 1 : 2;
            }
        }
        
        public static bool IsChangingLanguage
        {
            get
            {
                return SessionProvider.Get("IsChangingLanguage") != null && (bool)SessionProvider.Get("IsChangingLanguage");
            }
            set { SessionProvider.Set("IsChangingLanguage", value); }
        }

        public static string Email
        {
            get
            {
                return SessionProvider.Get("Email") == null ? "" : SessionProvider.Get("Email").ToString();
            }
            set { SessionProvider.Set("Email", value); }
        }

        public static Roles Role
        {
            get
            {
                return SessionProvider.Get("ViewRole") == null ? SessionProvider.Get("Role") == null ? Roles.Nothing : (Roles)SessionProvider.Get("Role")
                                                               : SessionProvider.Get("ViewRole") == null ? Roles.Nothing : (Roles)SessionProvider.Get("ViewRole");
            }
            set
            {
                SessionProvider.Set("Role", value);
                SessionProvider.Set("ViewRole", null);
            }
        }

        public static Roles RealRole
        {
            get
            {
                return SessionProvider.Get("Role") == null ? Roles.Nothing : (Roles)SessionProvider.Get("Role");
            }
            set { SessionProvider.Set("Role", value); }
        }

        public static Roles ViewRole
        {
            get
            {
                return SessionProvider.Get("ViewRole") == null ? Roles.Nothing : (Roles)SessionProvider.Get("ViewRole");
            }
            set { SessionProvider.Set("ViewRole", value); }
        }

        public static List<AccessPage> AccessListPages
        {
            get
            {
                return SessionProvider.Get("AccessListPages") == null ? null : (List<AccessPage>)SessionProvider.Get("AccessListPages");
            }
            set { SessionProvider.Set("AccessListPages", value); }
        }

        public static void ClearData()
        {
            SessionProvider.InvalidateAll();
        }

        public static bool HasAccess(string page)
        {
            if (AccessListPages == null) return false;
            var access = AccessListPages.Find(o => o.Page == page);
            return access == null ? AccessListPages.Exists(o => o.Page == "*" && o.CanAccess) : access.CanAccess;
        }

        public static string GetDefaultPage()
        {
            var loginPage = System.Configuration.ConfigurationManager.AppSettings["LoginPage"];
            if (AccessListPages == null) return loginPage;
            var access = AccessListPages.Find(o => o.DefaultPage);
            return access == null ? loginPage : access.Page == "*" ?
                System.Configuration.ConfigurationManager.AppSettings["DefaultPage"] : access.Page;
        }

        public enum Languages
        {
            EN,
            ES
        }

        public enum Roles
        {
            Nothing,
            Admin,
            Employee,
            Assistant,
            Agent,
            PaymentService,
            InvestmentReturn
        }
    }

    public class AccessPage
    {
        public string Page { get; set; }
        public bool CanAccess { get; set; }
        public bool DefaultPage { get; set; }
    }
}
