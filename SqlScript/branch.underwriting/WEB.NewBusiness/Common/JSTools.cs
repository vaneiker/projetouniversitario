using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace WEB.NewBusiness.Common
{
    public static class JSTools
    { 
        public class OptionsPopup
        {
            public Panel panel { get; set; }
            public Boolean AutoOpen { get; set; }
            public Boolean ShowTitleBar { get; set; }
            public String Title { get; set; }
            public bool isModal { get; set; }
            public bool resizable { get; set; }
            public HiddenField hdn { get; set; }
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron B.
        /// Despliega un Cuadro de Mensaje en pantalla con el texto pasado en el parametro Message
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="Message"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="isModal"></param>
        /// <param name="Title"></param>
        public static void MessageBox(this Control Ctrl, String Message, int? Width = 350, int? Height = null, Boolean isModal = true, String Title = "Alert")
        {
            if (Title == "Alert")
                Title = RESOURCE.UnderWriting.NewBussiness.Resources.Alert;
            var Func = string.Format("CustomDialogMessageEx('{0}',{1},{2},{3},'{4}');", Message, Width.HasValue ? Width.ToString() : "null", Height.HasValue ? Height.ToString() : "null", isModal.ToString().ToLower(), Title);
            Utility.ExcecuteJScript(Ctrl, Func);
        }

        public static void MessageBoxALIF(this Control Ctrl, String Message, int? Width = 350, int? Height = null, Boolean isModal = true, String Title = "Alert")
        {
            if (Title == "Alert")
                Title = RESOURCE.UnderWriting.NewBussiness.Resources.Alert;
            var Func = string.Format("CustomDialogMessageExALIF('{0}',{1},{2},{3},'{4}');", Message, Width.HasValue ? Width.ToString() : "null", Height.HasValue ? Height.ToString() : "null", isModal.ToString().ToLower(), Title);
            Utility.ExcecuteJScript(Ctrl, Func);
        }

        public static void ShowPopup(this Control Ctrl, OptionsPopup Settings)
        {
            Settings.panel.ClientIDMode = ClientIDMode.Static;
            Settings.hdn.ClientIDMode = ClientIDMode.Static;

            var Func = string.Format("JQueryPopup({" +
              "ElementIDorClass: '#{0}'" +
              "pautoOpen: {1}," +
              "pShowTitleBar:{2}," +
              "pTitle: '{3}'," +
              "pmodal: {4}," +
              "presizable:{5}," +
              "OnCLose: function () { $('#{6}').val('false'); }" +
              "});", Settings.panel.ID,
                     Settings.AutoOpen.ToString().ToLower(),
                     Settings.ShowTitleBar.ToString().ToLower(),
                     Settings.Title,
                     Settings.isModal.ToString().ToLower(),
                     Settings.resizable.ToString().ToLower(),
                     Settings.hdn.ID
                     );

            Utility.ExcecuteJScript(Ctrl, Func);
        }

        public static void DlgConfirmWithFuncCallBackExt(this Control Ctrl, string objId, string Message, int? Width, int? Height, string FuncCallBackYes, string FuncCallBackNo, string Key)
        {

            var FuncScript = string.Format("CustomDialogMessageEx('{0}','{1}',{2},{3},{4},{5},'{6}');",
                                                                 objId,
                                                                 Message,
                                                                 Width.HasValue ? Width.ToString() : "null",
                                                                 Height.HasValue ? Height.ToString() : "null",
                                                                 string.IsNullOrEmpty(FuncCallBackYes) ? "null" : FuncCallBackYes,
                                                                 string.IsNullOrEmpty(FuncCallBackYes) ? "null" : FuncCallBackNo,
                                                                 string.IsNullOrEmpty(Key) ? "null" : Key
                                                                 );
            Utility.ExcecuteJScript(Ctrl, FuncScript);

        }

        public static void DlgConfirmWithFuncCallBack(this Control Ctrl, string objId, string Message, int? Width, int? Height, string FuncCallBackYes, string FuncCallBackNo)
        {
            var FuncScript = string.Format("CustomDialogMessageEx('{0}','{1}',{2},{3},{4},{5});",
                                                                 objId,
                                                                 Message,
                                                                 Width.HasValue ? Width.ToString() : "null",
                                                                 Height.HasValue ? Height.ToString() : "null",
                                                                 string.IsNullOrEmpty(FuncCallBackYes) ? "null" : FuncCallBackYes,
                                                                 string.IsNullOrEmpty(FuncCallBackYes) ? "null" : FuncCallBackNo
                                                                 );
            Utility.ExcecuteJScript(Ctrl, FuncScript);
        }

        public static void CustomDialogMessageWithCallBack(this Control Ctrl, string Message, string FuncCallBack, string titlex, string OnCloseFunc, string key)
        {
            var FuncScript = string.Format("CustomDialogMessageWithCallBack('{0}',{1},'{2}',{3},'{4}');",
                                                                  Message,
                                                                  string.IsNullOrEmpty(FuncCallBack) ? "null" : FuncCallBack,
                                                                  titlex,
                                                                  string.IsNullOrEmpty(OnCloseFunc) ? "null" : OnCloseFunc,
                                                                  string.IsNullOrEmpty(key) ? "null" : key
                                                                  );
            Utility.ExcecuteJScript(Ctrl, FuncScript);
        }    
    }
}