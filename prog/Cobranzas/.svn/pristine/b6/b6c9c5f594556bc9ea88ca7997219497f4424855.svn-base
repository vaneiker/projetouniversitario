using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    /// <summary>
    /// vbarrera | 13 Mar 2019
    /// Movimiento de carga de documentos
    /// </summary>
    public class DocumentLoadingMovement: DocumentMovement
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<HttpPostedFileBase> files { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            AllowedLoad = true;
            AllowedGeneration = true;
            AllowedValidation = false;

            base.Initialize();
        }
    }
}
