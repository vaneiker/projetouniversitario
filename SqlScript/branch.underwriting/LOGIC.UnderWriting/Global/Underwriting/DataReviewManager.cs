using System;
using System.Collections.Generic;
using System.Data;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using System.Linq;
using LOGIC.UnderWriting.Common;

namespace LOGIC.UnderWriting.Global
{
    public class DataReviewManager
    {
        private DataReviewRepository _dataReviewRepository;
        private char[] _separtors;
        private string _dateFormat;

        public DataReviewManager()
        {
            _dataReviewRepository = SingletonUnitOfWork.Instance.DataReviewRepository;
            _separtors = new char[] { ';' };
            _dateFormat = "yyyy-MM-dd";
        }

        public virtual IEnumerable<DataReview> GetAll(Parameter.Case parameter)
        {
            return
                _dataReviewRepository.GetAll(parameter);
        }

        public virtual IEnumerable<DataReview.Change> GetAllRejected(int companyId, int underwriterId)
        {
            return
                _dataReviewRepository.GetAllRejected(companyId, underwriterId);
        }
        public virtual IEnumerable<DataReview.Change> GetAllApproved(int companyId, int underwriterId)
        {
            return
                _dataReviewRepository.GetAllApproved(companyId, underwriterId);
        }

        public virtual IEnumerable<Case.Process> GetAllInProcessNB(int companyId, int underwriterId)
        {
            return
                _dataReviewRepository.GetAllInProcessNB(companyId, underwriterId);
        }
        public virtual IEnumerable<Case.Process> GetAllInReviewNB(int companyId, int underwriterId)
        {
            return
                _dataReviewRepository.GetAllInReviewNB(companyId, underwriterId);
        }

        public virtual IEnumerable<DataReview.DocumentToReview> GetDocumentsToReview(Policy.Parameter policyParameter)
        {
            return
                 _dataReviewRepository.GetDocumentsToReview(policyParameter);
        }

        public virtual int SetDocumentReview(DataReview.DocumentToReview docReview)
        {
            return
                _dataReviewRepository.SetDocumentReview(docReview);
        }

        public virtual DataReview.DocumentInfomation GetDocument(DataReview.DocumentInfomation document)
        {
            if (document.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (document.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (document.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (document.DomesticRegId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (document.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (document.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (document.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (document.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (document.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (document.DocumentTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DocumentTypeId");
            if (document.DocumentCategoryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DocumentCategoryId");
            if (document.DocumentId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DocumentId");

            return
                _dataReviewRepository.GetDocument(document);
        }

        public virtual IEnumerable<DataReview.DRCaseResult> SendToUnderwriting(IEnumerable<DataReview.DRCase> drCases)
        {
            DataTable dt;
            IEnumerable<DataReview.DRCaseResult> result;

            if (drCases != null && drCases.Any())
            {
                foreach (DataReview.DRCase drCase in drCases)
                    this.IsValid(drCase, Utility.DataBaseActionType.Update);

                this.CreateDTPolicyContactMerge(out dt);
                this.ConvertPolicyContactMergeListToDT(drCases, ref dt);
                result = this.SendToUnderwriting(dt);
            }
            else
                result = null;

            return
                result;
        }

        public virtual IEnumerable<DataReview.ContactMerge> GetContactMerge(Policy.Parameter policyParameter)
        {
            return
                 _dataReviewRepository.GetContactMerge(policyParameter);
        }

        public virtual IEnumerable<DataReview.ContactMerge> GetContactMergeMath(IEnumerable<int> contactIds, int languageId)
        {
            IEnumerable<DataReview.ContactMerge> contactMergeContactMaths, contactMergeCompanyMaths, tempResult, resultWithoutFilter;
            List<DataReview.ContactMerge> result;
            DataReview.ContactMerge contactMerge;
            bool isContact;

            if (contactIds == null || !contactIds.Any())
                throw new ArgumentException("This property can't be null or empty.", "contactIds");

            tempResult = null;
            result = new List<DataReview.ContactMerge>(1);
            contactMergeContactMaths = null;
            contactMergeCompanyMaths = null;
            isContact = true;

            foreach (int contactId in contactIds)
            {
                contactMerge = this.GetContactMergeById(contactId);

                resultWithoutFilter = null;
                tempResult = null;

                switch (contactMerge.ContactTypeId)
                {
                    case 1:
                    case 4:
                    case 6:
                        if (contactMergeContactMaths == null)
                            contactMergeContactMaths = this.GetContactMergeToMath(contactMerge.ContactTypeId, languageId);

                        isContact = true;
                        break;
                    case 5:
                    case 7:
                        if (contactMergeCompanyMaths == null)
                            contactMergeCompanyMaths = this.GetContactMergeToMath(contactMerge.ContactTypeId, languageId);

                        isContact = false;
                        break;
                }

                resultWithoutFilter = (isContact ? contactMergeContactMaths : contactMergeCompanyMaths)
                                        .Select(cmm => { return this.GetWhereMath(cmm, contactMerge); })
                                        .ToArray();

                tempResult = resultWithoutFilter
                            .Where(cmm =>
                                            (cmm.MathName <= 0.05)
                                        || (cmm.MathName <= 0.10 && cmm.MathDob.Value)
                                        || (cmm.MathIds.Value))
                            .ToArray();

                tempResult = tempResult
                            .Where(cmm => cmm.ContactId != contactId)
                            .ToArray();

                if (tempResult != null)
                    result.AddRange(tempResult);
            }

            return
                result
                    .ToArray();
        }

        [ObsoleteAttribute("This method is deprecated.")]
        public virtual IEnumerable<DataReview.ContactMerge> GetContactMergeMath(int contactId, int languageId)
        {
            IEnumerable<DataReview.ContactMerge> contactMergeMaths, result, resultWithoutFilter;
            //DataReview.ContactMerge[] tempResult;
            DataReview.ContactMerge contactMerge;

            if (contactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "contactId");

            contactMerge = this.GetContactMergeById(contactId);
            contactMergeMaths = this.GetContactMergeToMath(contactMerge.ContactTypeId, languageId);

            if (contactMergeMaths != null && contactMergeMaths.Any())
            {
                resultWithoutFilter = contactMergeMaths
                            .Select(cmm => { return GetWhereMath(cmm, contactMerge); })
                            .ToArray();

                result = resultWithoutFilter
                            .Where(cmm =>
                                               (cmm.MathName <= 0.05)
                                            || (cmm.MathName <= 0.10 && cmm.MathDob.Value)
                                            || (cmm.MathIds.Value))
                            .ToArray();

                result = result
                            .Where(cmm => cmm.ContactId != contactId)
                            .ToArray();

                //if (result != null && result.Any())
                //{
                //    tempResult = result.ToArray();
                //    for (int i = 0; i < tempResult.Length; i++)
                //        tempResult[i].RowNumber = i;

                //    result = tempResult;
                //}
            }
            else
                result = null;

            return
                result;
        }

        private DataReview.ContactMerge GetWhereMath(DataReview.ContactMerge contactMergeMath, DataReview.ContactMerge contactMerge)
        {
            double percentage;
            string[] aIds;
            bool mathIds;
            string tempId;

            contactMergeMath.ContactIdMergeOwner = contactMerge.ContactId;

            contactMergeMath.MathDob = contactMergeMath.Dob.HasValue && contactMerge.Dob.HasValue
                                        ? contactMergeMath.Dob.Value.ToString(_dateFormat) == contactMerge.Dob.Value.ToString(_dateFormat)
                                        : false;

            if (!string.IsNullOrWhiteSpace(contactMerge.Ids) && !string.IsNullOrWhiteSpace(contactMergeMath.Ids))
            {
                mathIds = false;
                aIds = contactMerge.Ids.Split(_separtors, StringSplitOptions.RemoveEmptyEntries);

                if (aIds != null && aIds.Length > 0)
                {
                    tempId = contactMergeMath.Ids.Trim().ToLower();
                    for (int i = 0; i < aIds.Length; i++)
                        if (tempId.Contains(aIds[i].Trim().ToLower()))
                        {
                            mathIds = true;
                            break;
                        }
                }

                contactMergeMath.MathIds = mathIds;
            }
            else
                contactMergeMath.MathIds = false;


            if (!string.IsNullOrWhiteSpace(contactMerge.FullName) && !string.IsNullOrWhiteSpace(contactMergeMath.FullName))
            {
                this.EditDistance(contactMerge.FullName, contactMergeMath.FullName, out percentage);
                contactMergeMath.MathName = percentage;
            }
            else
                contactMergeMath.MathName = 0.99;

            return
                contactMergeMath;
        }

        private int EditDistance(string s, string t, out double percentage)
        {
            percentage = 0;

            // d es una tabla con m+1 renglones y n+1 columnas
            int costo = 0;
            int m = s.Length;
            int n = t.Length;
            int[,] d = new int[m + 1, n + 1];

            // Verifica que exista algo que comparar
            if (n == 0) return m;
            if (m == 0) return n;

            // Llena la primera columna y la primera fila.
            for (int i = 0; i <= m; d[i, 0] = i++) ;
            for (int j = 0; j <= n; d[0, j] = j++) ;


            /// recorre la matriz llenando cada unos de los pesos.
            /// i columnas, j renglones
            for (int i = 1; i <= m; i++)
            {
                // recorre para j
                for (int j = 1; j <= n; j++)
                {
                    /// si son iguales en posiciones equidistantes el peso es 0
                    /// de lo contrario el peso suma a uno.
                    costo = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1,   //Eliminacion
                                  d[i, j - 1] + 1),               //Inserccion 
                                  d[i - 1, j - 1] + costo);      //Sustitucion
                }
            }

            /// Calculamos el porcentaje de cambios en la palabra.
            if (s.Length > t.Length)
                percentage = ((double)d[m, n] / (double)s.Length);
            else
                percentage = ((double)d[m, n] / (double)t.Length);
            return d[m, n];
        }

        private IEnumerable<DataReview.ContactMerge> GetContactMergeToMath(int contactTypeId, int languageId)
        {
            return
                _dataReviewRepository.GetContactMergeMath(contactTypeId, languageId);
        }
        private DataReview.ContactMerge GetContactMergeById(int contactId)
        {
            return
                _dataReviewRepository.GetContactMergeById(contactId);
        }

        private IEnumerable<DataReview.DRCaseResult> SendToUnderwriting(DataTable drCase)
        {
            List<DataReview.DRCaseResult> result;
            DataReview.DRCaseResult tempResult;
            DataTable temp;

            try
            {
                temp = _dataReviewRepository.SendToUnderwriting(drCase);
                result = new List<DataReview.DRCaseResult>(1);

                if (temp != null && temp.Rows.Count > 0)
                {
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        tempResult = new DataReview.DRCaseResult
                        {
                            StatusCode = int.Parse(temp.Rows[i]["Status_Code"].ToString()),
                            Message = temp.Rows[i]["Message"].ToString()
                        };

                        result.Add(tempResult);
                    }
                }

                return
                    result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create the datatable equvalent to [Policy].[UDDT_PL_POLICY_CONTACT_MERGE] on db.
        /// </summary>
        private void CreateDTPolicyContactMerge(out DataTable dt)
        {
            dt = new DataTable();

            Type tipo = typeof(int);

            dt.Columns.Add("Corp_Id", tipo);
            dt.Columns.Add("Region_Id", tipo);
            dt.Columns.Add("Country_Id", tipo);
            dt.Columns.Add("Domesticreg_Id", tipo);
            dt.Columns.Add("State_Prov_Id", tipo);
            dt.Columns.Add("City_Id", tipo);
            dt.Columns.Add("Office_Id", tipo);
            dt.Columns.Add("Case_Seq_No", tipo);
            dt.Columns.Add("Hist_Seq_No", tipo);
            dt.Columns.Add("Current_Contact_Id", tipo);
            dt.Columns.Add("New_Contact_Id", tipo);
            dt.Columns.Add("UserId", tipo);
            dt.Columns.Add("RowNumber", tipo);
        }
        private void ConvertPolicyContactMergeListToDT(IEnumerable<DataReview.DRCase> drCases, ref DataTable dt)
        {
            int counter;
            counter = 1;
            
            foreach (DataReview.DRCase drCase in drCases)
            {
                dt.Rows.Add(
                        drCase.CorpId,
                        drCase.RegionId,
                        drCase.CountryId,
                        drCase.DomesticRegId,
                        drCase.StateProvId,
                        drCase.CityId,
                        drCase.OfficeId,
                        drCase.CaseSeqNo,
                        drCase.HistSeqNo,
                        drCase.CurrentContactId,
                        drCase.NewContactId,
                        drCase.UserId,
                        counter
                    );

                counter++;
            }
        }

        private void IsValid(DataReview.DRCase drCase, Utility.DataBaseActionType action)
        {
            if (drCase.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (drCase.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (drCase.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (drCase.DomesticRegId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticRegId");
            if (drCase.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (drCase.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (drCase.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (drCase.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (drCase.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (drCase.CurrentContactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CurrentContactId");
            if (drCase.UserId <= 0)
                throw new ArgumentException("This property can't be under 0.", "UserId");
            if (drCase.NewContactId.HasValue && drCase.NewContactId.Value <= 0)
                throw new ArgumentException("This property can't be under 0.", "NewContactId");
            if (drCase.NewContactId.HasValue && drCase.CurrentContactId == drCase.NewContactId.Value)
                throw new ArgumentException("This property can't be equal.", "CurrentContactId & NewContactId");

            //switch (action)
            //{
            //    case Utility.DataBaseActionType.Update:
            //    case Utility.DataBaseActionType.Delete:
            //        break;
            //    case Utility.DataBaseActionType.Insert:
            //        break;
            //    case Utility.DataBaseActionType.Select:
            //    default:
            //        break;
            //}
        }
    }
}
