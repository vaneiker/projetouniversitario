﻿using KSI.Cobranza.DataLayer.Interfaces;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class LoanRepository : BaseRepository, IBaseRepository<Loan>
    {
        public LoanRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<Loan.PaymentPlan> GetPaymentPlan(Nullable<long> accountId)
        {
            IEnumerable<Loan.PaymentPlan> result;
            var temp = base._dbContext.SP_GET_LOANS_PAYMENT_PLAN(accountId);
            result = temp.Select(r => new Loan.PaymentPlan
            {
                Quota = r.Quota,
                QuotaDate = r.QuotaDate,
                CapitalBalance = r.CapitalBalance,
                Capital = r.Capital,
                Rate = r.Rate,
                LoanRate = r.LoanRate,
                Commision = r.Commision,
                FinancialQuota = r.FinancialQuota,
                Expense = r.Expense,
                TotalPayment = r.TotalPayment
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<Loan.codeudor> GetCodeudor(Nullable<long> accountId)
        {
            IEnumerable<Loan.codeudor> result;
            var temp = base._dbContext.SP_GET_LOANS_CODEBTOR_INFORMATIONS_DETAIL(accountId);
            result = temp.Select(r => new Loan.codeudor
            {
                account = r.account,
                accountId = r.accountId,
                accountStatusName = r.accountStatusName,
                accountName = r.accountName,
                Fullname = r.Fullname,
                codebtorFullname = r.codebtorFullname,
                codebtorIdentificationNumber = r.codebtorIdentificationNumber,
                codebtorClientId = r.codebtorClientId,
                codebtorrelatedContactId = r.codebtorrelatedContactId,
                codebtorTypeName = r.codebtorTypeName,
                companyId = r.companyId,
                clientId = r.clientId,
                codebtorTypeId = r.codebtorTypeId,
                canDeposit = r.canDeposit,
                canWithdraw = r.canWithdraw,
                canCancel = r.canCancel,
                IsJointY = r.IsJointY,
                IsJointO = r.IsJointO,
                isActive = r.isActive,
                CreateDate = r.CreateDate,
                ModiDate = r.ModiDate,
                CreateUsrId = r.CreateUsrId,
                ModiUsrId = r.ModiUsrId,
                hostName = r.hostName
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<Loan.PolicyInformation> GetPolicyInformation(Nullable<long> accountId)
        {
            IEnumerable<Loan.PolicyInformation> result;
            var temp = base._dbContext.SP_GET_LOANS_ENDORSE_COLLATERAL_INFORMATIONS_DETAIL(accountId);
            result = temp.Select(r => new Loan.PolicyInformation
            {
                policyTypeName = r.policyTypeName,
                FullName = r.FullName,
                policyNo = r.policyNo,
                Amount = r.Amount,
                isActive = r.isActive,
                policyCollateralName = r.policyCollateralName,
                Date = r.Date,
                EffectiveDate = r.EffectiveDate,
                endorseNo = r.endorseNo,
                endorseAmount = r.endorseAmount,
                endorseInicialDate = r.endorseInicialDate,
                endorseDate = r.endorseDate,
                endorseEffectiveDate = r.endorseEffectiveDate,
                collateralId = r.collateralId,
                companyId = r.companyId,
                policyTypeId = r.policyTypeId,
                relatedContactId = r.relatedContactId,
                policyCollateralComment = r.policyCollateralComment,
                notificationDate = r.notificationDate,
                CreateDate = r.CreateDate,
                ModiDate = r.ModiDate,
                CreateUsrId = r.CreateUsrId,
                ModiUsrId = r.ModiUsrId,
                hostName = r.hostName,
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<Loan.QuotaInformation> GetReceipOfPayment(Nullable<long> accountId)
        {
            IEnumerable<Loan.QuotaInformation> result;
            var temp = base._dbContext.SP_GET_LOANS_QUOTA_HEADER(accountId);
            result = temp.Select(r => new Loan.QuotaInformation
            {
                transactionPaymentPlanId = r.transactionPaymentPlanId,
                quotaNumber = r.quotaNumber,
                emisionQuotaDate = r.emisionQuotaDate,
                endQuotaDate = r.endQuotaDate,
                validationTotal = r.validationTotal,
                validationBalance = r.validationBalance,
                ISLastQuota = r.ISLastQuota,
                IsPrepayment = r.IsPrepayment,
                transactionReasonName = r.transactionReasonName,
                LoanStatusName = r.LoanStatusName,
                fullName = r.fullName,
                accountId = r.accountId,
                loanNumber = r.loanNumber,
                transactionReasonId = r.transactionReasonId,
                capitalAmount = r.capitalAmount,
                interestAmoint = r.interestAmoint,
                commissionAmount = r.commissionAmount,
                expenseAmount = r.expenseAmount,
                rateLateAmount = r.rateLateAmount,
                chargesPrepayment = r.chargesPrepayment,
                capitalBalance = r.capitalBalance,
                interestBalance = r.interestBalance,
                commissionBalance = r.commissionBalance,
                expenseBalance = r.expenseBalance,
                rateLateBalance = r.rateLateBalance,
                chargesPrepaymentBalance = r.chargesPrepaymentBalance,
                dCapital = r.dCapital,
                dInterestAmoint = r.dInterestAmoint,
                dCommissionAmoun = r.dCommissionAmoun,
                dExpenseAmount = r.dExpenseAmount,
                dRateLateAmount = r.dRateLateAmount,
                dChargeAmount = r.dChargeAmount,
                dDiscountAmount = r.dDiscountAmount,
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<Loan.Guarantee> GetLoanGuarantee(Nullable<long> accountId)
        {
            IEnumerable<Loan.Guarantee> result;
            var temp = base._dbContext.SP_GET_LOANS_COLLATERAL_INFORMATIONS_RESUMEN(accountId);
            result = temp.Select(r => new Loan.Guarantee
            {
                accountId = r.accountId,
                collateralId = r.collateralId,
                collateralName = r.collateralName,
                collateralTypeName = r.collateralTypeName,
                collateralTypeSIBName = r.collateralTypeSIBName,
                percent = r.percent,
                amount = r.amount,
                contractNumber = r.contractNumber,
                codeDesc = r.codeDesc
            })
            .ToArray();

            return
                result;
        }

        public Loan.Detail GetLoanDetailInformation(long? quotationId, int? loanNumber, long? accountId)
        {
            Loan.Detail result;
            var temp = base._dbContext.SP_GET_LOANS_INFORMATIONS_DETAIL(quotationId, loanNumber, accountId);
            result = temp.Select(r => new Loan.Detail
            {
                quotationId = r.quotationId,
                LoanNumber = r.LoanNumber,
                fullName = r.fullName,
                clientid = r.clientid,
                identificationNumber = r.identificationNumber,
                LoanStatusName = r.LoanStatusName,
                quotationPaymentTypeName = r.quotationPaymentTypeName,
                frequency = r.frequency,
                frequencyName = r.frequencyName,
                loanTerm = r.loanTerm,
                LoanDillingDay = r.LoanDillingDay,
                CurrencyName = r.CurrencyName,
                AmountRequested = r.AmountRequested,
                amountApproved = r.amountApproved,
                financedAmount = r.financedAmount,
                DisbursedAmount = r.DisbursedAmount,
                OutstandingBalance = r.OutstandingBalance,
                QuotaAmount = r.QuotaAmount,
                RateAnnual = r.RateAnnual,
                RateMonth = r.RateMonth,
                RateCommissionAnnual = r.RateCommissionAnnual,
                RateCommissionMonth = r.RateCommissionMonth,
                RateLatenAnnual = r.RateLatenAnnual,
                RateLateMonth = r.RateLateMonth,
                qoutationDate = r.qoutationDate,
                ApprovedDate = r.ApprovedDate,
                disbursementDate = r.disbursementDate,
                expirationDate = r.expirationDate,
                ClosedDate = r.ClosedDate,
                LastClosedDate = r.LastClosedDate,
                LastQuotaDate = r.LastQuotaDate,
                lastPaidDate = r.lastPaidDate,
                fullNameExecutive = r.fullNameExecutive,
                fullNamePromoter = r.fullNamePromoter
            })
            .FirstOrDefault();

            return
                result;
        }

        public IEnumerable<Loan> GetLoanInformation(string clienteName, string identificationNumber, Nullable<long> quotationId, Nullable<long> accountId, string collateralReference, string chasisNumber)
        {
            IEnumerable<Loan> result;
            var temp = base._dbContext.SP_GET_LOANS_INFORMATIONS(clienteName, identificationNumber, quotationId, accountId, collateralReference, chasisNumber);
            result = temp.Select(r => new Loan
            {
                accountId = r.accountId,
                quotationId = r.quotationId,
                relatedContactId = r.relatedContactId,
                FirstName = r.FirstName,
                MiddleName = r.MiddleName,
                Lastname = r.Lastname,
                SecondLastname = r.SecondLastname,
                FullName = r.FullName,
                IdentificationNumber = r.IdentificationNumber,
                IdentificationName = r.IdentificationName,
                account = r.account,
                AreaCode = r.AreaCode,
                Phone = r.Phone
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<Loan.Vehicle> GetVehicleDetail(Nullable<long> collateralId)
        {
            IEnumerable<Loan.Vehicle> result;
            var temp = base._dbContext.SP_GET_LOANS_COLLATERAL_INFORMATIONS_DETAIL(collateralId);
            result = temp.Select(r => new Loan.Vehicle
            {
                collateralFieldId = r.collateralFieldId,
                collateralId = r.collateralId,
                collateralFieldName = r.collateralFieldName,
                collateralFieldValue = r.collateralFieldValue,
                ISRequired = r.ISRequired,
                collateralFieldComment = r.collateralFieldComment
            })
            .ToArray();

            return
                result;
        }

        public IEnumerable<Loan.paymentProjection> GetProjectedStatement(Nullable<long> accountId, Nullable<System.DateTime> dateStatement, Nullable<int> idTipo, Nullable<decimal> montoPago)
        {
            IEnumerable<Loan.paymentProjection> result;
            var temp = base._dbContext.SP_GET_LOANS_PAYMENT_PLAN_PROYECTIONS(accountId, dateStatement, idTipo, montoPago);
            result = temp.Select(r => new Loan.paymentProjection
            {
                Description = r.Description,
                Value = r.Value,
                TipoSaldo = r.TipoSaldo
            })
            .ToArray();

            return
                result;
        }

        #region cobranza
        public IEnumerable<Loan.PaymentAndDebts> GetPaymentAndDebt(Nullable<long> accountId = null, Nullable<DateTime> FDateDebt = null
            , Nullable<DateTime> TDateDebt = null, Nullable<DateTime> FDatePay = null, Nullable<DateTime> TDatePay = null)
        {
            IEnumerable<Loan.PaymentAndDebts> result;
            var temp = base._dbContext.SP_GET_LOANS_PAYMENT_AND_DEBTS(accountId, FDateDebt, TDateDebt, FDatePay, TDatePay);
            result = temp.Select(r => new Loan.PaymentAndDebts
            {
                accountId = r.accountId,
                capitalAmount = r.capitalAmount,
                chargesPrepayment = r.chargesPrepayment,
                commissionAmount = r.commissionAmount,
                DueDate = r.DueDate,
                emisionQuotaDate = r.emisionQuotaDate,
                expenseAmount = r.expenseAmount,
                interestAmoint = r.interestAmoint,
                PaidAmount = r.PaidAmount,
                QuotaAmount = r.QuotaAmount,
                QuotaAmountBalance = r.QuotaAmountBalance,
                QuotaNumber = r.QuotaNumber,
                rateLateAmount = r.rateLateAmount,
                validationTotal = r.validationTotal,
                PaidDate = r.PaidDate,
                AmountToPay = r.AmountToPay,
                LatePay = r.LatePay,
                Balance = r.Balance
            })
            .ToArray();

            return
                result;
        }


        public IEnumerable<Loan.CardDomitiliation> GetLoanDomiciliationCard(Nullable<long> accountId, Nullable<long> clientId)
        {
            IEnumerable<Loan.CardDomitiliation> result;
            var temp = base._dbContext.SP_GET_LOANS_DOMICILIATION_CARD(accountId, clientId);
            result = temp.Select(r => new Loan.CardDomitiliation
            {
                clientId = r.clientId,
                accountId = r.accountId,
                CardTypeId = r.CardTypeId,
                LastFourDigits = r.LastFourDigits,
                CardNumber = r.CardNumber,
                ExpirationDate = r.ExpirationDate,
                CVV2 = r.CVV2,
                CardHolder = r.CardHolder,
                ExpirationDateYYMM = r.ExpirationDateMMYYYY,
                IsMain = r.IsMain,
                ApplyRange = r.ApplyRange,
                DateFrom = r.DateFrom,
                DateTo = r.DateTo,
                isActive = r.isActive,
                CreateDate = r.CreateDate,
                ModiDate = r.ModiDate,
                CreateUsrId = r.CreateUsrId,
                ModiUsrId = r.ModiUsrId,
                hostName = r.hostName,
                HasLoan = r.HasLoan,
                CardTypeDesc = r.CardTypeDesc,
                StatusDesc = r.isActive.HasValue ? (r.isActive.Value ? "Activa" : "Desactivada") : "Desactivada"
            })
            .ToArray();

            return
                result;
        }
        /// <summary>
        /// Author      : Lic. Carlos Ml. Lebron Batista
        /// Create Date : 2018-09-26
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="cardTypeId"></param>
        /// <param name="lastFourDigits"></param>
        /// <param name="cardNumber"></param>
        /// <param name="expirationDate"></param>
        /// <param name="cVV2"></param>
        /// <param name="cardHolder"></param>
        /// <param name="expirationDateMMYYYY"></param>
        /// <param name="isActive"></param>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <param name="isMain"></param>
        /// <param name="applyRange"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="isActiveLoan"></param>
        /// <returns></returns>
        public Loan.CardDomitiliation SetDomitiliatonCard(Nullable<long> clientId, Nullable<int> cardTypeId, string lastFourDigits, string cardNumber, Nullable<System.DateTime> expirationDate, string cVV2, string cardHolder, string expirationDateMMYYYY, Nullable<bool> isActive, Nullable<int> userId, Nullable<long> accountId, Nullable<bool> isMain, Nullable<bool> applyRange, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo, Nullable<bool> isActiveLoan)
        {
            var result = new Loan.CardDomitiliation();
            var temp = base._dbContext.SP_SET_CONTACT_DOMICILIATION_CARD
                                                             (clientId,
                                                              cardTypeId,
                                                              cardNumber.Trim() != "" && cardNumber.Trim().Length >= 4 ? cardNumber.Trim().Substring(cardNumber.Trim().Length - 4, 4) : "",
                                                              cardNumber.Trim(),
                                                              expirationDate,
                                                              cVV2,
                                                              cardHolder,
                                                              expirationDateMMYYYY,
                                                              isActive,
                                                              userId,
                                                              accountId,
                                                              isMain,
                                                              applyRange,
                                                              dateFrom,
                                                              dateTo,
                                                              isActive
                                                              )
                                                              .ToArray();

            result = temp.Select(x => new Loan.CardDomitiliation
            {
                clientId = x.clientId.Value,
                CardTypeId = x.CardTypeId.Value,
                LastFourDigits = x.LastFourDigits
            })
            .FirstOrDefault();

            return
                result;
        }

        public Loan.CreditDebitDirectPayment SetCreditDebitDirectPayment(Nullable<long> creditDebitDirectPaymentId, Nullable<long> accountId, Nullable<int> cardTypeId, Nullable<int> directPaymentStatusId, string cardNumber, string lastFourDigits, string cardName, Nullable<int> yearExpiration, Nullable<int> monthExpiration, Nullable<decimal> quotaAmount, Nullable<decimal> balance, Nullable<decimal> amountPaid, Nullable<System.DateTime> datePaid, Nullable<System.DateTime> dateProcessedCard, Nullable<System.DateTime> dateProcessedEasybank, string authorizationNumber, string receiptNumberEasybank, Nullable<int> userId, string userName)
        {    
            var result = new Loan.CreditDebitDirectPayment();
            var temp = base._dbContext.SP_SET_CREDIT_DEBIT_DIRECT_PAYMENT(creditDebitDirectPaymentId, accountId, cardTypeId, directPaymentStatusId, cardNumber, lastFourDigits, cardName, yearExpiration, monthExpiration, quotaAmount, balance, amountPaid, datePaid, dateProcessedCard, dateProcessedEasybank, authorizationNumber, receiptNumberEasybank, userId, userName).ToArray();
            result = temp.Select(x => new Loan.CreditDebitDirectPayment
            {
                DirectPaymentId = x.DirectPaymentId,
                Action = x.Action
            })
            .FirstOrDefault();

            return
                result;  
        }

        #endregion

        public IEnumerable<Loan> GetAll(long? entityId = null)
        {
            throw new NotImplementedException();
        }

        public Loan FindById(long? Id)
        {
            throw new NotImplementedException();
        }
    }
}
