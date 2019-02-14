using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.Base;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Repositories;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Implementations
{
    public class PaymentsRepository : GlobalRepository, IPaymentsRepository
    {
        public PaymentsRepository(GlobalEntities globalEntities)
            : base(globalEntities)
        {

        }

        public PaymentsRepository(ATLANEntities atlanEntities)
            : base(null)
        {
            initAtlanRepository(atlanEntities);
        }

        public IQueryable<VW_GET_PAYMENT_HISTORY> getAllPaymentsHistory()
        {
            var results = globalModel.VW_GET_PAYMENT_HISTORY.AsQueryable();
            return results;
        }

        public IQueryable<VW_GET_PAYMENT_HISTORY> getPaymentsByFilter(PaymentHistory filters)
        {
            var results = this.getAllPaymentsHistory().Where(f => f.Transaction_Date >= filters.FromDate && f.Transaction_Date <= filters.ToDate).AsQueryable();
            return results;
        }

        public bool processTransaction(Payment payment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountType> getListAccountType()
        {
            var accountlist = globalModel.ST_BANK_ACCOUNT_TYPE.Where(s => s.Bnk_Accnt_Type_Status == true)
                                                              .Select(a => new AccountType
                                                                {
                                                                    Bank_Account_Type_Id = a.Bank_Account_Type_Id,
                                                                    Bnk_Accnt_Type_Desc = a.Bnk_Accnt_Type_Desc
                                                                }).ToArray();
            return accountlist;

        }

        public IEnumerable<CreditCardType> getCardTypeList()
        {
            var cardTypeList = globalModel.ST_CARD_TYPE.Where(s => s.Card_Type_Status == true)
                                                       .Select(a => new CreditCardType
                                                        {
                                                            Card_Type_Id = a.Card_Type_Id,
                                                            Card_Type_Desc = a.Card_Type_Desc,
                                                        }).ToArray();
            return cardTypeList;

        }

        public IEnumerable<PaymentsResult> SetPayments(Payment payment)
        {
            var results = globalModel.SP_SET_PM_PAYMENTS(
                                                         payment.Corp_Id,
                                                         payment.Region_Id,
                                                         payment.Country_Id,
                                                         payment.Domesticreg_Id,
                                                         payment.State_Prov_Id,
                                                         payment.City_Id,
                                                         payment.Office_Id,
                                                         payment.Case_Seq_No,
                                                         payment.Hist_Seq_No,
                                                         payment.Payment_Id,
                                                         payment.DueAmount,
                                                         payment.Periodic_Premium_Amount,
                                                         payment.Base_Premium,
                                                         payment.Exceptional_premium,
                                                         payment.Exceptional_premium2,
                                                         payment.Base_Commision,
                                                         payment.Base_Commision2,
                                                         payment.Exceptional_Commisions,
                                                         payment.Exceptional_Commisions2,
                                                         payment.DueDate,
                                                         payment.PaidDate,
                                                         payment.PaidAmount,
                                                         payment.Payment_Status_Id,
                                                         payment.UserId
                                                        ).Select(s => new PaymentsResult()
                                                        {
                                                            Action = s.Action.ToString(),
                                                            Case_Seq_No = s.Case_Seq_No.HasValue ? s.Case_Seq_No.Value : default(int),
                                                            City_Id = s.City_Id.HasValue ? s.City_Id.Value : default(int),
                                                            Corp_Id = s.Corp_Id.HasValue ? s.Corp_Id.Value : default(int),
                                                            Country_Id = s.Country_Id.HasValue ? s.Country_Id.Value : default(int),
                                                            Domesticreg_Id = s.Domesticreg_Id.HasValue ? s.Domesticreg_Id.Value : default(int),
                                                            Hist_Seq_No = s.Hist_Seq_No.HasValue ? s.Hist_Seq_No.Value : default(int),
                                                            Office_Id = s.Office_Id.HasValue ? s.Office_Id.Value : default(int),
                                                            Region_Id = s.Region_Id.HasValue ? s.Office_Id.Value : default(int),
                                                            State_Prov_Id = s.State_Prov_Id.HasValue ? s.Office_Id.Value : default(int),
                                                            Payment_Id = s.Payment_Id
                                                        }).ToList();
            return results;
        }

        public List<PaymentsDetailResult> SetPaymentsDetails(PaymentsDetail detail, PolicyID policy)
        {
            var results = globalModel.SP_SET_PM_PAYMENTS_DETAILS_ALL(
                                                                     policy.Corp_Id,
                                                                     policy.Region_Id,
                                                                     policy.Country_Id,
                                                                     policy.Domesticreg_Id,
                                                                     policy.State_Prov_Id,
                                                                     policy.City_Id,
                                                                     policy.Office_Id,
                                                                     policy.Case_Seq_No,
                                                                     policy.Hist_Seq_No,
                                                                     detail.Payment_Id,
                                                                     detail.Relationship_To_Owner_Or_Insured,
                                                                     detail.PaymentDet_Id,
                                                                     detail.Receipt_Type_Id,
                                                                     detail.Payment_Source_Type_Id,
                                                                     detail.Payment_Source_Id,
                                                                     detail.Account_Type_Id,
                                                                     detail.Payment_Control_Id,
                                                                     detail.Payment_Detail_Source_Id,
                                                                     detail.Currency_Id,
                                                                     detail.Doc_Type_Id,
                                                                     detail.Doc_Category_Id,
                                                                     detail.Document_Id,
                                                                     detail.Origin_Credit_Amount,
                                                                     detail.Origin_Debit_Amount,
                                                                     detail.Usd_Credit_Amount,
                                                                     detail.Usd_Debit_Amount,
                                                                     detail.Rate,
                                                                     detail.Transaction_Date,
                                                                     detail.Due_Date,
                                                                     detail.Posted_Amount,
                                                                     detail.Posted_Date,
                                                                     detail.Receipt_Date,
                                                                     detail.Transaction_Description,
                                                                     detail.Transaction_Reference,
                                                                     detail.EFT_Date,
                                                                     detail.EFT_ABA_Number,
                                                                     detail.EFT_Account_Number,
                                                                     detail.EFT_Account_Holder,
                                                                     detail.EFT_Account_Holder_Source,
                                                                     detail.Other_Description,
                                                                     detail.Result_Code,
                                                                     detail.OrderId,
                                                                     detail.Payment_Status_Id,
                                                                     detail.Payment_Status,
                                                                     detail.Seq_No,
                                                                     detail.Type_Id,
                                                                     detail.Effective_Date,
                                                                     detail.Expire_Date,
                                                                     detail.Number,
                                                                     detail.Control_Digit,
                                                                     detail.Name,
                                                                     detail.Status,
                                                                     detail.UserId
                                                                    ).Select(s => new PaymentsDetailResult()
                                                                    {
                                                                        PolicyId = new PolicyID()
                                                                        {
                                                                            Case_Seq_No = s.Case_Seq_No.HasValue ? s.Case_Seq_No.Value : default(int),
                                                                            City_Id = s.City_Id.HasValue ? s.City_Id.Value : default(int),
                                                                            Corp_Id = s.Corp_Id.HasValue ? s.Corp_Id.Value : default(int),
                                                                            Country_Id = s.Country_Id.HasValue ? s.Country_Id.Value : default(int),
                                                                            Domesticreg_Id = s.Domesticreg_Id.HasValue ? s.Domesticreg_Id.Value : default(int),
                                                                            Hist_Seq_No = s.Hist_Seq_No.HasValue ? s.Hist_Seq_No.Value : default(int),
                                                                            Office_Id = s.Office_Id.HasValue ? s.Office_Id.Value : default(int),
                                                                            Region_Id = s.Region_Id.HasValue ? s.Region_Id.Value : default(int),
                                                                            State_Prov_Id = s.State_Prov_Id.HasValue ? s.State_Prov_Id.Value : default(int),
                                                                        },
                                                                        Seq_No = s.Seq_No,
                                                                        Payment_Id = s.Payment_Id,
                                                                        PaymentDet_Id = s.PaymentDet_Id
                                                                    }).ToList();
            return results;
        }

        public Currency getCurrencyByCurrencyID(int Currency_Id)
        {
            var results = globalModel.ST_CURRENCY.Where(c => c.Currency_Status == true && c.Currency_Id == Currency_Id)
                                                 .Select(r => new Currency
                                                 {
                                                     Currency_Desc = r.Currency_Desc,
                                                     Currency_Id = r.Currency_Id
                                                 })
                                                 .FirstOrDefault();
            return results;
        }

        public BussinessLine getBusinessLineByLine_Id(int Business_Line_Id)
        {
            var results = globalModel.ST_BUSINESS_LINE.Where(s => s.Bl_Status == 1 && s.Bl_Id == Business_Line_Id)
                                                      .Select(r => new BussinessLine
                                                      {
                                                          Bl_Desc = r.Bl_Desc,
                                                          Bl_Id = r.Bl_Id,
                                                          Bl_Type_Id = r.Bl_Type_Id
                                                      }).FirstOrDefault();
            return results;
        }


        ///GP METHODS
        public BussinessLine getBusinessLineByLineCodeGP(int BusinessLineCode)
        {
            var results = atlanModel.ST_BUSINESS_LINE.Where(b => b.BusinessLine_Code == BusinessLineCode && b.BusinessLine_Status == 1)
                                                     .Select(r => new BussinessLine
                                                     {
                                                         Bl_Id = r.BusinessLine_Id,
                                                         Bl_Code = r.BusinessLine_Code,
                                                         Bl_Desc = r.BusinessLine_NameKey
                                                     })
                                                     .FirstOrDefault();
            return results;
        }

        public string getProductDescriptionByPlanTypeCodeGP(string PlanTypeCode)
        {
            var results = atlanModel.VW_ST_PRODUCTS_DESCRIPTIONS.Where(c => c.CODE == PlanTypeCode)
                                                                .Select(r => r.DESCRIPTION)
                                                                .FirstOrDefault();
            return results;
        }

        public string getOfficeDescriptionByOfficeNumberCodeGP(int OFFICE_NUMBER)
        {
            var result = atlanModel.ST_OFFICE_CODES.Where(r => r.Office_Status == 1 && r.Office_Code == OFFICE_NUMBER).FirstOrDefault();
            return result != null ? result.Office_NameKey : string.Empty;

        }

        public IQueryable<VW_ST_PMT_HISTORY> getAllPaymentHistoryGP()
        {
            var results = atlanModel.VW_ST_PMT_HISTORY;
            return results;
        }

        public string getPaymentBatchByBarcode(string barcode)
        {
            var results = atlanModel.VW_ST_PMT_PAYMENTS_BY_BARCODE_KT.Where(b => b.KT_BARCODE == barcode)
                                                                     .FirstOrDefault();
            if (results != null)
                return results.BATCH;
            return string.Empty;
        }

        public IEnumerable<ktPayment> getPaymentsByBatch(string batch)
        {
            var results = atlanModel.VW_ST_PMT_PAYMENTS_BY_BARCODE_KT.Where(bt => bt.BATCH == batch)
                                                                     .ToArray()
                                                                     .Select(i => new ktPayment()
                                                                     {
                                                                         Additional_Info = i.ADDITIONAL_INFO,
                                                                         PaymentNumber = i.GP_PAYMENT_NUMBER,
                                                                         Barcode = i.KT_BARCODE,
                                                                         Batch = i.BATCH
                                                                     });
            if (results != null)
                return results;
            return null;
        }

        public bool getHaveRecentPayments(string policy_no)
        {
            var result = atlanModel.USP_GET_POLICY_HAS_RECENT_PAYMENTS(policy_no).Count();
            return (result > 0);
        }

        public IEnumerable<DailyCashDetails> getDailyCashPayments(string Collector, DateTime PaymentDate, int? PaymentType, DateTime PaymentDateTo)
        {
            var result = atlanModel.SP_GET_DAILY_CASH_DETAILS(Collector, PaymentDate, PaymentType, PaymentDateTo)
                                   .ToArray()
                                   .Select(r => new DailyCashDetails
                                   {
                                       CUSTNAME = r.CUSTNAME,
                                       GP_PAYMENT_NUMBER = r.GP_PAYMENT_NUMBER,
                                       PAYMENT_AMOUNT = r.PAYMENT_AMOUNT.GetValueOrDefault(),
                                       PAYMENT_TYPE = r.PAYMENT_TYPE,
                                       POLICY_NUMBER  = r.POLICY_NUMBER,
                                       PAYMENT_DATE = r.PAYMENT_DATE,
                                       PAYMENT_DATETIME = r.PAYMENT_DATETIME.GetValueOrDefault(),
                                       PAYMENT_HOUR = r.PAYMENT_HOUR,
                                       CHECKBOOK_ID = r.CHECKBOOK_ID,
                                       GP_STATUS = r.GP_STATUS
                                   });
            return result;
        }
    }
}
