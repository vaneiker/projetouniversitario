
using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using System.Web;

namespace WEB.ConfirmationCall.Common
{
    /// <summary>
    /// Author       : Lic. Carlos Ml. Lebron
    /// Created Date : 10/05/2014
    /// </summary>
    public class Services
    {
        private string key = "SessionData";
        public Common.SessionList SessionData { get; set; }

        public Services(string KeyName = "SessionData")
        {
            key = KeyName;
            RefreshData();
        }

        public void RefreshData()
        {
            if (HttpContext.Current.Session == null) return;
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, new SessionList(key));
                (HttpContext.Current.Session[key] as SessionList).PolicyInfo = new SessionContact();
            }

            SessionData = (HttpContext.Current.Session[key] as SessionList);
        }

        #region Services
        /// <summary>
        /// Manager de Contactos
        /// </summary>
        public IContact oContactManager = new DI.UnderWriting.UnderWritingDIManager().ContactManager;
        /// <summary>
        /// Manager de Requerimientos
        /// </summary>
        public IRequirement oRequirement = new DI.UnderWriting.UnderWritingDIManager().RequirementManager;
        /// <summary>
        /// Manager de Casos
        /// </summary>
        public ICase oCaseManager = new DI.UnderWriting.UnderWritingDIManager().CaseManager;
        /// <summary>
        /// Manager de requirements
        /// </summary>
        public IRequirement oRequirementManager = new DI.UnderWriting.UnderWritingDIManager().RequirementManager;
        /// <summary>
        /// Manager de Polizas
        /// </summary>
        public IPolicy oPolicyManager = new DI.UnderWriting.UnderWritingDIManager().PolicyManager;
        /// <summary>
        /// Manager de IPayment
        /// </summary>
        public IPayment oPaymentManager = new DI.UnderWriting.UnderWritingDIManager().PaymentManager;

        /// <summary>
        /// Manger de DropDown
        /// </summary>
        public IDropDown oDropDownManager = new UnderWritingDIManager().DropDownManager;

        /// <summary>
        /// Manager de Rider 
        /// </summary>
        public IRider oRiderManager = new DI.UnderWriting.UnderWritingDIManager().RiderManager;

        /// <summary>
        /// Manager de Beneficiary 
        /// </summary>
        public IBeneficiary oBeneficiaryManager = new DI.UnderWriting.UnderWritingDIManager().BeneficiaryManager;

        /// <summary>
        /// Manager de ConfirmationCall 
        /// </summary>
        public IConfirmationCall oConfirmationCallManager = new DI.UnderWriting.UnderWritingDIManager().ConfirmationCallManager;


        /// <summary>
        /// Manager Step
        /// </summary>
        public IStep oStepManager = new DI.UnderWriting.UnderWritingDIManager().StepManager;
        

        //Traer SessionData del session 
        //Oficina
        public int Corp_Id
        {
            get
            {
                int corpId = (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CorpId;
                return corpId > 0 ? corpId : 1;
            }
            set
            {
                SessionData.PolicyInfo.CorpId = value;
                SessionData.Save();
            }
        }

        /// <summary>
        /// RegionID es el id de la region
        /// </summary>
        public int Region_Id
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.RegionId; }
            set
            {
                SessionData.PolicyInfo.RegionId = value;
                SessionData.Save();
            }
        }

        public int Country_Id
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CountryId; }
            set
            {
                SessionData.PolicyInfo.CountryId = value;
                SessionData.Save();
            }
        }

        public int Domesticreg_Id
        {
            get
            {
                return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.DomesticregId;
            }
            set
            {
                SessionData.PolicyInfo.DomesticregId = value;
                SessionData.Save();
            }
        }

        public int State_Prov_Id
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StateProvId; }
            set
            {
                SessionData.PolicyInfo.StateProvId = value;
                SessionData.Save();
            }
        }

        public int City_Id
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CityId; }
            set
            {
                SessionData.PolicyInfo.CityId = value;
                SessionData.Save();
            }
        }

        public int Office_Id
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.OfficeId; }
            set
            {
                SessionData.PolicyInfo.OfficeId = value;
                SessionData.Save();
            }
        }
        //Fin Oficina                                                         

        public string Policy_Id
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.PolicyNo; }
            set
            {
                SessionData.PolicyInfo.PolicyNo = value;
                SessionData.Save();
            }
        }

        public int Case_Seq_No
        {
            get
            {
                return ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CaseSeqNo != 0) ?
                    (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CaseSeqNo : 0;
            }
            set
            {
                SessionData.PolicyInfo.CaseSeqNo = value;
                SessionData.Save();
            }

        }

        public int? Additional_Contact_Id
        {
            get
            {
                return ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.AdditionalContactId.HasValue) ?
                    (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.AdditionalContactId : -1;
            }
            set
            {
                SessionData.PolicyInfo.AdditionalContactId = value;
                SessionData.Save();
            }

        }


        public int Hist_Seq_No
        {
            get
            {
                return ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.HistSeqNo != 0) ?
                    (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.HistSeqNo : 0;
            }
            set
            {
                SessionData.PolicyInfo.HistSeqNo = value;
                SessionData.Save();
            }
        }

        //Informacion del Owner//
        public int Owner_Id
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.OwnerContactId != 0) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.OwnerContactId : -1;
            }
            set
            {
                SessionData.PolicyInfo.OwnerContactId = value;
                SessionData.Save();

            }
        }

        //Informacion del Contacto//
        public int? Insured_Contact_Id
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.InsuredContactId.HasValue) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.InsuredContactId : -1;
            }
            set
            {
                SessionData.PolicyInfo.InsuredContactId = value;
                SessionData.Save();

            }
        }

        //Estado del Caso//
        public string Case_Status
        {
            get { return (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CaseStatus; }
            set
            {
                SessionData.PolicyInfo.CaseStatus = value;
                SessionData.Save();
            }
        }

        //Contacto Actual//
        public int Current_Contact_Id
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CurrentContactId != 0) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CurrentContactId : -1;
            }
            set
            {
                SessionData.PolicyInfo.CurrentContactId = value;
                SessionData.Save();

            }
        }

        //Tipo de Contacto Actual//
        public ContactType Current_Contact_Type_Id
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CurrentContactTypeId.ToInt()>0) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.CurrentContactTypeId : ContactType.None;
            }
            set
            {
                SessionData.PolicyInfo.CurrentContactTypeId = value;
                SessionData.Save();

            }
        }

        public int Step_Type_Id
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StepTypeId != 0) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StepTypeId : -1;
            }
            set
            {
                SessionData.PolicyInfo.StepTypeId = value;
                SessionData.Save();

            }
        }

        public int Step_Id
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StepId != 0) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StepId : -1;
            }
            set
            {
                SessionData.PolicyInfo.StepId = value;
                SessionData.Save();

            }
        }

        public int Step_Case_No
        {
            get
            {
                return
                  ((HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StepCaseNo != 0) ?
                  (HttpContext.Current.Session[key] as SessionList).Stored.PolicyInfo.StepCaseNo : -1;
            }
            set
            {
                SessionData.PolicyInfo.StepCaseNo = value;
                SessionData.Save();

            }
        }

        /// <summary>
        /// Inicializa la session con los valores por defecto
        /// </summary>
        public void CleanSessionKeys()
        {
            SessionData.PolicyInfo.CleanSessionKeys();
            SessionData.Save();
        }

        public string mp3TempDir
        {
            get { return HttpContext.Current.Server.MapPath(@"~\TempFiles\Mp3\"); }
        }
        public string recordingsDir
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["Recording_path"]; }
        }
        public string SoxFilePath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["SoxExe_Path"]; }
        }

        #endregion
    }
}