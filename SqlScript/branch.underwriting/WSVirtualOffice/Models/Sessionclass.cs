
using System;
using System.Web;
using System.Web.SessionState;
using System.Linq;
using System.Data;
using System.Collections.Generic;

using WSVirtualOffice;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models
{
    public class Sessionclass
    {
        public enum screennum
        {
            customer = 1,
            plan = 2,
            riders = 3,
            occupation = 4,
            beneficiary = 5,
            planoptions = 6,
            planreq = 7,
            illustration = 8,
            opbalance = 9,
            eforms = 10,
            dashboard = 11,
            newcontact = 12,
            calender = 13,
            reporting = 14,
            compareillus = 15,
            searchengine = 16,
            agentinfo = 17,
            contacts = 18,
            searchcontacts = 19,
            dashboardbo = 20,
            masters = 21,
            report = 22,
            home = 23,
            agentoccupations = 24,
            compareillusselection = 25,
            compareillusdisplay = 26,
              eformsmain=27
        }

        public enum LOGROLE
        {
            NONE = 0,
            AGENT = 1,
            SUPERVISOR = 2,
            SYSADMIN = 3,
            POLICYADMIN = 4,
            AGENTSUPERVISOR = 5,
            BACKOFFICE = 6
        }

        public static void setIllustrationfilename(HttpSessionState session, String Illustrationfilename)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.Illustrationfilename = Illustrationfilename;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }


        public static Sessionclass getSessiondata(HttpSessionState session)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            return sessiondata;
        }

        public enum CASECLIENTMODES
        {
            NONE = 0,
            NEWILLUSTRATION = 1,
            NEWCONTACT = 2,
            EXISTINGILLUSTRATION = 3,
            EXISTINGCONTACT = 4,
            EXISTINGCLIENT = 5,
            POLICYUPDATE = 6
        }

        public enum BOTTOMMENUMODE
        {
            NONE = 0,
            NEWILLUSTRATION = 1,
            NEWCONTACT = 2,
            EXISTINGILLUSTRATION = 3,
            EXISTINGCONTACT = 4,
            EXISTINGCLIENT = 5,
            POLICYUPDATE = 6,
            SEEILLUSTRATION = 7,
            DUPLICATEILLUSTRATION = 8
        }

        public enum DASHBOARDSCREEN
        {
            ILLUSTRATIONS = 0,
            POLICYNUMBER = 1,
            APPROVALS = 2
        }

        public CASECLIENTMODES clientmode = 0;
        public BOTTOMMENUMODE bottommenumode = 0;

        public DASHBOARDSCREEN bodashboard = DASHBOARDSCREEN.ILLUSTRATIONS;

        public IllustrationRecord currentillustrationrecord;

        public screennum currentscreen = 0;
        public screennum previousscreen = 0;
        public screennum tempscreen = 0;
        public String Prospect = null;
        public int userid = 0;
        public businesslogic.Userdata userdetails = null;
        public int agentid = 0;
        public long agentlogno = 0;
        public String agentcode = null;
        public String language = "en";
        public static String SESSIONOBJECT = "SESSIONOBJECT";
        public LOGROLE loggedin = LOGROLE.NONE;
        public Boolean isLoggedin = false;
        public string User_Status;
        public string Cust_Status;
        public String usertypecode;

        public Boolean isadmin;

        //public string txtopeningaccountvalue_pi = null;
        //public string txttargetpremium = null;
        //public string txtminpremium = null;
        //public string txtopeningyear_pi = null;
        //public string txtopeningyear_pi1 = null;

        public long customerno = 0;
        public long customerplanno = 0;
        public long othercustomerno = 0;
        public int checkcount = 0;

        //public string annualprem = null;
        //public string mindata = null;
        //public string targetdata = null;
        //public string insuredamt = null;
        //public string totalinsuredamt = null;
        //public string periodicprem = null;
        //public string PlanCountry = null;
        //public string planfamily = null;
        //public string countryclient = null;
        public DataTable reportdata = null;
        public DataTable dt = null;
        public DataTable dttwo = null;
        public IMaineduretire eduretire = null;
        public IMaineduretirefixed eduretirefixd = null;
        public IMaintermfixed termfixed = null;
        public IMainfuneral funeralfixed = null;
        public IMainInsuranceData imins = null;


        public List<syncmaster> masters = new List<syncmaster>();
        public List<productdet> products = new List<productdet>();

        public long customerno_compare = 0;
        public List<List<DataTable>> dt_compare = null;
        public List<List<DataTable>> dt_compare1 = null;
        public List<List<DataTable>> dt_compare2 = null;
        public List<string> perlist = null;
        public string leftbutid = null;
        //public string botbutid = "btnClientInfo";

        public string clientid = "";

        public string primary = "";
        public string other = "";
        public String Illustrationfilename = null;

        public string dispillustrationno = "";

        public string illusdashboardclick = "";

        public Boolean ispolicyupdate = false;
        public Boolean isnewillustration = false;
        //public Boolean ispolicynumber = false;

        public DataTable orginalagent;
        public DataTable newagent;

        public DataTable dtagency;
        public DataTable dtagent;
        public DataTable dtagencygroup;
        public DataTable dtagentgroup;

        public String password = null;

        public UserProfileInfo userprofile = null;

        public List<long> CompareIllusPlans = new List<long>();

        public static void setCurrentscreen(HttpSessionState session, screennum screen)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.currentscreen = screen;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }


        //public static int getCurrentscreen(HttpSessionState session)
        //{
        //    Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];

        //    return screennum;


        //}


        public static void setCurrentIllustrationRecord(HttpSessionState session, IllustrationRecord currentillustrationrecord)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.currentillustrationrecord = currentillustrationrecord;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setAgentlogno(HttpSessionState session, long agentlogno)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.agentlogno = agentlogno;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }


        public static void setAgentcode(HttpSessionState session, String agentcode)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.agentcode = agentcode;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }


        public static void setCustomerno(HttpSessionState session, long customerno)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.customerno = customerno;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setOtherCustomerno(HttpSessionState session, long othercustomerno)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.othercustomerno = othercustomerno;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setCustomerplanno(HttpSessionState session, long customerplanno)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.customerplanno = customerplanno;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setCuststatus(HttpSessionState session, String custstatus)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.Cust_Status = custstatus;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setProspect(HttpSessionState session, String prospect)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.Prospect = prospect;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setAgentid(HttpSessionState session, int agentid)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.agentid = agentid;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }


        public static void setClientmode(HttpSessionState session, CASECLIENTMODES mode)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.clientmode = mode;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;
        }

        public static void setPassword(HttpSessionState session, String password)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.password = password;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setBottommenumode(HttpSessionState session, BOTTOMMENUMODE mode)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.bottommenumode = mode;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;
        }


        public static void setUsertypecode(HttpSessionState session, String usertypecode)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.usertypecode = usertypecode;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setIsadmin(HttpSessionState session, Boolean isadmin)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.isadmin = isadmin;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;

        }

        public static void setCompareIllusPlans(HttpSessionState session, List<long> plans)
        {
            Sessionclass sessiondata = (Sessionclass)session[Sessionclass.SESSIONOBJECT];
            sessiondata.CompareIllusPlans = plans;
            session[Sessionclass.SESSIONOBJECT] = sessiondata;
        }
    }
}