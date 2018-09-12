using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class AmmendmentRepository : GlobalRepository
    {
        public AmmendmentRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<Ammendment> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo)
        {
            IEnumerable<Ammendment> result;
            IEnumerable<SP_GET_PL_AMMENDMENTS_Result> temp;

            temp = globalModel.SP_GET_PL_AMMENDMENTS(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo);

            result = temp
                .Select(a => new Ammendment
                {
                    CorpId = a.Corp_Id,
                    RegionId = a.Region_Id,
                    CountryId = a.Country_Id,
                    DomesticregId = a.Domesticreg_Id,
                    StateProvId = a.State_Prov_Id,
                    CityId = a.City_Id,
                    OfficeId = a.Office_Id,
                    CaseSeqNo = a.Case_Seq_No,
                    HistSeqNo = a.Hist_Seq_No,
                    AmmendmentId = a.Ammendment_Id,
                    AmmendmentTypeId = a.Ammendment_Type_Id,
                    InsuredScopeId = a.Insured_Scope_Id,
                    AmmendmentDetId = a.Ammendment_Det_Id,
                    DocCategoryId = a.Doc_Category_Id,
                    DocTypeId = a.Doc_Type_Id,
                    DocumentId = a.Document_Id,
                    DocumentStatus = a.Document_Status,
                    DocCategoryDesc = a.Doc_Category_Desc,
                    DocTypeDesc = a.Doc_Type_Desc,
                    DateFrom = a.Date_From,
                    DateTo = a.Date_To,
                    Comments = a.Comments,
                    AmmendmentDate = a.Ammendment_Date,
                    SignatureReq = a.Signature_Req,
                    AmmendmentStatus = a.Ammendment_Status,
                    InsuredScopeDesc = a.Insured_Scope_Desc,
                    AmmendTypeDesc = a.Ammend_Type_Desc,
                    Status = a.Status,
                    DocumentBinary = null
                })
                .ToArray();

            return
                result;
        }

        public virtual Ammendment Get(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            Ammendment result;
            IEnumerable<SP_GET_PL_AMMENDMENT_Result> temp;

            temp = globalModel.SP_GET_PL_AMMENDMENT(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);

            result = temp
                .Select(a => new Ammendment
                {
                    CorpId = a.Corp_Id,
                    RegionId = a.Region_Id,
                    CountryId = a.Country_Id,
                    DomesticregId = a.Domesticreg_Id,
                    StateProvId = a.State_Prov_Id,
                    CityId = a.City_Id,
                    OfficeId = a.Office_Id,
                    CaseSeqNo = a.Case_Seq_No,
                    HistSeqNo = a.Hist_Seq_No,
                    AmmendmentId = a.Ammendment_Id,
                    AmmendmentTypeId = a.Ammendment_Type_Id,
                    InsuredScopeId = a.Insured_Scope_Id,
                    AmmendmentDetId = a.Ammendment_Det_Id,
                    DocCategoryId = a.Doc_Category_Id,
                    DocTypeId = a.Doc_Type_Id,
                    DocumentId = a.Document_Id,
                    DocumentStatus = a.Document_Status,
                    DocCategoryDesc = a.Doc_Category_Desc,
                    DocTypeDesc = a.Doc_Type_Desc,
                    DateFrom = a.Date_From,
                    DateTo = a.Date_To,
                    Comments = a.Comments,
                    AmmendmentDate = a.Ammendment_Date,
                    SignatureReq = a.Signature_Req,
                    AmmendmentStatus = a.Ammendment_Status,
                    InsuredScopeDesc = a.Insured_Scope_Desc,
                    AmmendTypeDesc = a.Ammend_Type_Desc,
                    Status = a.Status,
                    DocumentBinary = a.Document_Binary,
                    DocumentName = a.Document_Name
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual int Insert(Ammendment ammendment)
        {
            int result;
            IEnumerable<SP_SET_PL_AMMENDMENTS_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_PL_AMMENDMENTS(
                ammendment.CorpId,
                ammendment.RegionId,
                ammendment.CountryId,
                ammendment.DomesticregId,
                ammendment.StateProvId,
                ammendment.CityId,
                ammendment.OfficeId,
                ammendment.CaseSeqNo,
                ammendment.HistSeqNo,
                ammendment.AmmendmentId,
                ammendment.AmmendmentTypeId,
                ammendment.InsuredScopeId,
                ammendment.DateFrom,
                ammendment.DateTo,
                ammendment.Comments,
                ammendment.AmmendmentDate,
                ammendment.SignatureReq,
                ammendment.CreateUser,
                "INSERT");

            return
                result;
        }

        public virtual Ammendment.Detail InsertAmmendmentDetail(Ammendment.Detail ammeDet)
        {
            Ammendment.Detail result;
            IEnumerable<SP_SET_DOCUMENT_Result> tempDoc;
            IEnumerable<SP_SET_PL_AMMEND_DETAIL_Result> tempAmmDet;
            ObjectParameter documentId;

            documentId = new ObjectParameter("Document_Id", -1);
            result = null;

            tempDoc = globalModel.SP_SET_DOCUMENT(
                ammeDet.DocTypeId,
                ammeDet.DocCategoryId,
                documentId,
                ammeDet.DocumentBinary,
                ammeDet.DocumentName,
                ammeDet.CreationDate,
                ammeDet.ExpireDate,
                ammeDet.UserId
                ).ToArray();

            if (tempDoc != null && tempDoc.Any())
            {
                ammeDet.DocumentId = tempDoc.First().Document_Id.ConvertToNoNullable();

                tempAmmDet = globalModel.SP_SET_PL_AMMEND_DETAIL(
                ammeDet.CorpId,
                ammeDet.RegionId,
                ammeDet.CountryId,
                ammeDet.DomesticregId,
                ammeDet.StateProvId,
                ammeDet.CityId,
                ammeDet.OfficeId,
                ammeDet.CaseSeqNo,
                ammeDet.HistSeqNo,
                ammeDet.AmmendmentId,
                ammeDet.AmmendmentDetId,
                ammeDet.DocTypeId,
                ammeDet.DocCategoryId,
                ammeDet.DocumentId,
                ammeDet.ClientSignatureDate,
                ammeDet.UserId
                )
                .ToArray();

                if (tempAmmDet != null && tempAmmDet.Any())
                {
                    result = tempAmmDet.Select(d => new Ammendment.Detail
                    {
                        CorpId = d.Corp_Id.ConvertToNoNullable(),
                        RegionId = d.Region_Id.ConvertToNoNullable(),
                        CountryId = d.Country_Id.ConvertToNoNullable(),
                        DomesticregId = d.Domesticreg_Id.ConvertToNoNullable(),
                        StateProvId = d.State_Prov_Id.ConvertToNoNullable(),
                        CityId = d.City_Id.ConvertToNoNullable(),
                        OfficeId = d.Office_Id.ConvertToNoNullable(),
                        CaseSeqNo = d.Case_Seq_No.ConvertToNoNullable(),
                        HistSeqNo = d.Hist_Seq_No.ConvertToNoNullable(),
                        AmmendmentId = d.Ammendment_Id.ConvertToNoNullable(),
                        AmmendmentDetId = d.Ammendment_Det_Id.ConvertToNoNullable()
                    })
                    .First();
                }
            }

            return
                result;
        }
    }
}
