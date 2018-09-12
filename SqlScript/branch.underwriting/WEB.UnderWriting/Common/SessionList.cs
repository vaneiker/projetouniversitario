using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WEB.UnderWriting.Common
{
    public class SessionList
    {
        public SessionContact ContactInfo
        {
            get;
            set;
        }
        public string TabName { get; set; }
        public string SaveActiveTab { get; set; }

        public string key = "SessionData";

        public SessionList(string KeyNama = "SessionData")
        {
            key = KeyNama;
        }
        public SessionList Stored
        {
            get
            { return HttpContext.Current.Session[key] as SessionList; }
        }
        public void Save()
        {
            if (HttpContext.Current.Session == null)
            {

                HttpContext.Current.Session.Add(key, new SessionList());
                (HttpContext.Current.Session[key] as SessionList).ContactInfo = new SessionContact();
            }
            else
            {
                if (HttpContext.Current.Session[key] == null)
                {
                    HttpContext.Current.Session.Add(key, new SessionList());
                    (HttpContext.Current.Session[key] as SessionList).ContactInfo = new SessionContact();
                }
            }

            foreach (PropertyInfo item in PopertiesToSave())
            {
                switch (item.Name)
                {
                    case "ContactInfo":
                        (HttpContext.Current.Session[key] as SessionList).ContactInfo = (Stored != null ? Stored.ContactInfo : (HttpContext.Current.Session[key] as SessionList).ContactInfo);
                        break;
                    case "TabName":
                        (HttpContext.Current.Session[key] as SessionList).TabName = (Stored != null ? Stored.TabName : (HttpContext.Current.Session[key] as SessionList).TabName);
                        break;
                    case "SaveActiveTab":
                        (HttpContext.Current.Session[key] as SessionList).SaveActiveTab = (Stored != null ? Stored.SaveActiveTab : (HttpContext.Current.Session[key] as SessionList).SaveActiveTab);
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
        public Entity.UnderWriting.Entities.Case.SearchResult SearchResult { get; set; }
        public int Corp_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public int Domesticreg_Id { get; set; }
        public int State_Prov_Id { get; set; }
        public int City_Id { get; set; }
        public int Office_Id { get; set; }
        public int Case_Seq_No { get; set; }
        public int Hist_Seq_No { get; set; }
        public int Owner_Id { get; set; }
        public string Policy_Id { get; set; }
        public int Contact_Id { get; set; }
        public int Directory_Id { get; set; }
        public int RoleTypeId { get; set; }
        public int ContactSeq_No { get; set; }
        public int Underwriter_Id { get; set; }
        public bool IsOwner { get; set; }
        public bool OwnerIsInsured { get; set; }
        public string PdfViewerKey { get; set; }
        public int? AddInsuredContactId { get; set; }
        public int CompanyId { get; set; }
        public int? ContactAge { get; set; }
        public int? InsuredPeriod { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string UnderwriterEmail { get; set; }

        public string TransunionUser { get; set; }
        public string TransunionPass { get; set; }
        public string TransunionDefaultPassword { get; set; }
        public string UserName { get; set; }
        
        public int LanguageId { get; set; }
        public String ContactGender { get; set; }
        public Tools.ProductBehavior  ProductDesc { get; set; }
        
    }
}