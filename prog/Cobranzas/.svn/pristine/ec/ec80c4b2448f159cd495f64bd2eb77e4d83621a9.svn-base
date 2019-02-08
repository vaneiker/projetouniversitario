using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentsXmlProvider
    {
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// La finalidad de este metodo es establecer un proveedor de datos
        /// que le permite a esta clase obtener los valores necesarios para 
        /// contruir el respectivo documento XML
        /// </summary>
        /// <param name="DataManager"></param>
        void SetDataManager(IBaseLogic<Loan> DataManager);

        /// <summary>
        /// vbarrera |08 Feb 2019
        /// Invoque este metodo para obtener el binario del documetno xml respectivo
        /// </summary>
        /// <returns></returns>
        byte[] GetXml();
    }
}
