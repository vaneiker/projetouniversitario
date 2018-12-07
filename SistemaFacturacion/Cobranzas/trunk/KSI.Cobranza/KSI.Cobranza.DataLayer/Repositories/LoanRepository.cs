﻿using KSI.Cobranza.DataLayer.EFModel;
using KSI.Cobranza.DataLayer.Interfaces;
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

        public IEnumerable<Loan.LoanQueue> GetLoansInQueue(Nullable<int> QueueTypeId, Nullable<int> AssingToId, Nullable<int> VendorId)
        {
            IEnumerable<Loan.LoanQueue> result;
            var temp = base._dbContext.SP_GET_QUEUE_BY_USER(QueueTypeId, AssingToId, VendorId);
            result = temp.Select(r => new Loan.LoanQueue
            {
                AccountId = r.AccountId
                ,
                AccountReference = r.AccountReference
                ,
                ActionDate = r.ActionDate
                ,
                amountApproved = r.amountApproved
                ,
                AssingTo = r.AssingTo
                ,
                AssingToId = r.AssingToId
                ,
                ClientName = r.ClientName
                ,
                ConceptTypeName = r.ConceptTypeName
                ,
                CreateDate = r.CreateDate
                ,
                CreateUsrId = r.CreateUsrId
                ,
                DaysLate = r.DaysLate
                ,
                DepartamentSubmitted = r.DepartamentSubmitted
                ,
                DepartamentTransferred = r.DepartamentTransferred
                ,
                DistributionDesc = r.DistributionDesc
                ,
                DistributionId = r.DistributionId
                ,
                EndDate = r.EndDate
                ,
                ExecutiveFullName = r.ExecutiveFullName
                ,
                hostName = r.hostName
                ,
                IsActive = r.IsActive
                ,
                loanNumber = r.loanNumber
                ,
                LoanStatusName = r.LoanStatusName
                ,
                LoanTerm = r.LoanTerm
                ,
                ModiDate = r.ModiDate
                ,
                ModiUsrId = r.ModiUsrId
                ,
                monto = r.monto
                ,
                officeName = r.officeName
                ,
                PromoterFullName = r.PromoterFullName
                ,
                QueueId = r.QueueId
                ,
                QueueSourceDesc = r.QueueSourceDesc
                ,
                QueueSourceId = r.QueueSourceId
                ,
                QueueStatusDesc = r.QueueStatusDesc
                ,
                QueueStatusId = r.QueueStatusId
                ,
                QueueTypeDesc = r.QueueTypeDesc
                ,
                QueueTypeId = r.QueueTypeId
                ,
                Rate = r.Rate
                ,
                SubmittedByDepartmentId = r.SubmittedByDepartmentId
                ,
                transactionPaymentPlanId = r.transactionPaymentPlanId
                ,
                TransferredFromDepartmentId = r.TransferredFromDepartmentId
                ,
                TypeofTracking = r.TypeofTracking
                ,
                VendorId = r.VendorId
                ,
                quotationId = r.quotationId.Value
                ,
                relatedContactId = r.relatedContactId.Value
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
                fullNamePromoter = r.fullNamePromoter,
                account = r.account,
                accountId = r.accountId
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
                TipoSaldo = r.TipoSaldo,
                NameKey = r.NameKey
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

        public Loan.Correspondence GetLoanCorrespondence(Nullable<long> accountId)
        {
            Loan.Correspondence result;
            IEnumerable<SP_GET_LOAN_CORRESPONDENCE_Result> temp;
            temp = base._dbContext.SP_GET_LOAN_CORRESPONDENCE(accountId);
            result = temp.Select(x => new Loan.Correspondence
            {
                CaseNo = x.CaseNo,
                CaseTypeId = x.CaseTypeId,
                CanseTypeName = x.CanseTypeName,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                accountID = x.accountID,
                ConceptTypeName = x.ConceptTypeName,
                account = x.account,
                EmailMainClient = x.EmailMainClient,
                EmailAddClient = x.EmailAddClient,
                EmailAgent = x.EmailAgent,
                EmailOffice = x.EmailOffice,
                EmailProvider = x.EmailProvider,
                EmailAdd = x.EmailAdd,
                clientName = x.clientName,
                AgentFullName = x.AgentFullName,
                OficinaFullName = x.OficinaFullName
            })
            .FirstOrDefault();

            return
                result;
        }

        public IEnumerable<Loan.Template> GetTemplate(Nullable<long> templateId)
        {
            IEnumerable<Loan.Template> result;
            IEnumerable<SP_GET_TEMPLATES_TH_Result> temp;
            temp = base._dbContext.SP_GET_TEMPLATES_TH(templateId);
            result = temp.Select(x => new Loan.Template
            {
                TemplateId = x.TemplateId,
                TemplateName = x.TemplateName,
                TemplateCode = x.TemplateCode,
                PartialViewName = x.PartialViewName,
                Description = x.Description,
                DocumentNameKey = x.DocumentNameKey,
                isActive = x.isActive,
                CreateDate = x.CreateDate,
                ModiDate = x.ModiDate,
                CreateUsrId = x.CreateUsrId,
                ModiUsrId = x.ModiUsrId,
                hostName = x.hostName
            });

            return
                 result;
        }


        public Loan.Correspondence.RelatedDocuments.ResultHeader SetTemplate(Nullable<long> templateSentId, Nullable<short> templateId, Nullable<long> accountId, Nullable<long> clienteId, Nullable<System.DateTime> sendDate, string clientName, string documentPath, string documentName, string emails, string comments, Nullable<bool> isActive, Nullable<bool> isSendToClient, Nullable<bool> isSendToOffice, Nullable<bool> isSendToAgent, Nullable<int> caseDepartmentID, Nullable<System.DateTime> caseDate, Nullable<System.TimeSpan> caseHour, string caseComment, Nullable<long> caseNo, Nullable<int> userId, string userName)
        {
            IEnumerable<Loan.Correspondence.RelatedDocuments.ResultHeader> result;
            IEnumerable<SP_SET_TEMPLATE_SEND_Result> temp;
            temp = base._dbContext.SP_SET_TEMPLATE_SEND(templateSentId, templateId, accountId, clienteId, sendDate, clientName, documentPath, documentName, emails, comments, isActive, isSendToClient, isSendToOffice, isSendToAgent, caseDepartmentID, caseDate, caseHour, caseComment, caseNo, userId, userName);

            result = temp.Select(x => new Loan.Correspondence.RelatedDocuments.ResultHeader
            {
                Action = x.Action,
                TemplateSentId = x.TemplateSentId
            });

            return
                 result
                 .FirstOrDefault();
        }

        public Loan.Correspondence.RelatedDocuments.ResultDetail SetTemplateRelatedFile(Nullable<long> templateSentRelatedFileId, Nullable<long> templateSentId, Nullable<int> documentTypeGroupId, string documentPath, string documentName, string comments, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<decimal> sizeFile)
        {
            IEnumerable<Loan.Correspondence.RelatedDocuments.ResultDetail> result;
            IEnumerable<SP_SET_TEMPLATE_SEND_RELATED_DOCUMENT_Result> temp;
            temp = base._dbContext.SP_SET_TEMPLATE_SEND_RELATED_DOCUMENT(templateSentRelatedFileId, templateSentId, documentTypeGroupId, documentPath, documentName, comments, isActive, userId, userName, sizeFile);

            result = temp.Select(x => new Loan.Correspondence.RelatedDocuments.ResultDetail
            {
                Action = x.Action,
                TemplateSentRelatedFileId = x.TemplateSentRelatedFileId
            });

            return
                 result
                 .FirstOrDefault();
        }

        public IEnumerable<Loan.Correspondence.RelatedDocuments> GetTemplateRelatedFile(Nullable<long> templateId, Nullable<long> accountId, Nullable<long> templateSentId)
        {
            IEnumerable<Loan.Correspondence.RelatedDocuments> result;
            IEnumerable<SP_GET_LOAN_TEMPLATE_SENT_RELATED_FILE_TH_Result> temp;
            temp = base._dbContext.SP_GET_LOAN_TEMPLATE_SENT_RELATED_FILE_TH(templateId, accountId, templateSentId);
            result = temp.Select(x => new Loan.Correspondence.RelatedDocuments
            {
                TemplateId = x.TemplateId,
                TemplateSentId = x.TemplateSentId,
                AccountId = x.AccountId,
                ClienteId = x.ClienteId,
                documentTypeGroupId = x.documentTypeGroupId,
                documentGroupId = x.documentGroupId,
                TemplateName = x.TemplateName,
                TemplateCode = x.TemplateCode,
                PartialViewName = x.PartialViewName,
                Description = x.Description,
                DocumentNameKey = x.DocumentNameKey,
                SendDate = x.SendDate,
                ClientName = x.ClientName,
                DocumentPath = x.DocumentPath,
                documentName = x.documentName,
                emails = x.emails,
                comments = x.comments,
                RelatedDocumentPath = x.RelatedDocumentPath,
                RelatedDocumentName = x.RelatedDocumentName,
                RelatedComments = x.RelatedComments,
                RelatedIsActive = x.RelatedIsActive,
                documentTypeGroupCode = x.documentTypeGroupCode,
                documentTypeGroupName = x.documentTypeGroupName,
                documentGroupName = x.documentGroupName,
                documentGroupCode = x.documentGroupCode,
                isActive = x.isActive,
                CreateDate = x.CreateDate,
                ModiDate = x.ModiDate,
                CreateUsrId = x.CreateUsrId,
                ModiUsrId = x.ModiUsrId,
                hostName = x.hostName,
                TemplateSentRelatedFileId = x.TemplateSentRelatedFileId,
                sizeFile = x.sizeFile
            });

            return
                 result;
        }

        #endregion

        public Loan.Correspondence.RelatedDocuments.DeleteResult DeleteRelateFile(Nullable<long> templateSentId, Nullable<long> templateSentRelatedFileId)
        {
            IEnumerable<SP_SET_DELETE_TEMPLATE_SEND_RELATED_DOCUMENT_Result> temp;
            Loan.Correspondence.RelatedDocuments.DeleteResult result;
            temp = base._dbContext.SP_SET_DELETE_TEMPLATE_SEND_RELATED_DOCUMENT(templateSentId, templateSentRelatedFileId);
            result = temp.Select(o => new Loan.Correspondence.RelatedDocuments.DeleteResult
            {
                TemplateSentRelatedFileId = o.TemplateSentRelatedFileId,
                TemplateSentId = o.TemplateSentId,
                DocumentPath = o.DocumentPath
            }).FirstOrDefault();


            return
                result;
        }

        public IEnumerable<Loan> GetAll(long? entityId = null)
        {
            throw new NotImplementedException();
        }

        public Loan FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan.Cases> GetMeetingCase(Nullable<long> relatedContactId, Nullable<long> accountId, Nullable<long> caseNumber, Nullable<int> meetingStatusId)
        {
            IEnumerable<SP_GET_MEETING_CASE_Result> temp;
            IEnumerable<Loan.Cases> result;
            temp = base._dbContext.SP_GET_MEETING_CASE(relatedContactId, accountId, caseNumber, meetingStatusId);
            result = temp.Select(p => new Loan.Cases
            {
                relatedContactId = p.relatedContactId,
                MeetingTypeId = p.MeetingTypeId,
                MeetingSubTypeId = p.MeetingSubTypeId,
                MeetingCaseId = p.MeetingCaseId,
                accountId = p.accountId,
                MeetingStatusId = p.MeetingStatusId,
                MeetingStatusDesc = p.MeetingStatusDesc,             
                ReasonId = p.ReasonId,
                DepartmentId = p.DepartmentId,
                CategoryId = p.CategoryId,
                PriorityId = p.PriorityId,
                CaseNumber = p.CaseNumber,
                MeetingDate = p.MeetingDate,
                MeetingShortNote = p.MeetingShortNote,
                CallAssignedId = p.CallAssignedId,
                NotifiedToEmail = p.NotifiedToEmail,
                Notified = p.Notified,
                AttemptNo = p.AttemptNo,
                MeetingDesc = p.MeetingDesc,
                MeetingSubDesc = p.MeetingSubDesc,
                ReasonDesc = p.ReasonDesc,
                DepartamentDesc = p.DepartamentDesc,
                CategoryDesc = p.CategoryDesc,
                PriorityDesc = p.PriorityDesc,
                CallAssingName = p.CallAssingName,
                CreatedUserName = p.CreatedUserName,
                ModifiedUserName = p.ModifiedUserName,
                NotesCount = p.NotesCount,
                CallCount = p.CallCount,
                FullName = p.FullName,
                account = p.account,
                IsActive = p.IsActive,
                CreateDate = p.CreateDate,
                ModiDate = p.ModiDate,
                CreateUsrId = p.CreateUsrId,
                ModiUsrId = p.ModiUsrId,
                hostName = p.hostName
            });

            return
                result;
        }

        public IEnumerable<Loan.Cases.Detail> GetMeetingCaseNote(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId)
        {
            IEnumerable<SP_GET_MEETING_CASE_NOTE_Result> temp;
            IEnumerable<Loan.Cases.Detail> result;
            temp = _dbContext.SP_GET_MEETING_CASE_NOTE(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId);
            result = temp.Select(p => new Loan.Cases.Detail
            {
                relatedContactId = p.relatedContactId,
                MeetingTypeId = p.MeetingTypeId,
                MeetingSubTypeId = p.MeetingSubTypeId,
                MeetingCaseId = p.MeetingCaseId,
                accountId = p.accountId,
                MeetingStatusId = p.MeetingStatusId,
                MeetingStatusDesc = p.MeetingStatusDesc,
                ReasonId = p.ReasonId,
                DepartmentId = p.DepartmentId,
                CategoryId = p.CategoryId,
                MeetingCaseNoteId = p.MeetingCaseNoteId,
                PriorityId = p.PriorityId,
                ServiceChannelId = p.ServiceChannelId,
                OriginatedById = p.OriginatedById,
                CaseNumber = p.CaseNumber,
                MeetingDate = p.MeetingDate,
                MeetingShortNote = p.MeetingShortNote,
                CallAssignedId = p.CallAssignedId,
                NotifiedToEmail = p.NotifiedToEmail,
                Notified = p.Notified,
                AttemptNo = p.AttemptNo,
                MeetingDesc = p.MeetingDesc,
                MeetingSubDesc = p.MeetingSubDesc,
                ReasonDesc = p.ReasonDesc,
                DepartamentDesc = p.DepartamentDesc,
                CategoryDesc = p.CategoryDesc,
                PriorityDesc = p.PriorityDesc,
                ServiceChannelDesc = p.ServiceChannelDesc,
                Note = p.Note,
                CallAssingName = p.CallAssingName,
                CreatedUserName = p.CreatedUserName,
                ModifiedUserName = p.ModifiedUserName,
                CallCount = p.CallCount,
                FullName = p.FullName,
                account = p.account,
                IsActive = p.IsActive,
                MeetingClosedDate = p.MeetingClosedDate,
                CreateDate = p.CreateDate,
                ModiDate = p.ModiDate,
                CreateUsrId = p.CreateUsrId,
                ModiUsrId = p.ModiUsrId,
                hostName = p.hostName,
                QueueId = p.QueueId
            });

            return
                result;
        }

        public IEnumerable<Loan.Cases.Detail.Calls> GetMeetingCaseNoteCall(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId)
        {
            IEnumerable<SP_GET_MEETING_CASE_NOTE_CALL_Result> temp;
            IEnumerable<Loan.Cases.Detail.Calls> result;
            temp = _dbContext.SP_GET_MEETING_CASE_NOTE_CALL(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId);
            result = temp.Select(p => new Loan.Cases.Detail.Calls
            {
                relatedContactId = p.relatedContactId,
                MeetingTypeId = p.MeetingTypeId,
                MeetingSubTypeId = p.MeetingSubTypeId,
                MeetingCaseId = p.MeetingCaseId,
                accountId = p.accountId,
                MeetingStatusId = p.MeetingStatusId,
                ReasonId = p.ReasonId,
                DepartmentId = p.DepartmentId,
                CategoryId = p.CategoryId,
                MeetingCaseNoteId = p.MeetingCaseNoteId,
                PriorityId = p.PriorityId,
                ServiceChannelId = p.ServiceChannelId,
                OriginatedById = p.OriginatedById,
                MeetingCaseNoteCallId = p.MeetingCaseNoteCallId,
                CaseNumber = p.CaseNumber,
                MeetingDate = p.MeetingDate,
                MeetingShortNote = p.MeetingShortNote,
                CallAssignedId = p.CallAssignedId,
                NotifiedToEmail = p.NotifiedToEmail,
                Notified = p.Notified,
                AttemptNo = p.AttemptNo,
                MeetingDesc = p.MeetingDesc,
                MeetingSubDesc = p.MeetingSubDesc,
                ReasonDesc = p.ReasonDesc,
                DepartamentDesc = p.DepartamentDesc,
                CategoryDesc = p.CategoryDesc,
                PriorityDesc = p.PriorityDesc,
                ServiceChannelDesc = p.ServiceChannelDesc,
                Note = p.Note,
                CallDuration = p.CallDuration,
                CallStart = p.CallStart,
                CallStop = p.CallStop,
                DialedNumber = p.DialedNumber,
                Extension = p.Extension,
                FileName = p.FileName,
                FullPathFile = p.FullPathFile,
                CallLogId = p.CallLogId,
                CallRexUserId = p.CallRexUserId,
                UserFirstName = p.UserFirstName,
                UserLastName = p.UserLastName,
                CallAssingName = p.CallAssingName,
                CreatedUserName = p.CreatedUserName,
                ModifiedUserName = p.ModifiedUserName,
                FullName = p.FullName,
                account = p.account,
                IsActive = p.IsActive,
                CreateDate = p.CreateDate,
                ModiDate = p.ModiDate,
                CreateUsrId = p.CreateUsrId,
                ModiUsrId = p.ModiUsrId,
                hostName = p.hostName
            });

            return
                result;
        }

        public Loan.Cases SetMeetingCase(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<long> accountId, Nullable<int> meetingStatusId, Nullable<int> reasonId, Nullable<int> departmentId, Nullable<int> categoryId, Nullable<long> caseNumber, Nullable<System.DateTime> meetingDate, string meetingShortNote, Nullable<int> callAssignedId, string notifiedToEmail, Nullable<bool> notified, Nullable<int> attemptNo, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<System.DateTime> meetingClosedDate, Nullable<int> queueId)
        {
            Loan.Cases result;
            IEnumerable<SP_SET_MEETING_CASE_Result> temp;
            temp = _dbContext.SP_SET_MEETING_CASE(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, accountId, meetingStatusId, reasonId, departmentId, categoryId, caseNumber, meetingDate, meetingShortNote, callAssignedId, notifiedToEmail, notified, attemptNo, isActive, userId, userName, meetingClosedDate, queueId);
            result = temp.Select(x => new Loan.Cases
            {
                relatedContactId = x.relatedContactId.GetValueOrDefault(),
                MeetingTypeId = x.MeetingTypeId.GetValueOrDefault(),
                MeetingSubTypeId = x.MeetingSubTypeId.GetValueOrDefault(),
                MeetingCaseId = x.MeetingCaseId.GetValueOrDefault(),
                accountId = x.accountId,
                Action = x.Action
            })
            .FirstOrDefault();

            return
                result;
        }

        public Loan.Cases SetMeetingNote(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> priorityId, Nullable<int> serviceChannelId, Nullable<int> originatedById, string note, Nullable<bool> isActive, Nullable<int> userId, string userName)
        {
            Loan.Cases result;
            IEnumerable<SP_SET_MEETING_CASE_NOTE_Result> temp;
            temp = _dbContext.SP_SET_MEETING_CASE_NOTE(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, priorityId, serviceChannelId, originatedById, note, isActive, userId, userName);
            result = temp.Select(x => new Loan.Cases
            {
                relatedContactId = x.relatedContactId.GetValueOrDefault(),
                MeetingTypeId = x.MeetingTypeId.GetValueOrDefault(),
                MeetingSubTypeId = x.MeetingSubTypeId.GetValueOrDefault(),
                MeetingCaseId = x.MeetingCaseId.GetValueOrDefault(),
                MeetingCaseNoteId = x.MeetingCaseNoteId.GetValueOrDefault(),
                Action = x.Action
            })
            .FirstOrDefault();

            return
                result;
        }

        public Loan.Cases.Detail.Calls SetMeetingCall(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> meetingCaseNoteCallId, Nullable<System.TimeSpan> callDuration, Nullable<System.DateTime> callStart, Nullable<System.DateTime> callStop, string dialedNumber, string extension, string fileName, string fullPathFile, string callLogId, string callRexUserId, string userFirstName, string userLastName, Nullable<bool> isActive, Nullable<int> userId, string userName)
        {
            Loan.Cases.Detail.Calls result;
            IEnumerable<SP_SET_MEETING_CASE_NOTE_CALL_Result> temp;
            temp = _dbContext.SP_SET_MEETING_CASE_NOTE_CALL(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, meetingCaseNoteCallId, callDuration, callStart, callStop, dialedNumber, extension, fileName, fullPathFile, callLogId, callRexUserId, userFirstName, userLastName, isActive, userId, userName);
            result = temp.Select(x => new Loan.Cases.Detail.Calls
            {
                relatedContactId = x.relatedContactId.GetValueOrDefault(),
                MeetingTypeId = x.MeetingTypeId.GetValueOrDefault(),
                MeetingSubTypeId = x.MeetingSubTypeId.GetValueOrDefault(),
                MeetingCaseId = x.MeetingCaseId.GetValueOrDefault(),
                MeetingCaseNoteId = x.MeetingCaseNoteId.GetValueOrDefault(),
                MeetingCaseNoteCallId = x.MeetingCaseNoteCallId.GetValueOrDefault(),
                Action = x.Action
            })
            .FirstOrDefault();

            return
                result;
        }

        public Loan.Cases.Detail.File SetMeetingCaseFile(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> meetingCaseNoteFileId, Nullable<int> documentTypeGroupId, string documentPath, string documentName, string comments, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<decimal> sizeFile)
        {
            Loan.Cases.Detail.File result;
            IEnumerable<SP_SET_MEETING_CASE_FILE_Result> temp;
            temp = _dbContext.SP_SET_MEETING_CASE_FILE(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId, meetingCaseNoteFileId, documentTypeGroupId, documentPath, documentName, comments, isActive, userId, userName, sizeFile);
            result = temp.Select(x => new Loan.Cases.Detail.File
            {
                relatedContactId = x.relatedContactId.GetValueOrDefault(),
                MeetingTypeId = x.MeetingTypeId.GetValueOrDefault(),
                MeetingSubTypeId = x.MeetingSubTypeId.GetValueOrDefault(),
                MeetingCaseId = x.MeetingCaseId.GetValueOrDefault(),
                MeetingCaseNoteId = x.MeetingCaseNoteId.GetValueOrDefault(),
                MeetingCaseNoteFileId = x.MeetingCaseNoteFileId.GetValueOrDefault(),
                Action = x.Action
            })
            .FirstOrDefault();

            return
                result;
        }

        public IEnumerable<Loan.Cases.Detail.File> GetMeetingCaseFile(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId)
        {
            IEnumerable<Loan.Cases.Detail.File> result;
            IEnumerable<SP_GET_MEETING_CASE_FILE_Result> temp;
            temp = _dbContext.SP_GET_MEETING_CASE_FILE(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId);
            result = temp.Select(x => new Loan.Cases.Detail.File
            {
                relatedContactId = x.relatedContactId,
                MeetingTypeId = x.MeetingTypeId,
                MeetingSubTypeId = x.MeetingSubTypeId,
                MeetingCaseId = x.MeetingCaseId,
                accountId = x.accountId,
                MeetingStatusId = x.MeetingStatusId,
                MeetingStatusDesc = x.MeetingStatusDesc,
                ReasonId = x.ReasonId,
                DepartmentId = x.DepartmentId,
                CategoryId = x.CategoryId,
                MeetingCaseNoteId = x.MeetingCaseNoteId,
                PriorityId = x.PriorityId,
                ServiceChannelId = x.ServiceChannelId,
                OriginatedById = x.OriginatedById,
                MeetingCaseNoteFileId = x.MeetingCaseNoteFileId,
                documentTypeGroupId = x.documentTypeGroupId,
                DocumentPath = x.DocumentPath,
                SizeFile = x.SizeFile,
                documentName = x.documentName,
                MeetingCaseNoteFilecomments = x.MeetingCaseNoteFilecomments,
                CaseNumber = x.CaseNumber,
                MeetingDate = x.MeetingDate,
                MeetingShortNote = x.MeetingShortNote,
                CallAssignedId = x.CallAssignedId,
                NotifiedToEmail = x.NotifiedToEmail,
                Notified = x.Notified,
                AttemptNo = x.AttemptNo,
                MeetingDesc = x.MeetingDesc,
                MeetingSubDesc = x.MeetingSubDesc,
                ReasonDesc = x.ReasonDesc,
                DepartamentDesc = x.DepartamentDesc,
                CategoryDesc = x.CategoryDesc,
                PriorityDesc = x.PriorityDesc,
                ServiceChannelDesc = x.ServiceChannelDesc,
                Note = x.Note,
                CallAssingName = x.CallAssingName,
                CreatedUserName = x.CreatedUserName,
                ModifiedUserName = x.ModifiedUserName,
                CallCount = x.CallCount,
                FullName = x.FullName,
                account = x.account,
                IsActive = x.IsActive,
                CreateDate = x.CreateDate,
                ModiDate = x.ModiDate,
                CreateUsrId = x.CreateUsrId,
                ModiUsrId = x.ModiUsrId,
                hostName = x.hostName,
                MeetingClosedDate = x.MeetingClosedDate,
                QueueId = x.QueueId
            });            

            return
                result;
        }
    }
}
