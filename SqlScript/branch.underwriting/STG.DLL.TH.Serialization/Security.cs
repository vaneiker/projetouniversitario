using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace STG.DLL.TH.Serialization
{
    public class Security
    {
        public class Layer : SecurityPolicyAssertion
        {
            private string m_username;
            private string m_password;
            private X509Certificate2 m_certificate;

            public Layer(string user, string password)
                : this(user, password, null)
            {
            }

            public Layer(string user, string password, string certificateLocation)
            {
                m_username = user;
                m_password = password;
                //If we are passed a certificate location, load it in as a new X509 certificate 
                if (!string.IsNullOrEmpty(certificateLocation))
                {
                    StreamReader sr = new StreamReader(certificateLocation);
                    Stream certStream = sr.BaseStream;

                    if (certStream == null)
                    {
                        throw new Exception("Could not find certificate: " + certificateLocation);
                    }

                    byte[] certData = new byte[Convert.ToInt32(certStream.Length) + 1];
                    certStream.Read(certData, 0, Convert.ToInt32(certStream.Length));
                    certStream.Close();
                    sr.Close();

                    m_certificate = new X509Certificate2(certData);
                }
            }

            public string Username
            {
                //Returns the username to use to login 
                get { return m_username; }
            }

            public string Password
            {
                //Returns the password to use to login 
                get { return m_password; }
            }

            public X509Certificate2 Certificate
            {
                //Returns the location of the client certificate to encrypt the message 
                get { return m_certificate; }
            }

            public override SoapFilter CreateServiceInputFilter(FilterCreationContext context)
            {
                return null;
            }

            public override SoapFilter CreateServiceOutputFilter(FilterCreationContext context)
            {
                return null;
            }

            public override SoapFilter CreateClientInputFilter(FilterCreationContext context)
            {
                return null;
            }

            public override SoapFilter CreateClientOutputFilter(FilterCreationContext context)
            {
                return new Filter(this);
            }

            public override void ReadXml(System.Xml.XmlReader reader, System.Collections.Generic.IDictionary<string, System.Type> extensions)
            {
                reader.Read();
            }
        }
        public class Filter : SendSecurityFilter
        {
            private Layer m_parentAssertion;

            public Filter(Layer parentAssertion)
                : base(parentAssertion.ServiceActor, true)
            {
                m_parentAssertion = parentAssertion;
            }

            public override void SecureMessage(Microsoft.Web.Services3.SoapEnvelope envelope, Microsoft.Web.Services3.Security.Security security)
            {
                if ((m_parentAssertion != null))
                {
                    //Add a username token to the envelope, if we are sent a password send it as plain text 
                    UsernameToken ut = null;
                    if (string.IsNullOrEmpty(m_parentAssertion.Password))
                    {
                        ut = new UsernameToken(m_parentAssertion.Username, "none", PasswordOption.SendNone);
                    }
                    else
                    {
                        ut = new UsernameToken(m_parentAssertion.Username, m_parentAssertion.Password, PasswordOption.SendPlainText);
                    }
                    security.Tokens.Add(ut);

                    //If we have a certicate, encrypt the username token, but set the key algorithm 
                    if ((m_parentAssertion.Certificate != null))
                    {
                        ISecurityTokenManager stm = SecurityTokenManager.GetSecurityTokenManagerByTokenType(WSTrust.TokenTypes.X509v3);
                        ((X509SecurityTokenManager)stm).DefaultKeyAlgorithm = "RSA15";
                        ((X509SecurityTokenManager)stm).DefaultSessionKeyAlgorithm = "AES128";

                        X509SecurityToken st = new X509SecurityToken(m_parentAssertion.Certificate);
                        security.Elements.Add(new EncryptedData(st, "#" + ut.Id));
                        security.Tokens.Add(st);
                    }
                }
            }
        }
    }
}
