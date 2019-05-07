using Declarative.Invoicing.Data.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Data.Repository
{
    public class BaseRepository
    {
        private  DeclarativeInvoiceDataContext DataContext;
        protected Declarative_InvoicesEntities DeInContex;

        public BaseRepository()
        {
            DataContext = new DeclarativeInvoiceDataContext();
            DeInContex = DataContext.DeInContex;
        } 

    }
}
