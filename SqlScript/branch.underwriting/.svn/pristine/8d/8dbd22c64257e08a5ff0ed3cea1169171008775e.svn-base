using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WEB.ConfirmationCall.Common
{
    public enum ContactType
    {
        None = 0,
        Owner = 1,
        Insured = 2,
        AdditionalInsured = 3
    }

    public class SessionList
    {
        public SessionContact PolicyInfo { get; set; }

        private  string key = "SessionData";

        public SessionList(string KeyName = "SessionData")
        {
            key = KeyName;
        }


        public  SessionList Stored
        {
            get
            {
                return HttpContext.Current.Session[key] as SessionList;
            }
        }

        public void Save()
        {
            if (HttpContext.Current.Session == null)
            {

                HttpContext.Current.Session.Add(key, new SessionList());
                (HttpContext.Current.Session[key] as SessionList).PolicyInfo = new SessionContact();
            }
            else
            {
                if (HttpContext.Current.Session[key] == null)
                {
                    HttpContext.Current.Session.Add(key, new SessionList());
                    (HttpContext.Current.Session[key] as SessionList).PolicyInfo = new SessionContact();
                }
            }

            foreach (PropertyInfo item in PopertiesToSave())
            {
                switch (item.Name)
                {
                    case "ContactInfo":
                        (HttpContext.Current.Session[key] as SessionList).PolicyInfo = (Stored != null ? Stored.PolicyInfo : (HttpContext.Current.Session[key] as SessionList).PolicyInfo);
                        break;
                }
            }
            PolicyInfo = (Stored != null ? Stored.PolicyInfo : (HttpContext.Current.Session[key] as SessionList).PolicyInfo);
            //HttpContext.Current.Session[key] = this;
        }

        private List<PropertyInfo> PopertiesToSave()
        {
            List<PropertyInfo> PropertyList = new List<PropertyInfo>((HttpContext.Current.Session[key] as SessionList).GetType().GetProperties());

            List<PropertyInfo> TmpList = new List<PropertyInfo>(PropertyList);

            TmpList.Remove(PropertyList.Where(x => x.Name == "Stored").First());

            foreach (PropertyInfo prop in PropertyList)
            {
                if (prop.GetValue((HttpContext.Current.Session[key] as SessionList), null) != null)
                {
                    TmpList.Remove(PropertyList.Where(x => x.Name == prop.Name).First());
                }
            }
            return TmpList;
        }
    }

    public class SessionContact
    {
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int DomesticregId { get; set; }
        public int StateProvId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int CaseSeqNo { get; set; }
        public int HistSeqNo { get; set; }
        public int OwnerContactId { get; set; }
        public int? AdditionalContactId { get; set; }
        public string PolicyNo { get; set; }
        public int? InsuredContactId { get; set; }
        public string CaseStatus { get; set; }
        public int CurrentContactId { get; set; }
        public ContactType CurrentContactTypeId { get; set; }
        public int StepTypeId { get; set; }
        public int StepId { get; set; }
        public int StepCaseNo { get; set; }

        public void CleanSessionKeys()
        {
            CorpId = -1;
            RegionId = -1;
            CountryId = -1;
            DomesticregId = -1;
            StateProvId = -1;
            CityId = -1;
            OfficeId = -1;
            CaseSeqNo = -1;
            HistSeqNo = -1;
            OwnerContactId = -1;
            InsuredContactId = null;
            AdditionalContactId = null;
            PolicyNo = null;
            CaseStatus = null;
            CurrentContactId = -1;
            CurrentContactTypeId = ContactType.None;
            StepTypeId = -1;
            StepId = -1;
            StepCaseNo = -1;
        }
    }
}