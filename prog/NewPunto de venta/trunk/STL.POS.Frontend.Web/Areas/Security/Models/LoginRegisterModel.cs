using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.Areas.Security.Models
{
    public class LoginRegisterModel
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string ConfirmEmail { get; set; }

        public string Errors { get; set; }

        public string UserCreatedMessage { get; set; }

        public Data.User GetUser()
        {
            var user = new Data.User();
            user.Email = Email;
            user.Name = Name;
            user.Surname = Surname;
            user.Telephone = Telephone;
            user.Username = Email;

            return user;
        }

        public bool IsValid(out List<string> errorMessages)
        {
            errorMessages = new List<string>();
            if (Email != ConfirmEmail)
            {
                errorMessages.Add("El E-Mail y la confirmación del E-Mail no coinciden.");
                return false;
            }
            return true;
        }

    }
}