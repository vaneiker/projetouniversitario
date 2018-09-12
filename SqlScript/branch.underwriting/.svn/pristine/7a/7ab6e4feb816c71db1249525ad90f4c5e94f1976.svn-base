using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class PaymentRepository : GlobalRepository
    {
        public PaymentRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual Payment GetHeader(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo)
        {
            Payment result;
            IEnumerable<SP_GET_PAYMENTS_HEADER_Result> temp;

            temp = globalModel.SP_GET_PAYMENTS_HEADER(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo);

            result = temp
                .Select(p => new Payment
                {
                    PolicyNo = p.Policy_No,
                    CorpId = p.Corp_Id,
                    RegionId = p.Region_Id,
                    CountryId = p.Country_Id,
                    DomesticregId = p.Domesticreg_Id,
                    StateProvId = p.State_Prov_Id,
                    CityId = p.City_Id,
                    OfficeId = p.Office_Id,
                    CaseSeqNo = p.Case_seq_No,
                    HistSeqNo = p.Hist_Seq_No,
                    PaymentFreqTypeId = p.Payment_Freq_Type_Id,
                    PaymentFreqId = p.Payment_Freq_Id,
                    AnnualPremium = p.Annual_Premium,
                    PaymentFreqTypeDesc = p.Payment_Freq_Type_Desc,
                    PremiumRecieved = p.Premium_Recieved,
                    AccountAmount = p.Account_Amount,
                    PeriodicPremium = p.Periodic_Premium,
                    MinimunPremiunAmount = p.Minimun_Premiun_Amount,
                    InitialContribution = p.Initial_Contribution,
                    PolicyEffectiveDate = p.Policy_Effective_Date,
                    MinimunPremiunAmountAnnual = p.Minimun_Premiun_Amount_Annual,
                    PolicyYear = p.PolicyYear,
                    PaymentPlan = p.Payment_Plan,
                    PaymentPlanEndDate = p.Payment_Plan_End_Date,
                    PaymentPlanStartDate = p.Payment_Plan_Start_Date,
                    PaymentDate = p.Payment_Date.ConvertToNoNullable(),
                    PaymentStatus = p.Payment_Status,
                    PaymentAmount = p.PaymentAmount,
                    Periods = GetPeriodPaymentPolicy(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo)
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual IEnumerable<Payment.Detail> GetAllDetail(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId
            , int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int? paymentStatusId)
        {
            IEnumerable<Payment.Detail> result;
            IEnumerable<SP_GET_PAYMENTS_PAYMENTS_Result> temp;

            temp = globalModel.SP_GET_PAYMENTS_PAYMENTS(coprId, regionId, countryId, domesticRegId
                    , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, paymentStatusId);

            result = temp
                .Select(pd => new Payment.Detail
                {
                    CorpId = pd.Corp_Id,
                    RegionId = pd.Region_Id,
                    CountryId = pd.Country_Id,
                    DomesticregId = pd.Domesticreg_Id,
                    StateProvId = pd.State_Prov_Id,
                    CityId = pd.City_Id,
                    OfficeId = pd.Office_Id,
                    CaseSeqNo = pd.Case_Seq_No,
                    HistSeqNo = pd.Hist_Seq_No,
                    PaymentId = pd.Payment_Id,
                    PaymentStatusId = pd.Payment_Status_Id,
                    DocumentTypeId = pd.Doc_Type_Id,
                    DocumentCategoryId = pd.Doc_Category_Id,
                    DocumentId = pd.Document_Id,
                    DueDate = pd.Due_Date,
                    PaidDate = pd.Paid_Date,
                    DueAmount = pd.Due_Amount,
                    PaidAmount = pd.Paid_Amount,
                    PaymentSourceDesc = pd.Payment_Source_Desc,
                    PaymentStatusDesc = pd.Payment_Status_Desc,
                    PolicyNo = pd.Policy_No,
                    HasDocument = pd.HasDocument.Value
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Payment.ApplyPaymentDetail> GetAllApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int paymentId, int? paymentDetId, int languageId)
        {
            IEnumerable<Payment.ApplyPaymentDetail> result;
            IEnumerable<SP_GET_PM_PAYMENTS_DETAILS_Result> temp;

            temp = globalModel.SP_GET_PM_PAYMENTS_DETAILS(coprId, regionId, countryId, domesticRegId
                    , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, paymentId, paymentDetId, languageId);

            result = temp
                .Select(pd => new Payment.ApplyPaymentDetail
                {
                    CorpId = pd.Corp_Id,
                    RegionId = pd.Region_Id,
                    CountryId = pd.Country_Id,
                    DomesticregId = pd.Domesticreg_Id,
                    StateProvId = pd.State_Prov_Id,
                    CityId = pd.City_Id,
                    OfficeId = pd.Office_Id,
                    CaseSeqNo = pd.Case_Seq_No,
                    HistSeqNo = pd.Hist_Seq_No,
                    PaymentId = pd.Payment_Id,
                    PaymentDetId = pd.PaymentDet_Id,
                    ReceiptTypeId = pd.Receipt_Type_Id,
                    PaymentSourceId = pd.Payment_Source_Id,
                    PaymentDetailSourceId = pd.Payment_Detail_Source_Id,
                    CurrencyId = pd.Currency_Id,
                    DocumentTypeId = pd.Doc_Type_Id,
                    DocumentCategoryId = pd.Doc_Category_Id,
                    DocumentId = pd.Document_Id,
                    OriginCreditAmount = pd.Origin_Credit_Amount,
                    OriginDebitAmount = pd.Origin_Debit_Amount,
                    UsdCreditAmount = pd.Usd_Credit_Amount,
                    UsdDebitAmount = pd.Usd_Debit_Amount,
                    Rate = pd.Rate,
                    TransactionDate = pd.Transaction_Date,
                    DueDate = pd.Due_Date,
                    PostedAmount = pd.Posted_Amount,
                    PostedDate = pd.Posted_Date,
                    ReceiptDate = pd.Receipt_Date,
                    TransactionDescription = pd.Transaction_Description,
                    TransactionReference = pd.Transaction_Reference,
                    EFTAccountNumber = pd.EFT_Account_Number,
                    EFTAccountHolder = pd.EFT_Account_Holder,
                    EFTAccountHolderSource = pd.EFT_Account_Holder_Source,
                    OtherDescription = pd.Other_Description,
                    ResultCode = pd.Result_Code,
                    PaymentStatus = pd.Payment_Status,
                    ReceiptTypeDesc = pd.Receipt_Type_Desc,
                    PaymentStatusDesc = pd.Payment_Status_Desc,
                    PaymentSourceDesc = pd.Payment_Source_Desc,
                    DocumentCategoryDesc = pd.Doc_Category_Desc,
                    HasDocument = pd.HasDocument.ConvertToNoNullable(),
                    SeqNo = pd.Seq_No,
                    TypeId = pd.Type_Id,
                    EffectiveDate = pd.Effective_Date,
                    ExpireDate = pd.Expire_Date,
                    Number = pd.Number,
                    ControlDigit = pd.Control_Digit,
                    Name = pd.Name,
                    Status = pd.Status,
                    AccountDesc = pd.Account_Desc,
                    AccountTypeId = pd.Account_Type_Id,
                    CardTypeDesc = pd.Card_Type_Desc,
                    PaymentSourceTypeId = pd.Payment_Source_Type_Id,
                    RelationshipToOwnerOrInsured = pd.Relationship_To_Owner_Or_Insured,
                    PaymentControlId = pd.Payment_Control_Id,
                    EFTDate = pd.EFT_Date,
                    EFTABANumber = pd.EFT_ABA_Number,
                    PaymentDocumentation = pd.PaymentDocumentation,
                    PaymentStatusId = pd.Payment_Status_Id,
                    PaidDate = pd.Paid_Date
                })
                .ToArray();

            return
                result;
        }

        public virtual Payment.DocumentInfomation GetDocument(int coprId, int regionId, int countryId
          , int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            Payment.DocumentInfomation result;
            IEnumerable<SP_GET_PAYMENTS_PAYMENTS_DOCUMENT_Result> temp;

            temp = globalModel.SP_GET_PAYMENTS_PAYMENTS_DOCUMENT(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);

            result = temp
                .Select(pd => new Payment.DocumentInfomation
                {
                    CorpId = pd.Corp_Id.Value,
                    RegionId = pd.Region_Id.Value,
                    CountryId = pd.Country_Id.Value,
                    DomesticregId = pd.Domesticreg_Id.Value,
                    StateProvId = pd.State_Prov_Id.Value,
                    CityId = pd.City_Id.Value,
                    OfficeId = pd.Office_Id.Value,
                    CaseSeqNo = pd.Case_Seq_No.Value,
                    HistSeqNo = pd.Hist_Seq_No.Value,
                    DocumentCategoryId = pd.Doc_Category_Id,
                    DocumentTypeId = pd.Doc_Type_Id,
                    DocumentId = pd.Document_Id,
                    DocumentName = pd.Document_Name,
                    FileCreationDate = pd.File_Creation_Date,
                    DocumentTypeDescription = pd.Doc_Type_Desc,
                    ContentType = pd.Content_Type,
                    Extension = pd.Extension,
                    DocumentBinary = pd.Document_Binary
                })
                .FirstOrDefault();

            return
                result;
        }

        private IEnumerable<Payment.Period> GetPeriodPaymentPolicy(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo)
        {
            IEnumerable<Payment.Period> result;
            IEnumerable<SP_GET_PAYMENTS_HEADER_DATES_PERIODS_Result> temp;

            temp = globalModel.SP_GET_PAYMENTS_HEADER_DATES_PERIODS(coprId, regionId, countryId, domesticRegId
                    , stateProvId, cityId, officeId, caseSeqNo, histSeqNo);

            result = temp
                .Select(p => new Payment.Period
                {
                    PayMonth = p.PayMonth,
                    PayDate = p.PayDate
                })
                .ToArray();

            return
                result;
        }

        public virtual Payment.ApplyPayment GetPayment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int paymentId)
        {
            Payment.ApplyPayment result;
            IEnumerable<SP_GET_PM_PAYMENTS_Result> temp;

            temp = globalModel.SP_GET_PM_PAYMENTS(coprId, regionId, countryId, domesticRegId
                    , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, paymentId);

            result = temp
                .Select(p => new Payment.ApplyPayment
                {
                    CorpId = p.Corp_Id,
                    RegionId = p.Region_Id,
                    CountryId = p.Country_Id,
                    DomesticregId = p.Domesticreg_Id,
                    StateProvId = p.State_Prov_Id,
                    CityId = p.City_Id,
                    OfficeId = p.Office_Id,
                    CaseSeqNo = p.Case_Seq_No,
                    HistSeqNo = p.Hist_Seq_No,
                    PaymentId = p.Payment_Id,
                    DueAmount = p.Due_Amount,
                    PeriodicPremiumAmount = p.Periodic_Premium_Amount,
                    BasePremium = p.Base_Premium,
                    ExceptionalPremiun = p.Exceptional_premium,
                    ExceptionalPremiun2 = p.Exceptional_premium2,
                    BaseCommision = p.Base_Commision,
                    BaseCommision2 = p.Base_Commision2,
                    ExceptionalCommisions = p.Exceptional_Commisions,
                    ExceptionalCommisions2 = p.Exceptional2_Commisions,
                    DueDate = p.Due_Date,
                    PaidDate = p.Paid_Date,
                    PaidAmount = p.Paid_Amount,
                    PaymentStatusId = p.Payment_Status_Id
                })
                .FirstOrDefault();

            return
                result;
        }
        
        public virtual Payment.ApplyPayment SetPayment(Payment.ApplyPayment payment)
        {
            Payment.ApplyPayment result;
            IEnumerable<SP_SET_PM_PAYMENTS_Result> temp;

            temp = globalModel.SP_SET_PM_PAYMENTS(
                        payment.CorpId,
                        payment.RegionId,
                        payment.CountryId,
                        payment.DomesticregId,
                        payment.StateProvId,
                        payment.CityId,
                        payment.OfficeId,
                        payment.CaseSeqNo,
                        payment.HistSeqNo,
                        payment.PaymentId,
                        payment.DueAmount,
                        payment.PeriodicPremiumAmount,
                        payment.BasePremium,
                        payment.ExceptionalPremiun,
                        payment.ExceptionalPremiun2,
                        payment.BaseCommision,
                        payment.BaseCommision2,
                        payment.ExceptionalCommisions,
                        payment.ExceptionalCommisions2,
                        payment.DueDate,
                        payment.PaidDate,
                        payment.PaidAmount,
                        payment.PaymentStatusId,
                        payment.UserId
                    )
                    .ToArray();

            if (temp != null && temp.Any())
            {
                result = temp
                    .Select(p => new Payment.ApplyPayment
                        {
                            CorpId = p.Corp_Id.Value,
                            RegionId = p.Region_Id.Value,
                            CountryId = p.Country_Id.Value,
                            DomesticregId = p.Domesticreg_Id.Value,
                            StateProvId = p.State_Prov_Id.Value,
                            CityId = p.City_Id.Value,
                            OfficeId = p.Office_Id.Value,
                            CaseSeqNo = p.Case_Seq_No.Value,
                            HistSeqNo = p.Hist_Seq_No.Value,
                            PaymentId = p.Payment_Id.Value
                        })
                    .FirstOrDefault();
            }
            else
                result = null;

            return
                result;
        }

        public virtual int DeletePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            int result;
            IEnumerable<SP_DELETE_PM_PAYMENTS_DETAILS_Result> temp;

            try
            {
                result = -1;
                temp = globalModel.SP_DELETE_PM_PAYMENTS_DETAILS(
                        paymentDetail.CorpId,
                        paymentDetail.RegionId,
                        paymentDetail.CountryId,
                        paymentDetail.DomesticregId,
                        paymentDetail.StateProvId,
                        paymentDetail.CityId,
                        paymentDetail.OfficeId,
                        paymentDetail.CaseSeqNo,
                        paymentDetail.HistSeqNo,
                        paymentDetail.PaymentId,
                        paymentDetail.PaymentDetId,
                        paymentDetail.UserId
                    );
            }
            catch (Exception)
            {
                result = -2;
            }

            return
                result;
        }
        
        public virtual Payment.ApplyPaymentDetail SetPaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            Payment.ApplyPaymentDetail result;
            IEnumerable<SP_SET_PM_PAYMENTS_DETAILS_ALL_Result> temp;

            temp = globalModel.SP_SET_PM_PAYMENTS_DETAILS_ALL(
                        paymentDetail.CorpId,
                        paymentDetail.RegionId,
                        paymentDetail.CountryId,
                        paymentDetail.DomesticregId,
                        paymentDetail.StateProvId,
                        paymentDetail.CityId,
                        paymentDetail.OfficeId,
                        paymentDetail.CaseSeqNo,
                        paymentDetail.HistSeqNo,
                        paymentDetail.PaymentId,
                        paymentDetail.RelationshipToOwnerOrInsured,
                        paymentDetail.PaymentDetId,
                        paymentDetail.ReceiptTypeId,
                        paymentDetail.PaymentSourceTypeId,
                        paymentDetail.PaymentSourceId,
                        paymentDetail.AccountTypeId,
                        paymentDetail.PaymentControlId,
                        paymentDetail.PaymentDetailSourceId,
                        paymentDetail.CurrencyId,
                        paymentDetail.DocumentTypeId,
                        paymentDetail.DocumentCategoryId,
                        paymentDetail.DocumentId,
                        paymentDetail.OriginCreditAmount,
                        paymentDetail.OriginDebitAmount,
                        paymentDetail.UsdCreditAmount,
                        paymentDetail.UsdDebitAmount,
                        paymentDetail.Rate,
                        paymentDetail.TransactionDate,
                        paymentDetail.DueDate,
                        paymentDetail.PostedAmount,
                        paymentDetail.PostedDate,
                        paymentDetail.ReceiptDate,
                        paymentDetail.TransactionDescription,
                        paymentDetail.TransactionReference,
                        paymentDetail.EFTDate,
                        paymentDetail.EFTABANumber,
                        paymentDetail.EFTAccountNumber,
                        paymentDetail.EFTAccountHolder,
                        paymentDetail.EFTAccountHolderSource,
                        paymentDetail.OtherDescription,
                        paymentDetail.ResultCode,
                        paymentDetail.OrderId,
                        paymentDetail.PaymentStatusId,
                        paymentDetail.PaymentStatus,
                        paymentDetail.SeqNo,
                        paymentDetail.TypeId,
                        paymentDetail.EffectiveDate,
                        paymentDetail.ExpireDate,
                        paymentDetail.Number,
                        paymentDetail.ControlDigit,
                        paymentDetail.Name,
                        paymentDetail.Status,
                        paymentDetail.UserId
                    )
                    .ToArray();

            if (temp != null && temp.Any())
            {
                result = temp
                    .Select(pd => new Payment.ApplyPaymentDetail
                    {
                        CorpId = pd.Corp_Id.ConvertToNoNullable(),
                        RegionId = pd.Region_Id.ConvertToNoNullable(),
                        CountryId = pd.Country_Id.ConvertToNoNullable(),
                        DomesticregId = pd.Domesticreg_Id.ConvertToNoNullable(),
                        StateProvId = pd.State_Prov_Id.ConvertToNoNullable(),
                        CityId = pd.City_Id.ConvertToNoNullable(),
                        OfficeId = pd.Office_Id.ConvertToNoNullable(),
                        CaseSeqNo = pd.Case_Seq_No.ConvertToNoNullable(),
                        HistSeqNo = pd.Hist_Seq_No.ConvertToNoNullable(),
                        PaymentId = pd.Payment_Id.ConvertToNoNullable(),
                        PaymentDetId = pd.PaymentDet_Id.ConvertToNoNullable(),
                        SeqNo = pd.Seq_No
                    })
                    .FirstOrDefault();
            }
            else
                result = null;

            return
                result;
        }
        
        public virtual int SetPaymentStatus(Payment.ApplyPayment payment)
        {
            int result;
            IEnumerable<SP_SET_PM_PAYMENTS_STATUS_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_PM_PAYMENTS_STATUS(
                        payment.CorpId,
                        payment.RegionId,
                        payment.CountryId,
                        payment.DomesticregId,
                        payment.StateProvId,
                        payment.CityId,
                        payment.OfficeId,
                        payment.CaseSeqNo,
                        payment.HistSeqNo,
                        payment.PaymentId,
                        payment.PaymentStatusId,
                        payment.UserId
                    );
            return
                result;
        }

        public virtual int SetPaymentDetailDocument(Payment.Document doc)
        {
            int result;
            IEnumerable<SP_SET_PM_PAYMENTS_DETAILS_DOCUMENT_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_PM_PAYMENTS_DETAILS_DOCUMENT(
                        doc.PaymentDetId,
                        doc.DocumentTypeId,
                        doc.DocumentCategoryId,
                        doc.DocumentId,
                        doc.DocumentBinary,
                        doc.DocumentName,
                        doc.FileCreationDate,
                        doc.FileExpireDate,
                        doc.UserId
                    );
            return
                result;
        }

        public virtual int SetPaymentDetailStatusByOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            int result;
            IEnumerable<SP_SET_PM_PAYMENTS_DETAILS_STATUS_BY_ORDER_ID_Result> temp;

            temp = globalModel.SP_SET_PM_PAYMENTS_DETAILS_STATUS_BY_ORDER_ID(
                        paymentDetail.OrderId,
                        paymentDetail.PaymentStatusId,
                        paymentDetail.SeqNo
                    );

            result = -1;

            return
                result;
        }

        public virtual Payment.Agreement SetPaymentAgreement(Payment.Agreement parameter)
        {
            Payment.Agreement result;
            IEnumerable<SP_SET_PM_PAYMENT_AGREEMENT_Result> temp;

            temp = globalModel.SP_SET_PM_PAYMENT_AGREEMENT(
                        parameter.CorpId,
                        parameter.RegionId,
                        parameter.CountryId,
                        parameter.DomesticregId,
                        parameter.StateProvId,
                        parameter.CityId,
                        parameter.OfficeId,
                        parameter.CaseSeqNo,
                        parameter.HistSeqNo,
                        parameter.PaymentAgreementId,
                        parameter.PaymentsAgreementQty,
                        parameter.DiscountPercentage,
                        parameter.DiscountAmount,
                        parameter.DiscountNameKey,
                        parameter.SurchargePercentage,
                        parameter.SurchargeAmount,
                        parameter.SurchargeNameKey,
                        parameter.InitialPayment,
                        parameter.TotalAgreementPayment,
                        parameter.ExternalId,
                        parameter.UserId
                    )
                    .ToArray();    

            if (temp != null && temp.Any())
            {
                result = temp
                    .Select(p => new Payment.Agreement
                    {
                        CorpId = p.Corp_Id,
                        RegionId = p.Region_Id,
                        CountryId = p.Country_Id,
                        DomesticregId = p.Domesticreg_Id,
                        StateProvId = p.State_Prov_Id,
                        CityId = p.City_Id,
                        OfficeId = p.Office_Id,
                        CaseSeqNo = p.Case_Seq_No,
                        HistSeqNo = p.Hist_Seq_No,
                        PaymentAgreementId = p.Payment_Agreement_Id
                    })
                    .FirstOrDefault();
            }
            else
                result = null;

            return
                result;
        }

        public virtual Payment.Agreement GetPaymentAgreement(Payment.Agreement parameter)
        {
            Payment.Agreement result;
            IEnumerable<SP_GET_PM_PAYMENT_AGREEMENT_Result> temp;

            temp = globalModel.SP_GET_PM_PAYMENT_AGREEMENT(
                        parameter.CorpId,
                        parameter.RegionId,
                        parameter.CountryId,
                        parameter.DomesticregId,
                        parameter.StateProvId,
                        parameter.CityId,
                        parameter.OfficeId,
                        parameter.CaseSeqNo,
                        parameter.HistSeqNo
                    )
                    .ToArray();

            if (temp != null && temp.Any())
            {
                result = temp
                    .Select(p => new Payment.Agreement
                    {
                        CorpId = p.Corp_Id,
                        RegionId = p.Region_Id,
                        CountryId = p.Country_Id,
                        DomesticregId = p.Domesticreg_Id,
                        StateProvId = p.State_Prov_Id,
                        CityId = p.City_Id,
                        OfficeId = p.Office_Id,
                        CaseSeqNo = p.Case_Seq_No,
                        HistSeqNo = p.Hist_Seq_No,
                        PaymentAgreementId = p.Payment_Agreement_Id,
                        PaymentsAgreementQty = p.Payments_Agreement_Qty,
                        DiscountPercentage = p.Discount_Percentage,
                        DiscountAmount = p.Discount_Amount,
                        InitialPayment = p.Initial_Payment
                    })
                    .FirstOrDefault();
            }
            else
                result = null;

            return
                result;
        }  

        public virtual IEnumerable<Payment.Agreement.Quot> GetPaymentAgreementQuots(Payment.Agreement parameter)
        {
            IEnumerable<Payment.Agreement.Quot> result;
            IEnumerable<GetPaymentAgreementQuots_Result> temp;

            temp = globalModelExtended.GetPaymentAgreementQuots(
                        parameter.CorpId,
                        parameter.RegionId,
                        parameter.CountryId,
                        parameter.DomesticregId,
                        parameter.StateProvId,
                        parameter.CityId,
                        parameter.OfficeId,
                        parameter.CaseSeqNo,
                        parameter.HistSeqNo
                    )
                    .ToArray();

            if (temp != null && temp.Any())
            {
                result = temp
                    .Select(p => new Payment.Agreement.Quot
                    {
                        TypeQty = p.TypeQty,
                        NumberOfQTy = p.NumberOfQTy,
                        ValueQty = p.ValueQty
                    });                    
            }
            else
                result = null;

            return
                result;
        }

        #region Provider
        public virtual int InsertPaymentLog(Payment.Provider.Log log)
        {
            int result;
            IEnumerable<SP_INSERT_PM_PROVIDER_LOG_Result> temp;

            temp = globalModel.SP_INSERT_PM_PROVIDER_LOG(
                        log.LogTypeId,
                        log.CorpId,
                        log.CompanyId,
                        log.ProjectId,
                        log.OrderId,
                        log.LogDesc
                    );

            result = 1;

            return
                result;
        }

        public virtual Payment.Provider.Log GetPaymentLog(Payment.Provider.Log log)
        {
            Payment.Provider.Log result;
            IEnumerable<SP_GET_PM_PROVIDER_LOG_Result> temp;

            temp = globalModel.SP_GET_PM_PROVIDER_LOG(
                    log.OrderId
                );

            result = temp
                .Select(t => new Payment.Provider.Log
                {
                    CorpId = t.Corp_Id,
                    CompanyId = t.Company_Id,
                    ProjectId = t.Project_Id,
                    OrderId = t.Order_Id
                })
                .FirstOrDefault();
            return
                result;
        }

        public virtual IEnumerable<Payment.Provider.Parameter> GetProviderParameter(Payment.Provider.Parameter parameter)
        {
            IEnumerable<Payment.Provider.Parameter> result;
            IEnumerable<SP_GET_PM_PROVIDER_PARAMETER_Result> temp;

            temp = globalModel.SP_GET_PM_PROVIDER_PARAMETER(
                    parameter.ProviderId,
                    parameter.TransactionTypeCatalogId,
                    parameter.ProviderTransactionTypeId
                );

            result = temp
                .Select(p => new Payment.Provider.Parameter
                {
                    ProviderId = p.Provider_Id,
                    TransactionTypeCatalogId = p.Transaction_Type_Catalog_Id,
                    ProviderTransactionTypeId = p.Provider_Transaction_Type_Id,
                    ParameterId = p.Parameter_Id,
                    ParameterTypeValueId = p.Parameter_Type_Value_Id,
                    ParameterName = p.Parameter_Name,
                    ParameterValue = p.Parameter_Value,
                    ParameterTypeValueDesc = p.Parameter_Type_Value_Desc,
                    OrderBy = p.Order_By
                })
                .ToArray();

            return
                result;
        }

        public virtual Payment.Provider.Transaction SetProviderTransaction(Payment.Provider.Transaction transaction)
        {
            Payment.Provider.Transaction result;
            IEnumerable<SP_SET_PM_PROVIDER_TRANSACTION_Result> temp;

            temp = globalModel.SP_SET_PM_PROVIDER_TRANSACTION(
                    transaction.ProviderId,
                    transaction.TransactionKeyId,
                    transaction.TransactionTypeCatalogId,
                    transaction.ProviderTransactionTypeId,
                    transaction.TransactionId,
                    transaction.TransactionDate,
                    transaction.CreditCardNumber,
                    transaction.CreditCardExpirationDate,
                    transaction.Amount,
                    transaction.Tax,
                    transaction.ResponseCode,
                    transaction.AuthorizationCode,
                    transaction.RetrievalReferenceNumber,
                    transaction.OrderId,
                    transaction.TransactionExtraData,
                    transaction.UserId
                );

            result = temp
                .Select(t => new Payment.Provider.Transaction
                {
                    Action = t.Action,
                    ProviderId = t.Provider_Id.ConvertToNoNullable(),
                    TransactionKeyId = t.Transaction_Key_Id.ConvertToNoNullable()
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual Payment.Provider.Transaction GetProviderTransactionInfoKey(Payment.Provider.Transaction transaction)
        {
            Payment.Provider.Transaction result;
            IEnumerable<SP_SET_PM_PROVIDER_TRANSACTION_INFO_KEY_Result> temp;

            temp = globalModel.SP_SET_PM_PROVIDER_TRANSACTION_INFO_KEY(
                    transaction.ProviderId,
                    transaction.TransactionTypeCatalogId,
                    transaction.ProviderTransactionTypeId,
                    transaction.UserId
                );

            result = temp
                .Select(t => new Payment.Provider.Transaction
                {
                    ProviderId = t.Provider_Id.ConvertToNoNullable(),
                    TransactionKeyId = t.Transaction_Key_Id,
                    TransactionTypeCatalogId = t.Transaction_Type_Catalog_Id,
                    ProviderTransactionTypeId = t.Provider_Transaction_Type_Id,
                    TransactionId = t.Transaction_Id,
                    TransactionDate = t.Transaction_Date.ConvertToNoNullable(),
                    OrderId = t.Order_Id
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual Payment.Provider.Transaction GetProviderTransactionByOrderId(Payment.Provider.Transaction transaction)
        {
            Payment.Provider.Transaction result;
            IEnumerable<SP_GET_PM_PROVIDER_TRANSACTION_BY_ORDERID_Result> temp;

            temp = globalModel.SP_GET_PM_PROVIDER_TRANSACTION_BY_ORDERID(transaction.OrderId);

            result = temp
                .Select(t => new Payment.Provider.Transaction
                {
                    ProviderId = t.Provider_Id,
                    TransactionKeyId = t.Transaction_Key_Id,
                    TransactionTypeCatalogId = t.Transaction_Type_Catalog_Id,
                    ProviderTransactionTypeId = t.Provider_Transaction_Type_Id,
                    TransactionId = t.Transaction_Id,
                    TransactionDate = t.Transaction_Date,
                    CreditCardNumber = t.Credit_Card_Number,
                    CreditCardExpirationDate = t.Credit_Card_Expiration_Date,
                    Amount = t.Amount,
                    Tax = t.Tax,
                    ResponseCode = t.Response_Code,
                    AuthorizationCode = t.Authorization_Code,
                    RetrievalReferenceNumber = t.Retrieval_Reference_Number,
                    OrderId = t.Order_Id,
                    TransactionExtraData = t.Transaction_Extra_Data
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual int UpdatePaymentDetailOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            int result;
            IEnumerable<SP_SET_PM_PAYMENTS_DETAILS_Result> temp;

            temp = globalModel.SP_SET_PM_PAYMENTS_DETAILS(
                        paymentDetail.PaymentDetId,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        paymentDetail.OrderId,
                        null,
                        null,
                        paymentDetail.UserId
                    );

            result = 1;

            return
                result;
        }
        #endregion
    }
}
