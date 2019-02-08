using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class PolicyInformationViewModels : BaseViewModels
    {
        public int PolicyTypeId { get; set; }
        public int InsuranceCarrierId { get; set; }
        public string PolicyNo { get; set; }
        public decimal? PolicyAmount { get; set; }
        public int EstadoId { get; set; }
        public string Description { get; set; }
        public DateTime PolicyDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public PolicyType PolicyType { get; set; }
        public InsuranceCarrier InsuranceCarrier { get; set; }
        public PolicyEstado PolicyEstado { get; set; }
        public IEnumerable<Endoses> Endoses { get; set; }
    }

    public class PolicyType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class InsuranceCarrier
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class PolicyEstado
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Endoses
    {

        public int PolicyInformationId { get; set; }
        public long Number { get; set; }
        public decimal? Amount { get; set; }
        public DateTime BegininggDate { get; set; }
        public DateTime EndoseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string policyTypeName { get; set; }
        public string FullName { get; set; }
        public string policyNo { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string policyCollateralName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public string endorseNo { get; set; }
        public Nullable<decimal> endorseAmount { get; set; }
        public Nullable<System.DateTime> endorseInicialDate { get; set; }
        public Nullable<System.DateTime> endorseDate { get; set; }
        public Nullable<System.DateTime> endorseEffectiveDate { get; set; }
        public int collateralId { get; set; }
        public int companyId { get; set; }
        public Nullable<int> policyTypeId { get; set; }
        public Nullable<long> relatedContactId { get; set; }
        public string policyCollateralComment { get; set; }
        public Nullable<System.DateTime> notificationDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> ModiDate { get; set; }
        public int CreateUsrId { get; set; }
        public Nullable<int> ModiUsrId { get; set; }
        public string hostName { get; set; }
    }
}