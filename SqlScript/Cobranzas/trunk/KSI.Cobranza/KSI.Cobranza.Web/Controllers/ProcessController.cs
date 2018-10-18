﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KSI.Cobranza.Web.Models;
using KSI.Cobranza.Web.Models.ViewModels;
using KSI.Cobranza.Web.Common;

namespace KSI.Cobranza.Web.Controllers
{
    public class ProcessController : BaseController
    {
        private ProcessModel _oProcessModel { get; set; }

        public ProcessController()
        {
            _oProcessModel = new Lazy<ProcessModel>().Value;
        }

        // GET: Process

        public ActionResult Index(string data)
        {
            var model = new ProcessViewModels();

            var objDataReqeuest = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                objDataReqeuest = Utility.URLDecrypt(data.Replace(" ", "+"));
                var dataResult = Utility.deserializeJSON<dataRequest>(objDataReqeuest);
                var baseModel = new BaseModel();

                ViewBag.TransactionReasons = baseModel.GetDropDown(Enums.DropDownType.transactionreason).Select(o => new BaseViewModels.KeyValue
                {
                    Key = o.Key,
                    Value = o.Value
                }).ToList();

                model = _oProcessModel.GetProcessModel(dataResult);

                var DataPayment = _oProcessModel.GetReceipOfPayment(dataResult.accountId);
                var AccountRow = DataPayment.FirstOrDefault();

                ViewBag.AccountNumber = AccountRow.accountId;
                ViewBag.LoanNumber = AccountRow.loanNumber;
                ViewBag.LoanStatusName = AccountRow.LoanStatusName;
                ViewBag.AccountName = AccountRow.fullName;

                ViewBag.BaseURL = string.Concat("/Process/Index/", System.Web.HttpContext.Current.Request.Url.Query, "&Page=");
            }
            else
                return RedirectToAction("Index", "Home", new SearchViewModels());

            return View(model);
        }

        public PartialViewResult GetCodeudorPersonalInformation(long? Id)
        {
            var model = new PersonalInformationViewModels
                {
                    phones = new List<Phone>(0),
                    emails = new List<EmailAddress>(0)
                };

            model = _oProcessModel.GetPersonalInformation(Id);

            return PartialView("_PersonalInformation", model);
        }

        public PartialViewResult _ContactPhone(long? CustomerId)
        {
            var model = GetDataPhone(CustomerId);
            return
                PartialView(model);
        }

        public PartialViewResult _ContactEmailAddress(long? CustomerId)
        {
            var model = GetDataEmail(CustomerId);
            return
              PartialView(model);
        }

        public void CheckPrimaryPhone(long? CustomerId, int Id)
        {
            _oProcessModel.SetCustomerPrimaryPhone(CustomerId, Id);
        }
        public void CheckPrimaryEmail(long? CustomerId, int Id)
        {
            _oProcessModel.SetCustomerPrimaryEmail(CustomerId, Id);
        }

        public PartialViewResult _GuaranteeList(long? AccountId)
        {
            return
                PartialView(GetDataGuarantee(AccountId));
        }

        public PartialViewResult _LoanInformation(long? quotationId, int? loanNumber, long? accountId)
        {
            var model = _oProcessModel.GetLoanDetail(null, null, accountId);

            return
                PartialView(model);
        }

        public PartialViewResult _VehicleInformation(long? AccountId)
        {
            return
                PartialView(GetDataGuarantee(AccountId));
        }

        public PartialViewResult _VehicleDetail(long? CollateralId)
        {
            var model = _oProcessModel.GetVehicleDetail(CollateralId);
            return
                PartialView(model);
        }

        public PartialViewResult _CodeudorInformation(long? AccountId)
        {
            var model = new List<codeudor>(0);
            model = _oProcessModel.GetCodeudor(AccountId).ToList();
            if (model.Any())
            {
                var Record = model.FirstOrDefault();
                ViewBag.AccountNumber = Record.account;
                ViewBag.Id = Record.accountId;
                ViewBag.Status = Record.accountStatusName;
                ViewBag.AccountName = Record.accountName;
                ViewBag.Customer = Record.Fullname;
            }

            return
                PartialView(model);
        }

        public PartialViewResult _PolicyInformation(long? AccountId)
        {
            var model = _oProcessModel.GetPolicyInfomation(AccountId);

            return
                PartialView(model);
        }

        public PartialViewResult _PaymentPlan(long? AccountId)
        {
            var model = _oProcessModel.GetPaymentPlan(AccountId);
            var DataAccount = _oProcessModel.GetReceipOfPayment(AccountId);
            var AccountRow = DataAccount.FirstOrDefault();

            ViewBag.AccountNumber = AccountRow.accountId;
            ViewBag.LoanNumber = AccountRow.loanNumber;
            ViewBag.AccountName = AccountRow.fullName;
            return
                PartialView(model);
        }

        public PartialViewResult _ReceipOfPayment(long? AccountId, string[] filters = null)
        {
            var model = _oProcessModel.GetReceipOfPayment(AccountId);

            if (filters != null)
            {
                filters = filters.Where(o => o != "0").ToArray();
                if (filters.Length > 0)
                {
                    model = model.Where(x => filters.Contains(x.transactionReasonId.ToString())).ToList();
                }
            }

            var baseModel = new BaseModel();

            ViewBag.TransactionReasons = baseModel.GetDropDown(Enums.DropDownType.transactionreason).Select(o => new BaseViewModels.KeyValue
            {
                Key = o.Key,
                Value = o.Value
            }).ToList();

            return
                PartialView(model);
        }

        public PartialViewResult _frmPhone(long? Id)
        {
            var model = _oProcessModel.GetPhoneModel(Id);
            return
                PartialView(model);
        }

        public PartialViewResult _frmEmail(long? Id)
        {
            var model = _oProcessModel.GetEmailModel(Id);

            return
                PartialView(model);
        }

        public PartialViewResult SetEmail(EmailAddress EmailAddress)
        {
            var model = _oProcessModel.GetEmailModel(null);

            if (ModelState.IsValid)
            {
                EmailAddress.Usuario = vUsr;
                var result = _oProcessModel.SetEmail(EmailAddress);
            }

            return
                PartialView("_frmEmail", model);
        }

        public PartialViewResult SetPhone(Phone phone)
        {
            if (ModelState.IsValid)
            {
                phone.Number = phone.Number.Replace("(", "").Replace(")", "-");
                phone.AreaCoede = phone.Number.Substring(0, 3);
                phone.Number = phone.Number.Substring(4, 8);
                phone.Usuario = vUsr;
                var result = _oProcessModel.SetPhone(phone);
            }

            var model = _oProcessModel.GetPhoneModel(null);
            return
                PartialView("_frmPhone", model);
        }

        public PartialViewResult _ProjectedStatement(Nullable<long> accountId = null)
        {
            var DataAccount = _oProcessModel.GetReceipOfPayment(accountId);
            var LoanData = _oProcessModel.GetLoanDetail(null, null, accountId);
            var AccountRow = DataAccount.FirstOrDefault();

            ViewBag.AccountNumber = AccountRow.accountId;
            ViewBag.LoanNumber = AccountRow.loanNumber;
            ViewBag.AccountName = AccountRow.fullName;
            ViewBag.FilterDayDefault = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:MM/dd/yyyy}", DateTime.Now);

            var ProjectedAmounts = _oProcessModel.GetProjectStatement(accountId, DateTime.Now, 3, 0);

            var OutStandingAmount = ProjectedAmounts.FirstOrDefault(o => o.Description.Contains("Saldo Total a Pagar"));
            if (OutStandingAmount != null)
                ViewBag.OutStandingBalance = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0.00}", Convert.ToDecimal(OutStandingAmount.Value));
            else
                ViewBag.OutStandingBalance = 0;

            return PartialView();
        }

        public PartialViewResult _GridProjectedStatement(Nullable<long> accountId = null, Nullable<System.DateTime> dateStatement = null, Nullable<int> idTipo = null, Nullable<decimal> montoPago = null)
        {
            var model = _oProcessModel.GetProjectStatement(accountId, dateStatement, idTipo, montoPago).ToList();
            model = model.Select(o => new paymentProjection
            {
                Description = o.Description,
                TipoSaldo = o.TipoSaldo,
                Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0.00}", Convert.ToDecimal(o.Value))
            }).ToList();

            var OutStandingAmount = model.FirstOrDefault(o => o.Description.Contains("Saldo Total a Pagar"));
            if (OutStandingAmount != null)
                ViewBag.OutStandingBalance = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0.00}", OutStandingAmount.Value);
            else
                ViewBag.OutStandingBalance = 0;

            return PartialView(model);
        }

        public PartialViewResult _GridReceipOfPayment(long? AccountId, string[] filters = null)
        {
            var model = _oProcessModel.GetReceipOfPayment(AccountId);
            var AccountRow = model.FirstOrDefault();

            if (filters != null)
            {
                filters = filters.Where(o => o != "0").ToArray();
                if (filters.Length > 0)
                {
                    model = model.Where(x => filters.Contains(x.transactionReasonId.ToString())).ToList();
                }
            }

            var baseModel = new BaseModel();

            ViewBag.TransactionReasons = baseModel.GetDropDown(Enums.DropDownType.transactionreason).Select(o => new BaseViewModels.KeyValue
            {
                Key = o.Key,
                Value = o.Value
            }).ToList();

            return
                PartialView(model);
        }

        public PartialViewResult _PaymentProcess(long? AccountId)
        {
            var model = _oProcessModel.GetPaymentProcessModel(AccountId);

            return
                PartialView(model);
        }

        public PartialViewResult SetPaymentProcess(PaymentProcessViewModels model)
        {
            if (ModelState.IsValid)
            {
                Nullable<long> creditDebitDirectPaymentId = null;
                Nullable<long> accountId = model.AccountId;
                Nullable<int> cardTypeId = model.CardTypeId;
                Nullable<int> directPaymentStatusId = Enums.DirectPaymentStatus.PendienteProcesar.ToInt();
                string cardNumber = model.CardNumber;
                var start = model.CardNumber.Length - 4;
                string lastFourDigits = model.CardNumber.Substring(start, 4);
                string cardName = model.CardTypeDesc;
                Nullable<int> yearExpiration = model.CardExpirationYear;
                Nullable<int> monthExpiration = model.CardExpirationMonth;
                Nullable<decimal> quotaAmount = model.share;
                Nullable<decimal> balance = model.Balance;
                Nullable<decimal> amountPaid = model.AmountReceivable;
                Nullable<System.DateTime> datePaid = DateTime.Now;
                Nullable<System.DateTime> dateProcessedCard = null;
                Nullable<System.DateTime> dateProcessedEasybank = null;
                string authorizationNumber = string.Empty;
                string receiptNumberEasybank = string.Empty;
                Nullable<int> userId = vUsr.UserID;
                string userName = vUsr.UserLogin;

                var result = _oProcessModel.SetPaymentProcess(
                      creditDebitDirectPaymentId, accountId, cardTypeId, directPaymentStatusId, cardNumber, lastFourDigits, cardName, yearExpiration, monthExpiration, quotaAmount, balance, amountPaid, datePaid, dateProcessedCard, dateProcessedEasybank, authorizationNumber, receiptNumberEasybank, userId, userName
                    );
            }
            else
            {
                var Errors = GetErrorsFromModel();
                var modelTemp = _oProcessModel.GetPaymentProcessModel(model.AccountId);
                model.Years = modelTemp.Years;
                model.CardTypes = modelTemp.CardTypes;                
                model.ModelErrorList.AddRange(Errors);
                model.hasError = true;
            }

            return
                PartialView("_PaymentProcess", model);
        }

        #region Get Data
        public GuaranteeViewModels GetDataGuarantee(long? AccountId)
        {
            var model = new GuaranteeViewModels { GuaranteeList = _oProcessModel.GetLoanGuarantee(AccountId), vehicleInformationDetail = new List<BaseViewModels.KeyValue>(0) };
            return
                 model;
        }

        public IEnumerable<Phone> GetDataPhone(long? CustomerId)
        {
            var data = _oProcessModel.GetPhones(CustomerId);
            return data;
        }

        public IEnumerable<EmailAddress> GetDataEmail(long? CustomerId)
        {
            var data = _oProcessModel.GetEmails(CustomerId);
            return data;
        }

        [HttpPost]
        public ActionResult GetMotnhs(int Year)
        {
            var result = _oProcessModel.GetMonhts(Year);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Cobranza
        public PartialViewResult _Collections(long? AccountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            var data = _oProcessModel.GetCollection(AccountId, PaidF, PaidT, DebtF, DebtT);

            return
              PartialView(data);
        }

        public PartialViewResult _CollectionsHistoryPaymentGrid(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            var data = _oProcessModel.GetCollectionHistoryPayment(accountId, PaidF, PaidT, DebtF, DebtT).ToList();

            return
              PartialView("_CollectionsHistoryPaymentGrid", data);
        }

        public PartialViewResult _CollectionsDomiciliationGrid(long? accountId)
        {
            var data = _oProcessModel.GetCardDomitiliation(accountId);
            ModelState.Clear();
            return
              PartialView(data);
        }

        public PartialViewResult _CollectionsPayments(long? accountId)
        {
            var data = _oProcessModel.GetCollectionsPayments(accountId);

            ModelState.Clear();
            return
              PartialView(data);
        }

        public PartialViewResult _CardDomiciliation(string dataRequest)
        {
            var data = Utility.deserializeJSON<dataRequest>(Utility.URLDecrypt(dataRequest));
            var model = _oProcessModel.GetCardDomitiliation(data.accountId);
            model.CustomerId = data.CustomerId.GetValueOrDefault();
            model.AccountId = data.accountId.GetValueOrDefault();
            return PartialView(model);
        }
        public PartialViewResult _EditCardDomiciliation(string dataRequest)
        {
            var data = Utility.deserializeJSON<dataRequestCard>(Utility.URLDecrypt(dataRequest));
            var model = _oProcessModel.GetEditCardDomitiliationViewModel(data.accountId, data.clientId, data.CardTypeId, data.LastFourDigits);
            model.CustomerId = data.clientId.GetValueOrDefault();
            model.AccountId = data.accountId.GetValueOrDefault();
            return PartialView("_CardDomiciliation", model);
        }

        [HttpPost]
        public ActionResult SetDomicliation(CardDomitiliationViewModel cardDomitiliationViewModel)
        {
            if (ModelState.IsValid)
            {

                var ExpirationDateYYMM = string.Concat(cardDomitiliationViewModel.CardExpirationYear.ToString().Substring(2, 2), cardDomitiliationViewModel.CardExpirationMonth.ToString().Length == 1 ? "0" + cardDomitiliationViewModel.CardExpirationMonth.ToString() : cardDomitiliationViewModel.CardExpirationMonth.ToString());
                _oProcessModel.SetCardDomiciliation(cardDomitiliationViewModel.CustomerId,
                                                   cardDomitiliationViewModel.CardTypeId,
                                                   cardDomitiliationViewModel.LastFourDigits,
                                                   cardDomitiliationViewModel.CardNumber,
                                                   null,
                                                   null,
                                                   cardDomitiliationViewModel.CardHolder,
                                                   ExpirationDateYYMM,
                                                   cardDomitiliationViewModel.StatusId == 1,
                                                   GetCurrentUserID().GetValueOrDefault(),
                                                   cardDomitiliationViewModel.AccountId,
                                                   null,
                                                   null,
                                                   null,
                                                   null,
                                                    cardDomitiliationViewModel.StatusId == 1
                                                   );
            }

            //var data = _oProcessModel.GetCardDomitiliation(cardDomitiliationViewModel.AccountId);

            return new EmptyResult();
        }
        #endregion

    }
}