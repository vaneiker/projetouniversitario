using STL.POS.AgentWSProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.NewVersion.CustomCode
{
    public class SessionList
    {
        public SessionObject sessionObject { get; set; }

        private string key = "SessionData";

        public SessionList(string KeyName = "SessionData") { key = KeyName; }

        public SessionList Stored
        {
            get { return HttpContext.Current.Session[key] as SessionList; }
        }

        public void Save()
        {
            if (HttpContext.Current.Session == null)
            {
                HttpContext.Current.Session.Add(key, new SessionList());
                (HttpContext.Current.Session[key] as SessionList).sessionObject = new SessionObject();
            }
            else
            {
                if (HttpContext.Current.Session[key] == null)
                {
                    HttpContext.Current.Session.Add(key, new SessionList());
                    (HttpContext.Current.Session[key] as SessionList).sessionObject = new SessionObject();
                }
            }

            foreach (PropertyInfo item in PopertiesToSave())
            {
                switch (item.Name)
                {
                    case "sessionObject":
                        (HttpContext.Current.Session[key] as SessionList).sessionObject = (Stored != null ? Stored.sessionObject : (HttpContext.Current.Session[key] as SessionList).sessionObject);
                        break;
                }
            }
        }

        private List<PropertyInfo> PopertiesToSave()
        {
            List<PropertyInfo> PropertyList = new List<PropertyInfo>((HttpContext.Current.Session[key] as SessionList).GetType().GetProperties());

            List<PropertyInfo> TmpList = new List<PropertyInfo>(PropertyList);

            TmpList.Remove(PropertyList.Where(x => x.Name == "Stored").First());

            foreach (PropertyInfo prop in PropertyList)
                if (prop.GetValue((HttpContext.Current.Session[key] as SessionList), null) != null)
                    TmpList.Remove(PropertyList.Where(x => x.Name == prop.Name).First());

            return TmpList;
        }
    }

    public class SessionObject
    {
        public int QuotationId { get; set; }
        public String QuotationNumber { get; set; }
        public String CoreQuotationNumber { get; set; }
        public Tuple<QuotationViewModel.Vehicles, QuotationViewModel> CurrentDataQuotation { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Drivers { get; set; }
        public IEnumerable<SelectListItem> dataPaymentFreq { get; set; }
        public List<AgentTreeInfoNew> AgentTreeInfoNew { get; set; }
        public bool isNotLawProduct { get; set; }
        public int currentCountry { get; set; }
        public bool isFinanced { get; set; }
        public int VehicleNumber { get; set; }
        public int TotalVehiclesCompleted { get; set; }
        public CustomCode.CommonEnums.RequestType RequestType { get; set; }
        public bool CanDoInclusion { get; set; }
        public bool CanDoExclusion { get; set; }        
        public bool IsShowPolicy { get; set; }        
        public bool onlyLoggedUsers { get; set; }
        public int? SecuenciaVehicleInclusion { get; set; }
        public bool CanSeeListUsers { get; set; }
        public SelectList ListUsers { get; set; }
        public bool CanDoCambios { get; set; }

        public string PolicySendByVO { get; set; }

        public bool IsAQuotation { get; set; }
        public String RiskLevel { get; set; }

        public string _actionData { get; set; }

        public bool CanDoNuevaPropuesta { get; set; }      


    }
}