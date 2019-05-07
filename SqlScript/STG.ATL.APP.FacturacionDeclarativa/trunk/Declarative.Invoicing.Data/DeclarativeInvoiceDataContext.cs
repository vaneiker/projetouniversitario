using Declarative.Invoicing.Data.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Data
{
    public class DeclarativeInvoiceDataContext
    {
        public DeclarativeInvoiceDataContext(string ConnStr = "") { }

        private Declarative_InvoicesEntities _DeInContex;

        public Declarative_InvoicesEntities DeInContex
        {
            get
            {
                return _DeInContex ?? new Declarative_InvoicesEntities();
            }
        }
    }
}
