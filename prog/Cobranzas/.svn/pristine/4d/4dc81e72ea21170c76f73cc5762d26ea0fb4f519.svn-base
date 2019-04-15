using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    /// <summary>
    /// vbarrera | 13 Mar 2019
    /// Movimiento de validación de documentos
    /// </summary>
    public class DocumentValidationMovement: DocumentMovement
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? IdShortAnswer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Observation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            AllowedLoad = false;
            AllowedValidation = true;
            AllowedGeneration = false;

            base.Initialize();
        }
    }
}
