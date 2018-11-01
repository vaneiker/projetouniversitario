using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.IdentityModel.Selectors;

namespace ATL.SVC.Services
{
    public class Authenticator : UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            if (userName != "atlkco" && password != "atl123kco")
            {
                throw new FaultException("Invalid user and/or password");
            }
        }
    }
}