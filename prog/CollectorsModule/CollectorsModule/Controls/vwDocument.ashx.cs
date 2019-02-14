using CollectorsModule.Commons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CollectorsModule.Controls
{
    /// <summary>
    /// Summary description for vwDocument
    /// </summary>
    public class vwDocument : IHttpHandler
    {
        public static Lazy<svcKwikTag.BridgeClient> bridge = new Lazy<svcKwikTag.BridgeClient>();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string barcode = context.Request.QueryString["Barcode"];
                if (string.IsNullOrEmpty(barcode)) { context.Response.Write("El código de barras no está disponible, recargue la página. Si le aparece nuevamente este mensaje, contacte al administrador."); return; }
                
                byte[] bytes;
                string fileName, contentType = "application/pdf";

                //Get Document
                svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters() 
                { 
                    barcode = barcode
                };
                var image = bridge.Value.RetrieveImageFile(parameters);
                if (image.Image == null)
                {
                    context.Response.Write("El documento para este registro aún no ha sido cargado o no existe, consulte directamente en la herramienta Kwiktag y en caso de existir el documento, consulte con el administrador.");
                    return;
                }
                var base64EncodedBytes = System.Convert.FromBase64String(image.Image);
                bytes = (byte[])base64EncodedBytes;
                fileName = barcode + ".pdf";
                context.Response.Buffer = true;
                context.Response.Charset = "";
                #region Download pdfs
                //Para descarga de archivo, implementar envio de query string con valor 1 y propiedad Download.
                if (context.Request.QueryString["Download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                }
                #endregion
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = contentType;
                context.Response.BinaryWrite(bytes);
                context.Response.Flush();
                //context.Response.End();
            }
            catch (Exception ex)
            {
                context.Response.Write("El documento no está disponible, consulte directamente en la herramienta Kwiktag y en caso de existir el documento, consulte con el administrador."); 
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}