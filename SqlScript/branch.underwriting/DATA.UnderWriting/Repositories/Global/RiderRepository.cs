using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class RiderRepository : GlobalRepository
    {
        public RiderRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<Rider> GetAll(Policy.Parameter policyParameter)
        {
            IEnumerable<Rider> result;
            IEnumerable<SP_GET_PL_RIDERS_Result> temp;

            temp = globalModel.SP_GET_PL_RIDERS(
                    policyParameter.CorpId,
                    policyParameter.RegionId,
                    policyParameter.CountryId,
                    policyParameter.DomesticregId,
                    policyParameter.StateProvId,
                    policyParameter.CityId,
                    policyParameter.OfficeId,
                    policyParameter.CaseSeqNo,
                    policyParameter.HistSeqNo,
                    policyParameter.LanguageId
                );

            result = temp
                .Select(r => new Rider
                {
                    CorpId = r.Corp_Id,
                    RegionId = r.Region_Id,
                    CountryId = r.Country_Id,
                    DomesticregId = r.Domesticreg_Id,
                    StateProvId = r.State_Prov_Id,
                    CityId = r.City_Id,
                    OfficeId = r.Office_Id,
                    CaseSeqNo = r.Case_seq_No,
                    HistSeqNo = r.Hist_Seq_No,
                    SerieId = r.Serie_Id,
                    RiderStatusId = r.Rider_Status_Id,
                    RiderTypeId = r.Rider_Type_Id,
                    RiderId = r.Rider_id,
                    UntilAge = r.Until_Age,
                    RyderTypeDesc = r.Ryder_Type_Desc,
                    RiderStatusDesc = r.Rider_Status_Desc,
                    SerieDesc = r.Serie_Desc,
                    SerieCode = r.Serie_Code,
                    BeneficiaryAmount = r.Beneficiary_Amount,
                    EffectiveDate = r.Effective_Date,
                    ReinsuranceAmount = r.Reinsurance_Amount,
                    ExpireDate = r.Expire_Date,
                    Premium = r.Premium,
                    AnnualPremium = r.Annual_Premium,
                    CashValue = r.Cash_Value,
                    LoanAmount = r.Loan_Amount,
                    Commissions = r.Commissions,
                    NumberOfYear = r.Number_Of_Year,
                    ExtraPremiumCommentShort = r.ExtraPremiumCommentShort,
                    ExtraPremiumCommentCompleted = r.ExtraPremiumCommentCompleted,
                    Comments = this.GetAllComments(policyParameter, r.Rider_Type_Id, r.Rider_id),
                    RiderInfo = r.Rider_Info,
                    SEGFAMADCount = r.SEGFAMAD_Count
                })
                .ToArray();

            return
                result;
        }

        public virtual int SetRider(Rider rider)
        {
            int result;
            IEnumerable<SP_SET_PL_RIDERS_Result> temp;

            temp = globalModel.SP_SET_PL_RIDERS(
                rider.CorpId,
                rider.RegionId,
                rider.CountryId,
                rider.DomesticregId,
                rider.StateProvId,
                rider.CityId,
                rider.OfficeId,
                rider.CaseSeqNo,
                rider.HistSeqNo,
                rider.RiderTypeId,
                rider.RiderId,
                rider.UntilAge,
                rider.BeneficiaryAmount,
                rider.EffectiveDate,
                rider.ReinsuranceAmount,
                rider.ExpireDate,
                rider.Premium,
                rider.AnnualPremium,
                rider.CashValue,
                rider.LoanAmount,
                rider.Commissions,
                rider.SerieId,
                rider.RiderStatusId,
                rider.NumberOfYear,
                rider.ExtraPremiumCommentCompleted,
                rider.RiderInfo,
                rider.UserId,null,null,null,null,null
                );
            result = -1;

            return
                result;
        }

        public virtual IEnumerable<Rider.Comment> GetAllComments(Policy.Parameter policyParameter, int riderTypeId, int riderId)
        {
            IEnumerable<Rider.Comment> result;
            IEnumerable<SP_GET_PL_RIDER_COMMENTS_Result> temp;

            temp = globalModel.SP_GET_PL_RIDER_COMMENTS(
                    policyParameter.CorpId,
                    policyParameter.RegionId,
                    policyParameter.CountryId,
                    policyParameter.DomesticregId,
                    policyParameter.StateProvId,
                    policyParameter.CityId,
                    policyParameter.OfficeId,
                    policyParameter.CaseSeqNo,
                    policyParameter.HistSeqNo,
                    riderTypeId, 
                    riderId);

            result = temp
                .Select(rc => new Rider.Comment
                {
                    CorpId = rc.Corp_Id,
                    RegionId = rc.Region_Id,
                    CountryId = rc.Country_Id,
                    DomesticregId = rc.Domesticreg_Id,
                    StateProvId = rc.State_Prov_Id,
                    CityId = rc.City_Id,
                    OfficeId = rc.Office_Id,
                    CaseSeqNo = rc.Case_seq_No,
                    HistSeqNo = rc.Hist_Seq_No,
                    RiderTypeId = rc.Rider_Type_Id,
                    Riderid = rc.Rider_id,
                    CommentId = rc.Comment_Id,
                    CommentBody = rc.Comment,
                    CommentDate = rc.Comment_Date,
                    CommentIssuedBy = rc.Comment_Issued_By,
                    CommentIssuedByName = rc.Comment_Issued_By_Name,
                })
                .ToArray();

            return
                result;
        }

        public virtual int InsertComment(Rider.Comment comment)
        {
            int result;
            IEnumerable<SP_INSERT_PL_RIDER_COMMENT_Result> temp;

            temp = globalModel.SP_INSERT_PL_RIDER_COMMENT(
                        comment.CorpId,
                        comment.RegionId,
                        comment.CountryId,
                        comment.DomesticregId,
                        comment.StateProvId,
                        comment.CityId,
                        comment.OfficeId,
                        comment.CaseSeqNo,
                        comment.HistSeqNo,
                        comment.RiderTypeId,
                        comment.Riderid,
                        comment.CommentBody,
                        comment.UserId
                );
            result = -1;

            return
                result;
        }

        public virtual int DeleteRider(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int? riderTypeId, int? riderId)
        {
            int result;
            IEnumerable<SP_DELETE_PL_RIDERS_Result> temp;

            temp = globalModel.SP_DELETE_PL_RIDERS(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, riderTypeId, riderId);
            result = -1;

            return
                result;
        }
    }
}
