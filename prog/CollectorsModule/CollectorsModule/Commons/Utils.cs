using CollectorsModule.bll.Services;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace CollectorsModule.Commons
{
    public static class Utils
    {
        /// <summary>
        /// Devuelve el keyvalue del keyname pasado como paramero un aspxGridView el grid debe tener habilitado Focused Row
        /// </summary>
        /// <param name="aspxGridView"></param>
        /// <param name="RowIndex"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetKeyFromAspxGridView(this ASPxGridView aspxGridView, string keyName)
        {
            dynamic result = null;
            var Key = aspxGridView.GetRowValues(aspxGridView.FocusedRowIndex, keyName);

            if (Key != null)
            {
                result = Key;
            }

            return result;
        }

        /// <summary>
        /// Ejecuta llamada de sentencia Javascript en Client-Side.
        /// </summary>
        /// <param name="Container"></param>
        /// <param name="JScript"></param>
        public static void JSExec(this Control Container, string JScript)
        {
            ScriptManager.RegisterStartupScript(Container.Page, Container.Page.GetType(), null, JScript, true);
        }

        /// <summary>
        /// Devuelve monto limpio enviado en parametro de entrada, basado en regla de si llega monto vacio, siempre devolvera 0.00, si llega con simbolos de dinero por igual se limpia a un decimal.
        /// </summary>
        /// <param name="strColumn"></param>
        /// <returns></returns>
        public static decimal getDecimalValue(string strColumn)
        {
            return decimal.Parse((string.IsNullOrEmpty(strColumn ?? string.Empty) ? "0.00" : (strColumn ?? string.Empty).ToString()).ToString(), NumberStyles.Currency);
        }

        /// <summary>
        /// Envia el correo de error a los administradores del sitio
        /// </summary>
        /// <param name="Parametros"></param>
        /// <param name="Metodo"></param>
        public static void SendError(string Parametros, string Metodo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(Metodo + ": parametros: " + Parametros);
            String Body = sb.ToString();

            System.Net.Mail.MailMessage me = new System.Net.Mail.MailMessage();
            System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["From"].ToString());
            System.Net.Mail.SmtpClient smtpServer = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString());
            me.From = from;
            if (System.Configuration.ConfigurationManager.AppSettings["Mail_Errors"] != null)
            {
                var to = System.Configuration.ConfigurationManager.AppSettings["Mail_Errors"].ToString().Split(';');
                foreach (var mail in to)
                {
                    me.To.Add(mail);
                }
            }
            else
            {
                me.To.Add("epimentel@statetrustlife.com");
            }
            me.IsBodyHtml = true;
            me.Body = Body;
            me.Subject = System.Configuration.ConfigurationManager.AppSettings["Subject"].ToString();
            try
            {
                smtpServer.Send(me);
            }
            catch (System.Net.Mail.SmtpException)
            {
                //No hay implementacion de registros de errores en BD o files fisicos, cuando se implemente, favor tomar en cuenta loggear este error.
            }
        }

        public static void ErrorLogDB(string parameters, string error_Logged)
        {
            try
            {
                Lazy<UtilitiesServices> US = new Lazy<UtilitiesServices>();
                US.Value.ErrorLogDB(parameters, error_Logged);
            }
            catch (Exception ex)
            {

            }
        }

        public static int GetRowVisibleCount(ASPxGridView Grid, string DefaultField, out int rowIndexOverload)
        {
            var counter = rowIndexOverload = 0;
            try
            {
                rowIndexOverload = Grid.PageIndex == 0?0:(Grid.PageIndex) * Grid.SettingsPager.PageSize;
                var pagerowcount = Grid.GetCurrentPageRowValues();
                if (pagerowcount == null || pagerowcount.Count <= 0)
                    counter = Grid.VisibleRowCount;
                else
                    counter = pagerowcount.Count();
            }
            catch (Exception) {}
            return counter;
        }

        /// <summary>
        /// Converts a string to PascalCase
        /// </summary>
        /// <param name="str">String to convert</param>
        public static string ToPascalCase(this string str)
        {

            // Replace all non-letter and non-digits with an underscore and lowercase the rest.
            string sample = string.Join("", str?.Select(c => Char.IsLetterOrDigit(c) ? c.ToString().ToLower() : "_").ToArray());

            // Split the resulting string by underscore
            // Select first character, uppercase it and concatenate with the rest of the string
            var arr = sample?
                .Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => $"{s.Substring(0, 1).ToUpper()}{s.Substring(1)}");

            // Join the resulting collection
            sample = string.Join(" ", arr);

            return sample;
        }

        public static string CleanSpaces(this string value)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            value = regex.Replace(value, " ");
            return value;
        }

        public static string Unescape(this string txt)
        {
            if (string.IsNullOrEmpty(txt)) { return txt; }
            StringBuilder retval = new StringBuilder(txt.Length);
            for (int ix = 0; ix < txt.Length;)
            {
                int jx = txt.IndexOf('\\', ix);
                if (jx < 0 || jx == txt.Length - 1) jx = txt.Length;
                retval.Append(txt, ix, jx - ix);
                if (jx >= txt.Length) break;
                switch (txt[jx + 1])
                {
                    case 'n': retval.Append('\n'); break;  // Line feed
                    case 'r': retval.Append('\r'); break;  // Carriage return
                    case 't': retval.Append('\t'); break;  // Tab
                    case '\\': retval.Append('\\'); break; // Don't escape
                    default:                                 // Unrecognized, copy as-is
                        retval.Append('\\').Append(txt[jx + 1]); break;
                }
                ix = jx + 2;
            }
            return retval.ToString();
        }
    }
}