using Collectors.Helpers;
using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Singleton;
using CollectorsModule.ell;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.bll.Services
{
    public class PaymentsService
    {
        Lazy<ClientSearchService> CSS = new Lazy<ClientSearchService>();
        Lazy<ProviderServices> PS = new Lazy<ProviderServices>();
        Lazy<UtilitiesServices> US = new Lazy<UtilitiesServices>();

        public void SetPaymentDetail(Payment head, String Payment_Id, Decimal AmountToPay, String PaymentNumber, Decimal CustomerBalance, String policy_no, int UserId, PolicyID policy)
        {
            PaymentsDetail detailPayment = new PaymentsDetail();
            detailPayment.UserId = 1;
            detailPayment.Account_Type_Id = 4;
            detailPayment.Currency_Id = 3;
            detailPayment.Due_Date = head.DueDate;
            detailPayment.Effective_Date = head.PaidDate;
            detailPayment.EFT_ABA_Number = "";
            detailPayment.EFT_Account_Holder = "";
            detailPayment.EFT_Account_Holder_Source = "";
            detailPayment.EFT_Account_Number = "";
            detailPayment.EFT_Date = head.PaidDate;

            detailPayment.Origin_Credit_Amount = 0;
            detailPayment.Origin_Debit_Amount = 0;
            detailPayment.Payment_Control_Id = 1;
            detailPayment.Payment_Detail_Source_Id = "";
            detailPayment.Payment_Id = int.Parse(Payment_Id);
            detailPayment.Payment_Source_Id = 1;
            detailPayment.Payment_Source_Type_Id = 2;

            detailPayment.Payment_Status = true;
            detailPayment.Payment_Status_Id = 1;
            detailPayment.PaymentDet_Id = 0;
            detailPayment.Posted_Amount = AmountToPay;
            detailPayment.Posted_Date = head.PaidDate;
            detailPayment.Rate = 1;
            detailPayment.Receipt_Date = head.PaidDate;
            detailPayment.Receipt_Type_Id = 1;
            detailPayment.Relationship_To_Owner_Or_Insured = 1; //
            detailPayment.OrderId = null;// OrderId;

            detailPayment.Doc_Category_Id = null;
            detailPayment.Doc_Type_Id = null;
            detailPayment.Document_Id = null;

            detailPayment.Other_Description = JsonConvert.SerializeObject(new { @PaymentNumber = PaymentNumber, @CustomerBalance = CustomerBalance });
            detailPayment.Result_Code = PaymentNumber;// null;
            detailPayment.Seq_No = null;
            detailPayment.Type_Id = null;
            detailPayment.Expire_Date = null;
            detailPayment.Name = null;
            detailPayment.Number = null;
            detailPayment.Status = false;
            detailPayment.Control_Digit = null;

            detailPayment.Transaction_Date = head.PaidDate;
            detailPayment.Transaction_Description = EnumHelper.GetDescription(Collectors.Helpers.Enums.PaymentForm.CREDITCARD);
            detailPayment.Transaction_Reference = policy_no;
            detailPayment.Usd_Credit_Amount = 0;
            detailPayment.Usd_Debit_Amount = 0;
            detailPayment.UserId = UserId;

            Singleton.Instance.UnitOfWork.PaymentsRepository.SetPaymentsDetails(detailPayment, policy);
        }

        public Payment SetPaymentHead(PolicyID policyid, Decimal amountToPay)
        {
            Payment headPayment = new Payment();

            headPayment.Corp_Id = policyid.Corp_Id.Value;
            headPayment.Region_Id = policyid.Region_Id.Value;
            headPayment.Country_Id = policyid.Country_Id.Value;
            headPayment.Domesticreg_Id = policyid.Domesticreg_Id.Value;
            headPayment.State_Prov_Id = policyid.State_Prov_Id.Value;
            headPayment.City_Id = policyid.City_Id.Value;
            headPayment.Office_Id = policyid.Office_Id.Value;
            headPayment.Case_Seq_No = policyid.Case_Seq_No.Value;
            headPayment.Hist_Seq_No = policyid.Hist_Seq_No.Value;
            headPayment.UserId = 1;
            headPayment.PaidDate = DateTime.Now;
            headPayment.PaidAmount = amountToPay;
            headPayment.Payment_Status_Id = 1;
            headPayment.Payment_Id = 0;
            headPayment.DueAmount = amountToPay;                    //=→     Pending Verifica
            headPayment.DueDate = DateTime.Now;
            headPayment.Base_Commision = 0;
            headPayment.Base_Commision2 = 0;
            headPayment.Base_Premium = 0;
            headPayment.Exceptional_Commisions = 0;
            headPayment.Exceptional_Commisions2 = 0;
            headPayment.Exceptional_premium = 0;
            headPayment.Exceptional_premium2 = 0;
            headPayment.Periodic_Premium_Amount = 0;

            return headPayment;
        }

        public IEnumerable<PaymentsResult> SetPayments(Payment payment)
        {
            var result = Singleton.Instance.UnitOfWork.PaymentsRepository.SetPayments(payment);
            return result;
        }

        public IEnumerable<Invoice> generateInvoiceList(IEnumerable<Payment> paymentsList, Invoice invoice, string UserName, string paymentForm)
        {
            var lstInvoice = new List<Invoice>();
            var amountDesc = paymentsList.Sum(a => a.PaidAmount);
            foreach (var pmt in paymentsList)
            {
                var _invoice = new Invoice()
                {
                    PayDate = DateTime.Now.ToShortDateString(),
                    Time = String.Format("{0:t}", DateTime.Now),
                    PaymentNumber = pmt.PaymentNumber,
                    FullName = pmt.Full_Name.Trim(),
                    Amount = pmt.PaidAmount.HasValue ? pmt.PaidAmount.Value : default(decimal),
                    Policy_No = pmt.Policy_No,
                    Amount_desc = Collectors.Helpers.Numalet.ToCardinal(amountDesc.HasValue ? amountDesc.Value : default(decimal)),
                    WayToPay = paymentForm,
                    Cashier = UserName,
                    CustomerBalance = pmt.CustomerBalance,
                    Company = invoice.Company,
                    Rnc = invoice.Rnc,
                    Address = invoice.Address,
                    Fax = invoice.Fax,
                    Telephone = invoice.Telephone
                };
                lstInvoice.Add(_invoice);
            }
            return lstInvoice;
        }

        public String generateInvoiceHTML(IEnumerable<Invoice> lstInvoice, HtmlDocument template)
        {
            var html = new StringBuilder();
            ///Building invoice list 
            var div = (from d in template.DocumentNode.Descendants("div")
                       where d.Id == "invoiceList"
                       select d).FirstOrDefault();
            var divHTML = div.OuterHtml;
            var divHTMLorg = div.OuterHtml;
            foreach (var inv in lstInvoice)
            {
                divHTML = divHTMLorg.Replace("@PaymentNumber", inv.PaymentNumber)
                                 .Replace("@PolicyNo", inv.Policy_No)
                                 .Replace("@PayDate", inv.PayDate)
                                 .Replace("@PaymentForm", inv.WayToPay)
                                 .Replace("@AmountR", inv.Amount.ToString("c"))
                                 .Replace("@PendingAmountR", (inv.CustomerBalance - inv.Amount).ToString("c"));
                html.Append(divHTML);
            }
            var genericValues = lstInvoice.FirstOrDefault();
            var Amount = lstInvoice.Sum(a => a.Amount);
            var CustomerBalance = lstInvoice.Sum(t => t.CustomerBalance);
            List<string> lstPaymentNumbers = lstInvoice.Select(p => p.PaymentNumber).ToList();
            List<string> lstPolicyNumbers = lstInvoice.Select(p => p.Policy_No.Trim()).ToList();
            string PaymentNumbers = string.Join(", ", lstPaymentNumbers);
            string PolicyConceptsNumbers = string.Join(", ", lstPolicyNumbers);
            div.InnerHtml = html.ToString();
            var result = template.DocumentNode.OuterHtml
                    .Replace("@Company", genericValues.Company)
                    .Replace("@PayDate", genericValues.PayDate)
                    .Replace("@Address", genericValues.Address)
                    .Replace("@Time", genericValues.Time)
                    .Replace("@RNC", genericValues.Rnc)
                    .Replace("@PAYMENTNUMBERLst", PaymentNumbers)
                    .Replace("@PAYMENTCONCEPTLst", PolicyConceptsNumbers)
                    .Replace("@FullName", genericValues.FullName)
                    .Replace("@Amount_desc", genericValues.Amount_desc)
                    .Replace("@Cashier", genericValues.Cashier)
                    .Replace("@AmountR", Amount.ToString("c"))
                    .Replace("@PendingAmountR", (CustomerBalance - Amount).ToString("c"));
            return result.ToString();
        }

        public IEnumerable<AccountType> getListAccountType()
        {
            var accountlist = Singleton.Instance.UnitOfWork.PaymentsRepository.getListAccountType();
            int lng = 2;
            foreach (var item in accountlist)
            {
                item.Bnk_Accnt_Type_Desc = Singleton.Instance.UnitOfWork.UtilitiesRepository.getTranslatedTextByLiteralDesc(item.Bnk_Accnt_Type_Desc, lng);
            }
            return accountlist;
        }

        public IEnumerable<CreditCardType> getListCardType()
        {
            var cardTypeList = Singleton.Instance.UnitOfWork.PaymentsRepository.getCardTypeList();
            return cardTypeList;
        }
        
        public Currency getCurrencyByCurrencyID(int Currency_Id)
        {
            var currency = Singleton.Instance.UnitOfWork.PaymentsRepository.getCurrencyByCurrencyID(Currency_Id);
            return currency;
        }

        public bool getHaveRecentPayments(string policy_no)
        {
            var result = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getHaveRecentPayments(policy_no);
            return result;
        }

        public BussinessLine getBusinessLineByLine_Id(int Business_Line_Id)
        {
            var result = Singleton.Instance.UnitOfWork.PaymentsRepository.getBusinessLineByLine_Id(Business_Line_Id);
            return result;
        }

        public IQueryable<VW_GET_PAYMENT_HISTORY> getAllPaymentsHistory()
        {
            var results = Singleton.Instance.UnitOfWork.PaymentsRepository.getAllPaymentsHistory();
            return results;
        }

        public IQueryable<VW_GET_PAYMENT_HISTORY> getPaymentsByFilter(PaymentHistory filters)
        {
            var results = Singleton.Instance.UnitOfWork.PaymentsRepository.getPaymentsByFilter(filters);
            return results;
        }

        ///GP METHODS
        public BussinessLine getBusinessLineByLineCodeGP(int BusinessLineCode)
        {
            var result = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getBusinessLineByLineCodeGP(BusinessLineCode);
            return result;
        }
        public string getProductDescriptionByPlanTypeCodeGP(string PlanTypeCode)
        {
            var result = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getProductDescriptionByPlanTypeCodeGP(PlanTypeCode);
            return result;
        }

        public string getOfficeDescriptionByOfficeNumberCodeGP(int OFFICE_NUMBER)
        {
            var result = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getOfficeDescriptionByOfficeNumberCodeGP(OFFICE_NUMBER);
            return result;
        }

        public IQueryable<VW_ST_PMT_HISTORY> getAllPaymentHistoryGP(PaymentHistory filterParameters)
        {
            var result = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getAllPaymentHistoryGP();
            if (filterParameters.FromDate != new DateTime())
            {
                result = result.Where(fd => fd.PAYMENT_DATE >= filterParameters.FromDate);
            }
            if (filterParameters.ToDate != new DateTime())
            {
                result = result.Where(td => td.PAYMENT_DATE <= filterParameters.ToDate);
            }
            if (!string.IsNullOrEmpty(filterParameters.UserName))
            {
                result = result.Where(u => u.RECEIVED_BY == filterParameters.UserName.ToLower());
            }
            if (filterParameters.Office_Code != "0" && filterParameters.Office_Code != string.Empty)
                result = result.Where(o => o.OFFICE_NUMBER == filterParameters.Office_Code);
            if (filterParameters.Module != "0" && filterParameters.Module != string.Empty)
            {
                result = result.Where(o => o.SOURCE_SYSTEM == filterParameters.Module);
            }
            if (filterParameters.Bl_Id != null && filterParameters.Bl_Id != 0)
            {
                result = result.Where(o => o.LINE_OF_BUSINESS == filterParameters.Bl_Id.ToString());
            }
            if (!string.IsNullOrEmpty(filterParameters.Policy_No))
            {
                result = result.Where(o => o.POLICY_NUMBER == filterParameters.Policy_No);
            }
            if (!string.IsNullOrEmpty(filterParameters.Currency_Desc))
            {
                result = result.Where(o => o.CURRENCY_ID == filterParameters.Currency_Desc);
            }
            return result;
        }

        public string getPaymentBatchByBarcode(string barcode)
        {
            var batch = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getPaymentBatchByBarcode(barcode);
            return batch;
        }

        public IEnumerable<Payment> getPaymentsByBatch(string batch)
        {
            try
            {
                List<Payment> paymentList = new List<Payment>();
                var results = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getPaymentsByBatch(batch);
                if (results != null)
                {
                    foreach (var trx in results)
                    {
                        JObject json = JObject.Parse(trx.Additional_Info);
                        var pmt = JsonConvert.DeserializeObject<ktPaymentInfo>(json.ToString());
                        paymentList.Add(new Payment()
                        {
                            PaidAmount = Decimal.Parse(pmt.Amount),
                            PaymentNumber = trx.PaymentNumber,
                            Full_Name = pmt.Full_Name,
                            Policy_No = pmt.Policy,
                            CustomerBalance = Decimal.Parse(pmt.CustomerBalance),
                            Payment_Form = pmt.Payment_Form,
                            Cashier = pmt.Cashier
                        });
                    }
                }
                return paymentList.ToArray();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<DailyCashDetails> getDailyCashPayments(string Collector, DateTime PaymentDate, int? PaymentType, DateTime PaymentDateTo)
        {
            try
            {
                var result = Singleton.Instance.UnitOfWorkGP.PaymentsRepositoryGP.getDailyCashPayments(Collector, PaymentDate, PaymentType, PaymentDateTo);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public struct ktPaymentInfo
        {
            public string Policy { get; set; }
            public string Amount { get; set; }
            public string DueDate { get; set; }
            public string CurrencyID { get; set; }
            public string Barcode { get; set; }
            public string CustomerBalance { get; set; }
            public string Full_Name { get; set; }
            public string Payment_Form { get; set; }
            public string Cashier { get; set; }
        }
    }
}
