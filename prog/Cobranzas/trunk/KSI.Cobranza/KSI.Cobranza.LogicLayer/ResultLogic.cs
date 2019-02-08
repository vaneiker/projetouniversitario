using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer
{
    public class ResultLogic<T> : BaseResultLogic<T> where T : class
    {
        /// <summary>
        /// En esta propiedad se devuelve un ienumerable del Tipo T
        /// </summary>
        public IEnumerable<T> dataResult { get; set; }
        /// <summary>
        /// En esta propiedad se devuelve un tipo T
        /// </summary>
        public T SingleResult { get; set; }
    }
}
