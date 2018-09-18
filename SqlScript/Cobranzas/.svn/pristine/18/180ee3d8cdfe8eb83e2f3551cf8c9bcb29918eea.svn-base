using KSI.Cobranza.DataLayer;
using KSI.Cobranza.DataLayer.Repositories;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class LoanManager : BaseManager, IBaseLogic<Loan>
    {
        private LoanRepository _loanRepository;

        public LoanManager()
        {
            _loanRepository = SingletonUnitOfWork.Instance.LoanRepository;
        }


        /// <summary>
        /// Get Payment Plan List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.PaymentPlan> GetPaymentPlan(Nullable<long> accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.PaymentPlan> _Result;

            try
            {
                var data = _loanRepository.GetPaymentPlan(accountId);
                _Result = new ResultLogic<Loan.PaymentPlan> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.PaymentPlan> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get  Codeudor List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.codeudor> GetCodeudor(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.codeudor> _Result;

            try
            {
                var data = _loanRepository.GetCodeudor(accountId);
                _Result = new ResultLogic<Loan.codeudor> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.codeudor> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Policy Information
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.PolicyInformation> GetPolicyInformation(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.PolicyInformation> _Result;

            try
            {
                var data = _loanRepository.GetPolicyInformation(accountId);
                _Result = new ResultLogic<Loan.PolicyInformation> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.PolicyInformation> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Policy Information
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.QuotaInformation> GetReceipOfPayment(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.QuotaInformation> _Result;

            try
            {
                var data = _loanRepository.GetReceipOfPayment(accountId);
                _Result = new ResultLogic<Loan.QuotaInformation> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.QuotaInformation> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Guarantee List
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Guarantee> GetLoanGuarantee(long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Guarantee> _Result;

            try
            {
                var data = _loanRepository.GetLoanGuarantee(accountId);
                _Result = new ResultLogic<Loan.Guarantee> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Guarantee> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Loan information
        /// </summary>
        /// <param name="searchType"></param>
        /// <param name="searchValue"></param>
        /// <param name="identificationNumber"></param>
        /// <returns></returns>
        public ResultLogic<Loan> GetLoanInformation(string clienteName, string identificationNumber, Nullable<long> quotationId, Nullable<long> accountId, string collateralReference, string ChasisNumber)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan> _Result;

            try
            {
                var data = _loanRepository.GetLoanInformation(clienteName, identificationNumber, quotationId, accountId, collateralReference, ChasisNumber);
                _Result = new ResultLogic<Loan> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// Get Loan Detail
        /// </summary>
        /// <param name="quotationId"></param>
        /// <param name="loanNumber"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Detail> GetLoanDetail(long? quotationId, int? loanNumber, long? accountId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Detail> _Result;

            try
            {
                var data = _loanRepository.GetLoanDetailInformation(quotationId, loanNumber, accountId);
                _Result = new ResultLogic<Loan.Detail> { entity = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Detail> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collateralId"></param>
        /// <returns></returns>
        public ResultLogic<Loan.Vehicle> GetVehicleDetail(Nullable<long> collateralId)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.Vehicle> _Result;

            try
            {
                var data = _loanRepository.GetVehicleDetail(collateralId);
                _Result = new ResultLogic<Loan.Vehicle> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.Vehicle> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dateStatement"></param>
        /// <param name="idTipo"></param>
        /// <returns></returns>
        public ResultLogic<Loan.paymentProjection> GetProjectedStatement(Nullable<long> accountId, Nullable<System.DateTime> dateStatement, Nullable<int> idTipo, Nullable<decimal> montoPago)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ResultLogic<Loan.paymentProjection> _Result;

            try
            {
                var data = _loanRepository.GetProjectedStatement(accountId, dateStatement, idTipo,montoPago);
                _Result = new ResultLogic<Loan.paymentProjection> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Loan.paymentProjection> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        public ResultLogic<Loan> GetAll(long? entityId = null)
        {
            throw new NotImplementedException();
        }

        public BaseResultLogic<Loan> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public Result Add(Loan entity)
        {
            throw new NotImplementedException();
        }

        public Result Delete(Loan entity)
        {
            throw new NotImplementedException();
        }

        public Result Edit(Loan entity)
        {
            throw new NotImplementedException();
        }
    }
}
