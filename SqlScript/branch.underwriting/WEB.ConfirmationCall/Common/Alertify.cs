using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace WEB.ConfirmationCall.Common
{
    public class Alertify
    {
        public static void Alert(string msg, Control control)
        {
            ScriptManager.RegisterStartupScript(control, control.GetType(), "alert",
                String.Format("alertify.alert('{0}');", msg.Replace("'", "\"")), true);
        }

        public static void Alert(StringBuilder msg, Control control)
        {
            ScriptManager.RegisterStartupScript(control, control.GetType(), "alert",
                String.Format("alertify.alert('{0}');", msg.ToString().Replace("'", "\"")), true);
        }

        public static void Alert(List<string> lstMsg, Control control)
        {
            var msg = "";
            foreach (var item in lstMsg)
              msg += "-"  + item + " </br>";
            ScriptManager.RegisterStartupScript(control, control.GetType(), "alert",
                String.Format("alertify.alert('{0}');", msg.Replace("'", "\"")), true);
        }
    }
}