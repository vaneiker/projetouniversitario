using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Frontend.Security.SecurityProvider
{
    public class AuthenticationProvider : IAuthenticationProvider
    {

        //private IAuthenticationSource adSource;

        private PosModel dataAccess;

        public AuthenticationProvider(PosModel da)
        {
            dataAccess = da;
        }

        private string EncodePassword(string pass, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA512");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        private string CreateHash(User user, bool lostPass = false)
        {
            var stringToEncode = user.Username + user.Salt + lostPass;
            byte[] bytes = Encoding.UTF8.GetBytes(stringToEncode);

            HashAlgorithm alg = HashAlgorithm.Create("SHA512");
            byte[] output = alg.ComputeHash(bytes);

            return Convert.ToBase64String(output);

        }

        private string GenerateRandomSalt(int size = 32)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var bytes = new Byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public bool AuthenticateUser(string username, string password)
        {

            //Try to authenticate with ActiveDirectory
            var authorized = true;
            //var authAd = adSource.AuthenticateUser(username, password);

            //switch (authAd)
            //{
            //    //TODO: for this stage, we asumed that the authentication is going to be made by POS only.
            //    case (AuthenticationStatus.Authenticated):
            //        {
            //If authenticated in AD, check if the user exists in POS
            var user = (from u in dataAccess.Users
                        where u.Username == username
                        && u.UserOrigin == UserOrigins.POS
                        select u).FirstOrDefault();

            if (user == null)
            {
                authorized = false;
            }
            else //Check password
            {
                if (string.IsNullOrEmpty(user.Salt))
                {
                    authorized = false;
                }
                else
                {
                    var encPass = EncodePassword(password, user.Salt);
                    if (encPass != user.PasswordEncoded)
                        authorized = false;
                }
            }

            //TODO: in this section, a decision must be taken in order to see from where the system takes the additional info needed as well as the password generation

            //    break;
            //}
            //TODO: the other cases must be taken in account in this section of the code
            //}

            return authorized;
        }

        public bool CreateUser(User user, out string message)
        {
            var created = true;
            message = string.Empty;
            var anotherUser = (from u in dataAccess.Users
                               where u.Username == user.Username
                               && u.UserOrigin == user.UserOrigin
                               select u).FirstOrDefault();

            if (anotherUser != null)
            {
                message = "Ya existe un usuario con el mismo nombre de usuario en la base de datos.";
                created = false;
            }
            else
            {
                var salt = GenerateRandomSalt();
                user.Salt = salt;
                user.DateCreated = DateTime.Now;
                user.UserStatus = UserStatus.Created;
                dataAccess.Users.Add(user);
                try
                {
                    dataAccess.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = "Se ha producido un error al guardar el usuario en la base de datos.";
                    created = false;
                }
            }

            return created;
        }

        public string ChangePasswordRequest(string username, bool isLost)
        {
            var user = (from u in dataAccess.Users
                        where u.Username == username
                        select u).FirstOrDefault();

            if (user != null)
            {
                //if (!string.IsNullOrWhiteSpace(user.ChangePasswordToken))
                //    return user.ChangePasswordToken;
                //else
                //{
                    var hash = CreateHash(user, isLost);
                    user.ChangePasswordToken = hash;
                    dataAccess.SaveChanges();
                    return hash;
                //}
            }
            else
            {
                return string.Empty;
            }
        }

        public bool SetPasswordForUser(string token, string oldPassword, string newPassword, out string userName, out string errorMessage)
        {
            //Check the existence of token and validity of password\
            userName = string.Empty;
            var user = (from u in dataAccess.Users
                        where u.ChangePasswordToken == token
                        select u).FirstOrDefault();
            errorMessage = string.Empty;
            var passUpdated = true;
            if (user == null)
            {
                errorMessage = "El token de cambio de contraseña no es válido.";
                passUpdated = false;
            }
            else
            {
                userName = user.Username;
                var isValidOldPassword = true;
                if (user.UserStatus == UserStatus.Active && !IsTokenForPasswordLost(user)) //Check old password; if not, old password is not needed
                    isValidOldPassword = this.AuthenticateUser(user.Username, oldPassword);

                if (!isValidOldPassword)
                {
                    errorMessage = "La contraseña ingresada no es válida.";
                    passUpdated = false;
                }
                else //Everything OK, check pass strength
                {
                    var minStrength = Convert.ToInt32(dataAccess.GetParameter(Parameter.PARAMETER_KEY_MIN_PASSWORD_STRENGTH, "2").Value);
                    var passStrength = (int)PasswordAdvisor.CheckStrength(newPassword);
                    if (passStrength < minStrength)
                    {
                        errorMessage = PasswordAdvisor.GetStrenghtAdvise((PasswordScore)passStrength);
                        passUpdated = false;
                    }
                    else
                    {
                        var newHash = EncodePassword(newPassword, user.Salt);
                        user.PasswordEncoded = newHash;
                        user.ChangePasswordToken = null;
                        user.LastDateModified = DateTime.Now;
                        user.UserStatus = UserStatus.Active;
                        try
                        {
                            dataAccess.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            errorMessage = "Se ha producido un error actualizando el usuario.";
                            passUpdated = false;
                        }
                    }
                }
            }

            return passUpdated;

        }

        public bool IsTokenForPasswordLost(User user)
        {
            var hash = CreateHash(user, true);

            return user.ChangePasswordToken == hash;
        }

        public void ClearPasswordRequest(string username)
        {
            throw new NotImplementedException();
        }
    }
}
