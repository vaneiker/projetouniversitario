using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectorsModule.Commons
{
    public class Kwiktag
    {
        public static Lazy<svcKwikTag.BridgeClient> bridge = new Lazy<svcKwikTag.BridgeClient>();
        public static string KTSyncTag(svcKwikTag.EstructureTags[] tags, svcKwikTag.EstructureParameters parameters)
        {
            try
            {
                return bridge.Value.Tag(tags, parameters);
                #region Old service call
                /*
                apiKT.ktService svc = new apiKT.ktService();
                var result = svc.CreateTag_svc(tags, parameters);
                return result;
                */
                #endregion
            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error generando KwikTag para usuario:" + parameters.userName, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error generando KwikTag para usuario:" + parameters.userName + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "");
                return string.Empty;
            }
        }

        public static svcKwikTag.XferImage RetrieveImageFile(svcKwikTag.EstructureParameters parameters)
        {
            try
            {
                return bridge.Value.RetrieveImageFile(parameters);
                #region Old service call
                /*
                apiKT.ktService svc = new apiKT.ktService();
                var result = svc.RetrieveImageFile(parameters);
                return result;
                */
                #endregion
            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error buscando KwikTag Image para usuario:" + parameters.userName + ", barcode:" + parameters.barcode, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error buscando KwikTag Image para usuario:" + parameters.userName + ", barcode:" + parameters.barcode + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "");
                return null;
            }

        }

        public static string nextBarcodeByUser(string userName, svcKwikTag.EstructureParameters parameters)
        {
            try
            {
                return bridge.Value.NextBarcodeByUser(userName, parameters);
                #region Old service call
                /*
                apiKT.ktService svc = new apiKT.ktService();
                var result = svc.nextBarcodeByUser(userName, parameters);
                return result;
                */
                #endregion  
            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error buscando next tag para usuario:" + parameters.userName + ", barcode:" + parameters.barcode, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error buscando next tag para usuario:" + parameters.userName + ", barcode:" + parameters.barcode + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "");
                return string.Empty;
            }

        }
    }
}
