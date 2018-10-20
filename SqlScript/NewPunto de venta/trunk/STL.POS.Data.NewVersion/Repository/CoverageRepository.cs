using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class CoverageRepository : BaseRepository
    {
        public CoverageRepository() { }

        #region Get
        public virtual CoverageExplication GetCoverageExplication(CoverageExplication.Parameter parameter)
        {
            CoverageExplication result;
            IEnumerable<SP_GET_COVERAGE_EXPLICATION_Result> temp;
            temp = PosContex.SP_GET_COVERAGE_EXPLICATION(parameter.coverageID);

            result = temp.Select(q => new CoverageExplication
            {
                CoverageID = q.CoverageID,
                Description = q.Description,
                Id = q.Id
            })
            .FirstOrDefault();

            return
                result;
        }
        #endregion

        #region Set
        public virtual BaseEntity SetCoverageDetail(Coverage.Parameter parameter)
        {
            BaseEntity result;
            IEnumerable<SP_SET_COVERAGE_DETAILS_Result> temp;
            temp = PosContex.SP_SET_COVERAGE_DETAILS(
                                                       parameter.id,
                                                       parameter.isSelected,
                                                       parameter.coverageDetailCoreId,
                                                       parameter.name,
                                                       parameter.amount,
                                                       parameter.minDeductible,
                                                       parameter.selfDamagesToProductLimits,
                                                       parameter.thirdPartyToProductLimits,
                                                       parameter.serviceType_Id,
                                                       parameter.limit,
                                                       parameter.userId,
                                                       parameter.deductible,
                                                       parameter.coveragePercentage,
                                                       parameter.baseDeductible
                                                    );

            result = temp.Select(q => new BaseEntity
            {
                Action = q.Action,
                EntityId = q.Id
            })
            .FirstOrDefault();

            return
                result;
        }
        #endregion
    }
}
