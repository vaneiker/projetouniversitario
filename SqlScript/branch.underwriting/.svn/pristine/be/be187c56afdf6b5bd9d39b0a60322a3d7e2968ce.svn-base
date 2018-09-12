using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class MedicalBll :IMedical
    {
        private MedicalManager _medicalManager; 
        public MedicalBll()
        {
            _medicalManager = new MedicalManager();
        }

        IEnumerable<Medical> IMedical.GetInfo(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                  _medicalManager.GetInfo(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                      , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        IEnumerable<Medical.Condition> IMedical.GetCondition(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                _medicalManager.GetCondition(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                    , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        IEnumerable<Medical.FamilyHistory> IMedical.GetFamilyHistory(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                 _medicalManager.GetFamilyHistory(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                     , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        int IMedical.SetInfo(Medical info)
        {
            return
                _medicalManager.SetInfo(info);
        }


        IEnumerable<Medical.ExamReceived> IMedical.GetExamReceived(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId)
        {
            return
                 _medicalManager.GetExamReceived(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                 , officeId, caseSeqNo, histSeqNo, contactId);
        }

        IEnumerable<Medical.ExamResult> IMedical.GetExamResult(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId, int medicalTestId)
        {
            return
                _medicalManager.GetExamResult(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, requirementCatId, requirementTypeId, requirementId, medicalTestId);
        }
    }
    public class MedicalWS : IMedical
    {
        IEnumerable<Medical> IMedical.GetInfo(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Medical.Condition> IMedical.GetCondition(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Medical.FamilyHistory> IMedical.GetFamilyHistory(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            throw new NotImplementedException();
        }

        int IMedical.SetInfo(Medical info)
        {
            throw new NotImplementedException();
        }


        IEnumerable<Medical.ExamReceived> IMedical.GetExamReceived(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Medical.ExamResult> IMedical.GetExamResult(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId, int medicalTestId)
        {
            throw new NotImplementedException();
        }
    }
}
