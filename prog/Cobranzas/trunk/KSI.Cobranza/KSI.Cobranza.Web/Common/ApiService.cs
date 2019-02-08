using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSI.Cobranza.LogicLayer.Implementation;

namespace KSI.Cobranza.Web.Common
{
    public class ApiService
    {
        public ApiService() { }

        public CustomerManager customerManager
        {
            get { return new Lazy<CustomerManager>().Value; }
        }

        public ContactPhoneManager contactPhoneManager
        {
            get { return new Lazy<ContactPhoneManager>().Value; }
        }

        public ContactEmailAddressManager contactEmailAddressManager
        {
            get { return new Lazy<ContactEmailAddressManager>().Value; }
        }

        public LoanManager loanManager
        {
            get { return new Lazy<LoanManager>().Value; }
        }

        public BaseManager baseManager
        {
            get { return new BaseManager(); }
        }
    }
}