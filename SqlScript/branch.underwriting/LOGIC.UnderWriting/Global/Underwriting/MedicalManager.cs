using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class MedicalManager
    {
        private MedicalRepository _medicalRepository;

        public MedicalManager()
        {
            _medicalRepository = SingletonUnitOfWork.Instance.MedicalRepository;
        }

        public virtual IEnumerable<Medical> GetInfo(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                _medicalRepository.GetInfo(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                    , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        public virtual IEnumerable<Medical.Condition> GetCondition(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                _medicalRepository.GetCondition(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        public virtual IEnumerable<Medical.FamilyHistory> GetFamilyHistory(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                _medicalRepository.GetFamilyHistory(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                 , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        public virtual IEnumerable<Medical.ExamReceived> GetExamReceived(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo, int contactId)
        {
             return
                _medicalRepository.GetExamReceived(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId);
        }

        public virtual IEnumerable<Medical.ExamResult> GetExamResult(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId
            , int requirementCatId, int requirementTypeId, int requirementId, int medicalTestId)
        {
            return
                _medicalRepository.GetExamResult(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, requirementCatId, requirementTypeId, requirementId, medicalTestId);
        }

        public virtual int SetInfo(Medical info)
        {
            return
                  _medicalRepository.SetInfo(info);
        }

    }
}
