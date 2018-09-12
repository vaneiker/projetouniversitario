using System;
using System.Collections.Generic;

namespace Entity.UnderWriting.Entities
{
    public class Rider
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
        public int? SerieId { get; set; }
        public int RiderStatusId { get; set; }
        public int RiderTypeId { get; set; }
        public int RiderId { get; set; }
        public int? UntilAge { get; set; }
        public string RyderTypeDesc { get; set; }
        public string RiderStatusDesc { get; set; }
        public string SerieDesc { get; set; }
        public string SerieCode { get; set; }
        public decimal? BeneficiaryAmount { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal? ReinsuranceAmount { get; set; }
        public DateTime? ExpireDate { get; set; }
        public decimal? Premium { get; set; }
        public decimal? AnnualPremium { get; set; }
        public decimal? CashValue { get; set; }
        public decimal? LoanAmount { get; set; }
        public bool? Commissions { get; set; }
        public int? NumberOfYear { get; set; }
        public string ExtraPremiumCommentShort { get; set; }
        public string ExtraPremiumCommentCompleted { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string RiderInfo { get; set; }
        public int? SEGFAMADCount { get; set; }

        public int UserId { get; set; }

        public class Comment
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
            public int RiderTypeId { get; set; }
            public int Riderid { get; set; }
            public int CommentId { get; set; }
            public string CommentBody { get; set; }
            public DateTime CommentDate { get; set; }
            public int CommentIssuedBy { get; set; }
            public string CommentIssuedByName { get; set; }
            public int UserId { get; set; }
        }
    }
}
