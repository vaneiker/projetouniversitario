using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher.Common
{
    public static class DispatcherUtilities
    {
        /// <summary>
        /// vbarrera | 06/Jun/2018
        /// Realiza una fusion entre dos objetos de tipo [KSI.Cobranza.EntityLayer.Response]
        /// </summary>
        /// <param name="Response"></param>
        /// <param name="OtherResponse"></param>
        public static void MergeResponse(
            this Response Response, Response OtherResponse)
        {
            Response.Message
                = Response.Message.RemoveLineEndings();
            OtherResponse.Message
                = OtherResponse.Message.RemoveLineEndings();

            if (!OtherResponse.State)
            {
                Response.State = OtherResponse.State;
                Response.Message += string.Format(" - {0}", OtherResponse.Message);
            }
        }
    }
}
