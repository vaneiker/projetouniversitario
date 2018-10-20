using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Frontend.Security.SecurityProvider
{

    public enum AuthenticationStatus
    {
        Authenticated,
        NotAuthenticated,
        UserNotExist,
        Error
    }

    public interface IAuthenticationSource
    {

        /// <summary>
        /// This method should validate the credentials against AD.
        /// </summary>
        /// <param name="username">User name to validate.</param>
        /// <param name="password">Password to validate</param>
        /// <returns></returns>
        AuthenticationStatus AuthenticateUser(string username, string password);

        /// <summary>
        /// This method should gather as much information as it can from AD and return a new User object filled with it.
        /// </summary>
        /// <param name="username">The username to gather info from.</param>
        /// <returns>New User object with AD information.</returns>
        User GetUserFromAd(string username);

    }
}
