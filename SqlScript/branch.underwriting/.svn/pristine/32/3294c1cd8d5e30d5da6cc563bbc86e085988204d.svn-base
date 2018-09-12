using System;
using System.Collections.Generic;
using System.Data;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Common;

namespace LOGIC.UnderWriting.Global
{
    public class FormManager
    {
        private FormRepository _formRepository;

        public FormManager()
        {
            _formRepository = SingletonUnitOfWork.Instance.FormRepository;
        }

        public virtual IEnumerable<Form.FieldValue> GetFormFieldValues(Form.FieldValue.Parameter parameters)
        {
            this.IsValid(parameters, Utility.DataBaseActionType.Select);

            if (!parameters.LanguageId.HasValue || parameters.LanguageId.Value <= 0)
                parameters.LanguageId = 2;

            return
                _formRepository.GetFormFieldValues(parameters);
        }

        public virtual DataTable GetFormDetailUddt()
        {
            return
                _formRepository.GetFormDetailUddt();
        }

        public virtual void SetFormDetail(DataTable formDetail)
        {
            _formRepository.SetFormDetail(formDetail);
        }

        private void IsValid(Form.FieldValue.Parameter parameters, Utility.DataBaseActionType action)
        {
            if (parameters.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (parameters.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (parameters.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (parameters.DomesticRegId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticRegId");
            if (parameters.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (parameters.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (parameters.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (parameters.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (parameters.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (parameters.ContactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactId");
            if (parameters.FormId <= 0)
                throw new ArgumentException("This property can't be under 0.", "FormId");

            //switch (action)
            //{
            //    case Utility.DataBaseActionType.Update:
            //    case Utility.DataBaseActionType.Delete:
            //    case Utility.DataBaseActionType.Insert:
            //    case Utility.DataBaseActionType.Select:
            //    default:
            //        break;
            //}
        }
    }
}
