using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace STL.POS.Frontend.Web.VirtualOfficeWs
{
    [DataContract]
    public class Result
    {
        /// <summary>
        /// A qué usuario se refiere el resultado indicado
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Verdadero si la operación se terminó correctamente; falso en otro caso.
        /// </summary>
        [DataMember]
        public bool Status { get; set; }

        /// <summary>
        /// Detalle del resultado de la operación. Usado principalmente en caso de error.
        /// </summary>
        [DataMember]
        public string StatusMessage { get; set; }

    }
}