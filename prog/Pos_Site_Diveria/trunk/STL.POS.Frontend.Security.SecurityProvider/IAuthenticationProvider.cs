using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Frontend.Security.SecurityProvider
{
    public interface IAuthenticationProvider
    {

        bool AuthenticateUser(string username, string password);

        bool CreateUser(User user, out string message);

        bool SetPasswordForUser(string token, string oldPassword, string newPassword, out string userName, out string errorMessage);

        string ChangePasswordRequest(string username, bool isLost);

        void ClearPasswordRequest(string username);

        bool IsTokenForPasswordLost(User user);
            
    }
}
