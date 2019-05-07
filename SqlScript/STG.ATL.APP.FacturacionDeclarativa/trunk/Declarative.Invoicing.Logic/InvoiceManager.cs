using Declarative.Invoicing.Data.Repository;
using Declarative.Invoicing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Logic
{
    public class InvoiceManager : BaseManager
    {
        private readonly InvoiceRepository invoiceRepository;

        public InvoiceManager()
        {
            invoiceRepository = new InvoiceRepository();
        }

        #region Get

        //public IEnumerable<Queue> GetQueue(string policy, DateTime? DateBilling)
        //{
        //    return
        //        queueRepository.GetQueue(policy, DateBilling);
        //}

        #endregion

        #region Set

        public virtual BaseEntities SetInvoiceHeader(Invoices.InvoiceHeaderParams parameters)        
        {
            return
                invoiceRepository.SetInvoiceHeader(parameters);
        }

        public virtual BaseEntities SetInvoiceDetail(Invoices.InvoiceDetailParams parameters)
        {
            return
                invoiceRepository.SetInvoiceDetail(parameters);
        }

        public virtual int SetPeriodInvoiced(Nullable<int> policyInfoId, Nullable<int> periodId, Nullable<System.DateTime> processDate)
        {
            return invoiceRepository.SetPeriodInvoiced(policyInfoId, periodId, processDate);
        }
        #endregion
    }
}
